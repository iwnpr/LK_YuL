var CurrentPluginVersion = "";
var CSPName = "";
var License = "";
var ValidTo = "";
var SerialNumber = "";
var FirstInstall = "";
var LicType = "";
var CompanyName = "";
var Version = "";
var IsInstalled = false;

var PluginInfo = { CSPName, Version, CurrentPluginVersion };
var CryptoProInfo = { ValidTo, SerialNumber, FirstInstall, LicType, CompanyName };

var FullInfo;

function GetCryptoProInfoAsync() {
    return new Promise(function (resolve, reject) {
        cadesplugin.async_spawn(function* (args) {
            var ProviderName = "Crypto-Pro GOST R 34.10-2012 Cryptographic Service Provider";
            var ProviderType = 80;

            try {
                var oAbout = yield cadesplugin.CreateObjectAsync("CAdESCOM.About");
                oVersion = yield oAbout.CSPVersion(ProviderName, parseInt(ProviderType, 10));

                Version = yield oVersion.toString();

                CurrentPluginVersion = yield oAbout.PluginVersion;
                CSPName = yield oAbout.CSPName(ProviderType);
                CurrentPluginVersion = (yield CurrentPluginVersion.toString());

                // Лицензия CSP
                try {
                    License = yield cadesplugin.CreateObjectAsync("CAdESCOM.CPLicense");
                    ValidTo = yield License.ValidTo();
                    SerialNumber = yield License.SerialNumber();
                    FirstInstall = yield License.FirstInstallDate();
                    LicType = yield License.Type();
                    CompanyName = yield License.CompanyName(cadesplugin.CADESCOM_PRODUCT_CSP);
                    IsInstalled = true;

                    PluginInfo = { CSPName, Version, CurrentPluginVersion };
                    CryptoProInfo = { ValidTo, SerialNumber, FirstInstall, LicType, CompanyName };
                    FullInfo = { PluginInfo, CryptoProInfo };

                    return args[0]({ Code: 200, Message: JSON.stringify(FullInfo)});
                }
                catch (err) {
                    try {
                        SerialNumber = cadesplugin.getLastError(err);
                        ValidTo = yield License.ValidTo(cadesplugin.CADESCOM_PRODUCT_OCSP);
                        SerialNumber = yield License.SerialNumber(cadesplugin.CADESCOM_PRODUCT_OCSP);
                        FirstInstall = yield License.FirstInstallDate(cadesplugin.CADESCOM_PRODUCT_OCSP);
                        LicType = yield License.Type(cadesplugin.CADESCOM_PRODUCT_OCSP);
                        CompanyName = yield License.CompanyName(cadesplugin.CADESCOM_PRODUCT_OCSP);
                        IsInstalled = true;

                        PluginInfo = { CSPName, Version, CurrentPluginVersion };
                        CryptoProInfo = { ValidTo, SerialNumber, FirstInstall, LicType, CompanyName };
                        FullInfo = { PluginInfo, CryptoProInfo };

                        return args[0]({ Code: 200, Message: JSON.stringify(FullInfo) });
                    }
                    catch (err) {
                        try {
                            ValidTo = yield License.ValidTo(cadesplugin.CADESCOM_PRODUCT_TSP);
                            SerialNumber = yield License.SerialNumber(cadesplugin.CADESCOM_PRODUCT_TSP);
                            FirstInstall = yield License.FirstInstallDate(cadesplugin.CADESCOM_PRODUCT_TSP);
                            LicType = yield License.Type(cadesplugin.CADESCOM_PRODUCT_TSP);
                            CompanyName = yield License.CompanyName(cadesplugin.CADESCOM_PRODUCT_TSP);
                            IsInstalled = true;

                            PluginInfo = { CSPName, Version, CurrentPluginVersion };
                            CryptoProInfo = { ValidTo, SerialNumber, FirstInstall, LicType, CompanyName };
                            FullInfo = { PluginInfo, CryptoProInfo };

                            return args[0]({ Code: 200, Message: JSON.stringify(FullInfo) });

                        }
                        catch (err) {
                            return args[0]({ Code: 300, Message: cadesplugin.getLastError(err) });
                        }

                    }

                }
            }
            catch (err) {
                return args[0]({ Code: 300, Message: cadesplugin.getLastError(err) });
            }
        }, resolve, reject);
    });
}