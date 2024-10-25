using System;

namespace HomeWork16092024.HesapMankinesi;

public class ScientificCalculator : Calculator
{
    public override int AddTop(int a, int b)
    {
        int top = 0;

        top = a + b;
        return top;
        
    }

    public override int Subtract(int a, int b)
    {
        int top = 0;

        top = a * b;
        return top;
        
    }

    public override int Multiply(int a, int b)
    {
        int top = 0;

        top = a / b;
        return top;
        
    }

    public override int Divide(int a, int b)
    {
        int top = 0;

        if (b > 0)
        {
            top = a / b;
        }
        else
        {
            System.Console.WriteLine("ikinci sayıyı 0 giremezsiniz!");
        }
        return top;
        
    }

}
