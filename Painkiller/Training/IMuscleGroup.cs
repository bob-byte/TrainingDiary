﻿using System;

namespace Painkiller
{
    public interface IMuscleGroup
    {
        public String[] Exercises();
        public void Reps(out Int32 min, out Int32 max);
        public void Sets(out Int32 min, out Int32 max);
    }
}