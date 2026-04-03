using System;

namespace Algorithms
{
    public class PasswordCracker
    {
        private bool isFound = false;
        private string secret;
        private int attempts = 0;

        public void Crack(char[] charset, char[] current, int index)
        {
            if (isFound)
                return;

            if (index == current.Length)
            {
                attempts++;
                string guess = new string(current);

                Console.WriteLine("Trying: " + guess);

                if (guess == secret)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Password FOUND: " + guess);
                    Console.ResetColor();
                    isFound = true;
                }
                return;
            }

            for (int i = 0; i < charset.Length; i++)
            {
                current[index] = charset[i];
                Crack(charset, current, index + 1);
            }
        }

        public void Start(string password, int length)
        {
            secret = password;
            char[] charset = { 'a', 'b', 'c', '1', '2', '3' };
            char[] current = new char[length];

            Crack(charset, current, 0);

            Console.WriteLine("Total Attempts: " + attempts);
        }
    }
}
