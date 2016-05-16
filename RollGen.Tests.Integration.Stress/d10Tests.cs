﻿using NUnit.Framework;

namespace RollGen.Tests.Integration.Stress
{
    [TestFixture]
    public class d10Tests : ProvidedDiceTests
    {
        protected override int die
        {
            get { return 10; }
        }

        protected override int GetRoll(int quantity)
        {
            return Dice.Roll(quantity).d10();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public override void FullRangeHit(int quantity)
        {
            AssertFullRangeHit(quantity);
        }

        [Test]
        public void RollWithLargestDieRollPossible()
        {
            Stress(AssertRollWithLargestDieRollPossible);
        }

        private void AssertRollWithLargestDieRollPossible()
        {
            var roll = Dice.Roll(Limits.Quantity).d10();
            Assert.That(roll, Is.InRange(Limits.Quantity, Limits.Quantity * 10));
        }
    }
}