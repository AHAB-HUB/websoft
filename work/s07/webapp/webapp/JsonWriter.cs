using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace webapp
{
    public class JsonWriter
    {
        public bool TransferMoney(int source, int dest, int amount)
        {
            var accounts = new JsonReader().Read();
            Account sourceAccount = accounts.FirstOrDefault(a => a.Number == source);
            Account destAccount = accounts.FirstOrDefault(a => a.Number == dest);

            if (sourceAccount != null && destAccount != null && sourceAccount.Balance >= amount)
            {
                sourceAccount.Balance -= amount;
                destAccount.Balance += amount;
                SaveAccounts(accounts);
                return true;
            }
            else
            {
                return false;
            }


            return true;
        }

        private void SaveAccounts(IEnumerable<Account> accounts)
        {
            String file = @"../../data/account.json";

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
