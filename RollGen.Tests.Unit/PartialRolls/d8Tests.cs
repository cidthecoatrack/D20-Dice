﻿using Moq;
using NUnit.Framework;
using RollGen.Domain.PartialRolls;
using System;

namespace RollGen.Tests.Unit.PartialRolls
{
    [TestFixture]
    public class d8Tests
    {
        private Mock<Random> mockRandom;
        private PartialRoll partialRoll;

        [SetUp]
        public void Setup()
        {
            mockRandom = new Mock<Random>();
        }

        [Test]
        public void ReturnRollValue()
        {
            partialRoll = new RandomPartialRoll(1, mockRandom.Object);
            mockRandom.Setup(r => r.Next(8)).Returns(42);

            var roll = partialRoll.d8();
            Assert.That(roll, Is.EqualTo(43));
        }

        [Test]
        public void RollQuantity()
        {
            partialRoll = new RandomPartialRoll(2, mockRandom.Object);
            mockRandom.SetupSequence(r => r.Next(8)).Returns(4).Returns(2);

            var roll = partialRoll.d8();
            Assert.That(roll, Is.EqualTo(8));
        }

        [Test]
        public void AfterRoll_AlwaysReturnZero()
        {
            partialRoll = new RandomPartialRoll(1, mockRandom.Object);
            mockRandom.Setup(r => r.Next(8)).Returns(42);

            partialRoll.d8();
            var roll = partialRoll.d8();
            Assert.That(roll, Is.EqualTo(0));
        }

        [Test]
        public void AfterOtherRoll_AlwaysReturnZero()
        {
            partialRoll = new RandomPartialRoll(1, mockRandom.Object);
            mockRandom.Setup(r => r.Next(8)).Returns(42);

            partialRoll.d(21);
            var roll = partialRoll.d8();
            Assert.That(roll, Is.EqualTo(0));
        }

        [Test]
        public void IfQuantityOverLimit_ThrowArgumentException()
        {
            partialRoll = new RandomPartialRoll(Limits.Quantity + 1, mockRandom.Object);
            Assert.That(() => partialRoll.d8(), Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("Die roll of 1000001d8 is too large for RollGen"));
        }

        [Test]
        public void IfAllInputsEqualToLimits_Roll()
        {
            partialRoll = new RandomPartialRoll(Limits.Quantity, mockRandom.Object);
            mockRandom.Setup(r => r.Next(8)).Returns(7);

            var roll = partialRoll.d8();
            Assert.That(roll, Is.EqualTo(Limits.Quantity * 8));
        }
    }
}