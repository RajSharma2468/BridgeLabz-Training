using System;

class Program
{
    static void AnalyzeTemperature(float[,] temperature)
    {
        int day = 0;

        while (day < 7)
        {
            float hottestTemperature = temperature[day, 0];
            float coldestTemperature = temperature[day, 0];
            float sumOfTemperature = 0;

            int hour = 0;

            do
            {
                float currentTemperature = temperature[day, hour];

                sumOfTemperature = sumOfTemperature + currentTemperature;

                if (currentTemperature > hottestTemperature)
                {
                    hottestTemperature = currentTemperature;
                }
                else
                {
                    // nothing
                }

                if (currentTemperature < coldestTemperature)
                {
                    coldestTemperature = currentTemperature;
                }
                else
                {
                    // nothing
                }

                hour = hour + 1;

            } while (hour < 24);

            float averageTemperature = sumOfTemperature / 24;

            switch (day)
            {
                case 0:
                    Console.WriteLine("Sunday");
                    break;
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
            }

            Console.WriteLine("Average Temperature = " + averageTemperature);
            Console.WriteLine("Hottest Temperature = " + hottestTemperature);
            Console.WriteLine("Coldest Temperature = " + coldestTemperature);
            Console.WriteLine("--------------------------------");

            day = day + 1;
        }
    }

    static void Main()
    {
        float[,] temperature = new float[7, 24];

        float value = 20;

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 24; j++)
            {
                temperature[i, j] = value;
                value = value + 1;
            }
        }

        AnalyzeTemperature(temperature);
    }
}
