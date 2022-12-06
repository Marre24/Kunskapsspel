using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel.Scenes
{
    class LearnComplexNumbersScene : IRoom
    {
        private readonly ImageManager imageManager = new ImageManager();
        public List<FloorSegment> floorSegments = new List<FloorSegment>();
        public List<InteractableObject> interactableObjects = new List<InteractableObject>();
        public List<PictureBox> hiddenPictureBoxes = new List<PictureBox>();
        public List<PictureBox> allPictureBoxes = new List<PictureBox>();
        private readonly List<Door> doors = new List<Door>();
        private readonly List<Enemy> enemies = new List<Enemy>();
        public GameForm gameForm;
        public LearnComplexNumbersScene(GameForm gameForm, TimerClass timerClass)
        {
            this.gameForm = gameForm;
            CreateFloorSegments();
            CreateDoors();
            CreateInteractableObjects();
            CreateEnemies(timerClass);
            CreateWalls();
        }

        public void CreateFloorSegments()
        {
            FloorSegment floorSegment = new FloorSegment(gameForm, this, new Point(0, Screen.PrimaryScreen.Bounds.Height / 2 - 1000 / 2), new Size(1500, 1000), Color.FromArgb(255, 41, 117));

            Size size = new Size(1000, 1500);
            new FloorSegment(gameForm, this, new Point(floorSegment.FloorBody.Location.X + floorSegment.Width - size.Width, floorSegment.FloorBody.Location.Y + floorSegment.Height), size, Color.FromArgb(255, 41, 117));

        }

        public void CreateDoors()
        {
            //Door exit = new Door(Rooms.LearnControlsScene, new Point(3950, Screen.PrimaryScreen.Bounds.Height / 2 - 500 / 2), new Size(50, 500), gameForm, false);
            //doors.Add(exit);
            //allPictureBoxes.Add(exit.doorBody);

            Door entry = new Door(Rooms.LearnControlsScene, new Point(3950, Screen.PrimaryScreen.Bounds.Height / 2 - 500 / 2), new Size(50, 500), gameForm, true, Color.FromArgb(44, 123, 55));
            doors.Add(entry);
            allPictureBoxes.Add(entry.doorBody);
        }

        public void CreateEnemies(TimerClass timer)
        {
            
        }

        public void CreateInteractableObjects()
        {
            InteractableObject npc = new InteractableObject(new Point(4000, doors[0].doorBody.Location.Y - 200), new Size(300, 300), imageManager.GetGeneralGoofyImage, gameForm, floorSegments);
            allPictureBoxes.Add(npc.hiddenBody);
            interactableObjects.Add(npc);
        }

        public void CreateWalls()
        {
        }

        public void StartScene()
        {
            UppdatePositions();

            foreach (Door door in doors)
                door.doorBody.Show();
            foreach (FloorSegment floorsegment in floorSegments)
                floorsegment.FloorBody.Show();
            foreach (InteractableObject interactableObject in interactableObjects)
                interactableObject.itemBody.Show();
            foreach (Enemy enemy in enemies)
                enemy.body.Show();
        }

        public void UppdatePositions()
        {
            foreach (Door door in doors)
                door.doorBody.Location = door.originalLocation;

            foreach (FloorSegment floor in floorSegments)
                floor.FloorBody.Location = floor.OrginalLocation;

            foreach (InteractableObject interactableObject in interactableObjects)
                interactableObject.itemBody.Location = interactableObject.OrginalLocation;

            foreach (Enemy enemy in enemies)
                enemy.body.Location = enemy.GetOriginalLocation;
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

        public List<Enemy> GetEnemies()
        {
            return enemies;
        }

        
    }
}
