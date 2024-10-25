using System;

namespace HomeWork16092024.BankacılıkUygulaması;

public class CheckingAccount : Account
{
    public CheckingAccount(int accountNumber, decimal balance) : base(accountNumber, balance)
    {

    }

    public void WriteCheck(decimal money)
    {
        System.Console.WriteLine($"{AccountNumber}'e {money}'lik Çek yazılıyor.");
    }

}
