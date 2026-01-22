using System;
using System.IO;

class ImageByteArray
{
    static void Main()
    {
        try
        {
            byte[] imageData = File.ReadAllBytes("image.jpg");

            using (MemoryStream ms = new MemoryStream(imageData))
            {
                File.WriteAllBytes("copyImage.jpg", ms.ToArray());
            }

            Console.WriteLine("Image copied successfully");
        }
        catch (IOException ex)
        {
            Console.WriteLine("IO Error: " + ex.Message);
        }
    }
}
