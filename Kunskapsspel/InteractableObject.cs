using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel
{
    public class InteractableObject
    {
        public PictureBox itemBody;
        private readonly GameForm form;
        public bool isCurrentlyInUse = false;

        public int Left { get => itemBody.Location.X; set { } }
        public int Right { get => itemBody.Location.X + itemBody.Width; set { } }
        public int Top { get => itemBody.Location.Y; set { } }
        public int Bot { get => itemBody.Location.Y + itemBody.Height; set { } }


        public InteractableObject(Point ItemTopLeftPoint, Size ItemSize, Image image, GameForm form)
        {
            this.form = form;
            CreateBody(ItemTopLeftPoint, ItemSize, image);
        }

        public void CreateBody(Point ItemTopLeftPoint, Size ItemSize, Image image)
        {
            itemBody = new PictureBox()
            {
                Location = ItemTopLeftPoint,
                Size = ItemSize,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = false,
                //BackColor = Color.Transparent,    
            };
            form.Controls.Add(itemBody);
            //itemBody.Parent = form.background;
        }

        public bool CanBeInteractedWith(Player player)                              // Change
        {
            if ((PointInbetween(Left, Right, player.LeftLocation) || PointInbetween(Left, Right, player.RightLocation)) && PointInbetween(Bot, Top, player.TopLocation))
                return true;

            return false;
        }

        private int highPoint = 0;
        private int lowPoint = 0;

        private bool PointInbetween(int pointA, int pointB, int comparePoint)
        {
            if (pointA == pointB)
            {
                MessageBox.Show("Error");
                return false;
            }

            if (pointA > pointB)
            {
                highPoint = pointA;
                lowPoint = pointB;
            }
            else
            {
                highPoint = pointB;
                lowPoint = pointA;
            }

            if (lowPoint <= comparePoint && highPoint >= comparePoint)
                return true;

            return false;
        }
    }
}
