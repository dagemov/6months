namespace Dagemov.Domain.Entities;

public class WorkShift
{
    public int Id { get; private set; }
    public DateTime OpenShift { get; private set; }
    public DateTime CloseShift { get; private set; }
    public string? Description { get; private set; }

    public DateTime CreatedDate { get; private set; }
    public DateTime UpdatedDate { get; private set; }
    protected WorkShift()
    {
       
    }
    public WorkShift(int id, DateTime openShift, DateTime endShift,string description)
    {
        if (id < 0) throw new ArgumentException($"Invalid Id to this record <{0}>");
        Id = id;
        ValidationShifts(openShift, endShift);
        ValidationDescription(description);
        OpenShift = openShift;
        CloseShift = endShift;
        Description = description;
        CreatedDate = DateTime.UtcNow;

        UpdatedDate = DateTime.UtcNow;
    }

    public static void ValidationShifts(DateTime openShift, DateTime endShift)
    {
        if(endShift  <= openShift) throw new ArgumentException("Invalid Shift programing   \n ples make sure and adjust the hours correctly");
        
    }
    private void SetShifts(DateTime openShift, DateTime endShift)
    {
        ValidationShifts(openShift, endShift);
        OpenShift = openShift;
        CloseShift = endShift;
        UpdatedDate = DateTime.UtcNow;
    }
    private static void ValidationDescription(string x)
    {
        if (string.IsNullOrWhiteSpace(x) || string.IsNullOrEmpty(x)) throw new ArgumentException("Invalid description is null or empy , ples inpout at valid Description ");
    }
    public  void UpdatedDescription(string newDescription)
    {
        ValidationDescription(newDescription);
        Description = newDescription;
        UpdatedDate = DateTime.UtcNow;

    }

    public void SetCreatedDate(DateTime dateTime)
    {
        CreatedDate = dateTime;
        UpdatedDate = DateTime.UtcNow;
    }
}
