namespace Dagemov.Domain.Interfaces;

public interface IAuditableEntity
{
    DateTime CreatedDate { get; }
    DateTime UpdatedDate { get; }
    string? ModifiedByUser { get; }

    void MarkCreated(DateTime date, string userName);
    void MarkUpdated(DateTime date, string userName);
}
