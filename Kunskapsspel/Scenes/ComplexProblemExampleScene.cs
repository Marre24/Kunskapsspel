using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel.Scenes
{
    class ComplexProblemExampleScene : IRoom
    {
        public List<FloorSegment> floorSegments = new List<FloorSegment>();
        public List<InteractableObject> interactableObjects = new List<InteractableObject>();
        public List<PictureBox> hiddenPictureBoxes = new List<PictureBox>();
        public List<PictureBox> allPictureBoxes = new List<PictureBox>();
        private readonly List<Door> doors = new List<Door>();
        private readonly List<Enemy> enemies = new List<Enemy>();
        public GameForm gameForm;
        private readonly Player player;
        public ComplexProblemExampleScene(GameForm gameForm, TimerClass timerClass, Player player)
        {
            this.player = player;
            this.gameForm = gameForm;
            CreateFloorSegments();
            CreateInteractableObjects();
            CreateDoors();
            CreateEnemies(timerClass);
        }

        public void CreateFloorSegments()
        {
            throw new NotImplementedException();
        }

        public void CreateDoors()
        {
            throw new NotImplementedException();
        }

        public void CreateEnemies(TimerClass timer)
        {
            throw new NotImplementedException();
        }

        public void CreateInteractableObjects()
        {
            throw new NotImplementedException();
        }

        public void StartScene()
        {
            UppdatePositions();

            foreach (PictureBox pictureBox in allPictureBoxes)
            {
                pictureBox.Show();
            }
        }

        public void UppdatePositions()
        {
            player.body.Location = player.originalLocation;

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

        public void CreateWalls()
        {
            throw new NotImplementedException();
        }
    }
}
