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
        first,
        second,
    }
    public class SceneManager
    {
        //TestScene TestScene = new TestScene();

        private IRoom currentRoom;
        public IRoom CurrentRoom { get => currentRoom; set { } }

        public Dictionary<Rooms, IRoom> rooms = new Dictionary<Rooms, IRoom>();
        public SceneManager(GameForm gameForm, TimerClass timer)
        {
            rooms.Add(Rooms.first, new SimpleRoom(gameForm, timer));
            rooms.Add(Rooms.second, new SimpleRoom(gameForm, timer));

            currentRoom = rooms[Rooms.first];

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
