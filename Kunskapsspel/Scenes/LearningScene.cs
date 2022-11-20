using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel.Scenes
{
    internal class LearningScene
    {
        readonly LearningLogic learningLogic;
        string answer;
        TextBox answerTextBox;
        public LearningScene(LearningTime learningTime, LearningLogic learningLogic)
        {
            this.learningLogic = learningLogic;
            learningTime.StartPosition = FormStartPosition.CenterScreen;
            learningTime.Size = new Size(1000, Screen.PrimaryScreen.Bounds.Height);

            CreateObjects(learningTime);
        }

        private void CreateObjects(LearningTime learningTime)
        {
            TextBox problemTextBox = new TextBox()
            {
                Size = new Size(learningTime.Width, 300),
                Location = new Point(0, 0),
                Font = new Font(new FontFamily("Comic Sans MS"), 25),
                Text = learningLogic.GetActiveProblem.problem,
                TabStop = false,
                Enabled = false,
            };
            learningTime.Controls.Add(problemTextBox);

            Label answerFormatLbl = new Label()
            {
                Size = new Size(learningLogic.GetActiveProblem.answerFormat.Length * 20, 100),
                Location = new Point(0, problemTextBox.Height),
                Text = learningLogic.GetActiveProblem.answerFormat,
                Font = new Font(new FontFamily("Comic Sans MS"), 25),
            };
            learningTime.Controls.Add(answerFormatLbl);

            answerTextBox = new TextBox()
            {
                Size = new Size(learningTime.Width, 300),
                Location = new Point(answerFormatLbl.Width, problemTextBox.Height),
                Font = new Font(new FontFamily("Comic Sans MS"), 25),
                Text = learningLogic.GetActiveProblem.solution,
                TabStop = false,
            };
            learningTime.Controls.Add(answerTextBox);

            Button button = new Button()
            {
                Size = new Size(100, 100),
                Location = new Point(500, 600),
                Text = "Svara",
                TabStop = false,
            };
            learningTime.Controls.Add(button);
            button.Click += Button_Click;

            Label timeTextBox = new Label()
            {
                Size = new Size(learningTime.Width, 600),
                Location = new Point(0, problemTextBox.Height + 300),
                Font = new Font(new FontFamily("Comic Sans MS"), 25),
                Text = "0",
            };
            learningTime.Controls.Add(timeTextBox);
            learningTime.timeTextBox = timeTextBox;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            answer = answerTextBox.Text;
            learningLogic.CheckAnswer(answer);
        }

        //private void PlaySound()
        //{
        //    SoundPlayer simpleSound = new SoundPlayer("./Resources/vine-boom.wav");
        //    simpleSound.Play();
        //}
    }
}
