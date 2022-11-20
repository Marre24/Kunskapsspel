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

        private Room currentRoom;
        public Room CurrentRoom { get => currentRoom; set { } }

        public Dictionary<Rooms, Room> rooms = new Dictionary<Rooms, Room>();
        public SceneManager(GameForm gameForm)
        {
            rooms.Add(Rooms.first, new SimpleRoom(gameForm, Color.Green));
            rooms.Add(Rooms.second, new SimpleRoom(gameForm, Color.Red));

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
