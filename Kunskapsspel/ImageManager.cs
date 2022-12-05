using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel
{
    class ImageManager
    {
        public Image GetPlayerFrontImage { get => Image.FromFile(@"./Resources/RobotFront.png"); }

        public Image GetPlayerBackImage { get => Image.FromFile(@"./Resources/RobotBack.png"); }

        public Image GetPlayerRightImage { get => Image.FromFile(@"./Resources/RobotRight.png"); }

        public Image GetPlayerLeftImage { get => Image.FromFile(@"./Resources/RobotLeft.png"); }

        public Image GetGeneralGoofyImage { get => Image.FromFile(@"./Resources/GeneralGoofy.png"); }

        public Image GetDevilImage { get => Image.FromFile(@"./Resources/Devil.png"); }

        public Image GetSignImage { get => Image.FromFile(@""); }

        public ImageManager() { }

        public void SetWallImageWithColor(Color wallColor, PictureBox Wall)
        {
            Wall.Image = Image.FromFile(@"./Resources/WallTiles3.png");
        }

    }
}
