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

        public MovementClass() { }

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

        public void Move(Player player, IRoom room, SceneManager sceneManager)
        {
            (int x, int y) = GetOffset();

            (bool canMoveX, bool canMoveY) = CanMoveTo(room.GetFloorSegments(), x, y, player);

            if (canMoveX)
            {
                foreach (Door door in room.GetDoors())
                    door.doorBody.Location = new Point(door.doorBody.Location.X + x, door.doorBody.Location.Y);
                foreach (FloorSegment floorSegment in room.GetFloorSegments())
                    floorSegment.FloorBody.Location = new Point(floorSegment.FloorBody.Location.X + x, floorSegment.FloorBody.Location.Y);
                foreach (PictureBox pb in room.GetHiddenPictureBoxes())
                    pb.Location = new Point(pb.Location.X + x, pb.Location.Y);
            }
                

            if (canMoveY)
            {
                foreach (Door door in room.GetDoors())
                    door.doorBody.Location = new Point(door.doorBody.Location.X, door.doorBody.Location.Y + y);
                foreach (FloorSegment floorSegment in room.GetFloorSegments())
                    floorSegment.FloorBody.Location = new Point(floorSegment.FloorBody.Location.X, floorSegment.FloorBody.Location.Y + y);
                foreach (PictureBox pb in room.GetHiddenPictureBoxes())
                    pb.Location = new Point(pb.Location.X, pb.Location.Y + y);
            }

            CheckForDoors(player, room.GetDoors(), sceneManager);
        }

        private void CheckForDoors(Player player, List<Door> doors, SceneManager sceneManager)
        {
            foreach (Door door in doors)
            {
                if (AreInsideOfPictureBox(door.doorBody, player))
                    sceneManager.ChangeSceneTo(door.target);
            }
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
