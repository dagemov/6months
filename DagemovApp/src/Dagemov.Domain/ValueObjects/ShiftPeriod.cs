using System;
using System.Collections.Generic;
using System.Text;

namespace Dagemov.Domain.ValueObjects;

public class ShiftPeriod
{
    public DateTime Startshift { get; private set; }
    public DateTime EndShift { get; private set; }
    protected ShiftPeriod()
    {
        
    }
    public ShiftPeriod(DateTime openShift, DateTime endShift)
    {
        ValidationShifts(openShift, endShift);
        Startshift = openShift;
        EndShift = endShift;
    }
    public static void ValidationShifts(DateTime openShift, DateTime endShift)
    {
        if (endShift <= openShift) throw new ArgumentException("Invalid Shift programing   \n ples make sure and adjust the hours correctly");  
    }

    private void SetStartShift(DateTime openShift)
    {
        Startshift = openShift;
    }
    private void SetEndShitf(DateTime closeShift)
    {
        EndShift = closeShift;
    }
}
