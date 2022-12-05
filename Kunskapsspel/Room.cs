using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel
{
    public interface IRoom
    {

        void CreateEnemies(TimerClass timer);
        void CreateDoors();
        void CreateFloorSegments();
        void CreateInteractableObjects();
        void UppdatePositions();
        List<FloorSegment> GetFloorSegments();
        List<PictureBox> GetAllPictureBoxes();
        List<InteractableObject> GetInteractableObjects();
        List<Door> GetDoors();
        void StartScene();
        void EndScene();
        List<Enemy> GetEnemies();
    }
}
