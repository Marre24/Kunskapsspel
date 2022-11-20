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
        private Timer timer;
        private readonly MovementClass movmentClass;
        private readonly GameForm gameForm;
        private bool spaceDown = false;
        private InteractClass interact;
        Player player;
        public TimerClass(string sceneName, GameForm gameForm)
        {
            this.gameForm = gameForm;
            gameForm.activeScene = CreateByTypeName(sceneName);

            movmentClass = new MovementClass();
            StartGame();
        }

        private object CreateByTypeName(string typeName)
        {
            var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                        from t in assembly.GetTypes()
                        where t.Name == typeName  
                        select t).FirstOrDefault();

            if (type == null)
                throw new InvalidOperationException("Type not found");

            return Activator.CreateInstance(type, gameForm);
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
                movmentClass.Move(gameForm.activeScene.previousDoor, gameForm.activeScene.nextDoor, gameForm.activeScene.floors, gameForm.activeScene.allPictureBoxes, player, gameForm);

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
            interact.Interact(gameForm.activeScene.interactableObjects, player, this);
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
