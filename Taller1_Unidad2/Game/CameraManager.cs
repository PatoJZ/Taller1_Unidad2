using CanvasDrawing.UtalEngine2D_2023_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller1_Unidad2.Game
{
    internal class CameraManager : EmptyUpdatable
    {
        public static List<Instance> AllInstances = new List<Instance>();
        public static int selectedIndex;
        public static CameraManager Instance;
        public override void Update()
        {
            if (GameEngine.KeyUp(Keys.C))
            {
                selectedIndex++;
                Console.WriteLine("Key detected");
                if (AllInstances.Count >= selectedIndex)
                {
                    selectedIndex %= AllInstances.Count;
                }
                GameEngine.MainCamera = AllInstances[selectedIndex].myCamera;
            }
        }
    }
}
