using Dagemov.Domain.Enums;
using Dagemov.Domain.Interfaces;
using Dagemov.Domain.ValueObjects;

namespace Dagemov.Domain.Entities;

public class WorkShift : IAuditableEntity
{
    public int Id { get; private set; }
    public ShiftPeriod ShiftPeriod { get; set; } = null!;
    public string? Description { get; private set; }
    public  WorkShiftStatus WorkShiftStatus { get; private set; }
    public DateTime BreakTime { get; private set; }

    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }
    public string? ModifiedByUser { get; private set; }

    protected WorkShift()
    {
        
    }
    public WorkShift(int id, DateTime openShift, DateTime endShift,string description, WorkShiftStatus workShiftStatus, string userName)
    {
        if (id < 0) throw new ArgumentException($"Invalid Id to this record <{0}>");
        Id = id;
        this.ShiftPeriod = new(openShift, endShift);
        
        ValidationDescription(description, nameof(Description));
        ValidationChooseEnum<WorkShiftStatus>(workShiftStatus, nameof(WorkShiftStatus));
        WorkShiftStatus = workShiftStatus;   
        Description = description;

    }


    private void SetShifts(DateTime openShift, DateTime endShift,string userName)
    {
        ShiftPeriod.ValidationShifts(openShift, endShift);
        this.ShiftPeriod = new(openShift, endShift);

    }
    private void SetBreakTime(DateTime breakTime)
    {
        BreakTime = breakTime;
    }
    private void SetStatusShift(WorkShiftStatus choose)
    {
        ValidationChooseEnum<WorkShiftStatus>(choose, nameof(WorkShiftStatus));
        WorkShiftStatus = choose;
    }
    private static void ValidationChooseEnum<TEnum>(WorkShiftStatus choice, string fieldName)
    {
        var range = Enum.GetNames(typeof(WorkShiftStatus)).Length;

        if (((int)choice)> range || ((int)choice) < 1)
        {
            throw new ArgumentException($"The field {fieldName} is invalid, please select a valid choice.");
        }
    }
    private static void ValidationDescription(string x, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(x) || string.IsNullOrEmpty(x)) throw new ArgumentException($"Invalid {fieldName} is null or empy , ples inpout at valid Description ");
    }
    public  void UpdatedDescription(string newDescription,string userName)
    {
        ValidationDescription(newDescription,nameof(Description));
        Description = newDescription;

    }
    //Actions

    public void CompleteShift(string userName)
    {
        if(this.WorkShiftStatus!= WorkShiftStatus.Active) throw new InvalidOperationException("Only the Activates shifts can be marked such completed");
        this.WorkShiftStatus = WorkShiftStatus.Completed;
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
