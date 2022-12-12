using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Kunskapsspel
{
    public class InteractClass
    {
        public InteractClass()
        {


        }

        public void Interact(List<InteractableObject> interactableObjects, Player player, TimerClass timerClass)
        {
            if (!Keyboard.IsKeyDown(Key.Space))
                return;
            foreach (InteractableObject interactableObject in interactableObjects)
            {
                if (interactableObject.CanBeInteractedWith(player))
                {
                    LearningTime learningTime = new LearningTime(timerClass);                                       //Ändra till att det beror på vilken interactable object 
                    learningTime.Show();
                }
            }
        }
        public void CheckForEnemies(List<Enemy> enemies)
        {
            //foreach (Enemy enemy in enemies)
            //    if (AreInsideOfPictureBox(enemy.hiddenBody, player) && !enemy.defeated)
            //        enemy.StartInteraction();
        }

        public void CheckForDoors(Player player, List<Door> doors, SceneManager sceneManager)
        {
            foreach (Door door in doors)
            {
                if (IsTouching(player, door.doorBody) && door.opened)
                    sceneManager.ChangeSceneTo(door.target);
            }
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
    }
}
