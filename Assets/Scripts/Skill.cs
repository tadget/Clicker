namespace Tadget
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [Serializable]
    public class Skill
    {
        public int level;
        public string name;
        public int tier;
        public List<Subskill> subskills;

        private float _work;

        public float GetWork()
        {
            _work = 0;
            foreach (var subskill in subskills)
            {
                switch (subskill.type)
                {
                    case Subskill.Type.Base:
                        _work += subskill.level;
                        break;
                    case Subskill.Type.Multiplier:
                        _work *= 1 + subskill.level;
                        break;
                    case Subskill.Type.CriticalChance:
                        if (F.rnd.Next(100) < subskill.level)
                        {
                            _work *= level;
                        }

                        break;
                }
            }
            return _work;
        }
    }
}
