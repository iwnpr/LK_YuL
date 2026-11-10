namespace user_interface_private_web.Pages.Requests.RequestOfBureau;

public interface IBureauRequestModelFactory
{
    BureauRequestModel Create(bool isNaturalPerson);
}

internal sealed class BureauRequestModelFactory : IBureauRequestModelFactory
{
    public BureauRequestModel Create(bool isNaturalPerson)
    {
        return new BureauRequestModel
        {
            Consent = new ConsentModel
            {
                IssueDate = DateTime.Now.ToShortDateString(),
                ExpiryDate = DateTime.Now.AddMonths(6).ToShortDateString()
            },
            NaturalPerson = isNaturalPerson ? new NaturalPersonModel() : null,
            LegalPerson = isNaturalPerson ? null : new LegalPersonModel()
        };
    }
}
