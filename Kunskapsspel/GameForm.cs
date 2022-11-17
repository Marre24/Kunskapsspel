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
    public partial class GameForm : System.Windows.Forms.Form
    {
        public PictureBox background;
        readonly TestScene testScene;
        private readonly StartScreenForm startScreenForm;
        public GameForm(StartScreenForm startScreenForm)
        {
            InitializeComponent();
            this.startScreenForm = startScreenForm;
            this.WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            testScene = new TestScene(this);
            new TimerClass(testScene, this);
            CreateExitButton();
            BackColor = Color.Green;
        }

        private void CreateExitButton()
        {
            Button exitBtn = new Button()
            {
                Size = new Size(50,50),
                Location = new Point(Screen.PrimaryScreen.Bounds.Width - 50, 0),
                Text = "Exit",
                TabStop = false,
                FlatStyle = FlatStyle.Flat,
            };
            Controls.Add(exitBtn);
            exitBtn.BringToFront();
            exitBtn.Click += ExitBtn_Click;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            startScreenForm.Show();
        }
    }
}
