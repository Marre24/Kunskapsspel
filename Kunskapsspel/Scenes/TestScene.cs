using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel.Scenes
{
    public class TestScene : GraficalScene
    {
        public TestScene(GameForm gameForm) : base(gameForm)
        {
            CreateBackground();
            CreateInteractableObjects();
        }

        public override void CreateBackground()
        {
            PictureBox mainFloor = new PictureBox()
            {
                Size = new Size(3000, 1000),
                Location = new Point(0, 0),
                Image = Image.FromFile(@"./Resources/Capybara.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            form.Controls.Add(mainFloor);
            allPictureBoxes.Add(mainFloor);
            floors.Add(mainFloor);

            PictureBox secondFloor = new PictureBox()
            {
                Size = new Size(1000, 1000),
                Location = new Point(500, mainFloor.Height),
                Image = Image.FromFile(@"./Resources/Capybara.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            form.Controls.Add(secondFloor);
            allPictureBoxes.Add(secondFloor);
            floors.Add(secondFloor);

        }

        public override void CreateInteractableObjects()
        {
            for (int i = 1; i <= 4; i++)
            {
                InteractableObject interactableObject = new InteractableObject(new Point(1500 * i, 500), new Size(300,300),Image.FromFile(@"./Resources/Capybara.jpg"), form);
                interactableObject.itemBody.BringToFront();
                allPictureBoxes.Add(interactableObject.itemBody);
                interactableObjects.Add(interactableObject);
            }
        }
    }
}
