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
    public class SimpleRoom : Room
    {
        public List<PictureBox> floorSegments = new List<PictureBox>();
        public List<InteractableObject> interactableObjects = new List<InteractableObject>();
        public List<PictureBox> allPictureBoxes = new List<PictureBox>();
        private readonly List<Door> doors = new List<Door>();
        public GameForm form;
        private readonly Color backColor;
        public SimpleRoom(GameForm gameForm, Color backColor)
        {
            this.backColor = backColor;
            form = gameForm;
            CreateBackground();
            CreateInteractableObjects();
            CreateDoors();
        }

        public void StartScene()
        {
            foreach (PictureBox pictureBox in allPictureBoxes)
            {
                pictureBox.Show();
            }
            form.BackColor = backColor;
        }

        private void CreateDoors()
        {
            Door exit = new Door(Rooms.second, new Point(3000 - 500, 0), new Size(500, 1000), form);
            doors.Add(exit);
            allPictureBoxes.Add(exit.doorBody);
        }

        private void CreateBackground()
        {
            PictureBox mainFloor = new PictureBox()
            {
                Size = new Size(3000, 1000),
                Location = new Point(0, 0),
                Image = Image.FromFile(@"./Resources/Capybara.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = false,
            };
            form.Controls.Add(mainFloor);
            allPictureBoxes.Add(mainFloor);
            floorSegments.Add(mainFloor);

            PictureBox secondFloor = new PictureBox()
            {
                Size = new Size(1000, 1000),
                Location = new Point(500, mainFloor.Height),
                Image = Image.FromFile(@"./Resources/Capybara.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = false,
            };
            form.Controls.Add(secondFloor);
            allPictureBoxes.Add(secondFloor);
            floorSegments.Add(secondFloor);

        }

        private void CreateInteractableObjects()
        {
            for (int i = 1; i <= 4; i++)
            {
                InteractableObject interactableObject = new InteractableObject(new Point(1500 * i, 500), new Size(300,300),Image.FromFile(@"./Resources/Capybara.jpg"), form);
                interactableObject.itemBody.BringToFront();
                allPictureBoxes.Add(interactableObject.itemBody);
                interactableObjects.Add(interactableObject);
            }
        }

        public List<PictureBox> GetFloorSegments()
        {
            return floorSegments;

        }

        public List<PictureBox> GetAllPictureBoxes()
        {
            return allPictureBoxes;
        }

        public List<Door> GetDoors()
        {
            return doors;
        }

        public void EndScene()
        {
            foreach (PictureBox pictureBox in allPictureBoxes)
            {
                pictureBox.Hide();
            }
        }

        public List<InteractableObject> GetInteractableObjects()
        {
            return interactableObjects;
        }
    }
}
