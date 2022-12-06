using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public PictureBox hiddenBody;
        private readonly GameForm form;
        public bool isCurrentlyInUse = false;
        private Point orgiginalLocation;
        public Point OrginalLocation { get => orgiginalLocation; set { } }

        public int Left { get => itemBody.Location.X; set { } }
        public int Right { get => itemBody.Location.X + itemBody.Width; set { } }
        public int Top { get => itemBody.Location.Y; set { } }
        public int Bot { get => itemBody.Location.Y + itemBody.Height; set { } }


        public InteractableObject(Point ItemPoint, Size ItemSize, Image image, GameForm form, List<FloorSegment> floorSegments)
        {
            this.form = form;
            orgiginalLocation = ItemPoint;

            CreateBody(ItemPoint, ItemSize, image);
            foreach (FloorSegment floorSegment in floorSegments)
                if (AreInsideOfPictureBox(floorSegment.FloorBody, itemBody))
                {
                    itemBody.Parent = floorSegment.FloorBody;
                    //itemBody.Location = new Point(itemBody.Location.X, itemBody.Location.Y + 90);
                }

            CreateHiddenBody(itemBody.Location, ItemSize, image);
        }

        public void CreateBody(Point ItemPoint, Size ItemSize, Image image)
        {
            itemBody = new PictureBox()
            {
                Location = ItemPoint,
                Size = ItemSize,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = false,
            };
            form.Controls.Add(itemBody);
        }

        public void CreateHiddenBody(Point ItemPoint, Size ItemSize, Image image)
        {
            hiddenBody = new PictureBox()
            {
                Location = ItemPoint,
                Size = ItemSize,
                Image = image,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = false,
            };
            form.Controls.Add(hiddenBody);
        }

        public bool CanBeInteractedWith(Player player)
        {
            return (IsBetweenX(player.LeftLocation) || IsBetweenX(player.RightLocation)) && (IsBetweenY(player.TopLocation) || IsBetweenY(player.BottomLocation));
        }

        private bool IsBetweenX(int xCord)
        {
            return hiddenBody.Location.X <= xCord && hiddenBody.Location.X + hiddenBody.Width >= xCord;
        }

        private bool IsBetweenY(int xCord)
        {
            return hiddenBody.Location.Y <= xCord && hiddenBody.Location.Y + hiddenBody.Height >= xCord;
        }

        private bool AreInsideOfPictureBox(PictureBox biggerBox, PictureBox smallerBox)
        {
            return (biggerBox.Location.X <= smallerBox.Left && biggerBox.Location.X + biggerBox.Width >= smallerBox.Right) && (biggerBox.Location.Y <= smallerBox.Top && biggerBox.Location.Y + biggerBox.Height >= smallerBox.Bottom);
        }

    }
}
