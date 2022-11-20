using System;
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
    internal class MovementClass
    {
        private const int movementSpeed = 35;
        const Key forwardKey = Key.W;
        const Key leftKey = Key.A;
        const Key backwardsKey = Key.S;
        const Key rightKey = Key.D;
        public MovementClass() { }

        private Tuple<int, int> GetOffset()
        {
            int x = 0;
            int y = 0;

            if (Keyboard.IsKeyDown(forwardKey))
                y += movementSpeed;
            if (Keyboard.IsKeyDown(backwardsKey))
                y -= movementSpeed;
            if (Keyboard.IsKeyDown(leftKey))
                x += movementSpeed;
            if (Keyboard.IsKeyDown(rightKey))
                x -= movementSpeed;

            return Tuple.Create(x, y);
        }

        public void Move(Door previousDoor, Door nextDoor, List<PictureBox> floors, List<PictureBox> allPictureBoxes, Player player, GameForm gameForm)
        {
            (int x, int y) = GetOffset();


            (bool canMoveX, bool canMoveY) = CanMoveTo(floors, x, y, player);

            if (canMoveX)
            {
                foreach (PictureBox pb in allPictureBoxes)
                    pb.Location = new Point(pb.Location.X + x, pb.Location.Y);
            }

            if (canMoveY)
            {
                foreach (PictureBox pb in allPictureBoxes)
                    pb.Location = new Point(pb.Location.X, pb.Location.Y + y);
            }

            CheckForDoors(previousDoor, nextDoor, player, gameForm);
        }

        private void CheckForDoors(Door previousDoor, Door nextDoor, Player player,GameForm gameForm)
        {
            if (previousDoor != null)
                if (AreInsideOfPictureBox(previousDoor.doorBody, player))
                    gameForm.ChangeSceneTo(previousDoor.goesTo);

            if (nextDoor != null)
                if (AreInsideOfPictureBox(nextDoor.doorBody, player))
                    gameForm.ChangeSceneTo(nextDoor.goesTo);


        }

        private Tuple<bool, bool> CanMoveTo(List<PictureBox> floors, int x, int y, Player player)
        {
            bool CanMoveX = false;
            bool CanMoveY = false;
            foreach (var floor in floors)
            {
                if (AreInsideOfPictureBox(floor, player) || WillBeInsideOfPictureBox(floor, player, x, y))
                {
                    if (floor.Location.X + x <= player.LeftLocation && floor.Location.X + floor.Width + x >= player.RightLocation)
                        CanMoveX = true;

                    if (floor.Location.Y + y <= player.BottomLocation && floor.Location.Y + floor.Height + y >= player.BottomLocation)
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
