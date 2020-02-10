using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace console
{
    class Application
    {
        readonly string breakLine = "--------------------------";
        readonly string opt1 = "1) View account.";
        readonly string opt2 = "2) View account by number.";
        readonly string opt3 = "3) Search.";
        readonly string opt4 = "4) Move.";
        readonly string opt5 = "5) New account.";
        readonly string opt6 = "6) Exit.";

        public void Run()
        {
            char ans = 'g';
            var accounts = ReadAccounts();

            do
            {
                accounts = ReadAccounts();
                Console.WriteLine(breakLine);
                Console.WriteLine(opt1);
                Console.WriteLine(opt2);
                Console.WriteLine(opt3);
                Console.WriteLine(opt4);
                Console.WriteLine(opt5);
                Console.WriteLine(opt6);
                Console.WriteLine(breakLine);
                ans = Console.ReadKey().KeyChar;
                Console.WriteLine("");

                switch (ans)
                {
                    case '1':
                        ShowAccounts(accounts);
                        break;
                    case '2':
                        String nmb;

                        while (true)
                        {
                            Console.Write("Enter the account  number you want  to view: ");
                            nmb = Console.ReadLine();

                            try
                            {
                                ShowAccounts(accounts, Convert.ToInt32(nmb));
                                break;
                            }
                            catch (FormatException e)
                            {
                                Console.Write("Please  use only integers! Press any key to continue...");
                                Console.ReadKey();
                                Console.Write("\n");
                            }
                        }
                        break;
                    case '3':
                        Console.Write("Enter the  value you want to search for: ");
                        Search(accounts, Console.ReadLine());
                        break;
                    case '4':
                        ShowAccounts(accounts);
                        Move(accounts);
                        break;
                    case '5':
                        NewAccount(accounts);
                        break;
                    case '6':
                        Console.WriteLine("Good bye!");
                        break;
                }

            } while (ans != '6');

        }
        // for  opt1 and opt2
        private void ShowAccounts(IEnumerable<Account> accounts, int number = 0)
        {
            bool isAvailable = false;
            Console.WriteLine("+---------+---------+---------+---------+");
            Console.WriteLine("|  Number | Balance |  Label  |  Owner  |");
            Console.WriteLine("+---------+---------+---------+---------+");

            foreach (var account in accounts)
            {
                if (number != 0)
                    if (number != account.Number)
                        continue;

                Console.Write('|');
                Console.Write("{0,9}", account.Number); Console.Write('|');
                Console.Write("{0,9}", account.Balance); Console.Write('|');
                Console.Write("{0,9}", account.Label); Console.Write('|');
                Console.Write("{0,9}", account.Owner); Console.Write("|\n");
                Console.WriteLine("+---------+---------+---------+---------+");
                isAvailable = true;
            }

            if (!isAvailable)
            {
                Console.Write('|');
                Console.Write("{0,36}", "No such account with this number!"); Console.Write("{0,5}", "|\n");
                Console.WriteLine("+---------+---------+---------+---------+");
            }
        }
        //for opt3
        public void Search(IEnumerable<Account> accounts, string value)
        {
            int nmb = 0;
            try
            {
                nmb = Convert.ToInt32(value);
            }
            catch (FormatException e)
            {
                //meh
            }
            bool isAvailable = false;
            Console.WriteLine("+---------+---------+---------+---------+");
            Console.WriteLine("|  Number | Balance |  Label  |  Owner  |");
            Console.WriteLine("+---------+---------+---------+---------+");

            foreach (var account in accounts)
            {

                if (account.Number == nmb
                      | account.Label.ToLower().IndexOf(value.ToLower()) != -1
                      | account.Owner.ToString().ToLower().IndexOf(value.ToLower()) != -1)
                {
                    Console.Write('|');
                    Console.Write("{0,9}", account.Number); Console.Write('|');
                    Console.Write("{0,9}", account.Balance); Console.Write('|');
                    Console.Write("{0,9}", account.Label); Console.Write('|');
                    Console.Write("{0,9}", account.Owner); Console.Write("|\n");
                    Console.WriteLine("+---------+---------+---------+---------+");
                    isAvailable = true;
                }
            }

            if (!isAvailable)
            {
                Console.Write('|');
                Console.Write("{0,36}", "No such account with this input!"); Console.Write("{0,5}", "|\n");
                Console.WriteLine("+---------+---------+---------+---------+");
            }
        }
        //for opt 4
        private void Move(IEnumerable<Account> accounts)
        {
            int acc1, acc2;
            bool isAcc1 = false, isAcc2 = false;

            while (true)
            {
                Console.WriteLine("Move balance from: ");
                try
                {
                    acc1 = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please use only integers! Press any key to continue..");
                    Console.ReadKey();
                    Console.Write("\n");
                }

            }

            while (true)
            {
                Console.WriteLine("Move balance to: ");
                try
                {
                    acc2 = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please use only integers! Press any key to continue..");
                    Console.ReadKey();
                    Console.Write("\n");
                }
            }

            foreach (var account in accounts)
            {
                if (acc1 == account.Number)
                {
                    isAcc1 = true;

                    foreach (var j in accounts)
                    {
                        if (j.Number == acc2)
                        {
                            isAcc2 = true;
                            j.Balance += account.Balance;
                            account.Balance = 0;
                            break;
                        }

                    }
                }
            }

            if (!isAcc1)
            {
                Console.WriteLine("Could not find an account with the number " + acc1);
            }
            else if (!isAcc2)
                Console.WriteLine("Could not find an account with the number " + acc2);

            if (isAcc1 && isAcc2)
                SaveAccounts(accounts);
        }

        private void NewAccount(IEnumerable<Account> accounts)
        {
            int number, balance, owner;
            string label;
            Console.WriteLine("-------------------");
            Console.WriteLine("New Account details");

            while (true)
            {
                try
                {
                    Console.WriteLine("Number: ");
                    number = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please use only integers! Press any key to continue..");
                    Console.ReadKey();
                    Console.Write("\n");
                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Balance: ");
                    balance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please use only integers! Press any key to continue..");
                    Console.ReadKey();
                    Console.Write("\n");
                }
            }

            Console.WriteLine("Label: ");
            label = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("Owner: ");
                    owner = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please use only integers! Press any key to continue..");
                    Console.ReadKey();
                    Console.Write("\n");
                }
            }

            Account tmp = new Account(number, balance, label, owner);
            IEnumerable<Account> c = accounts.Append(tmp);
            SaveAccounts(c);
        }

        //read data from json file
        private IEnumerable<Account> ReadAccounts()
        {
            String file = @"..\..\..\..\..\..\data\account.json";

            using (StreamReader r = new StreamReader(file))
            {
                string data = r.ReadToEnd();

                var json = JsonSerializer.Deserialize<Account[]>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

                return json;
            }
        }
        private void SaveAccounts(IEnumerable<Account> accounts)
        {
            String file = @"..\..\..\..\..\..\data\account.json";

            File.Delete(file);
            using (var outputStream = File.OpenWrite(file))
            {

                JsonSerializer.Serialize<IEnumerable<Account>>(
                    new Utf8JsonWriter(
                        outputStream,
                        new JsonWriterOptions
                        {
                            Indented = true
                        }
                    ),
                    accounts
                );
            }
        }

    }
}