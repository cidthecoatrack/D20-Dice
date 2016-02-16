﻿namespace RollGen
{
    public abstract class PartialRoll
    {
        public int d2() => d(2);
        public int d3() => d(3);
        public int d4() => d(4);
        public int d6() => d(6);
        public int d8() => d(8);
        public int d10() => d(10);
        public int d12() => d(12);
        public int d20() => d(20);
        public int Percentile() => d(100);
        public abstract int d(int die);
    }
}