using System;

public class clsBrokenClock
{

    
    private int counter;

    public int RtnNos()
    {
        DateTime goodClock = DateTime.Now;
        DateTime brokenClock = DateTime.Now;
        for (int i = 0; i < 1140; i++)
        {
            if (goodClock.ToShortTimeString() == brokenClock.ToShortTimeString())
            {
                counter++;
            }
            goodClock = goodClock.AddMinutes(1);
            brokenClock = brokenClock.AddMinutes(-1);
        }
        return counter;
    }
}
