using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace cards
{
    public partial class Scoreboard : MetroForm
    {
        public Scoreboard(double score)
        {
            InitializeComponent();
            MetroMessageBox.Show(this, "You lost");
        }
    }
}
