using System;

namespace HomeWork16092024.BankacılıkUygulaması;

public class Account
{
    public Account(int accountNumber, decimal balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public int AccountNumber { get; set; }

    public decimal Balance { get; set; }


}
