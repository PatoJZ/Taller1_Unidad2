using CanvasDrawing.UtalEngine2D_2023_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1_Unidad2.Game
{
    public class Player : Instance
    {
        public Player(Image newSprite, Vector2 newSize, float x = 0, float y = 0) : base( newSprite, newSize, x, y)
        {
            
        }
        public override void OnCollisionEnter(GameObject other)
        {

        }

        public override void Update()
        {
            if (GameEngine.KeyPress(Keys.Oemplus))
            {
                GameEngine.MainCamera.scale += Time.deltaTime;
            }
            if (GameEngine.KeyPress(Keys.OemMinus))
            {
                GameEngine.MainCamera.scale -= Time.deltaTime;
            }

            timerMove += Time.deltaTime;

            if (timerMove >= 1)
            {
                if (timerMove >= 2)
                {
                    timerMove -= 1;
                }

                bool moved = false;

                if (GameEngine.KeyPress(Keys.W))
                {
                    transform.position.y -= 50;
                    moved = true;
                }
                if (GameEngine.KeyPress(Keys.S))
                {
                    transform.position.y += 50;
                    moved = true;
                }
                if (GameEngine.KeyPress(Keys.A))
                {
                    transform.position.x -= 50;
                    moved = true;
                }
                if (GameEngine.KeyPress(Keys.D))
                {
                    transform.position.x += 50;
                    moved = true;
                }

                if (moved)
                {
                    myCamera.Position = transform.position;
                    timerMove -= 1;
                }
            }
        }
    }
}
