using Kunskapsspel.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunskapsspel
{
    public class SceneManager
    {
        //TestScene TestScene = new TestScene();

        enum SceneOrder
        {
            hej,
        }

        private readonly int currentSceneIndex = 0;

        public SceneManager()
        {
            GetAllGameScenes();
        }

        private void GetAllGameScenes()
        {


        }

        internal void ChangeSceneTo(string key)
        {
            throw new NotImplementedException();
        }
    }
}
