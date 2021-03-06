﻿using DnDGen.RollGen.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DnDGen.RollGen.PartialRolls
{
    internal class Roll
    {
        public int Quantity { get; set; }
        public int Die { get; set; }
        public int AmountToKeep { get; set; }
        public bool Explode { get; set; }

        public bool IsValid => QuantityValid && DieValid && KeepValid && ExplodeValid;
        private bool QuantityValid => Quantity > 0 && Quantity <= Limits.Quantity;
        private bool DieValid => Die > 0 && Die <= Limits.Die;
        private bool KeepValid => AmountToKeep > -1 && AmountToKeep <= Limits.Quantity;
        private bool ExplodeValid => !Explode || Die > 1;

        public Roll() { }

        public Roll(string toParse)
        {
            toParse = toParse.Trim();
            Explode = toParse.Contains("!");
            toParse = toParse.Replace("!", string.Empty);

            var sections = toParse.Split('d', 'k');

            Die = Convert.ToInt32(sections[1]);
            Quantity = 1;

            if (!string.IsNullOrEmpty(sections[0]))
                Quantity = Convert.ToInt32(sections[0]);

            if (sections.Length == 3 && !string.IsNullOrEmpty(sections[2]))
                AmountToKeep = Convert.ToInt32(sections[2]);
        }

        public static bool CanParse(string toParse)
        {
            if (string.IsNullOrWhiteSpace(toParse))
                return false;

            var trimmedSource = toParse.Trim();
            var strictRollRegex = new Regex(RegexConstants.StrictRollPattern);
            var rollMatch = strictRollRegex.Match(trimmedSource);

            return rollMatch.Success && rollMatch.Value == trimmedSource;
        }

        public IEnumerable<int> GetRolls(Random random)
        {
            ValidateRoll();

            var rolls = new List<int>(Quantity);

            for (var i = 0; i < Quantity; i++)
            {
                var roll = random.Next(Die) + 1;
                if (Explode && roll == Die)
                {
                    --i; // We're rerolling this die, so Quantity actually stays the same.
                }
                rolls.Add(roll);
            }

            if (AmountToKeep > 0 && AmountToKeep < rolls.Count())
                return rolls.OrderByDescending(r => r).Take(AmountToKeep);

            return rolls;
        }

        private void ValidateRoll()
        {
            if (IsValid)
                return;

            var message = $"{this} is not a valid roll.";

            if (!QuantityValid)
                message += $"\n\tQuantity: 0 < {Quantity} < {Limits.Quantity}";

            if (!DieValid)
                message += $"\n\tDie: 0 < {Die} < {Limits.Die}";

            if (!KeepValid)
                message += $"\n\tKeep: 0 <= {AmountToKeep} < {Limits.Quantity}";

            if (!ExplodeValid)
                message += $"\n\tExplode: Cannot explode die {Die}, must be > 1";

            throw new InvalidOperationException(message);
        }

        public int GetSum(Random random)
        {
            ValidateRoll();

            var rolls = GetRolls(random);
            return rolls.Sum();
        }

        public double GetPotentialAverage()
        {
            ValidateRoll();

            var quantity = GetEffectiveQuantity();
            var average = quantity * (Die + 1) / 2.0d;

            return average;
        }

        public int GetPotentialMinimum()
        {
            ValidateRoll();

            var quantity = GetEffectiveQuantity();

            return quantity;
        }

        private int GetEffectiveQuantity()
        {
            if (AmountToKeep > 0)
                return Math.Min(Quantity, AmountToKeep);

            return Quantity;
        }

        public int GetPotentialMaximum(bool includeExplode = true)
        {
            ValidateRoll();

            var quantity = GetEffectiveQuantity();
            var max = quantity * Die;

            //INFO: Since exploded dice can in theory be infinite, we will assume 10x multiplier,
            //which should cover 99.9% of use cases
            if (Explode && includeExplode)
                max *= 10;

            return max;
        }

        public bool GetTrueOrFalse(Random random)
        {
            ValidateRoll();

            var average = GetPotentialAverage();
            var sum = GetSum(random);

            return sum >= average;
        }

        public override string ToString()
        {
            var output = $"{Quantity}d{Die}";

            if (Explode)
                output += "!";

            if (AmountToKeep != 0)
                output += $"k{AmountToKeep}";

            return output;
        }
    }
}
