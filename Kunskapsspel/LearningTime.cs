using Kunskapsspel.Scenes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel
{
    public partial class LearningTime : System.Windows.Forms.Form
    {
        public Label timeTextBox;
        private readonly TimerClass timerClass;
        public LearningTime(TimerClass timerClass)
        {
            this.timerClass = timerClass;
            timerClass.Stop();
            InitializeComponent();
            FormClosing += LearningTime_FormClosing;
            LearningLogic learningLogic = new LearningLogic(this);
            LearningScene learningScene = new LearningScene(this, learningLogic);
        }

        private void LearningTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerClass.Start();
        }
    }
}
