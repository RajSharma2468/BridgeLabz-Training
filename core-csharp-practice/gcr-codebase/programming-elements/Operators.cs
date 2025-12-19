using System;
class Operators{
	// Arithmetic Operators
	static void Main(){
		int a=10;
		int b=20;
		Console.WriteLine("sum is "+(a+b));
		Console.WriteLine("Subtraction is "+(a-b));
		Console.WriteLine("Multiplication is "+(a*b));
		Console.WriteLine("Divison is "+(a/b));
		Console.WriteLine("Modulus is "+(a%b));
		a++;
		Console.WriteLine("increment is "+ a);
		b--;
		Console.WriteLine("decrement is "+ b);
		Console.WriteLine("Divison is "+ ((float)9/5));
		Console.WriteLine("Divison is "+ (9f/5f));
		
        double y = 10.0 / 3;
        Console.WriteLine(y);
		
		// Pre & Post Increment / Decrement
		int x = 5;

        Console.WriteLine(++x); // Pre-increment → 6
        Console.WriteLine(x++); // Post-increment → 6 (x becomes 7)
        Console.WriteLine(--x); // Pre-decrement → 6
        Console.WriteLine(x--); // Post-decrement → 6 (x becomes 5)
		
		// Relational (Comparison) Operators ==   !=   >   <   >=   <=
		Console.WriteLine(a < b); 
		
		// Logical Operators &&   ||   !
        
		bool p = true, q = false;
        Console.WriteLine(p && q);  // false
        
		// Assignment Operators =   +=   -=   *=   /=   %=   &=   |=   ^=   <<=   >>=
        int s=12;
         s += 5;   
		Console.WriteLine("now a is " + (s));
		
		// Unary Operators  +   -   !   ~   ++   --
        int c = 5;
        Console.WriteLine(-c);
		
		// Bitwise Operators &   |   ^   ~   <<   >>
        int r = 5, v = 3;
        Console.WriteLine(r & v);  // 1
        
	}
}