var CertificateRequest;
var code = 300;
var message = "";

async function RetrieveCertificate_Async(sDistinguishedName, sOwner)
{
	await cadesplugin.async_spawn (function*(arg) {

				try {
            var PrivateKey = yield cadesplugin.CreateObjectAsync("X509Enrollment.CX509PrivateKey");
						
        }
        catch (e) {
            //alert('Failed to create X509Enrollment.CX509PrivateKey: ' + cadesplugin.getLastError(e));
            message = "Не удалось создать X509Enrollment.CX509PrivateKey: " + cadesplugin.getLastError(e);
						return;
        }

        yield PrivateKey.propset_ProviderName("Crypto-Pro GOST R 34.10-2012 Cryptographic Service Provider");
        yield PrivateKey.propset_ProviderType(80);
		yield PrivateKey.propset_Existing(false);
        yield PrivateKey.propset_KeySpec(1); //XCN_AT_KEYEXCHANGE
		yield PrivateKey.propset_ExportPolicy(0x00000001);

        try {
            var CertificateRequestPkcs10 = yield cadesplugin.CreateObjectAsync("X509Enrollment.CX509CertificateRequestPkcs10");
        }
        catch (e) {
            //alert('Failed to create X509Enrollment.CX509CertificateRequestPkcs10: ' + cadesplugin.getLastError(e));
            message = "Не удалось создать X509Enrollment.CX509CertificateRequestPkcs10: " + cadesplugin.getLastError(e);
						return;
        }

		yield CertificateRequestPkcs10.InitializeFromPrivateKey(0x1, PrivateKey, "");

	



		



        try {
            var DistinguishedName = yield cadesplugin.CreateObjectAsync("X509Enrollment.CX500DistinguishedName");
        }
        catch (e) {
            //alert('Failed to create X509Enrollment.CX500DistinguishedName: ' + cadesplugin.getLastError(e));
            message = "Не удалось создать X509Enrollment.CX500DistinguishedName: " + cadesplugin.getLastError(e);
						return;
        }

				
		var dArray = sDistinguishedName.split(";");
        
		var dName = "";
				
		if (dArray[0]) dName = ' CN=\"' + dArray[0].replace(/"/g, '\"\"') + '\";';
		if (dArray[1]) dName += ' E=\"' + dArray[1].replace(/"/g, '\"\"') + '\";';
		if (dArray[2]) dName += ' O=\"' + dArray[2].replace(/"/g, '\"\"') + '\";';
		if (dArray[3]) dName += ' C=\"' + dArray[3].replace(/"/g, '\"\"') + '\";';
		if (dArray[4]) dName += ' L=\"' + dArray[4].replace(/"/g, '\"\"') + '\";';
		if (dArray[5]) dName += ' ИНН=\"' + dArray[5].replace(/"/g, '\"\"') + '\";';
		if (dArray[6]) dName += ' ОГРН=\"' + dArray[6].replace(/"/g, '\"\"') + '\";';

		dName += ' SN = \"Фамилия\"; G=\"Имя Отчество\";';
        
		yield DistinguishedName.Encode(dName);
				
        yield CertificateRequestPkcs10.propset_Subject(DistinguishedName);
				
        var KeyUsageExtension = yield cadesplugin.CreateObjectAsync("X509Enrollment.CX509ExtensionKeyUsage");
        var CERT_DATA_ENCIPHERMENT_KEY_USAGE = 0x10;
        var CERT_KEY_ENCIPHERMENT_KEY_USAGE = 0x20;
        var CERT_DIGITAL_SIGNATURE_KEY_USAGE = 0x80;
        var CERT_NON_REPUDIATION_KEY_USAGE = 0x40;

        yield KeyUsageExtension.InitializeEncode(
                    CERT_KEY_ENCIPHERMENT_KEY_USAGE |
                    CERT_DATA_ENCIPHERMENT_KEY_USAGE |
                    CERT_DIGITAL_SIGNATURE_KEY_USAGE |
                    CERT_NON_REPUDIATION_KEY_USAGE);
				
				
				
				/*******************************************/
				
				var objObjectId = yield cadesplugin.CreateObjectAsync('X509Enrollment.CObjectId');
				var objObjectIds = yield cadesplugin.CreateObjectAsync('X509Enrollment.CObjectIds');

				var objExtensionKeyUsage = yield cadesplugin.CreateObjectAsync('X509Enrollment.CX509ExtensionKeyUsage');
				var objExtensionEnhancedKeyUsage = yield cadesplugin.CreateObjectAsync('X509Enrollment.CX509ExtensionEnhancedKeyUsage');
				
				var OID_ClientUsage = '1.3.6.1.5.5.7.3.2';
		//var OID_ClientUsage = '1.3.6.1.4.1.311.21.8.4946465.16405226.12930948.10533807.2139545.33.5005369.11644649';
				
				yield objObjectId.InitializeFromValue(OID_ClientUsage);
				
				yield objObjectIds.Add(objObjectId);
				
				yield objExtensionEnhancedKeyUsage.InitializeEncode(objObjectIds);
				
				
				yield (yield CertificateRequestPkcs10.X509Extensions).Add(objExtensionEnhancedKeyUsage);


		/*******************************************/

	

		try {
			var template = "1.2.643.2.2.50.1.9.15897441.31220.9717245.9122781.28839.53360";

			var cobjObjectId = yield cadesplugin.CreateObjectAsync('X509Enrollment.CObjectId');
			yield cobjObjectId.InitializeFromValue(template);

			var objExtensionTemplate = yield cadesplugin.CreateObjectAsync("X509Enrollment.CX509ExtensionTemplate");

			yield objExtensionTemplate.InitializeEncode(cobjObjectId, 1, 0); 



			yield (yield CertificateRequestPkcs10.X509Extensions).Add(objExtensionTemplate);
		}
		catch (e) {
			message = "X509Enrollment.CX509ExtensionTemplate: " + cadesplugin.getLastError(e);
			return;
		}



				
        yield (yield CertificateRequestPkcs10.X509Extensions).Add(KeyUsageExtension);

        try {
            var Enroll = yield cadesplugin.CreateObjectAsync("X509Enrollment.CX509Enrollment");
        }
        catch (e) {
            //alert('Failed to create X509Enrollment.CX509Enrollment: ' + cadesplugin.getLastError(e));
            code="300"; message = "Не удалось создать X509Enrollment.CX509Enrollment: " + cadesplugin.getLastError(e);
						return;
        }
        
        var cert_req;
        try {
            yield Enroll.InitializeFromRequest(CertificateRequestPkcs10);
						
						var enrollFN = yield Enroll.FriendlyName;
						
						//alert(Object.keys(yield Enroll));
						yield Enroll.propset_CertificateFriendlyName(sOwner);
						
            
						cert_req = yield Enroll.CreateRequest(cadesplugin.XCN_CRYPT_STRING_BASE64HEADER);
        } catch (e) {
            //alert('Failed to generate KeyPair or reguest: ' + cadesplugin.getLastError(e));
						message = "Не удалось создать запрос сертификата: " + cadesplugin.getLastError(e);
		return;  }  

    //var params = encodeURIComponent(cert_req);

		code = 200; message = cert_req;
    });
}


async function GetCertificateRequestData(sDistinguishedName, sOwner)
{
	await RetrieveCertificate_Async(sDistinguishedName, sOwner);
	return {code, message};
}