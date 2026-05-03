using Dagemov.Domain.Enums;
using Dagemov.Domain.Interfaces;
using Dagemov.Domain.ValueObjects;

namespace Dagemov.Domain.Entities;

public class Company : IAuditableEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty!;
    public string LegalName { get; private set; } = string.Empty!;

    public string? Description { get; private set; } = string.Empty!;
    public CompanyMemberShipStatus CompanyMemberShipStatus { get; private set; }

    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }
    public string? ModifiedByUser { get; private set; }

    protected Company()
    {
        
    }
    public Company(
        Guid id,
        string name,
        string legalName,
        string description,
        CompanyMemberShipStatus companyMemberShipStatus,
        DateTime createdDate,
        string userName
        )
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
    public void UpdateName(string newName,string username)
    {
        ValidationStrings(newName , nameof(Name));
        Name = newName;
    }
    public void UpdateDescription(string newDescription,string username)
    {
        ValidationStrings(newDescription, nameof(Description));
        Description = newDescription;

    }

    public void MarkCreated(DateTime date, string userName)
    {
        ValidateAuditDate(date);
        ValidateAuditUser(userName);

        CreatedDate = date;
        UpdatedDate = date;
        ModifiedByUser = userName;
    }

    public void MarkUpdated(DateTime date, string userName)
    {
        ValidateAuditDate(date);
        ValidateAuditUser(userName);

        UpdatedDate = date;
        ModifiedByUser = userName;
    }
    private static void ValidateAuditDate(DateTime date)
    {
        if (date == default)
            throw new ArgumentException("Audit date cannot be default.");
    }

    private static void ValidateAuditUser(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("Audit user is required.");

        if (userName.Length > 150)
            throw new ArgumentException("Audit user cannot exceed 150 characters.");
    }
}
