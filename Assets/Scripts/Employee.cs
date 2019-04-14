namespace Tadget
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [Serializable]
    public class Employee
    {
        public List<Skill> skills;
        public Productivity productivity;

        public Employee(List<Skill> skills, Productivity productivity)
        {
            this.skills = skills;
            this.productivity = productivity;
        }
    }
}
