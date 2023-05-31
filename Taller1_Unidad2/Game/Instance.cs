using CanvasDrawing.UtalEngine2D_2023_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1_Unidad2.Game
{
    public class Instance : GameObject
    {
        public float timerMove = 0;
        public float speed = 1;
        public static int LASTID = 0;
        public int myId = 0;
        static Random rand;
        public Camera myCamera;
        //MovementLimits, definir una variable para el evitar el movimiento de las instances, para que no se salgan de la grilla
        //Esta variable será verificada antes del movimiento en Update

        public Instance ( Image newSprite, Vector2 newSize, float x = 0, float y = 0) : base(newSprite, newSize, x, y)
        {
            CameraManager.AllInstances.Add(this);
            myCamera = new Camera();
            myId = LASTID++;
            if (rand == null)
            {
                rand = new Random();
            }
        }

        public override void OnCollisionEnter(GameObject other)
        {
            GameEngine.Destroy(this);
        }

        public override void Update()
        {
            timerMove += (float)Time.deltaTime;
            if (timerMove >= 1)
            {

                timerMove -= 1 - (float)(rand.NextDouble()) / 100f;

                int moveOption = rand.Next(0, 4);
                switch (moveOption)
                {
                    case 0:
                        transform.position.x += 50;
                        break;
                    case 1:
                        transform.position.y += 50;
                        break;
                    case 2:
                        transform.position.x -= 50;
                        break;
                    case 3:
                        transform.position.y -= 50;
                        break;
                }
                myCamera.Position = transform.position;
            }
        }
    }
}
