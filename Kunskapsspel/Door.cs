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

        public Door(Rooms leedsTo, Point location, Size size, GameForm gameForm, bool isOpen, Color color)
        {
            originalLocation = location;
            target = leedsTo;
            CreateBody(gameForm, location, size, color);
            this.opened = isOpen;
        }
        private void CreateBody(GameForm gameForm, Point location, Size size, Color color)
        {
            doorBody = new PictureBox()
            {
                Location = location,
                Size = size,
                Visible = false,
                BackColor = color,
            };
            gameForm.Controls.Add(doorBody);
            doorBody.BringToFront();
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
