using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel.Scenes
{
    class StartingScene
    {
        readonly StartScreenForm startScreenForm;
        public StartingScene(StartScreenForm startScreenForm)
        {
            startScreenForm.WindowState = FormWindowState.Maximized;
            startScreenForm.FormBorderStyle = FormBorderStyle.None;
            this.startScreenForm = startScreenForm;
            CreateControls();
        }

        private void CreateControls()
        {
            PictureBox background = new PictureBox()
            {
                Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height),
                Location = new Point(0, 0),
                Image = Image.FromFile(@"./Resources/Capybara.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            startScreenForm.Controls.Add(background);


            Button exitBtn = new Button()
            {
                Size = new Size(50, 50),
                Location = new Point(Screen.PrimaryScreen.Bounds.Width - 50, 0),
                Text = "Exit",
                TabStop = false,
            };
            startScreenForm.Controls.Add(exitBtn);
            exitBtn.BringToFront();
            exitBtn.Click += ExitBtn_Click;


            Button startGameBtn = new Button()
            {
                Size = new Size(50, 50),
                Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - 25, 700),
                Text = "Start",
                TabStop = false,
            };
            startScreenForm.Controls.Add(startGameBtn);
            startGameBtn.BringToFront();
            startGameBtn.Click += StartGame_Click;


            ComboBox chapters = new ComboBox()
            {
                Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - 75, 500),
                Size = new Size(300, 40),
                Font = new Font(new FontFamily("Comic Sans MS"), 20),
                DropDownStyle = ComboBoxStyle.DropDownList,
            };
            chapters.Items.Add("Komplexa tal");
            startScreenForm.Controls.Add(chapters);
            chapters.BringToFront();

            Label label = new Label() 
            {
                Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - 240, 500),
                Size = new Size(165, 45),
                Font = new Font(new FontFamily("Comic Sans MS"), 20),
                Text = "Välj Kapitel",
            };

            startScreenForm.Controls.Add(label);
            label.BringToFront();

        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm(startScreenForm);
            gameForm.Show();
            startScreenForm.Hide();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            startScreenForm.Close();
        }

    }
}
