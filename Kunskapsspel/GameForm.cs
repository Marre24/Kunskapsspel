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
    public partial class GameForm : Form
    {
        private readonly StartScreenForm startScreenForm;

        public GameForm(StartScreenForm startScreenForm)
        {
            this.startScreenForm = startScreenForm;

            new GameManager(this);

            InitializeComponent();
            CreateDefaultGrafics();
        }

        private void CreateDefaultGrafics()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.Black;

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

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            startScreenForm.Show();
        }
    }
}
