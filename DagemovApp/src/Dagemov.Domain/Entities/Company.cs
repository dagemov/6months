namespace Dagemov.Domain.Entities;

public class Company
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty!;
    public string LegalName { get; private set; } = string.Empty!;

    public string? Description { get; private set; } = string.Empty!;
    public DateTime CreatedDate { get; private set; } 
    public DateTime UpdatedDate { get; private set; }
    public string? ModifideByUser { get; set; } = string.Empty!; //Coger el usuario que modifico la entidad (auditoria)

    protected Company()
    {
        
    }
    public Company(Guid id,string name,string legalName,string description)
    {
        if (id == Guid.Empty) throw new ArgumentException($"Id is no valid to save the record : {0}");
        ValidationStrings(name);
        ValidationStrings(legalName);
        
        this.Id = id;
        this.Name = name;
        this.LegalName = legalName;
        this.Description = description;
        CreatedDate = DateTime.UtcNow;

        UpdatedDate = DateTime.UtcNow;
    }
    //Validation rules to the string fiels 
    private static void ValidationStrings(string x)
    {
        if (string.IsNullOrEmpty(x) || string.IsNullOrWhiteSpace(x)) throw new ArgumentException("The field {0} is null or empty , ples write at valid field  ");
        if (x.Length < 3 || x.Length>250 ) throw new ArgumentException("The filed  must contain min 3 or more caracters . max 250");
    }
    public void UpdateName(string newName)
    {
        ValidationStrings(newName);
        Name = newName;
        UpdatedDate = DateTime.UtcNow;
    }
    public void UpdateDescription(string newDescription)
    {
        ValidationStrings(newDescription);
        Description = newDescription;
        UpdatedDate = DateTime.UtcNow;
    }

    
}
