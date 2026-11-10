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

                        let Version = yield cert.Version;
                        let SubjectName = yield cert.SubjectName;
                        let Thumbprint = yield cert.Thumbprint;
                        let IssuerName = yield cert.IssuerName;
                        let ValidFromDate = yield cert.ValidFromDate;
                        let ValidToDate = yield cert.ValidToDate;
                        let SerialNumber = yield cert.SerialNumber;
                        let PublicKey = yield cert.PublicKey();
                        let Algorithm = yield (yield PublicKey.Algorithm).FriendlyName;
                        let encodedKey = yield PublicKey.EncodedKey;
                        PublicKey = yield encodedKey.Format();
                        let ExtendedKeyUsage = yield cert.ExtendedKeyUsage();
                        let EKUs = yield ExtendedKeyUsage.EKUs;
                        let Item = yield EKUs.Item(1);
                        let PrivateKey = yield Item.OID;


                        let Certificate = { Version, SubjectName, Thumbprint, SerialNumber, IssuerName, ValidFromDate, ValidToDate, Algorithm, PublicKey, PrivateKey };

                        certList.push(Certificate);
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

                //return args[0]({ Code: 200, Message: certList.substr(0, certList.length - 1) });
                return args[0]({ Code: 200, Message: JSON.stringify(certList) });

            }

        }, resolve, reject);
    });
}


