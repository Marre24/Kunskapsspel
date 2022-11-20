using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel
{
    public class GameManager
    {
        private TimerClass timerClass;
        private InteractClass interactClass;
        private readonly GameForm gameForm;
        private MovementClass movementClass;
        public Player player;
        public SceneManager sceneManager;

        public GameManager(GameForm gameForm)
        {
            this.gameForm = gameForm;

            StartGame();
        }

        private void StartGame()
        {
            interactClass = new InteractClass();
            player = new Player(gameForm, Image.FromFile(@"./Resources/amogus.png"));
            movementClass = new MovementClass();
            timerClass = new TimerClass(this, movementClass);
            sceneManager = new SceneManager(gameForm);

            timerClass.Start();
        }

        

        internal void Interact()
        {
            //interactClass.Interact(interactableObjects, player, timerClass);
        }

        internal Room CurrentRoom()
        {
            return sceneManager.CurrentRoom;

        }
    }
}
