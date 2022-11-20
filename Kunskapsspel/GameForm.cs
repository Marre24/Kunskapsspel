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
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace Kunskapsspel
{
    public partial class GameForm : System.Windows.Forms.Form
    {
        public PictureBox background;
        private readonly StartScreenForm startScreenForm;
        public dynamic activeScene;

        public GameForm(StartScreenForm startScreenForm)
        {
            InitializeComponent();
            this.startScreenForm = startScreenForm;
            this.WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            TimerClass timerClass = new TimerClass("TestScene", this);
            CreateExitButton();
            BackColor = Color.Black;
        }

        private void CreateExitButton()
        {
            Button exitBtn = new Button()
            {
                Size = new Size(50, 50),
                Location = new Point(Screen.PrimaryScreen.Bounds.Width - 50, 0),
                Text = "Exit",
                ForeColor = Color.White,
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
            };
            Controls.Add(exitBtn);
            exitBtn.BringToFront();
            exitBtn.Click += ExitBtn_Click;
        }

        public void ChangeSceneTo(string sceneName)
        {
            //activeScene.FadeAway();

            var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        from t in assembly.GetTypes()
                        where t.Name == sceneName
                        select t).FirstOrDefault();

            if (type == null)
                throw new InvalidOperationException("Type not found");

            activeScene = Activator.CreateInstance(type, new GameForm(startScreenForm));

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            startScreenForm.Show();
        }
    }
}
