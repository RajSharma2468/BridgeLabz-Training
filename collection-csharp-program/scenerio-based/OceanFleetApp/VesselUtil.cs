using System.Collections.Generic;
using System.Linq;

public class VesselUtil
{
    private List<Vessel> vesselList = new List<Vessel>();

    public List<Vessel> VesselList
    {
        get { return vesselList; }
        set { vesselList = value; }
    }

    // Requirement 1
    public void AddVesselPerformance(Vessel vessel)
    {
        vesselList.Add(vessel);
    }

    // Requirement 2
    public Vessel GetVesselById(string vesselId)
    {
        foreach (var vessel in vesselList)
        {
            if (vessel.VesselId == vesselId) // Case-sensitive
            {
                return vessel;
            }
        }
        return null;
    }

    // Requirement 3
    public List<Vessel> GetHighPerformanceVessels()
    {
        List<Vessel> result = new List<Vessel>();

        if (vesselList.Count == 0)
            return result;

        double maxSpeed = vesselList.Max(v => v.AverageSpeed);

        foreach (var vessel in vesselList)
        {
            if (vessel.AverageSpeed == maxSpeed)
            {
                result.Add(vessel);
            }
        }

        return result;
    }
}
