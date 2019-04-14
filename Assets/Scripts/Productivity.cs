namespace Tadget
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [Serializable]
    public class Productivity
    {
        public float energy;
        public float motivation;
        public float boost;

        public Productivity(float energy, float motivation, float boost)
        {
            this.energy = energy;
            this.motivation = motivation;
            this.boost = boost;
        }
    }
}
