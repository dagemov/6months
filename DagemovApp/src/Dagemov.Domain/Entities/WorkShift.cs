using Dagemov.Domain.Enums;
using Dagemov.Domain.ValueObjects;

namespace Dagemov.Domain.Entities;

public class WorkShift
{
    public int Id { get; private set; }
    //public DateTime OpenShift { get; private set; }
    //public DateTime CloseShift { get; private set; } lo movimos a ShiftPeriod , para ser reutilizable en cualquier clase de domino que requiera anadir un shift
    private ShiftPeriod ShiftPeriod { get; set; }
    public string? Description { get; private set; }
    public  WorkShiftStatus WorkShiftStatus { get; private set; }
    public DateTime BreakTime { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }
    protected WorkShift()
    {
       
    }
    public WorkShift(int id, DateTime openShift, DateTime endShift,string description, WorkShiftStatus workShiftStatus)
    {
        if (id < 0) throw new ArgumentException($"Invalid Id to this record <{0}>");
        Id = id;
        this.ShiftPeriod = new(openShift, endShift);
        
        ValidationDescription(description, nameof(Description));
        ValidationChooseEnum<WorkShiftStatus>(workShiftStatus, nameof(WorkShiftStatus));
        WorkShiftStatus = workShiftStatus;   
        Description = description;
        CreatedDate = DateTime.UtcNow;

        UpdatedDate = DateTime.UtcNow;
    }


    private void SetShifts(DateTime openShift, DateTime endShift)
    {
        ShiftPeriod.ValidationShifts(openShift, endShift);
        this.ShiftPeriod = new(openShift, endShift);
        //OpenShift = openShift;
        //CloseShift = endShift;
        UpdatedDate = DateTime.UtcNow;
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
    public  void UpdatedDescription(string newDescription)
    {
        ValidationDescription(newDescription,nameof(Description));
        Description = newDescription;
        UpdatedDate = DateTime.UtcNow;

    }

    public void SetCreatedDate(DateTime dateTime)
    {
        CreatedDate = dateTime;
        UpdatedDate = DateTime.UtcNow;
    }
    //Actions

    public void CompleteShift()
    {
        if(this.WorkShiftStatus!= WorkShiftStatus.Active) throw new InvalidOperationException("Only the Activates shifts can be marked such completed");
        this.WorkShiftStatus = WorkShiftStatus.Completed;
        this.UpdatedDate = DateTime.UtcNow;
    }
}
