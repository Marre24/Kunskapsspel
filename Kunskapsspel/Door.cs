using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel
{
    public class Door
    {
        public PictureBox doorBody;
        public Rooms target;
        public Point originalLocation;
        public bool opened;

        public Door(Rooms leedsTo, Point location, Size size, GameForm gameForm, bool open)
        {
            originalLocation = location;
            target = leedsTo;
            CreateBody(gameForm, location, size);
            this.opened = open;
        }
        private void CreateBody(GameForm gameForm, Point location, Size size)
        {
            doorBody = new PictureBox()
            {
                Location = location,
                Size = size,
                Visible = false,
            };
            gameForm.Controls.Add(doorBody);
        }

        public void Open()
        {
            opened = true;
        }

        public void Close() 
        { 
            opened = false; 
        }

    }
}
