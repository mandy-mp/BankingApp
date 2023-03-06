namespace BankAccountTask;

public class Transaction 
{
    public decimal Amount { get; }
    public ACTION_TYPE Type { get; }

    public Transaction(decimal amount, ACTION_TYPE type) 
    {
        Amount = amount;
        Type = type;
    }

    public override string ToString()
    {
        switch(Type) 
        {
            case ACTION_TYPE.DEPOSIT: 
                return $"Deposited {Amount.ToString()}";
            case ACTION_TYPE.WITHDRAWAL: 
                return $"Withdrew {Amount.ToString()}";
            default: 
                throw new Exception($"Unknown transaction type {Type.ToString()}");
        }
    }
}
public enum ACTION_TYPE { WITHDRAWAL, DEPOSIT }