using System;


public interface ITransaction
{
    void MakeTransaction(double amount);
    bool CheckStatus();
}


public class Transaction
{
    public double Amount { get;  set; }
    public DateTime Date { get;  set; }

    public Transaction(double amount)
    {
        Amount = amount;
        Date = DateTime.Now;
    }

   
    ~Transaction()
    {
     
        Console.WriteLine("Object deleted");
    }
}


public class FinancialTransaction : Transaction, ITransaction
{
    private bool isTransactionSuccessful;

    public FinancialTransaction(double amount) : base(amount)
    {
        isTransactionSuccessful = false;
    }

   
    public void MakeTransaction(double amount)
    {
    
        Console.WriteLine($" Transaction  {amount} grn.");
        isTransactionSuccessful = true;
    }

   
    public bool CheckTransactionStatus()
    {
        
        return isTransactionSuccessful;
    }

    public bool CheckStatus()
    {
        throw new NotImplementedException();
    }

    ~FinancialTransaction()
    {
     
        Console.WriteLine("Object deleted");
    }
}


public class DepositTransaction : FinancialTransaction
{
    public DepositTransaction(double amount) : base(amount)
    {
        
    }

    ~DepositTransaction()
    {
        
        Console.WriteLine("Object deleted");
    }
}

public class WithdrawalTransaction : FinancialTransaction
{
    
    public WithdrawalTransaction(double amount) : base(amount)
    {
        
    }

    
    ~WithdrawalTransaction()
    {
        
        Console.WriteLine("Object deleted");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        var deposit = new DepositTransaction(1000);
        deposit.MakeTransaction(1000);

        var withdrawal = new WithdrawalTransaction(500);
        withdrawal.MakeTransaction(500);
    }
}