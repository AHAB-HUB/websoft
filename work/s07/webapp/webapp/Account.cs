﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace webapp
{
    public class Account
    {
        public Account(int number, int balance, string label, int owner)
        {
            this.Number = number;
            this.Balance = balance;
            this.Label = label;
            this.Owner = owner;
        }

        public Account() { }

        public int Number { get; set; }
        public int Balance { get; set; }
        public string Label { get; set; }
        public int Owner { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Account>(this);
        }


    }
}
