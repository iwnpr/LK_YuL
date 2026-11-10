var global_selectbox_container = new Array();
var global_isFromCont = new Array();
var global_selectbox_counter = 0;

function GetListOfCertificateAsync() {
    return new Promise(function (resolve, reject) {
    cadesplugin.async_spawn(function* (args) {
        var MyStoreExists = true;
        try {
            var oStore = yield cadesplugin.CreateObjectAsync("CAdESCOM.Store");
            if (!oStore) {
                alert("Create store failed");
                return args[0]("Create store failed");
            }

            yield oStore.Open();
        }
        catch (ex) {
            MyStoreExists = false;
        }

        certList = [];
        var certCnt;
        var certs;
        if (MyStoreExists) {
            try {
                certs = yield oStore.Certificates;
                certCnt = yield certs.Count;
            }
            catch (ex) {
                return args[0]("Ошибка при получении Certificates или Count: " + cadesplugin.getLastError(ex));
            }

            for (var i = 1; i <= certCnt; i++) {
                var cert;

                try {
                    cert = yield certs.Item(i);
                }
                catch (ex) {
                    return args[0]("Ошибка при перечислении сертификатов: " + cadesplugin.getLastError(ex));
                }

                try {
                    certList += (yield cert.SubjectName) + ";" +
                        (yield cert.Thumbprint) + ";" +
                        (yield cert.SerialNumber) + ";" +
                        (yield cert.IssuerName) + ";" +
                        (yield cert.ValidFromDate) + ";" +
                        (yield cert.ValidToDate) + ";" +
                        (yield (yield cert.IsValid()).Result) +  "$";
                }
                catch (ex) {
                    return args[0]("Ошибка при получении свойств сертификата: " + cadesplugin.getLastError(ex));
                }

                try {
                    global_selectbox_container.push(cert);
                    global_isFromCont.push(false);
                    global_selectbox_counter++;
                }
                catch (ex) {
                    return args[0]("Ошибка при получении Certificates или Count: " + cadesplugin.getLastError(ex));
                }

            }

            yield oStore.Close();

            return args[0]({Code: 200, Message: certList.substr(0, certList.length - 1) });

        }

    }, resolve, reject);
    });
}


