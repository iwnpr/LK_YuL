-- Local development fixture only. Run against legal_persons after bootstrap.
-- Plain password matches the existing UserManager.SignAsync implementation.
BEGIN;
DO $$ BEGIN
    IF to_regclass('public.__local_bootstrap') IS NULL THEN
        RAISE EXCEPTION 'Seed requires a database created by the local bootstrap';
    END IF;
    IF EXISTS (SELECT FROM personal_account.organizations WHERE id = -900001 AND itn <> '0000000000') THEN
        RAISE EXCEPTION 'Local seed organization key is occupied';
    END IF;
    IF EXISTS (SELECT FROM personal_account.td_users WHERE
        (id = -900001 AND login <> 'localadmin') OR (lower(login) = 'localadmin' AND id <> -900001)) THEN
        RAISE EXCEPTION 'Local seed user key or login is occupied';
    END IF;
    IF EXISTS (SELECT FROM personal_account.tr_organization_type WHERE id = -900001 AND organization_type <> 'local-dev') THEN
        RAISE EXCEPTION 'Local seed organization type key is occupied';
    END IF;
END $$;

INSERT INTO personal_account.tr_organization_type (id, organization_type, comment)
VALUES (-900001, 'local-dev', 'Локальная тестовая организация') ON CONFLICT (id) DO NOTHING;
INSERT INTO personal_account.organizations
    (id, legal_person_id, inserted, itn, psrn, full_name, short_name, is_active,
     tr_organization_type_id, organization_type)
VALUES (-900001, -900001, localtimestamp, '0000000000', '0000000000000',
    'Локальная тестовая организация', 'Локальная организация', true, -900001, 'local-dev')
ON CONFLICT (id) DO NOTHING;
INSERT INTO personal_account.td_users
    (id, login, password, email, last_name, first_name, organization_id,
     is_active, natural_person_id, is_approved, sault)
VALUES (-900001, 'localadmin', 'LocalAdmin_2026!', 'localadmin@example.invalid',
    'Тестовый', 'Администратор', -900001, true, -900001, true, 'local-dev')
ON CONFLICT (id) DO NOTHING;

-- Match the exact role names checked by public/AuthProvider and Razor pages.
DO $$
DECLARE
    service record;
    service_key integer;
BEGIN
    FOR service IN SELECT * FROM (VALUES
        (-900010, 'organizations', 'Организации'),
        (-900011, 'users', 'Пользователи'),
        (-900012, 'certificates', 'Сертификаты'),
        (-900013, 'abonents', 'Абоненты'),
        (-900014, 'documentation', 'Документация')
    ) AS roles(id, name, caption)
    LOOP
        IF EXISTS (SELECT FROM personal_account.tr_services WHERE id = service.id AND service_name <> service.name) THEN
            RAISE EXCEPTION 'Local seed service key is occupied: %', service.id;
        END IF;
        IF (SELECT count(*) FROM personal_account.tr_services WHERE service_name = service.name) > 1 THEN
            RAISE EXCEPTION 'Duplicate service name: %', service.name;
        END IF;
        SELECT id INTO service_key FROM personal_account.tr_services WHERE service_name = service.name;
        IF service_key IS NULL THEN
            INSERT INTO personal_account.tr_services (id, service_name, request_parameters, comment)
            VALUES (service.id, service.name, '<parameters/>', service.caption);
            service_key := service.id;
        END IF;
        INSERT INTO personal_account.organization_access (organizations_id, services_id, service_name, comment, access)
        SELECT -900001, service_key, service.name, service.caption, true
        WHERE NOT EXISTS (SELECT FROM personal_account.organization_access WHERE organizations_id = -900001 AND services_id = service_key);
        INSERT INTO personal_account.user_access (users_id, services_id, service_name, comment, access)
        SELECT -900001, service_key, service.name, service.caption, true
        WHERE NOT EXISTS (SELECT FROM personal_account.user_access WHERE users_id = -900001 AND services_id = service_key);
    END LOOP;
END $$;

DO $$ BEGIN
    IF (SELECT count(*) FROM personal_account.td_users WHERE lower(login) = 'localadmin') <> 1 THEN
        RAISE EXCEPTION 'Seed verification failed: duplicate login';
    END IF;
    IF NOT EXISTS (SELECT FROM personal_account.td_users u JOIN personal_account.organizations o ON o.id = u.organization_id
        WHERE u.id = -900001 AND o.id = -900001 AND o.legal_person_id = -900001 AND u.natural_person_id = -900001) THEN
        RAISE EXCEPTION 'Seed verification failed: organization or SQL Server links';
    END IF;
END $$;
COMMIT;
