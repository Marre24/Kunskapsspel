using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel
{
    public class Enemy
    {
        public bool defeated = false;
        public PictureBox body;
        public PictureBox hiddenBody;
        private TimerClass timerClass;
        private Point originalPoint;
        public Point GetOriginalLocation { get => originalPoint; }

        public Enemy(GameForm gameForm, Point location, Size size, Image image, List<FloorSegment> floorSegments, TimerClass timerClass)
        {
            this.timerClass = timerClass;
            originalPoint = location;

            CreateBody(gameForm, location, size, image);
            foreach (FloorSegment floorSegment in floorSegments)
            {
                if (AreInsideOfPictureBox(floorSegment.FloorBody, body))
                    body.Parent = floorSegment.FloorBody;
            }
            CreateHiddenBody(gameForm, location, size);
        }

        private void CreateHiddenBody(GameForm gameForm, Point location, Size size)
        {
            hiddenBody = new PictureBox()
            {
                Size = size,
                Location = location,
            };
            gameForm.Controls.Add(hiddenBody);
        }

        private void CreateBody(GameForm gameForm, Point location, Size size, Image image)
        {
            body = new PictureBox()
            {
                Image = image,
                Location= location,
                Size = size,
                Visible = false,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            gameForm.Controls.Add(body);
            body.BringToFront();
        }

        public void StartInteraction()
        {
            LearningTime learningTime = new LearningTime(timerClass);
            learningTime.Show();
        }
        private bool AreInsideOfPictureBox(PictureBox biggerBox, PictureBox smallerBox)
        {
            return (biggerBox.Location.X <= smallerBox.Left && biggerBox.Location.X + biggerBox.Width >= smallerBox.Right) && (biggerBox.Location.Y <= smallerBox.Top && biggerBox.Location.Y + biggerBox.Height >= smallerBox.Bottom);
        }
    }
}
