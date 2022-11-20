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
    public class TestScene
    {
        public List<PictureBox> floors = new List<PictureBox>();
        public List<InteractableObject> interactableObjects = new List<InteractableObject>();
        public List<PictureBox> allPictureBoxes = new List<PictureBox>();
        public Door previousDoor;
        public Door nextDoor;
        public GameForm form;
        public TestScene(GameForm gameForm)
        {
            CreateBackground();
            CreateInteractableObjects();
            CreateDoors();
        }

        private void CreateDoors()
        {
            nextDoor = new Door("TestScene2", new Point(3000 - 500, 0), new Size(500, 1000), form);
            allPictureBoxes.Add(nextDoor.doorBody);

        }

        public void CreateBackground()
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

        public void CreateInteractableObjects()
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
