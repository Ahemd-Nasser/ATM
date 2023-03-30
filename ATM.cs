using System;
using System.Globalization;
using static System.Console;


namespace ConsoleApplication1
{
    public class ATM
    {
        private Accounts Account = new Accounts();
        private string Current;
        private bool exit;

        public ATM()
        {
            exit = false;
        }
        public bool LogIn()
        {
            for (int i = 0; i < 3; i++)
            {
                Write(
                        
                    "Please write your Account number and Password\n"+
                    "Account number:"
                );
                string Acc, Pass;
                Acc = ReadLine();
                Write("Password:");
                Pass = ReadLine();
                if (!Account.Find(Acc, Pass))
                {
                    Console.Clear();
                    WriteLine("Invalid Account number or Password");
                    if (i < 2)
                    {
                        WriteLine("Please try again"+
                                  "\n tap on any key to exit");
                    }
                    else
                    {
                        WriteLine("You have exceeded the maximum number of login attempts" +
                                  "\n tap on any key to exit");
                    }
                    ReadKey();
                    Console.Clear();
                    
                }

                else
                {
                    Current = Acc;
                    Display(0);
                    return true;
                }
            }

            return false;

        }

        void show()
        {
            WriteLine("Please choase your transaction\n" +
                      "1- try again \n"+
                      "2- back\n"+
                      "3- Exit");
        }

        public void Display(int n)
        {
            
            if (n == 0)
            {
                while (true)
                {
                    if (exit)
                    {
                        return;
                    }
                    WriteLine("~~~~~~~~choase an transaction~~~~~~~~\n");
                    
                    WriteLine(
                        "1- Withdrawal\n"+
                        "2- Deposit\n"+
                        "3- Balance inquiry\n"+
                        "4- Exit"
                    );

                    int choice = int.Parse(ReadLine());
                    
                    Console.Clear();
                    
                    if (choice == 4) break;
                    
                    Display(choice);
                    
                }
            }
            
            else if (n == 1)
            {
                WriteLine("Please write the amount you want to withdrawal :");
                int money = int.Parse(ReadLine());
                bool Can = Account.Withdraw(Current, money);
                
                if (!Can)
                {
                    WriteLine("Your balance is not enough\n");

                }
                else
                {
                    WriteLine("--------------------------\n| Successful transaction |\n--------------------------\n");
                }

                show();
                
                int choice = int.Parse(ReadLine());
                
                Console.Clear();
                
                if (choice == 1)
                {
                    Display(n);
                    return;
                }
                if (choice == 2) return;

                exit = true;

            }
            else if (n == 2)
            {
                WriteLine("Please write the amount you want to Deposit :");
                int money = int.Parse(ReadLine());
                Account.Deposit(Current, money);
                
                show();
                
                int choice = int.Parse(ReadLine());
                
                Console.Clear();
                
                if (choice == 1)
                {
                    Display(n);
                    return;
                }
                if (choice == 2) return;

                exit = true;
                
            }
            else if (n == 3)
            {
                WriteLine($"Your balance is : ${Account[Current]}\n\n");
                
                WriteLine("Please choase your transaction\n" +
                          "1- back\n"+
                          "2- Exit");
                
                int choice = int.Parse(ReadLine());
                
                Console.Clear();
                
                if (choice == 1) return;

                exit = true;
                
            } 
            
        }
        
    }
}