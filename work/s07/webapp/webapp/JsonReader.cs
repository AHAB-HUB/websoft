using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace webapp
{
    public class JsonReader
    {
        public IEnumerable<Account> Read(int nmb = 0)
        {
            String file = @"..\..\data\account.json";
            IEnumerable<Account> json;

            using (StreamReader r = new StreamReader(file))
            {
                string data = r.ReadToEnd();

                    json = JsonSerializer.Deserialize<Account[]>(
                    data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }

            bool isAvailable = false;

                if (nmb != 0)
                    foreach (var account in json)
                    {
                        if (nmb == account.Number) {
                            isAvailable = true;
                            List<Account> s = new List<Account>();
                            s.Add(new Account(account.Number, account.Balance, account.Label, account.Owner));
                            return s;
                        }
                    }

            if(!isAvailable && nmb != 0)
                return null;

            return json;
        }
    }
}
