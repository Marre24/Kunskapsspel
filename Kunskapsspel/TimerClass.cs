using Kunskapsspel.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Kunskapsspel
{
    public class TimerClass
    {
        public Timer timer;
        private bool spaceDown = false;
        GameManager gameManager;
        public TimerClass(GameManager gameManager)
        {
            this.gameManager = gameManager;

            CreateTimer();
        }

        private void CreateTimer()
        {
            timer = new Timer()
            {
                Interval = 20,
            };
            timer.Tick += TickEvent;
        }

        private void TickEvent(object sender, EventArgs e)
        {

            if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.D))
                gameManager.Move();


            if (Keyboard.IsKeyUp(Key.Space))
                spaceDown = false;

            if (Keyboard.IsKeyDown(Key.Space))
            {
                if (spaceDown)
                    return;
                spaceDown = true;
                Interact();
            }

        }

        private void Interact()
        {
            gameManager.Interact();
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
