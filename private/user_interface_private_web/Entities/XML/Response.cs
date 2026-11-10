using System.Xml.Serialization;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlRootAttribute("RESPONSE", Namespace = "", IsNullable = false)]
public partial class tRESPONSE
{
    /// <remarks/>
    public tResponseHEADER? HEADER { get; set; }

    /// <remarks/>
    public tResponseBODY? BODY { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? version { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tResponseHEADER
{
    /// <remarks/>
    public string? ResponseCreatorDescription { get; set; }

    /// <remarks/>
    public string? ResponseDateTime { get; set; }

    /// <remarks/>
    public string? ResponseID { get; set; }

    /// <remarks/>
    public tRequestBODY? Request { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tRequestBODY
{

    /// <remarks/>
    public tRequestAttributes? RequestAttributes { get; set; }

    /// <remarks/>
    public tNaturalPersonSubject? NaturalPersonSubject { get; set; }

    /// <remarks/>
    public tLegalPerson? LegalPersonSubject { get; set; }

    /// <remarks/>
    public tReceipt? Receipt { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tRequestAttributes
{

    /// <remarks/>
    public tResponseCapabilities? ResponseCapabilities { get; set; }

    /// <remarks/>
    public tRequestAttributesReason? Reason { get; set; }

    /// <remarks/>
    public tReference0? RequestPurpose { get; set; }

    /// <remarks/>
    public tConsent? Consent { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? id { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tResponseCapabilities
{

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Score", IsNullable = false)]
    public List<tScore>? BailiffsServiceScores { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tReportDetalization CreditReportDetalization { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tGetExternalCreditReport getExternalCreditReport { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getScoringParameters { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool SelfRequestInResponse { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? PreviousRequestsCountLimit { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getRating1 { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getRating2 { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getRating3 { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getRating4 { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? getTaxServiceLPInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? getTaxServiceIEInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getVerificationService { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tPaymentHistoryRequestSchema getPaymentHistory { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tgetMigrationServiceDocumentCheck getMigrationServiceDocumentCheck { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getBailiffsServiceDebtInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getBailiffsServiceDebtInfoDetailed { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getTaxServiceDebtInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getFraudInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tBureauRatingRequestSchema getRating { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool dispatchBureauAccount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tBuildScoring buildScoring { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tGetIdentification getIdentification { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tGetOldReport getOldReport { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getReportWithAmp { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tReportFormat getReportFormat { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tAmpFromAllQcb getAmpFromAllQcb { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tScore
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Id { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tBureauAccountDispatching
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Error")]
    public List<tWarning>? Error { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Warning")]
    public List<tWarning>? Warning { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public long UserId { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public long HumanId { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? UserLogin { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsNewAccountCreated { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public long SmsMessageId { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tWarning
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Code { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFraudInfoBureauRating
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool HasSignsOfFraud { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEmployerInfo
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal OverduePart3MPlus { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tCollectionAgencyInfo
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool IsExist { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool HasDebt { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tAdditionalRating
{

    /// <remarks/>
    public tCollectionAgencyInfo? CollectionAgencyInfo { get; set; }

    /// <remarks/>
    public tEmployerInfo? EmployerInfo { get; set; }

    /// <remarks/>
    public tFraudInfoBureauRating? FraudInfo { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tPreScoringInfo
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool CheckPersonalData { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool Negative { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tTaxInfo
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool HasDebt { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tBailiffInfo
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool HasDebt { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tDocumentCheckInfo
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool DocumentIsValid { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFederalServicesRating
{

    /// <remarks/>
    public tDocumentCheckInfo? DocumentCheckInfo { get; set; }

    /// <remarks/>
    public tBailiffInfo? BailiffInfo { get; set; }

    /// <remarks/>
    public tTaxInfo? TaxInfo { get; set; }

    /// <remarks/>
    public tPreScoringInfo? PreScoringInfo { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tCreditReportParameters
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int CurrentTotalLiabilities { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int MonthlyPayment { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int PreviousRequests { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tMissedPayments
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Currently { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Last6Month { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Last24Month { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tCreditHistoryDuration
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Month { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tCreditCount
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Type { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Count { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tNumberOfContracts
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Bank { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int MFI { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Otherwise { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tCountrySource
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Name { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int ISO { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tCreditHistoryRating
{

    /// <remarks/>
    public tCountrySource? CountrySource { get; set; }

    /// <remarks/>
    public tNumberOfContracts? NumberOfContracts { get; set; }

    /// <remarks/>
    public tCreditCount? CreditCount { get; set; }

    /// <remarks/>
    public tCreditHistoryDuration? CreditHistoryDuration { get; set; }

    /// <remarks/>
    public tMissedPayments? MissedPayments { get; set; }

    /// <remarks/>
    public tCreditReportParameters? CreditReportParameters { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tBureauRating
{

    /// <remarks/>
    public tCreditHistoryRating? CreditHistoryRating { get; set; }

    /// <remarks/>
    public tFederalServicesRating? FederalServicesRating { get; set; }

    /// <remarks/>
    public tAdditionalRating? AdditionalRating { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFIEvent
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Date { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int EventTypeId { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int HasSignsOfFraud { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int HasAdjudication { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFraudInfo
{

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("EventGroup", IsNullable = false)]
    [System.Xml.Serialization.XmlArrayItemAttribute("Event", IsNullable = false, NestingLevel = 1)]
    public tFIEvent[][]? EventGroups { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tBureauScoringData
{

    /// <remarks/>
    public tBureauScoringDataCreditReportParameters? CreditReportParameters { get; set; }

    /// <remarks/>
    public tBureauScoringDataDefaultProbabilityParameters? DefaultProbabilityParameters { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tBureauScoringDataCreditReportParameters
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int OperationalCreditRating { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int LastTwoYearsMissedPayments { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int LastTwoYearsMaxMissedContinuouslyPayments { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int CreditHistoryLength { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int MaxActiveCreditHistoryLength { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TotalMonthlyPaymentAmount { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tBureauScoringDataDefaultProbabilityParameters
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int DefaultProbabilityIfKeptLoanBurden { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int DefaultProbabilityIfIncreasedLoanBurden { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int DefaultProbabilityIfDecreasedLoanBurden { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tCreditReportForFinancialManagerCheck
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int status { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tCreditReportForSubjectByUserCheck
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int status { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int freeReportsRemaining { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tTaxServiceDebtInfo
{

    /// <remarks/>
    public tFSPerson? Person { get; set; }

    /// <remarks/>
    public tTaxServiceDebtInfoDocument? Document { get; set; }

    /// <remarks/>
    public bool HasDebt { get; set; }

    /// <remarks/>
    public int Rating { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Error")]
    public List<tWarning>? Error { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Warning")]
    public List<tWarning>? Warning { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFSPerson
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? LastName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirstName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? MiddleName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? INN { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Snils { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceDebtInfoDocument
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Series { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Number { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tBailiff
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Phone { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tDepartment
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Address { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? AgencyName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFSLastPayment
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Date { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Amount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Bank { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFSPaymentsDetailed
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Payment")]
    public List<tFSPaymentDetailed>? Payment { get; set; }

    /// <remarks/>
    public tFSLastPayment? LastPayment { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Count { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Amount { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFSPaymentDetailed : tFSPayment
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Balance { get; set; }

}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(tFSPaymentDetailed))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFSPayment
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Amount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Reason { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Fine { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Initial { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFine
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Amount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tExecutiveDocumentDetailed
{

    /// <remarks/>
    public tFine? Fine { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ExecutiveDocumentInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Date { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Type { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Id { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Issuer { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFSPersonDetailed
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? LastName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirstName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? MiddleName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? INN { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Snils { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthPlace { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFSDebtDetailed
{

    /// <remarks/>
    public tFSPersonDetailed? Person { get; set; }

    /// <remarks/>
    public tDocumentBailif? Document { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ExecutoryProcess", IsNullable = false)]
    public List<tExecutoryProcessDetailed>? ExecutoryProcesses { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ExecutiveDocument", IsNullable = false)]
    public List<tExecutiveDocumentDetailed>? ExecutiveDocuments { get; set; }

    /// <remarks/>
    public tFSPaymentsDetailed? Payments { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("BillAmount", IsNullable = false)]
    public List<tBillsAgregatedBillAmount>? BillsAgregated { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ExecutoryProcessCancellation", IsNullable = false)]
    public List<tExecutoryProcessCancellationDetailed>? ExecutoryProcessCancellations { get; set; }

    /// <remarks/>
    public tDepartment? Department { get; set; }

    /// <remarks/>
    public tBailiff? Bailiff { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tDocumentBailif
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Series { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Number { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tExecutoryProcessDetailed : tFSData
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Id { get; set; }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(tExecutoryProcessCancellationDetailed))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(tExecutoryProcessDetailed))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFSData
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Date { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tExecutoryProcessCancellationDetailed : tFSData
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ReasonArticle { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ReasonPart { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ReasonPoint { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tBillsAgregatedBillAmount
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int MonthNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tDebtsDetailed
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Debt")]
    public List<tFSDebtDetailed>? Debt { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Count { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Amount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool HasDebt { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tBailiffsServiceDebtInfoDetailed
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Person")]
    public List<tBailiffsServiceDebtInfoDetailedPerson>? Person { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Document")]
    public List<tDocumentBailif>? Document { get; set; }

    /// <remarks/>
    public tDebtsDetailed? Debts { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tBailiffsServiceDebtInfoDetailedPerson
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? LastName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirstName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? MiddleName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? INN { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Snils { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tExecutoryProcessCancellation
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Date { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Reason { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFSDebt
{

    /// <remarks/>
    public tFSPerson? Person { get; set; }

    /// <remarks/>
    public tDocumentBailif? Document { get; set; }

    /// <remarks/>
    public string? Address { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ExecutoryProcess", IsNullable = false)]
    public List<tFSData>? ExecutoryProcesses { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ExecutiveDocument", IsNullable = false)]
    public List<tFSData>? ExecutiveDocuments { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Payment", IsNullable = false)]
    public List<tFSPayment>? Payments { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ExecutoryProcessCancellation", IsNullable = false)]
    public List<tExecutoryProcessCancellation>? ExecutoryProcessCancellations { get; set; }

    /// <remarks/>
    public string? DepartmentAddress { get; set; }

    /// <remarks/>
    public string? Bailiff { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tDebts
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Debt")]
    public List<tFSDebt>? Debt { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Count { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Amount { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFSPScore
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Id { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Desc { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float Prob { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tBailiffsServiceDebtInfo
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Person")]
    public List<tFSPerson>? Person { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Document")]
    public List<tDocumentBailif>? Document { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Score", IsNullable = false)]
    public List<tFSPScore>? Scores { get; set; }

    /// <remarks/>
    public tDebts? Debts { get; set; }

    /// <remarks/>
    public int Rating { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Error")]
    public List<tWarning>? Error { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tFSDocumentStatus
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Id { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Code { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tMigrationServiceDocumentCheck
{

    /// <remarks/>
    public tMigrationServiceDocumentCheckPerson? Person { get; set; }

    /// <remarks/>
    public tMigrationServiceDocumentCheckDocument? Document { get; set; }

    /// <remarks/>
    public tFSDocumentStatus? DocumentStatus { get; set; }

    /// <remarks/>
    public tFSDocumentStatus? PersonDocumentStatus { get; set; }

    /// <remarks/>
    public int Rating { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Error")]
    public List<tWarning>? Error { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tMigrationServiceDocumentCheckPerson
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? LastName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirstName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? MiddleName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tMigrationServiceDocumentCheckDocument
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Series { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Number { get; set; }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(tOperator))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tSummary
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Period")]
    public List<tSummaryPeriod>? Period { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Type { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tPeriodType PeriodType { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int PeriodCount { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tSummaryPeriod
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Payments")]
    public List<tSummaryPeriodPayments>? Payments { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Num { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirstDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tSummaryPeriodPayments
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tPaymentType Type { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Count { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Sum { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tPaymentType
{

    /// <remarks/>
    Phone,

    /// <remarks/>
    Bank,

    /// <remarks/>
    Utility,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tPeriodType
{

    /// <remarks/>
    d,

    /// <remarks/>
    m,

    /// <remarks/>
    y,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tOperator : tSummary
{

    /// <remarks/>
    public tOperatorAdditionalInfo? AdditionalInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int ID { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tOperatorAdditionalInfo
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int NumberActivityConfirmation { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int NumberLifePeriodRate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int NumberDiePeriodRate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int PeriodTotalPaymentCountRate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int PeriodTotalAmountRate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int PaymentRegionConcentrationRate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int PaymentTimeDistributionRate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int PaymentMethodDistributionRate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int MoneyTransferCountRate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TotalPaymentsSum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal PaymentsLast6MonthSum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal PaymentsLast3MonthSum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal PaymentsLast1MonthSum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int TotalPaymentsCount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int PaymentsLast6MonthCount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int PaymentsLast3MonthCount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int PaymentsLast1MonthCount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal TotalMaxPaymentSum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal MaxPaymentLast6MonthSum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal MaxPaymentLast3MonthSum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal MaxPaymentLast1MonthSum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirstPayDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? LastPayDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ProviderWithMaximumPaymentsCount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ProviderWithMaximumPaymentsSum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int PaymentsForMaxPaymentsCountProvider { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int MaxDifferenceInDays { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirstPaymentRegion { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? LastPaymentRegion { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? MaxPaymentRegion { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int BankOrganizationDistributionRate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int MaxDifferenceInDaysLast6Month { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? CountPaymentsDominantRegion { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int NumberOfPaymentsInDominantRegion { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal PercentPaymentsInDominantRegion { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal AverageAmountForEntirePeriod { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int MainHourPayment { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int CountOfMainHourPayment { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? RosSvyazRegion { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? RosSvyazOperator { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tPaymentHistoryRating
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Operator")]
    public List<tOperator>? Operator { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Summary")]
    public List<tSummary>? Summary { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Error")]
    public List<tWarning>? Error { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FromDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tSearchResult
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int id { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public int Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tPreScoringRating
{

    /// <remarks/>
    public tPreScoringRatingFullRating? FullRating { get; set; }

    /// <remarks/>
    public tPreScoringRatingSearchResult? SearchResult { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingFullRating
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Group")]
    public List<tPreScoringRatingFullRatingGroup>? Group { get; set; }

    /// <remarks/>
    public string? Ident { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingFullRatingGroup
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SubGroup")]
    public List<tPreScoringRatingFullRatingGroupSubGroup>? SubGroup { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int ID { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Name { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingFullRatingGroupSubGroup
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Article")]
    public List<tPreScoringRatingFullRatingGroupSubGroupArticle>? Article { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int ID { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Name { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingFullRatingGroupSubGroupArticle
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int ID { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int EventYear { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Module { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Name { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingSearchResult
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Record")]
    public List<tPreScoringRatingSearchResultRecord>? Record { get; set; }

    /// <remarks/>
    public tPreScoringRatingSearchResultRequest? Request { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingSearchResultRecord
{

    /// <remarks/>
    public int baseid { get; set; }

    /// <remarks/>
    public int inbaseid { get; set; }

    /// <remarks/>
    public tSearchResult? H { get; set; }

    /// <remarks/>
    public string? HT { get; set; }

    /// <remarks/>
    public tSearchResult? D { get; set; }

    /// <remarks/>
    public string? DT { get; set; }

    /// <remarks/>
    public tSearchResult? P { get; set; }

    /// <remarks/>
    public string? PT { get; set; }

    /// <remarks/>
    public tSearchResult? A { get; set; }

    /// <remarks/>
    public string? AT { get; set; }

    /// <remarks/>
    public tSearchResult? I { get; set; }

    /// <remarks/>
    public string? IT { get; set; }

    /// <remarks/>
    public int CDate { get; set; }

    /// <remarks/>
    public string? Article { get; set; }

    /// <remarks/>
    public int MainGroup { get; set; }

    /// <remarks/>
    public int SubGroup { get; set; }
    /// <remarks/>
    public string? St { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingSearchResultRequest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HUMAN")]
    public List<tPreScoringRatingSearchResultRequestHUMAN>? HUMAN { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("DOC")]
    public List<tPreScoringRatingSearchResultRequestDOC>? DOC { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PHONE")]
    public List<tPreScoringRatingSearchResultRequestPHONE>? PHONE { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("INN")]
    public List<tPreScoringRatingSearchResultRequestINN>? INN { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Address")]
    public List<tPreScoringRatingSearchResultRequestAddress>? Address { get; set; }

    /// <remarks/>
    public tPreScoringRatingSearchResultRequestSearchModul? SearchModul { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingSearchResultRequestHUMAN
{

    /// <remarks/>
    public string? LastName { get; set; }

    /// <remarks/>
    public string? FirstName { get; set; }

    /// <remarks/>
    public string? MiddleName { get; set; }

    /// <remarks/>
    public string? BirthDate { get; set; }

    /// <remarks/>
    public string? BPlace { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int id { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingSearchResultRequestDOC
{

    /// <remarks/>
    public string? dok_seria { get; set; }

    /// <remarks/>
    public string? dok_number { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int id { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingSearchResultRequestPHONE
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int id { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingSearchResultRequestINN
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int id { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingSearchResultRequestAddress
{

    /// <remarks/>
    public string? Region { get; set; }

    /// <remarks/>
    public string? District { get; set; }

    /// <remarks/>
    public string? DistrictExt { get; set; }

    /// <remarks/>
    public string? City { get; set; }

    /// <remarks/>
    public string? CityExt { get; set; }

    /// <remarks/>
    public string? Settlement { get; set; }

    /// <remarks/>
    public string? SettlementExt { get; set; }

    /// <remarks/>
    public string? Street { get; set; }

    /// <remarks/>
    public string? StreetExt { get; set; }

    /// <remarks/>
    public string? House { get; set; }

    /// <remarks/>
    public string? Korpus { get; set; }

    /// <remarks/>
    public string? Str { get; set; }

    /// <remarks/>
    public string? Flat { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int id { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPreScoringRatingSearchResultRequestSearchModul
{

    /// <remarks/>
    public int H { get; set; }

    /// <remarks/>
    public int D { get; set; }

    /// <remarks/>
    public int P { get; set; }

    /// <remarks/>
    public int A { get; set; }

    /// <remarks/>
    public int I { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tTaxServiceIEInfoData
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("IEMain")]
    public List<tTaxServiceIEInfoDataIEMain>? IEMain { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RegInfo")]
    public List<tTaxServiceIEInfoDataRegInfo>? RegInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("IdentData")]
    public List<tTaxServiceIEInfoDataIdentData>? IdentData { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Citizenship")]
    public List<tTaxServiceIEInfoDataCitizenship>? Citizenship { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ProofMinorsDoc")]
    public List<tTaxServiceIEInfoDataProofMinorsDoc>? ProofMinorsDoc { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("EconActivityTypesInfo")]
    public List<tTaxServiceIEInfoDataEconActivityTypesInfo>? EconActivityTypesInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxRegInfo")]
    public List<tTaxServiceIEInfoDataTaxRegInfo>? TaxRegInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PFRegInfo")]
    public List<tTaxServiceIEInfoDataPFRegInfo>? PFRegInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SIFRegInfo")]
    public List<tTaxServiceIEInfoDataSIFRegInfo>? SIFRegInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CMIFRegInfo")]
    public List<tTaxServiceIEInfoDataCMIFRegInfo>? CMIFRegInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LicInfo")]
    public List<tTaxServiceIEInfoDataLicInfo>? LicInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RegInfoBefore01012004")]
    public List<tTaxServiceIEInfoDataRegInfoBefore01012004>? RegInfoBefore01012004 { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("USRIEInfoByDocs")]
    public List<tTaxServiceIEInfoDataUSRIEInfoByDocs>? USRIEInfoByDocs { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CertInfo")]
    public List<tTaxServiceIEInfoDataCertInfo>? CertInfo { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataIEMain
{

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? IEState { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataRegInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? IEState { get; set; }

    /// <remarks/>
    public string? TerminationDate { get; set; }

    /// <remarks/>
    public string? IEType { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataIdentData
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? SurnameLat { get; set; }

    /// <remarks/>
    public string? NameLat { get; set; }

    /// <remarks/>
    public string? PatronymicLat { get; set; }

    /// <remarks/>
    public string? BirthDate { get; set; }

    /// <remarks/>
    public string? BirthPlace { get; set; }

    /// <remarks/>
    public string? Gender { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataCitizenship
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? CitizenshipType { get; set; }

    /// <remarks/>
    public string? CitizenshipCountry { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataProofMinorsDoc
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? ProofMinorsReason { get; set; }

    /// <remarks/>
    public string? DocType { get; set; }

    /// <remarks/>
    public string? DocNum { get; set; }

    /// <remarks/>
    public string? DocDate { get; set; }

    /// <remarks/>
    public string? DocIssuer { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataEconActivityTypesInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? OKVEDCode { get; set; }

    /// <remarks/>
    public string? Type { get; set; }

    /// <remarks/>
    public string? ActivityType { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataTaxRegInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? TaxRegDate { get; set; }

    /// <remarks/>
    public string? TaxRegReason { get; set; }

    /// <remarks/>
    public string? DeregDate { get; set; }

    /// <remarks/>
    public string? TaxDeregReason { get; set; }

    /// <remarks/>
    public string? TaxBodyName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataPFRegInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? PFRegNo { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? DeregDate { get; set; }

    /// <remarks/>
    public string? LocalPFName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataSIFRegInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? SIFRegNo { get; set; }

    /// <remarks/>
    public string? InitialRegDate { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? DeregDate { get; set; }

    /// <remarks/>
    public string? SIFexecutName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataCMIFRegInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? CMIFRegNo { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? DeregDate { get; set; }

    /// <remarks/>
    public string? LocalCMIFName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataLicInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? LicNo { get; set; }

    /// <remarks/>
    public string? LicDate { get; set; }

    /// <remarks/>
    public string? LicState { get; set; }

    /// <remarks/>
    public string? LicBody { get; set; }

    /// <remarks/>
    public string? ValidFromDate { get; set; }

    /// <remarks/>
    public string? ValidEndDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataRegInfoBefore01012004
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? RegNo { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataUSRIEInfoByDocs
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? EntryDate { get; set; }

    /// <remarks/>
    public string? Status { get; set; }

    /// <remarks/>
    public string? Event { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceIEInfoDataCertInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? CertSeries { get; set; }

    /// <remarks/>
    public string? CertNo { get; set; }

    /// <remarks/>
    public string? IssueDate { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }

    /// <remarks/>
    public string? Status { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tIndividualTitle
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Title")]
    public List<tNaturalPersonTitle>? Title { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("IdentificationDocument")]
    public List<tNaturalPersonIdentificationDocument>? IdentificationDocument { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? IndividualTaxpayerNumber { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tNaturalPersonTitle
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? LastName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirstName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? MiddleName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool isOldName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ActualityDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tNaturalPersonIdentificationDocument
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal DocTypeID { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocTypeText { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocSer { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocPlace { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocDelivInstName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocDelivInstCode { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool isOldDocument { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tTaxServiceIEInfo
{

    /// <remarks/>
    public tIndividualTitle? RequestIEInfoTitle { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Data")]
    public List<tTaxServiceIEInfoData>? Data { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Error")]
    public List<tWarning>? Error { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Warning")]
    public List<tWarning>? Warning { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tTaxInfoAddress
{

    /// <remarks/>
    public string? AddressString { get; set; }

    /// <remarks/>
    public string? TaxCode { get; set; }

    /// <remarks/>
    public tCaption? Region { get; set; }

    /// <remarks/>
    public tAddressIdentity? District { get; set; }

    /// <remarks/>
    public tAddressIdentity? City { get; set; }

    /// <remarks/>
    public tAddressIdentity? Village { get; set; }

    /// <remarks/>
    public tStreetAddress? StreetAddress { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tCaption
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ID { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Text { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tAddressIdentity
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Caption { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Ext { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tStreetAddress
{

    /// <remarks/>
    public tAddressIdentity? Street { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? HouseNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BuildingNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BuildingSymbol { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FlatNum { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tTaxServiceLPInfoData
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPMain")]
    public List<tTaxServiceLPInfoDataLPMain>? LPMain { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPAddress")]
    public List<tTaxServiceLPInfoDataLPAddress>? LPAddress { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CharterCapital")]
    public List<tTaxServiceLPInfoDataCharterCapital>? CharterCapital { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LLCCharterCapitalParts")]
    public List<tTaxServiceLPInfoDataLLCCharterCapitalParts>? LLCCharterCapitalParts { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("JSCCapitalAccount")]
    public List<tTaxServiceLPInfoDataJSCCapitalAccount>? JSCCapitalAccount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("InfoAboutCharterCapitalDecreasing")]
    public List<tTaxServiceLPInfoDataInfoAboutCharterCapitalDecreasing>? InfoAboutCharterCapitalDecreasing { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("StateOfLP")]
    public List<tTaxServiceLPInfoDataStateOfLP>? StateOfLP { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPEstabl")]
    public List<tTaxServiceLPInfoDataLPEstabl>? LPEstabl { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPtermintation")]
    public List<tTaxServiceLPInfoDataLPtermintation>? LPtermintation { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RusFounderMember")]
    public List<tTaxServiceLPInfoDataRusFounderMember>? RusFounderMember { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ForeignFounderMember")]
    public List<tTaxServiceLPInfoDataForeignFounderMember>? ForeignFounderMember { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NPFounderMember")]
    public List<tTaxServiceLPInfoDataNPFounderMember>? NPFounderMember { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPRFFounderMember")]
    public List<tTaxServiceLPInfoDataLPRFFounderMember>? LPRFFounderMember { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NPRFFounderMember")]
    public List<tTaxServiceLPInfoDataNPRFFounderMember>? NPRFFounderMember { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPSubjectRFFounderMember")]
    public List<tTaxServiceLPInfoDataLPSubjectRFFounderMember>? LPSubjectRFFounderMember { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NPSubjectRFFounderMember")]
    public List<tTaxServiceLPInfoDataNPSubjectRFFounderMember>? NPSubjectRFFounderMember { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPMunicipalFounderMember")]
    public List<tTaxServiceLPInfoDataLPMunicipalFounderMember>? LPMunicipalFounderMember { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NPMunicipalFounderMember")]
    public List<tTaxServiceLPInfoDataNPMunicipalFounderMember>? NPMunicipalFounderMember { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPPIFInfo")]
    public List<tTaxServiceLPInfoDataLPPIFInfo>? LPPIFInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NPPIFInfo")]
    public List<tTaxServiceLPInfoDataNPPIFInfo>? NPPIFInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SharesRegHolder")]
    public List<tTaxServiceLPInfoDataSharesRegHolder>? SharesRegHolder { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPReorgPredecessor")]
    public List<tTaxServiceLPInfoDataLPReorgPredecessor>? LPReorgPredecessor { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPReorgSuccessor")]
    public List<tTaxServiceLPInfoDataLPReorgSuccessor>? LPReorgSuccessor { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPReorgStartInfo")]
    public List<tTaxServiceLPInfoDataLPReorgStartInfo>? LPReorgStartInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AuthFreeNP")]
    public List<tTaxServiceLPInfoDataAuthFreeNP>? AuthFreeNP { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AdmCompany")]
    public List<tTaxServiceLPInfoDataAdmCompany>? AdmCompany { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LPBranchInfo")]
    public List<tTaxServiceLPInfoDataLPBranchInfo>? LPBranchInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RepresInfo")]
    public List<tTaxServiceLPInfoDataRepresInfo>? RepresInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("EconActivityTypesInfo")]
    public List<tTaxServiceLPInfoDataEconActivityTypesInfo>? EconActivityTypesInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxRegInfo")]
    public List<tTaxServiceLPInfoDataTaxRegInfo>? TaxRegInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PFRegInfo")]
    public List<tTaxServiceLPInfoDataPFRegInfo>? PFRegInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SIFRegInfo")]
    public List<tTaxServiceLPInfoDataSIFRegInfo>? SIFRegInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CMIFRegInfo")]
    public List<tTaxServiceLPInfoDataCMIFRegInfo>? CMIFRegInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LicInfo")]
    public List<tTaxServiceLPInfoDataLicInfo>? LicInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("USRLEntriesInfo")]
    public List<tTaxServiceLPInfoDataUSRLEntriesInfo>? USRLEntriesInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CertInfo")]
    public List<tTaxServiceLPInfoDataCertInfo>? CertInfo { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPMain
{

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }

    /// <remarks/>
    public string? ShortName { get; set; }

    /// <remarks/>
    public string? FirmName { get; set; }

    /// <remarks/>
    public string? ForeingName { get; set; }

    /// <remarks/>
    public string? Form { get; set; }

    /// <remarks/>
    public string? LPState { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPAddress
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }

    /// <remarks/>
    public string? Identity { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataCharterCapital
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? CapitalType { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLLCCharterCapitalParts
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? Amount { get; set; }

    /// <remarks/>
    public string? FractionQuotient { get; set; }

    /// <remarks/>
    public string? PercentageQuotient { get; set; }

    /// <remarks/>
    public string? Quotient { get; set; }

    /// <remarks/>
    public string? EncumbranceType { get; set; }

    /// <remarks/>
    public string? EncumbrancePeriodInfo { get; set; }

    /// <remarks/>
    public string? EncumbranceTermination { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataJSCCapitalAccount
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? CapitalAccountAmount { get; set; }

    /// <remarks/>
    public string? PeriodLastDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataInfoAboutCharterCapitalDecreasing
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? DecreasingAmount { get; set; }

    /// <remarks/>
    public string? DecreasingMethod { get; set; }

    /// <remarks/>
    public string? DecreasingDecisionDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataStateOfLP
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? LPState { get; set; }

    /// <remarks/>
    public string? RegBodyCode { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPEstabl
{

    /// <remarks/>
    public string? EstablType { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? RegNoBefore01072002 { get; set; }

    /// <remarks/>
    public string? RegBodyCode { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPtermintation
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? TerminationType { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? RegBodyCode { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataRusFounderMember
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? Form { get; set; }

    /// <remarks/>
    public string? LPMemberFounderFullName { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? PSRNFounder { get; set; }

    /// <remarks/>
    public string? RegNoBefore01072002 { get; set; }

    /// <remarks/>
    public string? ConstRegDate { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? KPP { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }

    /// <remarks/>
    public string? PSRNEst { get; set; }

    /// <remarks/>
    public string? FullNameEst { get; set; }

    /// <remarks/>
    public string? EncumbranceType { get; set; }

    /// <remarks/>
    public string? EncumbrancePeriodInfo { get; set; }

    /// <remarks/>
    public string? EncumbranceAmount { get; set; }

    /// <remarks/>
    public string? EncumbranceAmountRub { get; set; }

    /// <remarks/>
    public string? EncumbranceFractionQuotient { get; set; }

    /// <remarks/>
    public string? EncumbrancePercentageQuotient { get; set; }

    /// <remarks/>
    public string? EncumbranceQuotient { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataForeignFounderMember
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? LPMemberFounderFullName { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? RegCountry { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? RegNo { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? PSRNEst { get; set; }

    /// <remarks/>
    public string? FullNameEst { get; set; }

    /// <remarks/>
    public string? EncumbranceType { get; set; }

    /// <remarks/>
    public string? EncumbrancePeriodInfo { get; set; }

    /// <remarks/>
    public string? EncumbranceAmount { get; set; }

    /// <remarks/>
    public string? EncumbranceAmountRub { get; set; }

    /// <remarks/>
    public string? EncumbranceFractionQuotient { get; set; }

    /// <remarks/>
    public string? EncumbrancePercentageQuotient { get; set; }

    /// <remarks/>
    public string? EncumbranceQuotient { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataNPFounderMember
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? PSRNEst { get; set; }

    /// <remarks/>
    public string? FullNameEst { get; set; }

    /// <remarks/>
    public string? EncumbranceType { get; set; }

    /// <remarks/>
    public string? EncumbrancePeriodInfo { get; set; }

    /// <remarks/>
    public string? EncumbranceAmount { get; set; }

    /// <remarks/>
    public string? EncumbranceAmountRub { get; set; }

    /// <remarks/>
    public string? EncumbranceFractionQuotient { get; set; }

    /// <remarks/>
    public string? EncumbrancePercentageQuotient { get; set; }

    /// <remarks/>
    public string? EncumbranceQuotient { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPRFFounderMember
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? ShareType { get; set; }

    /// <remarks/>
    public string? Form { get; set; }

    /// <remarks/>
    public string? LPMemberFounderFullName { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? PSRNFounder { get; set; }

    /// <remarks/>
    public string? RegNoBefore01072002 { get; set; }

    /// <remarks/>
    public string? RegDateEst { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? KPP { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }

    /// <remarks/>
    public string? PSRNEst { get; set; }

    /// <remarks/>
    public string? FullNameEst { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataNPRFFounderMember
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? ShareType { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? PSRNEst { get; set; }

    /// <remarks/>
    public string? FullNameEst { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPSubjectRFFounderMember
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? ShareType { get; set; }

    /// <remarks/>
    public string? Form { get; set; }

    /// <remarks/>
    public string? LPMemberFounderFullName { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? PSRNFounder { get; set; }

    /// <remarks/>
    public string? RegNoBefore01072002 { get; set; }

    /// <remarks/>
    public string? ConstRegDate { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? KPP { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }

    /// <remarks/>
    public string? PSRNEst { get; set; }

    /// <remarks/>
    public string? FullNameEst { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataNPSubjectRFFounderMember
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? ShareType { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? PSRNEst { get; set; }

    /// <remarks/>
    public string? FullNameEst { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPMunicipalFounderMember
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? ShareType { get; set; }

    /// <remarks/>
    public string? Form { get; set; }

    /// <remarks/>
    public string? LPMemberFounderFullName { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? PSRNFounder { get; set; }

    /// <remarks/>
    public string? RegNoBefore01072002 { get; set; }

    /// <remarks/>
    public string? ConstRegDate { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? KPP { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }

    /// <remarks/>
    public string? PSRNEst { get; set; }

    /// <remarks/>
    public string? FullNameEst { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataNPMunicipalFounderMember
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? ShareType { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? PSRNEst { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPPIFInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? ShareType { get; set; }

    /// <remarks/>
    public string? Form { get; set; }

    /// <remarks/>
    public string? LPMemberFounderFullName { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? PSRNFounder { get; set; }

    /// <remarks/>
    public string? RegNoBefore01072002 { get; set; }

    /// <remarks/>
    public string? ConstRegDate { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? KPP { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }

    /// <remarks/>
    public string? PSRNEst { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataNPPIFInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? ShareType { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? AmountRub { get; set; }

    /// <remarks/>
    public string? PSRNEst { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataSharesRegHolder
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPReorgPredecessor
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? Form { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? ReorgLPFullName { get; set; }

    /// <remarks/>
    public string? RegNoBefore01072002 { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? KPP { get; set; }

    /// <remarks/>
    public string? LPAddress { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPReorgSuccessor
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? Form { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }

    /// <remarks/>
    public string? RegNoBefore01072002 { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? KPP { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPReorgStartInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? ReorgState { get; set; }

    /// <remarks/>
    public string? Form { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }

    /// <remarks/>
    public string? RegNoBefore01072002 { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? KPP { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataAuthFreeNP
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? Title { get; set; }

    /// <remarks/>
    public string? Surname { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? Patronymic { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataAdmCompany
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? CompanyPSRN { get; set; }

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public string? CompanyMember { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }

    /// <remarks/>
    public string? KPP { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLPBranchInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataRepresInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }

    /// <remarks/>
    public tTaxInfoAddress? Address { get; set; }

    /// <remarks/>
    public string? CityCode { get; set; }

    /// <remarks/>
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    public string? Fax { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataEconActivityTypesInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? OKVEDCode { get; set; }

    /// <remarks/>
    public string? Type { get; set; }

    /// <remarks/>
    public string? ActivityType { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataTaxRegInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? ITN { get; set; }

    /// <remarks/>
    public string? KPP { get; set; }

    /// <remarks/>
    public string? TaxRegDate { get; set; }

    /// <remarks/>
    public string? DeregDate { get; set; }

    /// <remarks/>
    public string? TaxBodyCode { get; set; }

    /// <remarks/>
    public string? TaxBodyName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataPFRegInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }

    /// <remarks/>
    public string? PFRegNo { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? DeregDate { get; set; }

    /// <remarks/>
    public string? LocalPFName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataSIFRegInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }

    /// <remarks/>
    public string? SIFRegNo { get; set; }

    /// <remarks/>
    public string? InitialRegDate { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? DeregDate { get; set; }

    /// <remarks/>
    public string? SIFexecutName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataCMIFRegInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }

    /// <remarks/>
    public string? CMIFRegNo { get; set; }

    /// <remarks/>
    public string? RegDate { get; set; }

    /// <remarks/>
    public string? DeregDate { get; set; }

    /// <remarks/>
    public string? LocalCMIFName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataLicInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? RecordDate { get; set; }

    /// <remarks/>
    public string? LicNo { get; set; }

    /// <remarks/>
    public string? LicDate { get; set; }

    /// <remarks/>
    public string? LicState { get; set; }

    /// <remarks/>
    public string? LicBody { get; set; }

    /// <remarks/>
    public string? ValidFromDate { get; set; }

    /// <remarks/>
    public string? ValidEndDate { get; set; }

    /// <remarks/>
    public string? LicTerr { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataUSRLEntriesInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? EntryDate { get; set; }

    /// <remarks/>
    public string? Event { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }

    /// <remarks/>
    public string? Status { get; set; }

    /// <remarks/>
    public string? PSRN { get; set; }

    /// <remarks/>
    public string? FullName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tTaxServiceLPInfoDataCertInfo
{

    /// <remarks/>
    public string? SRN { get; set; }

    /// <remarks/>
    public string? CertNo { get; set; }

    /// <remarks/>
    public string? CertSeries { get; set; }

    /// <remarks/>
    public string? IssueDate { get; set; }

    /// <remarks/>
    public string? RegBodyName { get; set; }

    /// <remarks/>
    public string? Status { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tTaxServiceLPInfo
{

    /// <remarks/>
    public tLegalTitle? RequestLPInfoTitle { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Data")]
    public List<tTaxServiceLPInfoData>? Data { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Error")]
    public List<tWarning>? Error { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Warning")]
    public List<tWarning>? Warning { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tLegalTitle
{

    /// <remarks/>
    public tLegalName? Name { get; set; }

    /// <remarks/>
    public string? IndividualTaxpayerNumber { get; set; }

    /// <remarks/>
    public string? ForeignID { get; set; }

    /// <remarks/>
    public string? PrimaryStateRegistrationNumber { get; set; }

    /// <remarks/>
    public string? RegistrationNumber { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tLegalName
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FullName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ShortName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirmName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? NationalName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? EngName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? OtherName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tTaxServiceInfo
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxServiceLPInfo")]
    public List<tTaxServiceLPInfo>? TaxServiceLPInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxServiceIEInfo")]
    public List<tTaxServiceIEInfo>? TaxServiceIEInfo { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEmployerRatingOverdue
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Active1M { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Active2M { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Active3MPlus { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Closed1M { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Closed2M { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Closed3MPlus { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEmployerRatingContract
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Active { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Closed { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEmployerRatingCounts
{

    /// <remarks/>
    public int Clients { get; set; }

    /// <remarks/>
    public tEmployerRatingContract? Contract { get; set; }

    /// <remarks/>
    public tEmployerRatingOverdue? Overdue { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEmployerRatingAverages
{

    /// <remarks/>
    public string? Salary { get; set; }

    /// <remarks/>
    public decimal EmployeeAge { get; set; }

    /// <remarks/>
    public string? EmployeeExperience { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEmployerRatingAddress
{

    /// <remarks/>
    public string? Index { get; set; }

    /// <remarks/>
    public string? City { get; set; }

    /// <remarks/>
    public string? Street { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEmployerRatingEconomicActivity
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Id { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEmployerRatingCompany
{

    /// <remarks/>
    public string? Name { get; set; }

    /// <remarks/>
    public tEmployerRatingEconomicActivity? EconomicActivity { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Address")]
    public List<tEmployerRatingAddress>? Address { get; set; }

    /// <remarks/>
    public tEmployerRatingAverages? Averages { get; set; }

    /// <remarks/>
    public tEmployerRatingCounts? Counts { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEmployerRatingCity
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Name { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Clients { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEmployerRatingMessage
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int Id { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEmployerRating
{

    /// <remarks/>
    public tEmployerRatingMessage? Message { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("City", typeof(tEmployerRatingCity), IsNullable = false)]
    public tEmployerRatingCity[][]? Locations { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Company")]
    public List<tEmployerRatingCompany>? Company { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tDebtRating
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("OutstandingDebt")]
    public List<tDebtRatingOutstandingDebt>? OutstandingDebt { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("OverdueCount")]
    public List<tDebtRatingOverdueCount>? OverdueCount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TotalMonthlyPayment")]
    public List<tSum>? TotalMonthlyPayment { get; set; }

    /// <remarks/>
    public int CreditCount { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tDebtRatingOutstandingDebt
{

    /// <remarks/>
    public int Count { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Sum")]
    public List<tSum>? Sum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int type { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tSum
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Currency { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tDebtRatingOverdueCount
{

    /// <remarks/>
    public int Count { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Sum")]
    public List<tSum>? Sum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int period { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int type { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tRatings
{

    /// <remarks/>
    public tDebtRating? DebtRating { get; set; }

    /// <remarks/>
    public tEmployerRating? EmployerRating { get; set; }

    /// <remarks/>
    public string? EmployerRatingString { get; set; }

    /// <remarks/>
    public string? PreScoringRatingByNameString { get; set; }

    /// <remarks/>
    public string? PreScoringRatingByAddressString { get; set; }

    /// <remarks/>
    public int NumericRating { get; set; }


    /// <remarks/>
    public tTaxServiceInfo? TaxServiceInfo { get; set; }

    /// <remarks/>
    public tPreScoringRating? PreScoringRating { get; set; }

    /// <remarks/>
    public tPaymentHistoryRating? PaymentHistoryRating { get; set; }

    /// <remarks/>
    public tMigrationServiceDocumentCheck? MigrationServiceDocumentCheck { get; set; }

    /// <remarks/>
    public tBailiffsServiceDebtInfo? BailiffsServiceDebtInfo { get; set; }

    /// <remarks/>
    public tBailiffsServiceDebtInfoDetailed? BailiffsServiceDebtInfoDetailed { get; set; }

    /// <remarks/>
    public tTaxServiceDebtInfo? TaxServiceDebtInfo { get; set; }

    /// <remarks/>
    public tCreditReportForSubjectByUserCheck? CreditReportForSubjectByUserCheck { get; set; }

    /// <remarks/>
    public tCreditReportForFinancialManagerCheck? CreditReportForFinancialManagerCheck { get; set; }

    /// <remarks/>
    public tBureauScoringData? BureauScoringData { get; set; }

    /// <remarks/>
    public tFraudInfo? FraudInfo { get; set; }

    /// <remarks/>
    public tBureauRating? BureauRating { get; set; }

    /// <remarks/>
    public tBureauAccountDispatching? BureauAccountDispatching { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tInquiryStat
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int ByLastHourPeriod { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int ByLastDayPeriod { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int ByLastWeekPeriod { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int ByLastMonthPeriod { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int ByLastQuarterPeriod { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int ByLastYearPeriod { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int TotalByAllTime { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tPreviousRequests
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Request")]
    public List<tPreviousRequest>? Request { get; set; }

    /// <remarks/>
    public tInquiryStat? TotalCount { get; set; }

    /// <remarks/>
    public tInquiryStat? SelfTotalCount { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tPreviousRequest : tHistoricalRequestBODY
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool Ownership { get; set; }

}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPreviousRequest))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tHistoricalRequestBODY
{

    /// <remarks/>
    public tHistoricalRequestAttributes? RequestAttributes { get; set; }

    /// <remarks/>
    public tNaturalPersonSubject? NaturalPersonSubject { get; set; }

    /// <remarks/>
    public tLegalPerson? LegalPersonSubject { get; set; }

    /// <remarks/>
    public tNaturalPersonIdentificationDocument? Document { get; set; }

    /// <remarks/>
    public tAddressOld? Address { get; set; }

    /// <remarks/>
    public tPhone? Phone { get; set; }

    /// <remarks/>
    public tReceipt? Receipt { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tHistoricalRequestAttributes : tPrevRequestAttributes
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DateTime { get; set; }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(tHistoricalRequestAttributes))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tPrevRequestAttributes
{

    /// <remarks/>
    public tPrevRequestAttributesResponseCapabilities? ResponseCapabilities { get; set; }

    /// <remarks/>
    public tPrevRequestAttributesReason? Reason { get; set; }

    /// <remarks/>
    public tReference0? RequestPurpose { get; set; }

    /// <remarks/>
    public tConsent? Consent { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? id { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPrevRequestAttributesResponseCapabilities
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tReportDetalization CreditReportDetalization { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tGetExternalCreditReport getExternalCreditReport { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getScoringParameters { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool SelfRequestInResponse { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? PreviousRequestsCountLimit { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getRating1 { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getRating2 { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getRating3 { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getRating4 { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? getTaxServiceLPInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? getTaxServiceIEInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getVerificationService { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tPaymentHistoryRequestSchema getPaymentHistory { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tgetMigrationServiceDocumentCheck getMigrationServiceDocumentCheck { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getBailiffsServiceDebtInfo { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getBailiffsServiceDebtInfoDetailed { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getTaxServiceDebtInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getFraudInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tBureauRatingRequestSchema getRating { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool dispatchBureauAccount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tBuildScoring buildScoring { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tGetIdentification getIdentification { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tGetOldReport getOldReport { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool getReportWithAmp { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tReportFormat getReportFormat { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tAmpFromAllQcb getAmpFromAllQcb { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tReportDetalization
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("4")]
    Item4,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("5")]
    Item5,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("6")]
    Item6,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("7")]
    Item7,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tGetExternalCreditReport
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tPaymentHistoryRequestSchema
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tgetMigrationServiceDocumentCheck
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tBureauRatingRequestSchema
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tBuildScoring
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("-100")]
    Item100,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("4")]
    Item4,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("5")]
    Item5,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("6")]
    Item6,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("7")]
    Item7,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tGetIdentification
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("4")]
    Item4,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tGetOldReport
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tReportFormat
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tAmpFromAllQcb
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPrevRequestAttributesReason
{

    /// <remarks/>
    public tReference? SalesChannel { get; set; }

    /// <remarks/>
    public tReference? ApplicationType { get; set; }

    /// <remarks/>
    public tReference? ApplicationOrigin { get; set; }

    /// <remarks/>
    public tPrevRequestAttributesReasonApplicationCollateral? ApplicationCollateral { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal CustomerClaimCreditLimit { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal MontlyPaymentAmount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? CurrencyID { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? CurrencyCaption { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ID { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Text { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tReference
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? type { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPrevRequestAttributesReasonApplicationCollateral
{

    /// <remarks/>
    public tPrevRequestAttributesReasonApplicationCollateralIncome? Income { get; set; }

    /// <remarks/>
    public tPrevRequestAttributesReasonApplicationCollateralProperty? Property { get; set; }

    /// <remarks/>
    public tPrevRequestAttributesReasonApplicationCollateralWorkExperience? WorkExperience { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPrevRequestAttributesReasonApplicationCollateralIncome
{

    /// <remarks/>
    public tReference? Period { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ConfirmationDocument")]
    public List<tReference>? ConfirmationDocument { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Amount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? CurrencyID { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPrevRequestAttributesReasonApplicationCollateralProperty
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Car")]
    public List<tPrevRequestAttributesReasonApplicationCollateralPropertyCar>? Car { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Realty")]
    public List<tPrevRequestAttributesReasonApplicationCollateralPropertyRealty>? Realty { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPrevRequestAttributesReasonApplicationCollateralPropertyCar
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ConfirmationDocument")]
    public List<tReference>? ConfirmationDocument { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BrandAndModel { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? CreationYear { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? VIN { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? RegistrationNumber { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPrevRequestAttributesReasonApplicationCollateralPropertyRealty
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ConfirmationDocument")]
    public List<tReference>? ConfirmationDocument { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? type { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? description { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tPrevRequestAttributesReasonApplicationCollateralWorkExperience
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? NumberOfYears { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tReference0
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal type { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tConsent
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute()]
    public List<byte>? Pdf { get; set; }

    /// <remarks/>
    public tLegalPersonSubjectForConcent? LegalPersonSubject { get; set; }
    public tNaturalPersonSubjectForConcent? NaturalPersonSubject { get; set; }

    /// <remarks/>
    public tUserIndividualEntrepreneurForConcent? UserIndividualEntrepreneur { get; set; }
    public tUserLegalEntityForConcent? UserLegalEntity { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool RequestorResponsibility { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Purpose { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? OtherPurposeAsText { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? IssueDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ExpiryDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DateOfContract { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tReasonForConsentTransfer ReasonForConsentTransfer { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tConsentExpiration ConsentExpiration { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool noPensionNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool ConsentEForm { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? HashCode { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tLegalPersonSubjectForConcent
{

    /// <remarks/>
    public tLegalNameForConcent? Name { get; set; }

    /// <remarks/>
    public string? PrimaryStateRegistrationNumber { get; set; }
    public string? RegistrationNumber { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RestructuredTitle")]
    public List<tRestructuredTitleForConcent>? RestructuredTitle { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Address { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? PhoneNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? eMail { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? IndividualTaxpayerNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? TaxpayerNumber { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tLegalNameForConcent
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FullName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ShortName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirmName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType
{

    /// <remarks/>
    PrimaryStateRegistrationNumber,

    /// <remarks/>
    RegistrationNumber,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tRestructuredTitleForConcent
{

    /// <remarks/>
    public tLegalNameForConcent? Name { get; set; }

    /// <remarks/>
    public string? PrimaryStateRegistrationNumber { get; set; }
    public string? RegistrationNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemChoiceType1 ItemElementName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType1
{

    /// <remarks/>
    PrimaryStateRegistrationNumber,

    /// <remarks/>
    RegistrationNumber,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tNaturalPersonSubjectForConcent
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Name")]
    public List<tNaturalPersonNameForConsent>? Name { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("IdentificationDocument")]
    public List<tNaturalPersonIdentificationDocument>? IdentificationDocument { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthPlace { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? IndividualTaxpayerNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? TaxpayerNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? PensionNumber { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tNaturalPersonNameForConsent : tNaturalPersonName
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool isOldName { get; set; }

}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(tNaturalPersonNameForConsent))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tNaturalPersonName
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? LastName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirstName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? MiddleName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tUserIndividualEntrepreneurForConcent
{

    /// <remarks/>
    public string? PrimaryStateRegistrationNumber { get; set; }
    public string? RegistrationNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemChoiceType2 ItemElementName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? LastName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FirstName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? MiddleName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? IndividualTaxpayerNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? TaxpayerNumber { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType2
{

    /// <remarks/>
    PrimaryStateRegistrationNumber,

    /// <remarks/>
    RegistrationNumber,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tUserLegalEntityForConcent
{

    /// <remarks/>
    public string? PrimaryStateRegistrationNumber { get; set; }
    public string? RegistrationNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemChoiceType3 ItemElementName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? FullName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? IndividualTaxpayerNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? TaxpayerNumber { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType3
{

    /// <remarks/>
    PrimaryStateRegistrationNumber,

    /// <remarks/>
    RegistrationNumber,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tReasonForConsentTransfer
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tConsentExpiration
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tNaturalPersonSubject
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Title")]
    public List<tNaturalPersonTitle>? Title { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("IdentificationDocument")]
    public List<tNaturalPersonIdentificationDocument>? IdentificationDocument { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("IndividualEntrepreneur")]
    public List<tIndividualEntrepreneur>? IndividualEntrepreneur { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Address")]
    public List<tAddressWithUseExtension>? Address { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Phone")]
    public List<tPhoneWithConfirmationExtension>? Phone { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PersonalInternetPage")]
    public List<tUrl>? PersonalInternetPage { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("EMail")]
    public List<tEMail>? EMail { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Employer")]
    public List<tLegalPerson>? Employer { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthPlace { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? IndividualTaxpayerNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? TaxpayerNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? PensionNumber { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tGender Gender { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public tMaritalStatus MaritalStatus { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Education { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Children { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? CitizenshipCountryCode { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tIndividualEntrepreneur
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? PSRN { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? RegDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? RegData { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tAddressWithUseExtension : tAddressOld
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? UseDuration { get; set; }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAddressWithUseExtension))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tAddressOld
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Caption")]
    public List<tCaption>? Caption { get; set; }

    /// <remarks/>
    public tCaption? Region { get; set; }

    /// <remarks/>
    public tAddressIdentity? District { get; set; }

    /// <remarks/>
    public tAddressIdentity? City { get; set; }

    /// <remarks/>
    public tAddressIdentity? Village { get; set; }

    /// <remarks/>
    public tStreetAddress? StreetAddress { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tPhoneWithConfirmationExtension : tPhone
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ConfirmationType { get; set; }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPhoneWithConfirmationExtension))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tPhone
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ID { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Text { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Number { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tUrl
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? address { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tEMail
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? address { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? OwnerID { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tLegalPerson
{

    /// <remarks/>
    public tLegalTitle? Title { get; set; }

    /// <remarks/>
    public string? eMail { get; set; }

    /// <remarks/>
    public string? www { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RestructuredTitle")]
    public List<tLegalTitle>? RestructuredTitle { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Address")]
    public List<tAddressOld>? Address { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Phone")]
    public List<tPhone>? Phone { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? CountryCode { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tGender
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum tMaritalStatus
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("0")]
    Item0,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("4")]
    Item4,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("5")]
    Item5,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("6")]
    Item6,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("7")]
    Item7,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("8")]
    Item8,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tReceipt
{

    /// <remarks/>
    public string? AmpReceiptId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ТипРезультат
{

    /// <remarks/>
    public ТипРезультатИдентификаторОтвета? ИдентификаторОтвета { get; set; }
    public ТипРезультатОшибка? Ошибка { get; set; }
    public ТипРезультатУспешно? Успешно { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Версия { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ОГРН { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ТипРезультатИдентификаторОтвета
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ИдентификаторЗапроса { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public long ВремяГотовности { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ТипРезультатОшибка
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Код { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string? Value { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ТипРезультатУспешно
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ИдентификаторЗапроса { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ТипДУЛПредпринимателя
{

    /// <remarks/>
    public string? Серия { get; set; }

    /// <remarks/>
    public string? Номер { get; set; }

    /// <remarks/>

    public string? ДатаВыдачи { get; set; }

    /// <remarks/>
    public string? НаименованиеОргана { get; set; }

    /// <remarks/>
    public string? КодПодразделения { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public СправочникДУЛ КодДУЛ { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? НаименованиеДУЛ { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
public enum СправочникДУЛ
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("21")]
    Item21,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("22.1")]
    Item221,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("22.2")]
    Item222,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("22.3")]
    Item223,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("23")]
    Item23,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("24")]
    Item24,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("25")]
    Item25,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("26")]
    Item26,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("27")]
    Item27,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("28")]
    Item28,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("31")]
    Item31,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("32")]
    Item32,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("35")]
    Item35,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("37")]
    Item37,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("38")]
    Item38,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("999")]
    Item999,
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType21
{

    /// <remarks/>
    ОбязательствНет,

    /// <remarks/>
    Обязательства,

    /// <remarks/>
    Ошибка,

    /// <remarks/>
    СубъектНеНайден,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public enum ТипСведенияОПлатежахТипОтвета
{

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,

    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tAddressEntity
{

    /// <remarks/>
    public tCaption? Region { get; set; }

    /// <remarks/>
    public tAddressIdentity? District { get; set; }

    /// <remarks/>
    public tAddressIdentity? City { get; set; }

    /// <remarks/>
    public tAddressIdentity? Village { get; set; }

    /// <remarks/>
    public tStreetAddress? StreetAddress { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tIdentityDocForAdditionalPart
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal DocTypeID { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocOtherName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocSer { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocDelivInstName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocDelivInstCode { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? DocEndDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tNaturalPersonBirthDatePlace
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthCountryCode { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BirthPlace { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tReportPdf
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute()]
    public List<byte>? pdf { get; set; }

    /// <remarks/>
    public int reportKindCode { get; set; }

    /// <remarks/>
    public object? hasCreditHistory_0 { get; set; }
    public object? hasCreditHistory_1 { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemChoiceType20 ItemElementName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType20
{

    /// <remarks/>
    hasCreditHistory_0,

    /// <remarks/>
    hasCreditHistory_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class FL_SocialType
{

    /// <remarks/>
    public string? socialNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ParticipationType
{

    /// <remarks/>
    public string? role { get; set; }

    /// <remarks/>
    public string? kindCode { get; set; }


    /// <remarks/>
    public string? uid { get; set; }

    /// <remarks/>

    public string? fundDate { get; set; }

    /// <remarks/>
    public object? overdueExist_0 { get; set; }
    public object? overdueExist_1 { get; set; }

    /// <remarks/>
    public object? stopExist_0 { get; set; }
    public object? stopExist_1 { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? acquirerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType19
{

    /// <remarks/>
    overdueExist_0,

    /// <remarks/>
    overdueExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Item1ChoiceType2
{

    /// <remarks/>
    stopExist_0,

    /// <remarks/>
    stopExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class RejectType
{

    /// <remarks/>

    public string? rejectDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("rejectCode")]
    public List<string>? rejectCode { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class Application
{

    /// <remarks/>
    public string? role { get; set; }

    /// <remarks/>
    public string? sum { get; set; }

    /// <remarks/>
    public string? currency { get; set; }

    /// <remarks/>
    public string? uid { get; set; }

    /// <remarks/>

    public string? applicationDate { get; set; }

    /// <remarks/>
    public string? sourceCode { get; set; }

    /// <remarks/>
    public string? wayCode { get; set; }

    /// <remarks/>

    public string? approvalEndDate { get; set; }

    /// <remarks/>

    public string? stageEndDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("purposeCode")]
    public List<string>? purposeCode { get; set; }

    /// <remarks/>
    public string? stageCode { get; set; }

    /// <remarks/>

    public string? stageDate { get; set; }

    /// <remarks/>
    public string? applicationCode { get; set; }

    /// <remarks/>
    public string? num { get; set; }

    /// <remarks/>
    public string? loanSum { get; set; }
    public string? platformExist_0 { get; set; }
    public string? platformExist_1 { get; set; }
    public string? loanCurrency { get; set; }


    /// <remarks/>
    public RejectType? Reject { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class InformationalPartType
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Application")]
    public List<Application>? Application { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Participation")]
    public List<ParticipationType>? Participation { get; set; }

    [System.Xml.Serialization.XmlElement("ProhibitionsInfo")]
    public ProhibitionsInfo? ProhibitionsInfo { get; set; }
}

public class ProhibitionsInfo
{
    [System.Xml.Serialization.XmlElement("ProhibitionAndLifting")]
    public List<ProhibitionAndLifting>? ProhibitionAndLifting { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("prohibitionNoData")]
    public ProhibitionNoData? ProhibitionNoData { get; set; }
}

public class ProhibitionAndLifting
{
    [System.Xml.Serialization.XmlElementAttribute("ProhibitionInfo")]
    public List<ProhibitionInfo>? ProhibitionInfo { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("ProhibitionLiftingInfo")]
    public List<ProhibitionLiftingInfo>? ProhibitionLiftingInfo { get; set; }
}

public class ProhibitionInfo
{
    [System.Xml.Serialization.XmlElementAttribute("prohibitionApplicationDate")]
    public string? ProhibitionApplicationDate { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("prohibitionApplicationTime")]
    public string? ProhibitionApplicationTime { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("prohibitionDate")]
    public string? ProhibitionDate { get; set; }


    [System.Xml.Serialization.XmlElementAttribute("prohibitionConditions")]
    public List<string>? ProhibitionСonditions { get; set; }
}

public class ProhibitionLiftingInfo
{
    [System.Xml.Serialization.XmlElementAttribute("liftingApplicationDate")]
    public string? LiftingApplicationDate { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("liftingApplicationTime")]
    public string? LiftingApplicationTime { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("liftingDate")]
    public string? LiftingDate { get; set; }
}

public class ProhibitionNoData
{

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class PersonCustomerType
{
    /// <remarks/>
    public string? lastName { get; set; }

    /// <remarks/>
    public string? firstName { get; set; }

    /// <remarks/>
    public string? middleName { get; set; }

    /// <remarks/>
    public string? birthDate { get; set; }

    /// <remarks/>
    public string? birthPlace { get; set; }

    /// <remarks/>
    public string? regNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxNum_group")]
    public List<TaxNumGroupType>? TaxNum_group { get; set; }

    /// <remarks/>
    public string? socialNum { get; set; }

    /// <remarks/>
    public string? docCode { get; set; }

    /// <remarks/>
    public string? docOtherName { get; set; }

    /// <remarks/>
    public string? docSeries { get; set; }

    /// <remarks/>
    public string? docNum { get; set; }

    /// <remarks/>

    public string? issueDate { get; set; }

    /// <remarks/>
    public string? docIssuer { get; set; }

    /// <remarks/>
    public string? deptCode { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class TaxNumGroupType
{

    /// <remarks/>
    public string? taxCode { get; set; }


    /// <remarks/>
    public string? taxNum { get; set; }

    public string? innChecked_1 { get; set; }
    public string? innChecked_0 { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class OrgCustomerType
{
    [XmlAttribute()]
    public string? customerId { get; set; }

    /// <remarks/>
    public string? regRusExist_0 { get; set; }
    public string? regRusExist_1 { get; set; }

    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>
    public string? fullName { get; set; }

    /// <remarks/>
    public string? shortName { get; set; }

    /// <remarks/>
    public string? otherName { get; set; }

    /// <remarks/>
    public string? lei { get; set; }

    /// <remarks/>
    public string? regNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxNum_group")]
    public List<TaxNumGroupType>? TaxNum_group { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType18
{

    /// <remarks/>
    regRusExist_0,

    /// <remarks/>
    regRusExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class RequestGoalGroupType
{

    /// <remarks/>
    public string? requestGoalCode { get; set; }

    /// <remarks/>
    public string? requestOtherGoal { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class RequestType
{

    /// <remarks/>
    public string? requestKindCode { get; set; }

    /// <remarks/>

    public string? responseDate { get; set; }

    /// <remarks/>

    public string? requestDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("requestGoal_group")]
    public List<RequestGoalGroupType>? requestGoal_group { get; set; }

    /// <remarks/>
    public string? requestSum { get; set; }

    /// <remarks/>
    public string? requestCurrency { get; set; }

    /// <remarks/>
    public string? beginDateMonitoringChanging { get; set; }
    public string? monitoringChangingFact_0 { get; set; }
    public string? monitoringChangingFact_1 { get; set; }

    /// <remarks/>
    public OrgCustomerType? OrgCustomer { get; set; }

    public PersonCustomerType? PersonCustomer { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemsChoiceType6
{

    /// <remarks/>
    beginDateMonitoringChanging,

    /// <remarks/>
    monitoringChangingFact_0,

    /// <remarks/>
    monitoringChangingFact_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CollectionType
{

    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>
    public string? courtName { get; set; }
    public string? debtSum { get; set; }
    public string? debtCurrency { get; set; }
    public string? debtBalance { get; set; }

    /// <remarks/>
    public string? actNum { get; set; }

    /// <remarks/>

    public string? actDate { get; set; }

    public string? actResolution { get; set; }

    public string? actResolutionOld { get; set; }

    /// <remarks/>
    public string? execDocNum { get; set; }

    /// <remarks/>

    public string? endDate { get; set; }

    /// <remarks/>
    public string? onceSum { get; set; }
    public string? periodSum { get; set; }


    /// <remarks/>
    public string? totalSum { get; set; }

    /// <remarks/>
    public string? calcDate { get; set; }


    /// <remarks/>
    public string? freqCode { get; set; }


    /// <remarks/>
    public string? currency { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType17
{

    /// <remarks/>
    onceSum,

    /// <remarks/>
    periodSum,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AccountingType
{
    public string? exist_0 { get; set; }
    public string? exist_1 { get; set; }
    public string? sum { get; set; }
    public string? currency { get; set; }
    public string? rate { get; set; }

    /// <remarks/>
    public string? minInterest { get; set; }

    /// <remarks/>
    public string? maxInterest { get; set; }


    /// <remarks/>
    public string? supportExist_0 { get; set; }

    public string? supportExist_1 { get; set; }

    public string? supportInfo { get; set; }

    /// <remarks/>

    public string? calcDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemsChoiceType5
{

    /// <remarks/>
    exist_0,

    /// <remarks/>
    exist_1,

    /// <remarks/>
    sum,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Items1ChoiceType2
{

    /// <remarks/>
    supportExist_0,

    /// <remarks/>
    supportExist_1,

    /// <remarks/>
    supportInfo,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ServiceOrgType
{

    /// <remarks/>
    public string? regRusExist_0 { get; set; }
    public string? regRusExist_1 { get; set; }


    /// <remarks/>
    public string? fullName { get; set; }

    /// <remarks/>
    public string? shortName { get; set; }

    /// <remarks/>
    public string? otherName { get; set; }

    /// <remarks/>
    public string? regNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxNum_group")]
    public List<TaxNumGroupType>? TaxNum_group { get; set; }

    /// <remarks/>

    public string? date { get; set; }

    /// <remarks/>

    public string? endDate { get; set; }

    /// <remarks/>
    public string? issuerName { get; set; }

    /// <remarks/>
    public string? issuerRegNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType16
{

    /// <remarks/>
    regRusExist_0,

    /// <remarks/>
    regRusExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class PersonAcquirerType
{

    /// <remarks/>
    public string? lastName { get; set; }

    /// <remarks/>
    public string? firstName { get; set; }

    /// <remarks/>
    public string? middleName { get; set; }

    /// <remarks/>

    public string? birthDate { get; set; }

    /// <remarks/>
    public string? birthPlace { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxNum_group")]
    public List<TaxNumGroupType>? TaxNum_group { get; set; }

    /// <remarks/>
    public string? socialNum { get; set; }

    /// <remarks/>
    public string? docCode { get; set; }

    /// <remarks/>
    public string? docOtherName { get; set; }

    /// <remarks/>
    public string? docSeries { get; set; }

    /// <remarks/>
    public string? docNum { get; set; }

    /// <remarks/>

    public string? issueDate { get; set; }

    /// <remarks/>
    public string? docIssuer { get; set; }

    /// <remarks/>
    public string? deptCode { get; set; }

    /// <remarks/>

    public string? date { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class OrgAcquirerType
{

    /// <remarks/>
    public string? code { get; set; }


    /// <remarks/>
    public string? regRusExist_0 { get; set; }
    public string? regRusExist_1 { get; set; }


    /// <remarks/>
    public string? fullName { get; set; }

    /// <remarks/>
    public string? shortName { get; set; }

    /// <remarks/>
    public string? otherName { get; set; }

    /// <remarks/>
    public string? lei { get; set; }

    /// <remarks/>
    public string? regNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxNum_group")]
    public List<TaxNumGroupType>? TaxNum_group { get; set; }

    /// <remarks/>

    public string? date { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType15
{

    /// <remarks/>
    regRusExist_0,

    /// <remarks/>
    regRusExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ArbitrationManagerSourceType
{

    /// <remarks/>
    public string? lastName { get; set; }

    /// <remarks/>
    public string? firstName { get; set; }

    /// <remarks/>
    public string? middleName { get; set; }

    /// <remarks/>

    public string? birthDate { get; set; }

    /// <remarks/>
    public string? birthPlace { get; set; }

    /// <remarks/>
    public string? sroName { get; set; }

    /// <remarks/>
    public string? sroAddress { get; set; }

    /// <remarks/>

    public string? acceptDate { get; set; }

    /// <remarks/>

    public string? terminationDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxNum_group")]
    public List<TaxNumGroupType>? TaxNum_group { get; set; }

    /// <remarks/>
    public string? socialNum { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class PersonSourceType
{

    /// <remarks/>
    public string? lastName { get; set; }

    /// <remarks/>
    public string? firstName { get; set; }

    /// <remarks/>
    public string? middleName { get; set; }

    /// <remarks/>

    public string? birthDate { get; set; }

    /// <remarks/>
    public string? birthPlace { get; set; }

    /// <remarks/>
    public string? docCode { get; set; }

    /// <remarks/>
    public string? docOtherName { get; set; }

    /// <remarks/>
    public string? docSeries { get; set; }

    /// <remarks/>
    public string? docNum { get; set; }

    /// <remarks/>

    public string? issueDate { get; set; }

    /// <remarks/>
    public string? docIssuer { get; set; }

    /// <remarks/>
    public string? deptCode { get; set; }

    /// <remarks/>
    public string? regNum { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class OrgSourceType
{
    [XmlAttribute()]
    public string? ownerId { get; set; }
    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>
    public string? regRusExist_0 { get; set; }
    public string? regRusExist_1 { get; set; }

    /// <remarks/>
    public string? fullName { get; set; }

    /// <remarks/>
    public string? shortName { get; set; }

    /// <remarks/>
    public string? otherName { get; set; }

    /// <remarks/>
    public string? lei { get; set; }

    /// <remarks/>

    public string? sourceDateStart { get; set; }

    /// <remarks/>
    public string? regNum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxNum_group")]
    public List<TaxNumGroupType>? TaxNum_group { get; set; }

    /// <remarks/>

    public string? beginDateSourceBankruptcy { get; set; }

    /// <remarks/>

    public string? endDateSourceBankruptcy { get; set; }


    /// <remarks/>

    public string? beginDateSourceLiquidation { get; set; }

    /// <remarks/>

    public string? endDateSourceLiquidation { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType14
{

    /// <remarks/>
    regRusExist_0,

    /// <remarks/>
    regRusExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ConfidentionalPartType
{
    /// <remarks/>
    [XmlElementAttribute("OrgAcquirer")] public OrgAcquirerType? OrgAcquirer { get; set; }

    [XmlElementAttribute("PersonAcquirer")]public PersonAcquirerType? PersonAcquirer { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ServiceOrg")]
    public ServiceOrgType? ServiceOrg { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Accounting")]
    public List<AccountingType>? Accounting { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class StopSendType
{

    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>
    public string? date { get; set; }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(SourceLiquidationType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SourceBankruptcyType
{

    /// <remarks/>
    public string? debtSum { get; set; }

    /// <remarks/>
    public string? startDate { get; set; }
    public string? transferDebtSum { get; set; }
    public string? transferDate { get; set; }

    /// <remarks/>
    public string? debtEndSum { get; set; }

    /// <remarks/>
    public string? endDate { get; set; }

    /// <remarks/>
    public string? debtLastPaySum { get; set; }

    /// <remarks/>
    public string? lastPayDate { get; set; }

    /// <remarks/>
    public string? ownerChangeExist_0 { get; set; }
    public string? ownerChangeExist_1 { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("obligationEndCode")]
    public string? obligationEndCode { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("obligationEndExist_0")]
    public string? obligationEndExist_0 { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("obligationEndExist_1")]
    public string? obligationEndExist_1 { get; set; }

    /// <remarks/>
    public string? currency { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType13
{

    /// <remarks/>
    ownerChangeExist_0,

    /// <remarks/>
    ownerChangeExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemsChoiceType4
{

    /// <remarks/>
    obligationEndCode,

    /// <remarks/>
    obligationEndExist_0,

    /// <remarks/>
    obligationEndExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SourceLiquidationType : SourceBankruptcyType
{
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AvgPaymentType
{

    /// <remarks/>
    public string? sum { get; set; }

    /// <remarks/>
    public string? calcDate { get; set; }

    /// <remarks/>
    public string? currency { get; set; }

    /// <remarks/>
    public string? uid { get; set; }

    /// <remarks/>
    public string? bureauRegNum { get; set; }

    /// <remarks/>
    public string? stopReceiveExist_0 { get; set; }
    public string? stopReceiveExist_1 { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType12
{

    /// <remarks/>
    stopReceiveExist_0,

    /// <remarks/>
    stopReceiveExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CourtType
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("actExist_0")]
    public string? actExist_0 { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("actExist_1")]
    public string? actExist_1 { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("actResolution")]
    public string? actResolution { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("actResolutionOld")]
    public string? actResolutionOld { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("actStartExist_0")]
    public string? actStartExist_0 { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("actStartExist_1")]
    public string? actStartExist_1 { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("date")]
    public string? date { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("info")]
    public string? info { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("lawsuitCode")]
    public string? lawsuitCode { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("num")]
    public string? num { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("sumTotal")]
    public string? sumTotal { get; set; }
    public string? currency { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemsChoiceType3
{

    /// <remarks/>
    actExist_0,

    /// <remarks/>
    actExist_1,

    /// <remarks/>
    actResolution,

    /// <remarks/>
    actStartExist_0,

    /// <remarks/>
    actStartExist_1,

    /// <remarks/>
    date,

    /// <remarks/>
    info,

    /// <remarks/>
    lawsuitCode,

    /// <remarks/>
    num,

    /// <remarks/>
    sumTotal,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ContractEndType
{
    /// <remarks/>
    public string? date { get; set; }

    /// <remarks/>
    public string? code { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class WarrantyReturnType
{
    /// <remarks/>
    public string? sum { get; set; }
    public string? currency { get; set; }

    /// <remarks/>
    public string? paidSum { get; set; }

    /// <remarks/>
    public string? compliance_0 { get; set; }
    public string? compliance_1 { get; set; }

    /// <remarks/>
    public string? calcDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType11
{

    /// <remarks/>
    compliance_0,

    /// <remarks/>
    compliance_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ProvisionPaymentType
{
    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>
    public string? date { get; set; }

    /// <remarks/>
    public string? sum { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ProvisionPaymentOffsetType
{
    /// <remarks/>
    public string? wayCode { get; set; }

    /// <remarks/>
    public string? date { get; set; }

    /// <remarks/>
    public string? sum { get; set; }
    public string? currency { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(GuaranteeType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class WarrantyType
{
    /// <remarks/>
    public string? uid { get; set; }

    /// <remarks/>
    public string? sum { get; set; }

    /// <remarks/>
    public string? currency { get; set; }

    /// <remarks/>
    public string? openDate { get; set; }

    /// <remarks/>
    public string? endDate { get; set; }

    /// <remarks/>
    public string? factEndDate { get; set; }

    /// <remarks/>
    public string? endCode { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GuaranteeType : WarrantyType
{
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class InsuranceType
{

    /// <remarks/>
    public string? franchiseExist_0 { get; set; }

    public string? franchiseExist_1 { get; set; }

    /// <remarks/>
    public string? startDate { get; set; }

    /// <remarks/>
    public string? insuranceEndDate { get; set; }

    /// <remarks/>
    public string? insuranceFactEndDate { get; set; }

    /// <remarks/>
    public string? endCode { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType10
{

    /// <remarks/>
    franchiseExist_0,

    /// <remarks/>
    franchiseExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CollateralType
{

    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>
    public string? date { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("SumGroup")]
    public List<SumGroupType>? SumGroup { get; set; }

    /// <remarks/>
    public string? collateralEndDate { get; set; }

    /// <remarks/>
    public string? collateralFactEndDate { get; set; }

    /// <remarks/>
    public string? endReason { get; set; }

    /// <remarks/>
    public string? contractTotalSum { get; set; }

    /// <remarks/>
    public string? contractCount { get; set; }

    /// <remarks/>
    public string? location { get; set; }

    /// <remarks/>
    public string? actualCost { get; set; }

    /// <remarks/>
    public string? calcDate { get; set; }

}

public partial class SumGroupType
{
    public string? sum { get; set; }

    public string? currency { get; set; }

    public string? assessDate { get; set; }

    public string? priceCode { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CollateralGroupType
{

    /// <remarks/>
    public string? propertyId { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Collateral")]
    public CollateralType? Collateral { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Insurance")]
    public List<InsuranceType>? Insurance { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class NonMonetarySubjectType
{

    /// <remarks/>
    public string? item { get; set; }

    /// <remarks/>
    public string? fulfillment { get; set; }

    /// <remarks/>
    public object? fulfillmentFailExist_0 { get; set; }
    public object? fulfillmentFailExist_1 { get; set; }

    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType9
{

    /// <remarks/>
    fulfillmentFailExist_0,

    /// <remarks/>
    fulfillmentFailExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class NonMonetarySourceType
{

    /// <remarks/>
    public string? item { get; set; }

    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>

    public string? date { get; set; }


    /// <remarks/>
    public string? propertyId { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class DebtBurdenInfoType
{

    /// <remarks/>
    public string? loadRange { get; set; }

    /// <remarks/>

    public string? loadCalcDate { get; set; }


    /// <remarks/>
    public string? incomeInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("incomeInfoSource")]
    public List<string?>? incomeInfoSource { get; set; }

    /// <remarks/>
    public string? loadFact_0 { get; set; }
    public string? loadFact_1 { get; set; }

    /// <remarks/>
    public string? loadCalculationFact_0 { get; set; }
    public string? loadCalculationFact_1 { get; set; }

    /// <remarks/>
    public string? dealUid { get; set; }

    public string? ownerId { get; set; }

    public string? actualityDate { get; set; }

    public string? creationDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType8
{

    /// <remarks/>
    loadFact_0,

    /// <remarks/>
    loadFact_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Item1ChoiceType1
{

    /// <remarks/>
    loadCalculationFact_0,

    /// <remarks/>
    loadCalculationFact_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class MonthlyPaymentType
{
    /// <remarks/>
    public string? sum { get; set; }

    /// <remarks/>

    public string? calcDate { get; set; }


    /// <remarks/>
    public string? sumTotal { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class PaymentType
{
    /// <remarks/>
    public string? calcDate { get; set; }

    /// <remarks/>
    public string? paymentSum { get; set; }
    public string? payCurrency { get; set; }

    /// <remarks/>
    public string? paymentMainSum { get; set; }

    /// <remarks/>
    public string? paymentPercentSum { get; set; }

    /// <remarks/>
    public string? paymentOtherSum { get; set; }

    /// <remarks/>
    public string? totalSum { get; set; }

    /// <remarks/>
    public string? totalMainSum { get; set; }

    /// <remarks/>
    public string? totalPercentSum { get; set; }

    /// <remarks/>
    public string? totalOtherSum { get; set; }

    /// <remarks/>
    public string? date { get; set; }

    /// <remarks/>
    public string? sizeCode { get; set; }

    /// <remarks/>
    public string? scheduleCode { get; set; }

    /// <remarks/>
    public string? lastMissPaySum { get; set; }

    /// <remarks/>
    public string? paySum24 { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class DebtOverdueType
{

    /// <remarks/>
    public string? debtOverdueSum { get; set; }


    /// <remarks/>
    public string? debtOverdueMainSum { get; set; }

    /// <remarks/>
    public string? debtOverduePercentSum { get; set; }

    /// <remarks/>
    public string? debtOverdueOtherSum { get; set; }

    /// <remarks/>
    public string? debtOverdueStartDate { get; set; }

    /// <remarks/>
    public string? mainMissDate { get; set; }

    /// <remarks/>
    public string? percentMissDate { get; set; }

    /// <remarks/>
    public string? missDuration { get; set; }

    /// <remarks/>
    public string? repaidMissDuration { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class DebtDueType
{
    /// <remarks/>
    public string? debtDueSum { get; set; }

    /// <remarks/>
    public string? debtDueMainSum { get; set; }

    /// <remarks/>
    public string? debtDuePercentSum { get; set; }

    /// <remarks/>
    public string? debtDueOtherSum { get; set; }

    /// <remarks/>
    public string? debtDueStartDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class DebtType
{
    /// <remarks/>
    public string? debtSum { get; set; }
    public string? currency { get; set; }

    /// <remarks/>
    public string? debtMainSum { get; set; }

    /// <remarks/>
    public string? debtPercentSum { get; set; }

    /// <remarks/>
    public string? debtOtherSum { get; set; }

    /// <remarks/>
    public string? graceUnconfExist_0 { get; set; }

    public string? graceUnconfExist_1 { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType7
{
    /// <remarks/>
    graceUnconfExist_0,

    /// <remarks/>
    graceUnconfExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class DebtGroupType
{

    /// <remarks/>
    public string? lastPayExist_0 { get; set; }
    public string? lastPayExist_1 { get; set; }

    /// <remarks/>
    public string? calcDate { get; set; }

    /// <remarks/>
    public DebtType? Debt { get; set; }

    /// <remarks/>
    public DebtDueType? DebtDue { get; set; }

    /// <remarks/>
    public DebtOverdueType? DebtOverdue { get; set; }

    public PaymentType? Payment { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType6
{

    /// <remarks/>
    lastPayExist_0,

    /// <remarks/>
    lastPayExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class FundType
{

    /// <remarks/>

    public string? date { get; set; }


    /// <remarks/>
    public string? num { get; set; }

    /// <remarks/>
    public string? startSum { get; set; }
    public string? currency { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ContractTermsChangesType
{

    /// <remarks/>
    public string? termsChangeCode { get; set; }


    /// <remarks/>
    public string? termsChangeDesc { get; set; }

    /// <remarks/>

    public string? changingDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ContractChangesType
{

    /// <remarks/>

    public string? changeDate { get; set; }

    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>
    public string? specialCode { get; set; }

    /// <remarks/>
    public string? otherDesc { get; set; }

    /// <remarks/>
    public string? startDate { get; set; }


    /// <remarks/>
    public string? endDate { get; set; }

    /// <remarks/>
    public string? actualEndDate { get; set; }


    /// <remarks/>
    public string? endCode { get; set; }

    /// <remarks/>
    public string? currencyRate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class TotalCostType
{
    /// <remarks/>
    public string? minPercentCost { get; set; }

    /// <remarks/>
    public string? minCost { get; set; }

    /// <remarks/>
    public string? calcDate { get; set; }

    /// <remarks/>
    public string? maxPercentCost { get; set; }

    /// <remarks/>
    public string? maxCost { get; set; }

    /// <remarks/>
    public string? maxPercentCash { get; set; }

    /// <remarks/>
    public string? maxPercentCashless { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class PaymentTermsType
{
    /// <remarks/>
    public string? mainPaySum { get; set; }

    /// <remarks/>
    public string? mainPayDate { get; set; }

    /// <remarks/>
    public string? percentPaySum { get; set; }

    /// <remarks/>
    public string? percentPayDate { get; set; }

    /// <remarks/>
    public string? freqCode { get; set; }

    /// <remarks/>
    public string? minCardPay { get; set; }

    public string? minPay { get; set; }

    /// <remarks/>
    public string? graceDate { get; set; }

    /// <remarks/>
    public string? graceEndDate { get; set; }

    /// <remarks/>
    public string? percentEndDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class JointDebtorsType
{
    /// <remarks/>
    public string? num { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AmountInfoType
{
    /// <remarks/>
    public string? securitySum { get; set; }

    /// <remarks/>
    public string? securityCurrency { get; set; }

    /// <remarks/>
    public string? securityTypeCode { get; set; }

    /// <remarks/>
    public string? calcDate { get; set; }

    /// <remarks/>
    public string? securityUid { get; set; }

    /// <remarks/>
    public string? liabilityLimit { get; set; }
    public string? limitCurrency { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AmountType
{
    /// <remarks/>
    public string? sum { get; set; }

    /// <remarks/>
    public string? currency { get; set; }

    /// <remarks/>
    public string? calcDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class DealType
{

    /// <remarks/>
    public string? role { get; set; }

    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>
    public string? kindCode { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("purposeCode")]
    public List<string>? purposeCode { get; set; }

    /// <remarks/>
    public string? consumerExist_0 { get; set; }
    public string? consumerExist_1 { get; set; }

    /// <remarks/>
    public string? cardExist_0 { get; set; }
    public string? cardExist_1 { get; set; }


    /// <remarks/>
    public string? novationExist_0 { get; set; }
    public string? novationExist_1 { get; set; }


    /// <remarks/>
    public string? monetarySourceExist_0 { get; set; }
    public string? monetarySourceExist_1 { get; set; }


    public string? monetarySubjectExist_0 { get; set; }
    public string? monetarySubjectExist_1 { get; set; }

    /// <remarks/>

    public string? endDate { get; set; }


    /// <remarks/>
    public string? creditorCode { get; set; }




    public string? partialExist_0 { get; set; }
    public string? partialExist_1 { get; set; }

    public string? transferUid { get; set; }




    public string? creditLineExist_0 { get; set; }
    public string? creditLineExist_1 { get; set; }
    /// <remarks/>
    public string? creditLineCode { get; set; }


    /// <remarks/>
    public string? floatRateExist_0 { get; set; }
    public string? floatRateExist_1 { get; set; }

    /// <remarks/>
    public string? partialTransferExist_0 { get; set; }
    public string? partialTransferExist_1 { get; set; }

    /// <remarks/>
    public string? startDate { get; set; }


    /// <remarks/>
    public string? repaymentFact_0 { get; set; }
    public string? repaymentFact_1 { get; set; }

    /// <remarks/>
    public string? transferFact_0 { get; set; }
    public string? transferFact_1 { get; set; }

    [XmlElementAttribute("installmentCode")] public List<string>? installmentCode { get; set; }

    /// <remarks/>
    public string? partnerFinancingFact_0 { get; set; }
    public string? partnerFinancingFact_1 { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType5
{

    /// <remarks/>
    consumerExist_0,

    /// <remarks/>
    consumerExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Item1ChoiceType
{

    /// <remarks/>
    cardExist_0,

    /// <remarks/>
    cardExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Item2ChoiceType
{

    /// <remarks/>
    novationExist_0,

    /// <remarks/>
    novationExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Item3ChoiceType
{

    /// <remarks/>
    monetarySourceExist_0,

    /// <remarks/>
    monetarySourceExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemsChoiceType2
{

    /// <remarks/>
    partialExist_0,

    /// <remarks/>
    partialExist_1,

    /// <remarks/>
    transferUid,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Items1ChoiceType1
{

    /// <remarks/>
    creditLineCode,

    /// <remarks/>
    creditLineExist_0,

    /// <remarks/>
    creditLineExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Item4ChoiceType
{

    /// <remarks/>
    floatRateExist_0,

    /// <remarks/>
    floatRateExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Item5ChoiceType
{

    /// <remarks/>
    partialTransferExist_0,

    /// <remarks/>
    partialTransferExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Item6ChoiceType
{

    /// <remarks/>
    repaymentFact_0,

    /// <remarks/>
    repaymentFact_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Item7ChoiceType
{

    /// <remarks/>
    transferFact_0,

    /// <remarks/>
    transferFact_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Item8ChoiceType
{

    /// <remarks/>
    partnerFinancingFact_0,

    /// <remarks/>
    partnerFinancingFact_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class DealUidType
{

    /// <remarks/>
    public string? uid { get; set; }

    /// <remarks/>
    public string? num { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("refUid")]
    public List<string>? refUid { get; set; }

    /// <remarks/>
    public string? openDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CreditRecordType
{

    /// <remarks/>
    public DealUidType? DealUid { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Deal")]
    public List<DealType>? Deal { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Amount")]
    public List<AmountType>? Amount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AmountInfo")]
    public List<AmountInfoType>? AmountInfo { get; set; }

    /// <remarks/>
    public JointDebtorsType? JointDebtors { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("PaymentTerms")]
    public List<PaymentTermsType>? PaymentTerms { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TotalCost")]
    public List<TotalCostType>? TotalCost { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ContractChanges")]
    public List<ContractChangesType>? ContractChanges { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ContractTermsChanges")]
    public List<ContractTermsChangesType>? ContractTermsChanges { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Fund")]
    public List<FundType>? Fund { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Debt_group")]
    public List<DebtGroupType>? Debt_group { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("MonthlyPayment")]
    public List<MonthlyPaymentType>? MonthlyPayment { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NonMonetarySource")]
    public List<NonMonetarySourceType>? NonMonetarySource { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NonMonetarySubject")]
    public List<NonMonetarySubjectType>? NonMonetarySubject { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Collateral_group")]
    public List<CollateralGroupType>? Collateral_group { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Warranty")]
    public List<WarrantyType>? Warranty { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Guarantee")]
    public List<GuaranteeType>? Guarantee { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ProvisionPayment")]
    public List<ProvisionPaymentType>? ProvisionPayment { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ProvisionPaymentOffset")]
    public List<ProvisionPaymentOffsetType>? ProvisionPaymentOffset { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("WarrantyReturn")]
    public List<WarrantyReturnType>? WarrantyReturn { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ContractEnd")]
    public List<ContractEndType>? ContractEnd { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Court")]
    public List<CourtType>? Court { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AvgPayment")]
    public List<AvgPaymentType>? AvgPayment { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SourceBankruptcy")]
    public List<SourceBankruptcyType>? SourceBankruptcy { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SourceLiquidation")]
    public List<SourceLiquidationType>? SourceLiquidation { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("StopSend")]
    public List<StopSendType>? StopSend { get; set; }

    /// <remarks/>
    public ConfidentionalPartType? ConfidentionalPart { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? acquirerId { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? serviceOrganizationId { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? lastUpdateInfoDate { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class FactorCodeGroupType
{
    /// <remarks/>
    public string? factorCode { get; set; }

    /// <remarks/>
    public string? factorPortion { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class IndividualBorrowerRatingType
{
    /// <remarks/>
    public string? ratingValue { get; set; }

    /// <remarks/>
    public string? calcDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("FactorCode_group")]
    public List<FactorCodeGroupType>? FactorCode_group { get; set; }

    /// <remarks/>
    public string? causeCode { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("otherCause")]
    public List<string>? otherCause { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class BankruptcyEndType
{
    [System.Xml.Serialization.XmlElementAttribute("bankruptcyEndFact_0")]
    public string? bankruptcyEndFact_0 { get; set; }
    [System.Xml.Serialization.XmlElementAttribute("resumeDate")]
    public string? resumeDate { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("bankruptcyEndFact_1")]
    public string? bankruptcyEndFact_1 { get; set; }
    [System.Xml.Serialization.XmlElementAttribute("completionDate")]
    public string? completionDate { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("settlementExist_0")]
    public string? settlementExist_0 { get; set; }
    [System.Xml.Serialization.XmlElementAttribute("settlementExist_1")]
    public string? settlementExist_1 { get; set; }
    [System.Xml.Serialization.XmlElementAttribute("settlementDate")]
    public string? settlementDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemsChoiceType1
{

    /// <remarks/>
    bankruptcyEndFact_0,

    /// <remarks/>
    bankruptcyEndFact_1,

    /// <remarks/>
    completionDate,

    /// <remarks/>
    resumeDate,

    /// <remarks/>
    settlementDate,

    /// <remarks/>
    settlementExist_0,

    /// <remarks/>
    settlementExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class DateGroupType
{

    /// <remarks/>
    public string? date { get; set; }

    /// <remarks/>
    public string? stage { get; set; }

    /// <remarks/>
    public string? link { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class BankruptcyType
{
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Date_group")]
    public List<DateGroupType>? Date_group { get; set; }


    [System.Xml.Serialization.XmlElementAttribute("illegalActExist_0")]
    public string? illegalActExist_0 { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("illegalActExist_1")]
    public string? illegalActExist_1 { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("illegalActDate")]
    public string? illegalActDate { get; set; }


    [System.Xml.Serialization.XmlElementAttribute("fakeActExist_0")]
    public string? fakeActExist_0 { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("fakeActExist_1")]
    public string? fakeActExist_1 { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("fakeActDate")]
    public string? fakeActDate { get; set; }

    /// <remarks/>
    public string? date { get; set; }

    /// <remarks/>
    public string? stage { get; set; }

    /// <remarks/>
    public string? link { get; set; }

    /// <remarks/>
    public string? info { get; set; }
    public string? num { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemsChoiceType
{
    /// <remarks/>
    illegalActDate,

    /// <remarks/>
    illegalActExist_0,

    /// <remarks/>
    illegalActExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum Items1ChoiceType
{

    /// <remarks/>
    fakeActDate,

    /// <remarks/>
    fakeActExist_0,

    /// <remarks/>
    fakeActExist_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class LegalCapacityGroupType
{
    /// <remarks/>
    public string? legalCapacityDate { get; set; }

    /// <remarks/>
    public string? legalCapacityDecisionNum { get; set; }

    /// <remarks/>
    public string? legalCapacityCourtName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class IncapacityGroupType
{

    /// <remarks/>

    public string? incapacityDate { get; set; }


    /// <remarks/>
    public string? incapacityDecisionNum { get; set; }

    /// <remarks/>
    public string? incapacityCourtName { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CapacityType
{

    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>
    public IncapacityGroupType? Incapacity_group { get; set; }
    public LegalCapacityGroupType? LegalCapacity_group { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class IndividualEntrepreneurType
{

    /// <remarks/>
    public string? regNum { get; set; }

    /// <remarks/>

    public string? date { get; set; }

    public string? endDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ContactType
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Phone_group")]
    public List<PhoneGroupType>? Phone_group { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("email")]
    public List<string>? email { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class PhoneGroupType
{

    /// <remarks/>
    public string? phone { get; set; }

    /// <remarks/>
    public string? phoneComment { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AddrFactType
{

    /// <remarks/>
    public string? postCode { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute()]
    public string? countryCode { get; set; }

    /// <remarks/>
    public string? countryOther { get; set; }

    /// <remarks/>
    public string? regStateNum { get; set; }

    /// <remarks/>
    public string? locationCode { get; set; }

    /// <remarks/>
    public string? locationOther { get; set; }

    /// <remarks/>
    public string? street { get; set; }

    /// <remarks/>
    public string? house { get; set; }

    /// <remarks/>
    public string? estate { get; set; }

    /// <remarks/>
    public string? block { get; set; }

    /// <remarks/>
    public string? build { get; set; }

    /// <remarks/>
    public string? apart { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AddrRegType
{

    /// <remarks/>
    public string? code { get; set; }

    /// <remarks/>
    public string? postCode { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute()]
    public string? countryCode { get; set; }

    /// <remarks/>
    public string? countryOther { get; set; }

    /// <remarks/>
    public string? regStateNum { get; set; }

    /// <remarks/>
    public string? locationCode { get; set; }

    /// <remarks/>
    public string? locationOther { get; set; }

    /// <remarks/>
    public string? street { get; set; }

    /// <remarks/>
    public string? house { get; set; }

    /// <remarks/>
    public string? estate { get; set; }

    /// <remarks/>
    public string? block { get; set; }

    /// <remarks/>
    public string? build { get; set; }

    /// <remarks/>
    public string? apart { get; set; }

    /// <remarks/>

    public string? date { get; set; }

    /// <remarks/>
    public string? dept { get; set; }

    /// <remarks/>
    public string? deptCode { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class MainPartType
{
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AddrReg")]
    public List<AddrRegType>? AddrReg { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AddrFact")]
    public List<AddrFactType>? AddrFact { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AddrOld")]
    public List<AddrOldType>? AddrOld { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Contact")]
    public List<ContactType>? Contact { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("IndividualEntrepreneur")]
    public List<IndividualEntrepreneurType>? IndividualEntrepreneur { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Capacity")]
    public List<CapacityType>? Capacity { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Bankruptcy")]
    public List<BankruptcyType>? Bankruptcy { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("BankruptcyEnd")]
    public List<BankruptcyEndType>? BankruptcyEnd { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("IndividualBorrowerRating")]
    public List<IndividualBorrowerRatingType>? IndividualBorrowerRating { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("DebtBurdenInfo")]
    public List<DebtBurdenInfoType>? DebtBurdenInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CreditRecord")]
    public List<CreditRecordType>? CreditRecord { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Collection")]
    public List<CollectionType>? Collection { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AddrOldType
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute()]
    public string? addressCode { get; set; }

    /// <remarks/>
    public string? address { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class UL_ReorgType
{

    /// <remarks/>
    public string? fullName { get; set; }

    /// <remarks/>
    public string? shortName { get; set; }

    /// <remarks/>
    public string? regNum { get; set; }

    /// <remarks/>

    public string? date { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }



    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class UL_TaxType
{

    /// <remarks/>
    public TaxNumGroupType? TaxNum_group { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class UL_RegType
{

    /// <remarks/>
    public string? regNum { get; set; }

    /// <remarks/>
    public string? lei { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class UL_AddressType
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute()]
    public string? countryCode { get; set; }

    /// <remarks/>
    public string? countryOther { get; set; }

    /// <remarks/>
    public string? regStateNum { get; set; }

    /// <remarks/>
    public string? locationCode { get; set; }

    /// <remarks/>
    public string? locationOther { get; set; }

    /// <remarks/>
    public string? street { get; set; }

    /// <remarks/>
    public string? house { get; set; }

    /// <remarks/>
    public string? estate { get; set; }

    /// <remarks/>
    public string? block { get; set; }

    /// <remarks/>
    public string? build { get; set; }

    /// <remarks/>
    public string? apart { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Phone_group")]
    public List<PhoneGroupType>? Phone_group { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("email")]
    public List<string>? email { get; set; }

    /// <remarks/>
    public string? foreignerFact_0 { get; set; }
    public string? foreignerFact_1 { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType4
{

    /// <remarks/>
    foreignerFact_0,

    /// <remarks/>
    foreignerFact_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class UL_NameType
{

    /// <remarks/>
    public string? fullName { get; set; }

    /// <remarks/>
    public string? shortName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("otherName")]
    public List<string>? otherName { get; set; }

    /// <remarks/>
    public List<string>? prevFull { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class UL_TitlePartType
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UL_Name")]
    public List<UL_NameType>? UL_Name { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UL_Address")]
    public List<UL_AddressType>? UL_Address { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UL_AddressOld")]
    public List<AddrOldType>? UL_AddressOld { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UL_Reg")]
    public List<UL_RegType>? UL_Reg { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UL_Tax")]
    public List<UL_TaxType>? UL_Tax { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("UL_Reorg")]
    public List<UL_ReorgType>? UL_Reorg { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class FL_TaxType
{
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("TaxNum_group")]
    public List<TaxNumGroupType>? TaxNum_group { get; set; }

    /// <remarks/>
    public string? regNum { get; set; }

    public string? innChecked_1 { get; set; }
    public string? innChecked_0 { get; set; }

    /// <remarks/>
    public string? specialMode_0 { get; set; }
    public string? specialMode_1 { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
public enum ItemChoiceType22
{

    /// <remarks/>
    specialMode_0,

    /// <remarks/>
    specialMode_1,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class FL_PrevDocType
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute()]
    public string? countryCode { get; set; }

    /// <remarks/>
    public string? countryOther { get; set; }

    /// <remarks/>
    public string? docCode { get; set; }

    /// <remarks/>
    public string? docOtherName { get; set; }

    /// <remarks/>
    public string? docSeries { get; set; }

    /// <remarks/>
    public string? docNum { get; set; }

    /// <remarks/>

    public string? issueDate { get; set; }


    /// <remarks/>
    public string? docIssuer { get; set; }

    /// <remarks/>
    public string? deptCode { get; set; }

    /// <remarks/>

    public string? endDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class FL_DocType
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute()]
    public string? countryCode { get; set; }

    /// <remarks/>
    public string? countryOther { get; set; }

    /// <remarks/>
    public string? docCode { get; set; }

    /// <remarks/>
    public string? docOtherName { get; set; }

    /// <remarks/>
    public string? docSeries { get; set; }

    /// <remarks/>
    public string? docNum { get; set; }

    /// <remarks/>

    public string? issueDate { get; set; }


    /// <remarks/>
    public string? docIssuer { get; set; }

    /// <remarks/>
    public string? deptCode { get; set; }

    /// <remarks/>

    public string? endDate { get; set; }


    /// <remarks/>
    public string? foreignerCode { get; set; }

    /// <remarks/>
    [XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class FL_BirthType
{

    /// <remarks/>

    public string? birthDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute()]
    public string? countryCode { get; set; }

    /// <remarks/>

    public string? birthPlace { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(FL_PrevNameType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class FL_NameType
{

    /// <remarks/>
    public string? lastName { get; set; }

    /// <remarks/>
    public string? firstName { get; set; }

    /// <remarks/>
    public string? middleName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? actualityDate { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? creationDate { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class FL_PrevNameType : FL_NameType
{

    /// <remarks/>

    public string? date { get; set; }

}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class FL_TitlePartType
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("FL_Name")]
    public List<FL_NameType>? FL_Name { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("FL_PrevName")]
    public List<FL_PrevNameType>? FL_PrevName { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("FL_Birth")]
    public List<FL_BirthType>? FL_Birth { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("FL_Doc")]
    public List<FL_DocType>? FL_Doc { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("FL_PrevDoc")]
    public List<FL_PrevDocType>? FL_PrevDoc { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("FL_Tax")]
    public List<FL_TaxType>? FL_Tax { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("FL_Social")]
    public List<FL_SocialType>? FL_Social { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class TitlePartType
{

    /// <remarks/>
    public FL_TitlePartType? FL_TitlePart { get; set; }
    public UL_TitlePartType? UL_TitlePart { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlRootAttribute("Report", Namespace = "")]
public partial class tCReport
{

    /// <remarks/>
    public TitlePartType? TitlePart { get; set; }

    /// <remarks/>
    public MainPartType? MainPart { get; set; }

    public AdditionalPartType? AdditionalPart { get; set; }

    /// <remarks/>
    public InformationalPartType? InformationalPart { get; set; }

    public SourcesInfoTypeSource? SourcesInfo { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AdditionalPartType
{
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RequestInfo")]
    public List<RequestType>? RequestInfo { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ArbitrationManagerSource")]
    public ArbitrationManagerSourceType? ArbitrationManagerSource { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("OrgSource")]
    public List<OrgSourceType>? OrgSource { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("PersonSource")]
    public PersonSourceType? PersonSource { get; set; }


}



public partial class SourcesInfoTypeSource
{
    [System.Xml.Serialization.XmlElementAttribute("Source")]
    public List<Source>? Source { get; set; }
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class Source
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ownerId { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool ownership { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? sourceCode { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class tResponseBODY
{

    /// <remarks/>
    public tCReport? Report { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Error")]
    public List<tWarning>? Error { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Warning")]
    public List<tWarning>? Warning { get; set; }
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tRequestAttributesReason
{

    /// <remarks/>
    public tReference? SalesChannel { get; set; }

    /// <remarks/>
    public tReference? ApplicationType { get; set; }

    /// <remarks/>
    public tReference? ApplicationOrigin { get; set; }

    /// <remarks/>
    public tRequestAttributesReasonApplicationCollateral? ApplicationCollateral { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal CustomerClaimCreditLimit { get; set; }


    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal MontlyPaymentAmount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? CurrencyID { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? CurrencyCaption { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? ID { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? Text { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tRequestAttributesReasonApplicationCollateral
{

    /// <remarks/>
    public tRequestAttributesReasonApplicationCollateralIncome? Income { get; set; }

    /// <remarks/>
    public tRequestAttributesReasonApplicationCollateralProperty? Property { get; set; }

    /// <remarks/>
    public tRequestAttributesReasonApplicationCollateralWorkExperience? WorkExperience { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tRequestAttributesReasonApplicationCollateralIncome
{

    /// <remarks/>
    public tReference? Period { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ConfirmationDocument")]
    public List<tReference>? ConfirmationDocument { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Amount { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? CurrencyID { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tRequestAttributesReasonApplicationCollateralProperty
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Car")]
    public List<tRequestAttributesReasonApplicationCollateralPropertyCar>? Car { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Realty")]
    public List<tRequestAttributesReasonApplicationCollateralPropertyRealty>? Realty { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tRequestAttributesReasonApplicationCollateralPropertyCar
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ConfirmationDocument")]
    public List<tReference>? ConfirmationDocument { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? BrandAndModel { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? CreationYear { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? VIN { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? RegistrationNumber { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tRequestAttributesReasonApplicationCollateralPropertyRealty
{

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ConfirmationDocument")]
    public List<tReference>? ConfirmationDocument { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? type { get; set; }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? description { get; set; }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class tRequestAttributesReasonApplicationCollateralWorkExperience
{

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string? NumberOfYears { get; set; }
}
