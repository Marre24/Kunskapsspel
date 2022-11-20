using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel
{
    public class GraficalScene
    {
        public List<PictureBox> floors = new List<PictureBox>();
        public List<InteractableObject> interactableObjects = new List<InteractableObject>();
        public List<PictureBox> allPictureBoxes = new List<PictureBox>();
        public Door previousDoor;
        public Door nextDoor;
        public GameForm form;

        public GraficalScene(GameForm form)
        {
            this.form = form;
        }

        public void FadeAway()
        {
            foreach (PictureBox pictureBox in allPictureBoxes)
            {
                pictureBox.Hide();
            }
        }

        public virtual void CreateInteractableObjects() { }

        public virtual void CreateBackground() { }
    }
}
