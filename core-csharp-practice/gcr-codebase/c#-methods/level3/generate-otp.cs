using System;

class OTPGenerator
{
    static int GenerateOTP()
    {
        Random random = new Random();
        return random.Next(100000, 999999);
    }

    static void Main()
    {
        int otp = GenerateOTP();
        Console.WriteLine("Generated OTP: " + otp);
    }
}
