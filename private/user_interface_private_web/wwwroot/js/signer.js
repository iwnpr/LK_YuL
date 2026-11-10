var CAPICOM_CURRENT_USER_STORE = 2;
var CAPICOM_MY_STORE = "My";
var CAPICOM_STORE_OPEN_MAXIMUM_ALLOWED = 2;
var CADESCOM_CADES_BES = 1;
var CAPICOM_CERTIFICATE_FIND_SHA1_HASH = 0;
var CADESCOM_BASE64_TO_BINARY = 1;

function CreateSign(_thumbprint, _message) {
    return new Promise(function (resolve, reject) {
        cadesplugin.async_spawn(function* (args) {
            try {
                // Ищем сертификат для подписи
                var oStore = yield cadesplugin.CreateObjectAsync("CAdESCOM.Store");
                yield oStore.Open(CAPICOM_CURRENT_USER_STORE, CAPICOM_MY_STORE,
                    CAPICOM_STORE_OPEN_MAXIMUM_ALLOWED);

                var oStoreCerts = yield oStore.Certificates;
                var oCertificates = yield oStoreCerts.Find(
                    CAPICOM_CERTIFICATE_FIND_SHA1_HASH, _thumbprint);

                var certsCount = yield oCertificates.Count;
                if (certsCount === 0) {
                    err = "Сертификат не найден: " + _thumbprint;
                    //alert(err);
                    return args[0](err);
                }

                var oCertificate = yield oCertificates.Item(1);
                yield oStore.Close();

                // Создаем объект CAdESCOM.CPSigner
                var oSigner = yield cadesplugin.CreateObjectAsync("CAdESCOM.CPSigner");
                yield oSigner.propset_Certificate(oCertificate);
                //yield oSigner.propset_CheckCertificate(true);

                var oSignedData = yield cadesplugin.CreateObjectAsync("CAdESCOM.CadesSignedData");
                yield oSignedData.propset_ContentEncoding(CADESCOM_BASE64_TO_BINARY);
                yield oSignedData.propset_Content(_message);

                var sSignedMessage = yield oSignedData.SignCades(oSigner, CADESCOM_CADES_BES, false);

                return args[0](sSignedMessage);
            }
            catch (e) {
                err = cadesplugin.getLastError(e);
                return args[0](err);
            }


        }, resolve, reject);
    });
}

function SignVerify(sSignedMessage) {
    return new Promise(function (resolve, reject) {
        cadesplugin.async_spawn(function* (args) {
            try {
                
                var oSignedData2 = yield cadesplugin.CreateObjectAsync("CAdESCOM.CadesSignedData");
                yield oSignedData2.propset_ContentEncoding(CADESCOM_BASE64_TO_BINARY);

                yield oSignedData2.VerifyCades(sSignedMessage, CADESCOM_CADES_BES, false);

                alert("Подпись проверена");
                return args[0](yield oSignedData2.Content);
            }
            catch (err) {
                alert("При проверке подписи ответа произошла ошибка: " + cadesplugin.getLastError(err));
                return args[1](err);
            }

        }, resolve, reject);
    });
}


function base64ToBytes(base64) {
    const binString = atob(base64);
    return Uint8Array.from(binString, (m) => m.codePointAt(0));
}

function bytesToBase64(bytes) {
    const binString = String.fromCodePoint(...bytes);
    return btoa(binString);
}