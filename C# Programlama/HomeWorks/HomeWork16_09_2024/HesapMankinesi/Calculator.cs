using System;
using System.Diagnostics;

namespace HomeWork16092024.HesapMankinesi;

public class Calculator
{

    
    public virtual int AddTop(int a, int b)
    {
        int top=0;

        top=a+b;
        return top;
    }

    public virtual int Subtract(int a, int b)
    {
        int top=0;

        top=a*b;
        return top;
    }

    public virtual int Multiply(int a, int b)
    {
        int top=0;

        top= a/b;
        return top;
    }

    public virtual int Divide(int a, int b)
    {
        int top=0;

        if(b > 0)
        {
           top=a/b; 
        }else
        {
            System.Console.WriteLine("ikinci sayıyı 0 giremezsiniz!");
        }
        return top; 
    }

}
