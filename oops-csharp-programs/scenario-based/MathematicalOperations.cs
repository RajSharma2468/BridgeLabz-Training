using System;
class MathematicalOperations
{
    static void Main()
    {
        MathematicalOperations obj = new MathematicalOperations();
        Console.WriteLine("Press 1 A To calculate the factorial\nPress 2 To check if a number is prime\nPress 3 To find the greatest common divisor (GCD) of two numbers\nPress 4 to find the nth Fibonacci number.");
        int input = int.Parse(Console.ReadLine());
        if(input<1 || input >4){Console.WriteLine("Invalid Input Try  Again");return;}
        int number=0;
        if(input != 3)
        {
            Console.WriteLine("Enter the Number ==============>");
            number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);
            if(number==0){Console.WriteLine("Invalid Input Try Again");return;}
        }
        switch (input)
        {
            case 1:
                Console.WriteLine($"fatorial of {number} is {obj.factorial(number)}");
                break;
            case 2:
                obj.IsPrime(number);
                break;
            case 3:
                Console.WriteLine("Enter Two Numbers for Perform this operation==========>");
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                Console.WriteLine($"GCD of {num1}, {num2} is {obj.GCD(num1,num2)}");
                break;
            case 4:
                Console.WriteLine($"fabonacci of {number} is {obj.Fibonacci(number)}");
                break;
            default:
                Console.WriteLine("Invalid Input Try  Again");
                break;
            
        }
    }

    int factorial(int number)
    {
        if(number==1 || number==0)return 1;
        return factorial(number-1)*number;
    }

    void IsPrime(int number)
    {
        if (number < 2)Console.WriteLine($"{number} is not Prime");
        else if(number == 2)Console.WriteLine($"{number} is Prime");
        else{
            for(int i = 2; i * i <= number; i++){
                if (number % i == 0){
                    Console.WriteLine($"{number} is not Prime");
                    return;
                }
            }
            Console.WriteLine($"{number} is Prime");
        }
    }

    int Fibonacci(int number){
        if(number==0||number==1)return number;
        return Fibonacci(number-1)+Fibonacci(number-2);
    }

    int GCD(int a,int b){
        if(b==0)return a;
        return GCD(b,a%b);
    }
}