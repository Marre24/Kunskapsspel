using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel
{
    public class FloorSegment
    {
        private Point location;
        public int Height { get => size.Height; set { } }

        public Point OrginalLocation { get => location; set { } }

        public PictureBox FloorBody { get => floorBody; set { } }

        public int Width { get => floorBody.Width;}

        private PictureBox floorBody;

        private Size size;

        public FloorSegment(GameForm gameForm, IRoom room, Point location, Size size)
        {
            this.location = location;
            this.size = size;

            floorBody = new PictureBox()
            {
                Size = size,
                Location = location,
                Image = Image.FromFile(@"./Resources/Capybara.jpg"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = false,
            };
            gameForm.Controls.Add(floorBody);
            room.GetAllPictureBoxes().Add(floorBody);
            room.GetFloorSegments().Add(this);
        }
    }
}
