using Kunskapsspel.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Kunskapsspel
{
    public enum Rooms
    {
        LearnControlsScene,
        LearnComplexNumbersScene,
    }
    public class SceneManager
    {
        private IRoom currentRoom;
        public IRoom CurrentRoom { get => currentRoom; set { } }

        public Dictionary<Rooms, IRoom> rooms = new Dictionary<Rooms, IRoom>();
        public SceneManager(GameForm gameForm, TimerClass timer)
        {
            rooms.Add(Rooms.LearnControlsScene, new LearnControlsScene(gameForm, timer));
            rooms.Add(Rooms.LearnComplexNumbersScene, new LearnComplexNumbersScene(gameForm, timer));

            currentRoom = rooms[Rooms.LearnControlsScene];

            currentRoom.StartScene();
        }

        internal void ChangeSceneTo(Rooms room)
        {
            currentRoom.EndScene();

            currentRoom = rooms[room];
            currentRoom.StartScene();
        }
    }
}
