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
    public class SimpleRoom : IRoom
    {
        public List<FloorSegment> floorSegments = new List<FloorSegment>();
        public List<InteractableObject> interactableObjects = new List<InteractableObject>();
        public List<PictureBox> hiddenPictureBoxes= new List<PictureBox>();
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
            UppdatePositions();

            foreach (PictureBox pictureBox in allPictureBoxes)
            {
                pictureBox.Show();
            }
            form.BackColor = backColor;
        }

        private void UppdatePositions()
        {
            foreach (Door door in doors)
            {
                door.doorBody.Location = door.originalLocation;
            }

            foreach (FloorSegment floor in floorSegments)
            {
                floor.FloorBody.Location = floor.OrginalLocation;
            }

            foreach (InteractableObject interactableObject in interactableObjects)
            {
                interactableObject.itemBody.Location = interactableObject.OrginalLocation;
            }
        }

        private void CreateDoors()
        {
            Door exit = new Door(Rooms.second, new Point(3000 - 500, 0), new Size(500, 1000), form);
            doors.Add(exit);
            allPictureBoxes.Add(exit.doorBody);
        }

        private void CreateBackground()
        {
            FloorSegment floorSegment = new FloorSegment(form, this, new Point(0, 0), new Size(3000, 1000));

            FloorSegment floorSegment2 = new FloorSegment(form, this, new Point(0, floorSegment.OrginalLocation.Y + floorSegment.Height), new Size(1000, 1000));

        }

        private void CreateInteractableObjects()
        {
            InteractableObject interactableObject = new InteractableObject(new Point(1500, 500), new Size(300, 300), Image.FromFile(@"./Resources/Capybara.jpg"), form, floorSegments);
            allPictureBoxes.Add(interactableObject.itemBody);
            interactableObjects.Add(interactableObject);
            hiddenPictureBoxes.Add(interactableObject.hiddenBody);

        }

        public List<FloorSegment> GetFloorSegments()
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

        public List<PictureBox> GetHiddenPictureBoxes()
        {
            return hiddenPictureBoxes;
        }
    }
}
