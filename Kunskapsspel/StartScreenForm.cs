using Kunskapsspel.Scenes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kunskapsspel
{
    public partial class StartScreenForm : System.Windows.Forms.Form
    {
        public StartScreenForm()
        {
            InitializeComponent();
            StartingScene startingScene = new StartingScene(this);
        }
    }
}