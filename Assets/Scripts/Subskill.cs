namespace Tadget
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [Serializable]
    public class Subskill
    {
        public int level;
        public string name;
        public Type type;

        public enum Type
        {
            Base,
            Multiplier,
            CriticalChance
        }
    }
}
