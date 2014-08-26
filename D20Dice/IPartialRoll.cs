﻿using System;

namespace D20Dice
{
    public interface IPartialRoll
    {
        Int32 d2();
        Int32 d3();
        Int32 d4();
        Int32 d6();
        Int32 d8();
        Int32 d10();
        Int32 d12();
        Int32 d20();
        Int32 Percentile();
        Int32 d(Int32 die);
    }
}