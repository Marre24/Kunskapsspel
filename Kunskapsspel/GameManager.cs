using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunskapsspel
{
    public class GameManager
    {
        private TimerClass timerClass;
        private InteractClass interactClass;
        private readonly GameForm gameForm;
        private MovementClass movementClass;
        private Player player;
        SceneManager sceneManager;

        public GameManager(GameForm gameForm)
        {
            this.gameForm = gameForm;

            StartGame();
        }

        private void StartGame()
        {
            interactClass = new InteractClass();
            player = new Player(gameForm, Image.FromFile(@"./Resources/amogus.png"));
            timerClass = new TimerClass(this);
            movementClass = new MovementClass();
            sceneManager = new SceneManager();

            timerClass.Start();
        }

        internal void Move()
        {
            movementClass.Move(player, floors, allPictureBoxes, doors, sceneManager);
        }

        internal void Interact()
        {
            interactClass.Interact(interactableObjects, player, timerClass);
        }
    }
}
