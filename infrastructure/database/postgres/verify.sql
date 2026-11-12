\set ON_ERROR_STOP on
\connect legal_persons
BEGIN;
DO $$ BEGIN
    IF (SELECT count(*) FROM information_schema.tables WHERE table_schema = 'personal_account' AND table_type = 'BASE TABLE') <> 16 THEN
        RAISE EXCEPTION 'Expected 16 personal_account tables';
    END IF;
    IF 'requested'::personal_account.cert_status IS NULL OR 'court'::personal_account.governments IS NULL THEN
        RAISE EXCEPTION 'Enum types missing';
    END IF;
END $$;
-- Fields contributed by public; ID must support SQL Server bigint values.
INSERT INTO personal_account.organizations
    (legal_person_id, inserted, itn, psrn, full_name, short_name, is_active, tr_organization_type_id, organization_type, reg_date)
VALUES (3000000000, timestamp '2026-01-01', 'test', 'test', 'test', 'test', true, 1, 'test', date '2026-01-01')
RETURNING id AS organization_id \gset
INSERT INTO personal_account.td_users
    (login, password, email, last_name, first_name, organization_id, is_active, natural_person_id, is_approved)
VALUES ('bootstrap-test', 'unused', 'test@example.invalid', 'test', 'test', :organization_id, true, 1, true)
RETURNING id AS user_id \gset
INSERT INTO personal_account.te_temporary_codes (inserted, users_id, code)
VALUES (timestamp '2026-01-01', :user_id, 'bootstrap-test');
-- A private-side insert omits fields known only to public and must still succeed.
INSERT INTO personal_account.certificates
    (inserted, organizations_id, users_id, status, request_data, cert_owner, org_short_name)
VALUES (timestamp '2026-01-01', 1, 1, 'requested', '<request/>', 'test', 'test');
DO $$ BEGIN
    IF NOT EXISTS (SELECT FROM personal_account.certificates WHERE request_id = 0 AND legal_person_id = 0) THEN
        RAISE EXCEPTION 'Compatibility defaults missing';
    END IF;
END $$;
SELECT sault = '' AS salt_default FROM personal_account.td_users WHERE id = :user_id \gset
SELECT is_active AS active_default FROM personal_account.te_temporary_codes WHERE users_id = :user_id \gset
\if :salt_default
\else
    DO $$ BEGIN RAISE EXCEPTION 'Salt default missing'; END $$;
\endif
\if :active_default
\else
    DO $$ BEGIN RAISE EXCEPTION 'Temporary code default missing'; END $$;
\endif
ROLLBACK;
\connect bureau_qbch
DO $$ BEGIN
    IF (SELECT count(*) FROM information_schema.tables WHERE table_schema = 'qbchv3' AND table_type = 'BASE TABLE') <> 5 THEN
        RAISE EXCEPTION 'Expected 5 qbchv3 tables';
    END IF;
END $$;
\connect bureau_data
DO $$ BEGIN
    IF EXISTS (SELECT FROM information_schema.tables WHERE table_schema NOT IN ('pg_catalog', 'information_schema') AND table_name <> '__local_bootstrap') THEN
        RAISE EXCEPTION 'BureauData result projections must not create tables';
    END IF;
END $$;
