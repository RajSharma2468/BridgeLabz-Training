using System;


namespace Models
{
public class AadhaarRecord
{
public long AadhaarNumber { get; set; }
public string HolderName { get; set; }


public AadhaarRecord(long aadhaarNumber, string holderName)
{
AadhaarNumber = aadhaarNumber;
HolderName = holderName;
}


public override string ToString()
{
return HolderName + " -> " + AadhaarNumber;
}
}
}