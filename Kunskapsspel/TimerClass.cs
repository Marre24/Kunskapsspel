using Kunskapsspel.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Kunskapsspel
{
    public class TimerClass
    {
        private Timer timer;
        private readonly MovementClass movmentClass;
        private readonly TestScene testScene;
        private readonly GameForm gameForm;
        private bool spaceDown = false;
        private InteractClass interact;
        Player player;
        public TimerClass(TestScene testScene, GameForm gameForm)
        {
            this.testScene = testScene;
            this.gameForm = gameForm;
            movmentClass = new MovementClass();
            StartGame();
        }

        private void StartGame()
        {
            interact = new InteractClass();
            player = new Player(gameForm, Image.FromFile(@"./Resources/amogus.png"));

            timer = new Timer()
            {
                Interval = 20,
            };
            timer.Tick += TickEvent;
            timer.Start();
        }

        private void TickEvent(object sender, EventArgs e)
        {

            if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.D))
                movmentClass.Move(testScene.floors, testScene.allPictureBoxes, player);

            if (Keyboard.IsKeyUp(Key.Space))
                spaceDown = false;

            if (Keyboard.IsKeyDown(Key.Space))
            {
                Interact();
            }

        }

        private void Interact()
        {
            if (spaceDown)
                return;

            spaceDown = true;
            interact.Interact(testScene.interactableObjects, player, this);
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Start()
        {
            timer.Start();
        }
    }
}
