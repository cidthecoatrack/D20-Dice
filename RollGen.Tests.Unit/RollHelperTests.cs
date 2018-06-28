﻿using NUnit.Framework;

namespace RollGen.Tests.Unit
{
    [TestFixture]
    public class RollHelperTests
    {
        [TestCase(0, 1, "1d2-1")]
        [TestCase(0, 2, "1d3-1")]
        [TestCase(0, 4, "2d3-2")]
        [TestCase(0, 5, "1d6-1")]
        [TestCase(1, 1, "1")]
        [TestCase(1, 2, "1d2")]
        [TestCase(1, 3, "1d3")]
        [TestCase(1, 4, "1d4")]
        [TestCase(1, 5, "2d3-1")]
        [TestCase(1, 6, "1d6")]
        [TestCase(1, 7, "2d4-1")]
        [TestCase(1, 8, "1d8")]
        [TestCase(1, 9, "1d8+1d2-1")]
        [TestCase(1, 10, "1d10")]
        [TestCase(1, 11, "2d6-1")]
        [TestCase(1, 12, "1d12")]
        [TestCase(1, 20, "1d20")]
        [TestCase(1, 100, "1d100")]
        [TestCase(2, 2, "2")]
        [TestCase(2, 3, "1d2+1")]
        [TestCase(2, 4, "1d3+1")]
        [TestCase(2, 5, "1d4+1")]
        [TestCase(2, 6, "2d3")]
        [TestCase(2, 7, "1d6+1")]
        [TestCase(2, 8, "2d4")]
        [TestCase(2, 10, "1d8+1d2")]
        [TestCase(2, 12, "2d6")]
        [TestCase(2, 13, "1d12+1")]
        [TestCase(2, 15, "1d12+1d3")]
        [TestCase(2, 20, "2d10")]
        [TestCase(2, 24, "2d12")]
        [TestCase(2, 40, "2d20")]
        [TestCase(2, 200, "2d100")]
        [TestCase(3, 3, "3")]
        [TestCase(3, 4, "1d2+2")]
        [TestCase(3, 5, "1d3+2")]
        [TestCase(3, 6, "1d4+2")]
        [TestCase(3, 8, "1d6+2")]
        [TestCase(3, 9, "2d4+1")]
        [TestCase(3, 10, "1d8+2")]
        [TestCase(3, 12, "1d10+2")]
        [TestCase(3, 13, "2d6+1")]
        [TestCase(3, 18, "3d6")]
        [TestCase(3, 20, "1d12+2d4")]
        [TestCase(3, 28, "1d20+2d4")]
        [TestCase(4, 4, "4")]
        [TestCase(4, 5, "1d2+3")]
        [TestCase(4, 6, "1d3+3")]
        [TestCase(4, 7, "1d4+3")]
        [TestCase(4, 8, "2d3+2")]
        [TestCase(4, 9, "1d6+3")]
        [TestCase(4, 10, "2d4+2")]
        [TestCase(4, 12, "1d8+1d2+2")]
        [TestCase(4, 16, "1d12+1d2+2")]
        [TestCase(4, 32, "1d20+1d10+2")]
        [TestCase(5, 5, "5")]
        [TestCase(5, 8, "1d4+4")]
        [TestCase(5, 9, "2d3+3")]
        [TestCase(5, 10, "1d6+4")]
        [TestCase(5, 12, "1d8+4")]
        [TestCase(5, 13, "1d8+1d2+3")]
        [TestCase(5, 14, "1d10+4")]
        [TestCase(5, 16, "1d12+4")]
        [TestCase(5, 18, "1d12+1d3+3")]
        [TestCase(5, 20, "3d6+2")]
        [TestCase(5, 30, "1d20+2d4+2")]
        [TestCase(5, 50, "2d20+1d8+2")]
        [TestCase(6, 6, "6")]
        [TestCase(6, 7, "1d2+5")]
        [TestCase(6, 8, "1d3+5")]
        [TestCase(6, 9, "1d4+5")]
        [TestCase(6, 10, "2d3+4")]
        [TestCase(6, 11, "1d6+5")]
        [TestCase(6, 13, "1d8+5")]
        [TestCase(6, 15, "1d10+5")]
        [TestCase(6, 18, "1d12+1d2+4")]
        [TestCase(6, 20, "2d8+4")]
        [TestCase(6, 30, "1d20+1d6+4")]
        [TestCase(6, 45, "2d20+1d2+3")]
        [TestCase(7, 7, "7")]
        [TestCase(7, 10, "1d4+6")]
        [TestCase(7, 11, "2d3+5")]
        [TestCase(7, 12, "1d6+6")]
        [TestCase(7, 16, "1d10+6")]
        [TestCase(7, 18, "1d12+6")]
        [TestCase(7, 30, "1d20+2d3+4")]
        [TestCase(7, 50, "2d20+1d6+4")]
        [TestCase(8, 8, "8")]
        [TestCase(8, 9, "1d2+7")]
        [TestCase(8, 18, "2d6+6")]
        [TestCase(8, 16, "1d8+1d2+6")]
        [TestCase(9, 9, "9")]
        [TestCase(9, 14, "1d6+8")]
        [TestCase(9, 16, "1d8+8")]
        [TestCase(9, 30, "1d20+1d3+7")]
        [TestCase(10, 10, "10")]
        [TestCase(10, 11, "1d2+9")]
        [TestCase(10, 20, "2d6+8")]
        [TestCase(10, 24, "2d8+8")]
        [TestCase(10, 40, "1d20+1d12+8")]
        [TestCase(10, 50, "2d20+1d3+7")]
        [TestCase(10, 60, "2d20+1d8+1d6+6")]
        [TestCase(10, 80, "3d20+1d12+1d3+5")]
        [TestCase(10, 100, "4d20+2d8+4")]
        [TestCase(11, 11, "11")]
        [TestCase(11, 20, "1d10+10")]
        [TestCase(11, 40, "1d20+2d6+8")]
        [TestCase(12, 12, "12")]
        [TestCase(12, 13, "1d2+11")]
        [TestCase(12, 22, "2d6+10")]
        [TestCase(12, 24, "1d12+1d2+10")]
        [TestCase(12, 30, "2d10+10")]
        [TestCase(13, 13, "13")]
        [TestCase(14, 14, "14")]
        [TestCase(14, 15, "1d2+13")]
        [TestCase(15, 15, "15")]
        [TestCase(15, 30, "3d6+12")]
        [TestCase(15, 50, "1d20+1d10+1d8+12")]
        [TestCase(15, 150, "1d100+4d10+10")]
        [TestCase(16, 16, "16")]
        [TestCase(16, 17, "1d2+15")]
        [TestCase(17, 17, "17")]
        [TestCase(18, 18, "18")]
        [TestCase(18, 19, "1d2+17")]
        [TestCase(18, 72, "2d20+1d10+1d8+14")]
        [TestCase(19, 19, "19")]
        [TestCase(20, 20, "20")]
        [TestCase(20, 50, "1d20+1d12+18")]
        [TestCase(20, 80, "3d20+1d4+16")]
        [TestCase(20, 150, "1d100+2d12+1d10+16")]
        [TestCase(20, 160, "1d100+2d20+1d4+16")]
        [TestCase(20, 200, "1d100+4d20+1d6+14")]
        [TestCase(21, 30, "1d10+20")]
        [TestCase(21, 40, "1d20+20")]
        [TestCase(30, 50, "1d20+1d2+28")]
        [TestCase(30, 60, "1d20+1d12+28")]
        [TestCase(30, 100, "3d20+1d12+1d3+25")]
        [TestCase(30, 300, "2d100+3d20+3d6+22")]
        [TestCase(40, 400, "3d100+3d20+2d4+32")]
        [TestCase(45, 150, "1d100+2d4+42")]
        [TestCase(70, 160, "4d20+2d8+64")]
        [TestCase(100, 400, "3d100+1d4+96")]
        public void Roll(int lower, int upper, string expectedRoll)
        {
            var roll = RollHelper.GetRoll(lower, upper);
            Assert.That(roll, Is.EqualTo(expectedRoll));
        }

        [TestCase(1, 2, 2, "1")]
        [TestCase(6, 7, 9, "1d3")]
        [TestCase(6, 8, 10, "1d3+1")]
        [TestCase(6, 10, 18, "1d8+1d2+2")]
        [TestCase(9, 14, 27, "1d12+1d3+3")]
        [TestCase(9, 15, 27, "1d12+1d2+4")]
        [TestCase(12, 19, 36, "1d12+2d4+4")]
        [TestCase(15, 22, 45, "1d20+2d3+4")]
        public void Roll(int baseAmount, int lower, int upper, string expectedRoll)
        {
            var roll = RollHelper.GetRoll(baseAmount, lower, upper);
            Assert.That(roll, Is.EqualTo(expectedRoll));
        }

        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(0, 4)]
        [TestCase(0, 5)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(1, 3)]
        [TestCase(1, 4)]
        [TestCase(1, 5)]
        [TestCase(1, 6)]
        [TestCase(1, 7)]
        [TestCase(1, 8)]
        [TestCase(1, 9)]
        [TestCase(1, 10)]
        [TestCase(1, 11)]
        [TestCase(1, 12)]
        [TestCase(2, 2)]
        [TestCase(2, 3)]
        [TestCase(2, 4)]
        [TestCase(2, 5)]
        [TestCase(2, 6)]
        [TestCase(2, 7)]
        [TestCase(2, 8)]
        [TestCase(2, 10)]
        [TestCase(2, 12)]
        [TestCase(2, 15)]
        [TestCase(2, 13)]
        [TestCase(2, 20)]
        [TestCase(3, 3)]
        [TestCase(3, 4)]
        [TestCase(3, 5)]
        [TestCase(3, 6)]
        [TestCase(3, 8)]
        [TestCase(3, 9)]
        [TestCase(3, 10)]
        [TestCase(3, 12)]
        [TestCase(3, 13)]
        [TestCase(3, 18)]
        [TestCase(3, 20)]
        [TestCase(3, 28)]
        [TestCase(4, 4)]
        [TestCase(4, 5)]
        [TestCase(4, 6)]
        [TestCase(4, 7)]
        [TestCase(4, 8)]
        [TestCase(4, 9)]
        [TestCase(4, 10)]
        [TestCase(4, 12)]
        [TestCase(4, 16)]
        [TestCase(4, 32)]
        [TestCase(5, 5)]
        [TestCase(5, 8)]
        [TestCase(5, 9)]
        [TestCase(5, 10)]
        [TestCase(5, 12)]
        [TestCase(5, 13)]
        [TestCase(5, 14)]
        [TestCase(5, 16)]
        [TestCase(5, 18)]
        [TestCase(5, 20)]
        [TestCase(5, 30)]
        [TestCase(5, 50)]
        [TestCase(6, 6)]
        [TestCase(6, 7)]
        [TestCase(6, 8)]
        [TestCase(6, 9)]
        [TestCase(6, 10)]
        [TestCase(6, 11)]
        [TestCase(6, 13)]
        [TestCase(6, 15)]
        [TestCase(6, 18)]
        [TestCase(6, 20)]
        [TestCase(6, 30)]
        [TestCase(6, 45)]
        [TestCase(7, 7)]
        [TestCase(7, 10)]
        [TestCase(7, 11)]
        [TestCase(7, 12)]
        [TestCase(7, 16)]
        [TestCase(7, 18)]
        [TestCase(7, 30)]
        [TestCase(7, 50)]
        [TestCase(8, 8)]
        [TestCase(8, 9)]
        [TestCase(8, 18)]
        [TestCase(8, 16)]
        [TestCase(9, 9)]
        [TestCase(9, 14)]
        [TestCase(9, 16)]
        [TestCase(9, 30)]
        [TestCase(10, 10)]
        [TestCase(10, 11)]
        [TestCase(10, 20)]
        [TestCase(10, 24)]
        [TestCase(10, 40)]
        [TestCase(10, 50)]
        [TestCase(10, 60)]
        [TestCase(10, 80)]
        [TestCase(10, 100)]
        [TestCase(11, 11)]
        [TestCase(11, 20)]
        [TestCase(11, 40)]
        [TestCase(12, 12)]
        [TestCase(12, 13)]
        [TestCase(12, 22)]
        [TestCase(12, 24)]
        [TestCase(12, 30)]
        [TestCase(13, 13)]
        [TestCase(14, 14)]
        [TestCase(14, 15)]
        [TestCase(15, 15)]
        [TestCase(15, 30)]
        [TestCase(15, 50)]
        [TestCase(15, 150)]
        [TestCase(16, 16)]
        [TestCase(16, 17)]
        [TestCase(17, 17)]
        [TestCase(18, 18)]
        [TestCase(18, 19)]
        [TestCase(18, 72)]
        [TestCase(19, 19)]
        [TestCase(20, 20)]
        [TestCase(20, 50)]
        [TestCase(20, 80)]
        [TestCase(20, 150)]
        [TestCase(20, 160)]
        [TestCase(20, 200)]
        [TestCase(21, 30)]
        [TestCase(21, 40)]
        [TestCase(30, 50)]
        [TestCase(30, 60)]
        [TestCase(30, 100)]
        [TestCase(30, 300)]
        [TestCase(40, 400)]
        [TestCase(45, 150)]
        [TestCase(70, 160)]
        [TestCase(100, 400)]
        public void RollCollection(int lower, int upper)
        {
            var rollCollection = RollHelper.GetRollCollection(lower, upper);
            Assert.That(rollCollection.Lower, Is.EqualTo(lower));
            Assert.That(rollCollection.Upper, Is.EqualTo(upper));
            Assert.That(rollCollection.Matches(lower, upper), Is.True);
        }
    }
}
