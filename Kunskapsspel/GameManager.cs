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
        public TimerClass timerClass;
        public InteractClass interactClass;
        private readonly GameForm gameForm;
        public MovementClass movementClass;
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
            player = new Player(gameForm, Image.FromFile(@"./Resources/Karaktär.png"));
            movementClass = new MovementClass();
            timerClass = new TimerClass(this, movementClass);
            sceneManager = new SceneManager(gameForm);

            timerClass.Start();
        }

        

        internal Room CurrentRoom()
        {
            return sceneManager.CurrentRoom;

        }
    }
}
