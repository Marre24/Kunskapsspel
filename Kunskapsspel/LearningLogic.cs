using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel
{
    internal class LearningLogic
    {
        private readonly Problems activeProblem;
        private Timer solutionTimer;
        readonly LearningTime learningTime;
        private int seconds = 0;
        private int minutes = 0;

        public Problems GetActiveProblem { get => activeProblem; set { } }

        public LearningLogic(LearningTime learningTime)
        {
            activeProblem = new Problems();

            CreateTimer();
            this.learningTime = learningTime;
        }

        public void CheckAnswer(string answer)
        {
            answer = answer.Trim();
            foreach (char c in answer)
            {
                if (c < '0' || c > '9')
                {
                    MessageBox.Show("Svaret innehöll inte bara siffror.");
                    return;
                }
            }
            
            if (answer == activeProblem.solution)
                RightAnswer();
            else
                WrongAnswer();    
        }
        
        private void WrongAnswer()
        {
            MessageBox.Show("Fel Svar");
        }

        private void RightAnswer()
        {
            MessageBox.Show("Rätt svar");
        }
        
        private void CreateTimer()
        {
            solutionTimer = new Timer()
            {
                Interval = 1000,
            };
            solutionTimer.Tick += UppdateTime;
            solutionTimer.Start();
        }

        private void UppdateTime(object sender, EventArgs e)
        {
            if (++seconds >= 60)
            {
                minutes++;
                seconds -= 60;
            }

            learningTime.timeTextBox.Text = $"{minutes}m {seconds}s";
        }
    }
}
