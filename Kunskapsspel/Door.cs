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
        public string goesTo;
        public Door(string nextRoomName, Point location, Size size, GameForm gameForm)
        {
            CreateBody(gameForm, location, size);
            this.goesTo = nextRoomName;
        }
        public PictureBox doorBody;
        private void CreateBody(GameForm gameForm, Point location, Size size)
        {
            doorBody = new PictureBox()
            {
                Location = location,
                Size = size,

            };
            gameForm.Controls.Add(doorBody);
            gameForm.Hide();
        }
    }
}
