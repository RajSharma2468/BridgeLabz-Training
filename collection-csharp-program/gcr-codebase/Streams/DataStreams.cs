using System;
using System.IO;

class BinaryData
{
    static void Main()
    {
        string file = "student.bin";

        using (BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create)))
        {
            bw.Write(101);
            bw.Write("Raj");
            bw.Write(8.9);
        }

        using (BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open)))
        {
            int roll = br.ReadInt32();
            string name = br.ReadString();
            double gpa = br.ReadDouble();

            Console.WriteLine("Roll: " + roll);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("GPA: " + gpa);
        }
    }
}
