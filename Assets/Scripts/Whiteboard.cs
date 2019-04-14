namespace Tadget
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Sirenix.OdinInspector;

    [Serializable]
    public class Whiteboard
    {
        public List<Stage> stages;

        [Serializable]
        public class Stage
        {
            public int minimumSkillTier;
            [ShowInInspector]
            public List<Tuple<Employee, Skill>> employeeSkills;

            public Stage(int minimumSkillTier)
            {
                this.minimumSkillTier = minimumSkillTier;
                employeeSkills = new List<Tuple<Employee, Skill>>();
            }

            public bool TryAddEmployeeSkill(Tuple<Employee, Skill> employeeSkill)
            {
                if (employeeSkills == null)
                {
                    employeeSkills = new List<Tuple<Employee, Skill>>();
                }
                // If the skill fits the tier and the employee is not already assigned for the stage
                if (employeeSkill.Item2.tier >= minimumSkillTier &&
                    !employeeSkills.Exists(x => x.Item1 == employeeSkill.Item1))
                {
                    employeeSkills.Add(employeeSkill);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private float _work;
            public float GetWork()
            {
                _work = 0;
                foreach (var employeeSkill in employeeSkills)
                {
                    if(employeeSkill.Item1.productivity.energy > 0f)
                        _work += employeeSkill.Item2.GetWork();
                    // TODO add boost, motivation effects
                }
                return _work;
            }
        }

        public Whiteboard()
        {
            stages = new List<Stage>();
        }

        public IEnumerable GetWorkDone()
        {
            foreach (var stage in stages)
            {
                yield return stage.GetWork();
            }
            yield return null;
        }
    }
}
