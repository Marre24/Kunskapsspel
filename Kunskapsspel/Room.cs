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
        List<FloorSegment> GetFloorSegments();
        List<PictureBox> GetAllPictureBoxes();
        List<Door> GetDoors();
        void StartScene();
        void EndScene();
        List<InteractableObject> GetInteractableObjects();
        List<PictureBox> GetHiddenPictureBoxes();
        List<Enemy> GetEnemies();
    }
}
