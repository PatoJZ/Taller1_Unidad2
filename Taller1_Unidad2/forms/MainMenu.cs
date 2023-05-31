using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller1_Unidad2.forms
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            //Boton de Inicio
            Button start = new Button();
            start.Text = "START";
            start.Size = new Size(200, 50);
            start.Location = new Point((Width / 2) - 20 - (start.Width / 2), (Height / 2) + 100 - (start.Height / 2));
            start.Click += new EventHandler(ClickStart);
            this.Controls.Add(start);

            //Nombres Creadores
            Label names = new Label();
            names.Text = "Creadores: \nPatricio Jiménez\nTomás Concha";
            names.AutoSize = true;
            names.TextAlign = ContentAlignment.MiddleCenter;
            names.Location = new Point((Width / 2) - 40 - (names.Width / 2), (Height / 2) - 50 - (names.Height / 2));
            this.Controls.Add(names);
        }

        private void ClickStart(object sender, EventArgs e)
        {
            this.Hide();
            Map map = new Map();
            map.ShowDialog();
            this.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
