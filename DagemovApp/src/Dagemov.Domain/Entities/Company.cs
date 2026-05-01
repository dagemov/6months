using Dagemov.Domain.Enums;

namespace Dagemov.Domain.Entities;

public class Company
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty!;
    public string LegalName { get; private set; } = string.Empty!;

    public string? Description { get; private set; } = string.Empty!;
    public CompanyMemberShipStatus CompanyMemberShipStatus { get; private set; }
    public DateTime CreatedDate { get; private set; } 
    public DateTime UpdatedDate { get; private set; }
    public string? ModifideByUser { get; set; } = string.Empty!; //Coger el usuario que modifico la entidad (auditoria)

    protected Company()
    {
        
    }
    public Company(
        Guid id,
        string name,
        string legalName,
        string description,
        CompanyMemberShipStatus companyMemberShipStatus)
    {
        if (id == Guid.Empty) throw new ArgumentException($"Id is no valid to save the record : {0}");
        ValidationStrings(name,nameof( Name));
        ValidationStrings(legalName, nameof(legalName));
        ValidationCompanyStatus(companyMemberShipStatus, nameof(CompanyMemberShipStatus));
        this.Id = id;
        this.Name = name;
        this.LegalName = legalName;
        this.Description = description;
        CompanyMemberShipStatus = companyMemberShipStatus;
        CreatedDate = DateTime.UtcNow;

        UpdatedDate = DateTime.UtcNow;
    }
    //Validation rules to the string fiels 
    private static void ValidationStrings(string x,string fieldName)
    {
        if (string.IsNullOrEmpty(x) || string.IsNullOrWhiteSpace(x)) throw new ArgumentException($"The field {fieldName} is required  ");
        if (x.Length < 3 || x.Length>250 ) throw new ArgumentException($"The filed {fieldName}  must contain  between in 3 at 250 characters");
    }
    private static void ValidationCompanyStatus(CompanyMemberShipStatus choice, string fieldName)
    {
        if (!Enum.IsDefined(choice))
        {
            throw new ArgumentException($"The field {fieldName} is invalid, please select a valid choice.");
        }
    }
    public void UpdateName(string newName)
    {
        ValidationStrings(newName , nameof(Name));
        Name = newName;
        UpdatedDate = DateTime.UtcNow;
    }
    public void UpdateDescription(string newDescription)
    {
        ValidationStrings(newDescription, nameof(Description));
        Description = newDescription;
        UpdatedDate = DateTime.UtcNow;
    }

    
}
