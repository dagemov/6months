using Dagemov.Domain.Interfaces;

namespace Dagemov.Domain.ValueObjects;

public abstract class AbstracAuditTable : IAuditableEntity
{
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }
    public string? ModifiedByUser { get; private set; }
    protected AbstracAuditTable()
    {
        
    }
    public void MarkCreated(DateTime date, string userName)
    {
        ValidateDate(date);
        ValidateUser(userName);

        CreatedDate = date;
        UpdatedDate = date;
        ModifiedByUser = userName;
    }

    public void MarkUpdated(DateTime date, string userName)
    {
        ValidateDate(date);
        ValidateUser(userName);

        UpdatedDate = date;
        ModifiedByUser = userName;
    }

    private static void ValidateDate(DateTime date)
    {
        if (date == default)
            throw new ArgumentException("Audit date cannot be default.");
    }

    private static void ValidateUser(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("ModifiedByUser is required.");

        if (userName.Length > 150)
            throw new ArgumentException("ModifiedByUser cannot exceed 150 characters.");
    }
}
