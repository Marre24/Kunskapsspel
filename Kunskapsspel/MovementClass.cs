using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Kunskapsspel
{
    public class MovementClass
    {
        private const int movementSpeed = 35;
        private bool movePlayerX = false;

        public MovementClass() { }
        public void Move(Player player, IRoom room)
        {
            (int x, int y) = GetOffset();

            (bool willMoveCameraX, bool willMoveCameraY) = CanMoveTo(room.GetFloorSegments(), x, y, player);

            //movePlayerX = false;
            //foreach (FloorSegment floorSegment in room.GetFloorSegments())
            //    if (IsTouching(player, floorSegment.FloorBody))
            //        if ((IsAtEdge(x, floorSegment.FloorBody) && willMoveCameraX) || (player.body.Location != player.originalLocation))
            //        {
            //            willMoveCameraX = false;
            //            movePlayerX = true;
            //        }

            //if (movePlayerX && (player.body.Location.X - x > 0)) // && player.body.Location.X - x < player.originalLocation.X + x
              //  player.body.Location = new Point(player.body.Location.X - x, player.body.Location.Y);

            //if (movePlayerX && (player.body.Location.X + player.body.Width - x < Screen.PrimaryScreen.Bounds.Width))//&& player.body.Location.X - x > player.originalLocation.X
            //    player.body.Location = new Point(player.body.Location.X - x, player.body.Location.Y);



            if (willMoveCameraX)
                foreach (PictureBox pb in room.GetAllPictureBoxes())
                    pb.Location = new Point(pb.Location.X + x, pb.Location.Y);

            if (willMoveCameraY)
                foreach (PictureBox pb in room.GetAllPictureBoxes())
                    pb.Location = new Point(pb.Location.X, pb.Location.Y + y);
        }

        private bool IsAtEdge(int xOffset, PictureBox pictureBox)
        {
            return (0 < pictureBox.Location.X + xOffset) || (Screen.PrimaryScreen.Bounds.Width > pictureBox.Location.X + xOffset + pictureBox.Width);
        }

        public bool IsTouching(Player player, PictureBox pictureBox)
        {
            return (IsBetweenX(player.LeftLocation, pictureBox) || IsBetweenX(player.RightLocation, pictureBox)) && (IsBetweenY(player.TopLocation, pictureBox) || IsBetweenY(player.BottomLocation, pictureBox));
        }
        private bool IsBetweenX(int xCord, PictureBox pictureBox)
        {
            return pictureBox.Location.X <= xCord && pictureBox.Location.X + pictureBox.Width >= xCord;
        }

        private bool IsBetweenY(int yCord, PictureBox pictureBox)
        {
            return pictureBox.Location.Y <= yCord && pictureBox.Location.Y + pictureBox.Height >= yCord;
        }

        private Tuple<int, int> GetOffset()
        {
            int x = 0;
            int y = 0;

            if (Keyboard.IsKeyDown(Key.W))
                y += movementSpeed;
            if (Keyboard.IsKeyDown(Key.S))
                y -= movementSpeed;
            if (Keyboard.IsKeyDown(Key.A))
                x += movementSpeed;
            if (Keyboard.IsKeyDown(Key.D))
                x -= movementSpeed;

            return Tuple.Create(x, y);
        }

        private Tuple<bool, bool> CanMoveTo(List<FloorSegment> floors, int x, int y, Player player)
        {
            bool CanMoveX = false;
            bool CanMoveY = false;
            foreach (FloorSegment floorSegment in floors)
            {
                if (AreInsideOfPictureBox(floorSegment.FloorBody, player) || WillBeInsideOfPictureBox(floorSegment.FloorBody, player, x, y))
                {
                    if (floorSegment.FloorBody.Location.X + x <= player.LeftLocation && floorSegment.FloorBody.Location.X + floorSegment.FloorBody.Width + x >= player.RightLocation)
                        CanMoveX = true;

                    if (floorSegment.FloorBody.Location.Y + y <= player.BottomLocation && floorSegment.FloorBody.Location.Y + floorSegment.FloorBody.Height + y >= player.BottomLocation)
                        CanMoveY = true;
                }
            }

            return Tuple.Create(CanMoveX, CanMoveY);
        }

        private bool WillBeInsideOfPictureBox(PictureBox pictureBox, Player player, int x, int y)
        {
            return (pictureBox.Location.X + x <= player.LeftLocation && pictureBox.Location.X + pictureBox.Width + x >= player.RightLocation) && (pictureBox.Location.Y + y <= player.BottomLocation && pictureBox.Location.Y + pictureBox.Height + y >= player.BottomLocation);
        }

        private bool AreInsideOfPictureBox(PictureBox pictureBox, Player player)
        {
            return (pictureBox.Location.X <= player.LeftLocation && pictureBox.Location.X + pictureBox.Width >= player.RightLocation) && (pictureBox.Location.Y <= player.BottomLocation && pictureBox.Location.Y + pictureBox.Height >= player.BottomLocation);
        }
    }
}
