using CanvasDrawing.UtalEngine2D_2023_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Taller1_Unidad2.Game;

namespace Taller1_Unidad2.forms
{
    public partial class Map : Form
    {
        Image playerImage;
        Image enemyImage;
        Image goalImage;
        Vector2 imageSize = new Vector2(50, 50);
        //Vector2 movementLimits = new Vector2(500, 500); Buscar una forma de crear un rectangulo, 
        //del cual no se pueda salir

        public Map()
        {
            playerImage = global::Taller1_Unidad2.Properties.Resources.CorrerPistolas_2;
            enemyImage = global::Taller1_Unidad2.Properties.Resources.Enemigo_Rayo_Idle;
            //goalImage = global::Taller1_Unidad2.Properties.Resources.***IMAGEN DE META***
            //BackgroundImage = global::Taller1_Unidad2.Properties.Resources.***IMAGEN DE GRILLA***

            Random r = new Random();

            for (int i = 0; i < 8; i++)
            {
                new Instance( enemyImage, imageSize, 100 + r.Next() % 6 * 50, 100 + r.Next() % 6 * 50);
            }

            //instanciar la meta

            Player player = new Player(playerImage, imageSize, 100, 100);
            
            DoubleBuffered = true;
            InitializeComponent();
            player.myCamera.scale = 1f;
            player.myCamera.xSize = player.myCamera.ySize = 800;
            player.myCamera.Position = player.transform.position;
            GameEngine.MainCamera = player.myCamera;
            GameEngine.InitEngine(this);
            new CameraManager();
        }

        private void Map_Load(object sender, EventArgs e)
        {

        }
    }
}
