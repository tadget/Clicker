namespace Tadget
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class App : MonoBehaviour
    {
        private void Start()
        {
            Game();
        }

        public Whiteboard wb;

        public void Game()
        {
            UnitySystemConsoleRedirector.Redirect();

            List<Skill> skillset1 = new List<Skill>()
            {
                new Skill()
                {
                    level = 1,
                    name = "development",
                    subskills = new List<Subskill>()
                    {
                        new Subskill()
                        {
                            level = 2,
                            name = "c#",
                            type = Subskill.Type.Base
                        },
                        new Subskill()
                        {
                            level = 2,
                            name = "cheats",
                            type = Subskill.Type.Multiplier
                        },
                    }
                }
            };

            Employee employee1 = new Employee(skillset1, new Productivity(1f, 1f, 0f));

            wb = new Whiteboard();
            wb.stages.Add(new Whiteboard.Stage(0));
            wb.stages[0].TryAddEmployeeSkill(new Tuple<Employee, Skill>(employee1, employee1.skills[0]));

            ProduceGame();
        }

        public void ProduceGame()
        {
            if (wb == null) return;
            foreach (var stageWork in wb.GetWorkDone())
            {
                if(stageWork != null)
                    Debug.Log("Doing work " + stageWork);
            }
        }
    }
}
