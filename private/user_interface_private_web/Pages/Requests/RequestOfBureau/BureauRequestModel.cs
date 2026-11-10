namespace user_interface_private_web.Pages.Requests.RequestOfBureau;

public sealed class BureauRequestModel
{
    public RequestPurposeModel RequestPurpose { get; set; } = new();
    public ConsentModel Consent { get; set; } = new();
    public NaturalPersonModel? NaturalPerson { get; set; }
    public LegalPersonModel? LegalPerson { get; set; }
    public BureauReasonModel Reason { get; set; } = new();

    public ResponseCapabilitiesModel ResponseCapabilities { get; set; } = new();
}

public sealed class RequestPurposeModel
{
    public string Type { get; set; } = "1";
    public string Value { get; set; } = string.Empty;
}

public sealed class ConsentModel
{
    public string Available { get; set; } = "2";
    public string PurposeType { get; set; } = "1";
    public string OtherPurpose { get; set; } = string.Empty;
    public string IssueDate { get; set; } = string.Empty;
    public string ExpiryDate { get; set; } = string.Empty;
    public string ExpirationType { get; set; } = "1";
    public string LegalPersonAddress { get; set; } = string.Empty;
    public bool RequestorResponsibility { get; set; } = true;
}

public sealed class NaturalPersonModel
{
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string BirthDate { get; set; } = string.Empty;
    public string BirthPlace { get; set; } = string.Empty;
    public string Gender { get; set; } = "0";
    public string PensionNumber { get; set; } = string.Empty;
    public string IndividualTaxpayerNumber { get; set; } = string.Empty;
    public bool InnChecked { get; set; }
    public IdentificationDocumentModel Document { get; set; } = new();
    public List<AddressModel> Addresses { get; set; } = new();
    public List<PhoneModel> Phones { get; set; } = new();
}

public sealed class LegalPersonModel
{
    public string FullName { get; set; } = string.Empty;
    public string IndividualTaxpayerNumber { get; set; } = string.Empty;
    public string PrimaryStateRegistrationNumber { get; set; } = string.Empty;
    public List<AddressModel> Addresses { get; set; } = new();
    public List<PhoneModel> Phones { get; set; } = new();
}

public sealed class IdentificationDocumentModel
{
    public string Type { get; set; } = "21";
    public string Series { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string IssueDate { get; set; } = string.Empty;
    public string IssuerCode { get; set; } = string.Empty;
    public string IssuerName { get; set; } = string.Empty;
}

public sealed class AddressModel
{
    public string? RegistrationDate { get; set; }
    public string Type { get; set; } = "1";
    public string RegionId { get; set; } = "0";
    public string? RegionName { get; set; }
    public string DistrictType { get; set; } = string.Empty;
    public string DistrictName { get; set; } = string.Empty;
    public string CityType { get; set; } = string.Empty;
    public string CityName { get; set; } = string.Empty;
    public string VillageType { get; set; } = string.Empty;
    public string VillageName { get; set; } = string.Empty;
    public string StreetType { get; set; } = string.Empty;
    public string StreetName { get; set; } = string.Empty;
    public string HouseNumber { get; set; } = string.Empty;
    public string BuildingNumber { get; set; } = string.Empty;
    public string BuildingSymbol { get; set; } = string.Empty;
    public string FlatNumber { get; set; } = string.Empty;
}

public sealed class PhoneModel
{
    public string Type { get; set; } = "1";
    public string? Number { get; set; }
}

public sealed class BureauReasonModel
{
    public string Type { get; set; } = "0";
    public string CreditLimit { get; set; } = string.Empty;
    public string Currency { get; set; } = "RUR";
    public string ApplicationType { get; set; } = "1";
    public string ApplicationTypeText { get; set; } = "Новый продукт";
    public string ApplicationOrigin { get; set; } = "1";
    public string ApplicationOriginText { get; set; } = "Обращение клиента";
}



public sealed class ResponseCapabilitiesModel
{
    public GetSelfEmployedCheckModel GetSelfEmployedCheck { get; set; } = new();
}

public sealed class GetSelfEmployedCheckModel
{
    public DateOnly CheckDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}