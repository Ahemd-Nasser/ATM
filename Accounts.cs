using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Accounts
    {
        private Dictionary<string, string> account = new Dictionary<string, string>();
        private Dictionary<string, int> balance = new Dictionary<string, int>();

        public Accounts()
        {
            InsertAcc("1234", "2001");
            Deposit("1234", 500);
        }

        public int this[string cur]
        {
            get
            {
                return balance[cur];
            }
        }
        public bool Find(string Acc, string PassWord)
        {
            if (!account.ContainsKey(Acc) || (account.ContainsKey(Acc) && account[Acc]!=PassWord))
                return false;

            return true;
        }

        public bool InsertAcc(string Acc, string Password)
        {
            if (account.ContainsKey(Acc))
                return false;
            
            account.Add(Acc,Password);
            balance.Add(Acc,0);
            
            return true;
        }

        public void Deposit(string Acc, int DepositValue)
        {
            balance[Acc] += DepositValue;
        }

        public bool Withdraw(string Acc, int WithdrawValue)
        {
            if (balance[Acc] < WithdrawValue)
                return false;
            
            balance[Acc] -= WithdrawValue;
            
            return true;
        }



    }
}