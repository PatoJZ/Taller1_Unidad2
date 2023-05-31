using CanvasDrawing.UtalEngine2D_2023_1.Physics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanvasDrawing.UtalEngine2D_2023_1
{
    public static class GameEngine
    {
        private static List<KeyPressEventArgs> LastFrameKeyEvents = new List<KeyPressEventArgs>();
        public static List<Keys> KeysDown = new List<Keys>();
        public static Dictionary<Keys, bool> KeysPressed = new Dictionary<Keys, bool>();
        public static List<Keys> KeysUp = new List<Keys>();
        private static Form EngineDrawForm;
        private static Thread GameLoopThread = null;
        private static int FrameCount = 0;
        public static Camera MainCamera = new Camera();
        

        public static void Destroy(GameObject go)
        {
            GameObjectManager.AllDeadGameObjects.Add(go);
            go.OnDestroy();
        }
        public static void InitEngine(Form engineDrawForm)
        {
            EngineDrawForm = engineDrawForm;
            GameLoopThread = new Thread(GameLoop);
            EngineDrawForm.Paint += new System.Windows.Forms.PaintEventHandler(Paint);
            EngineDrawForm.KeyPress +=  new KeyPressEventHandler(KeyPressHandler);
            EngineDrawForm.KeyDown += new KeyEventHandler(KeyDownHandler);
            EngineDrawForm.KeyUp += new KeyEventHandler(KeyUpHandler);
            engineDrawForm.Height = MainCamera.ySize;
            engineDrawForm.Width = MainCamera.xSize;
            GameLoopThread.Start();
        }

        private static void KeyUpHandler(object sender, KeyEventArgs e)
        {
            KeysUp.Add(e.KeyCode);
            Console.WriteLine("Soltada Tecla " + e.KeyCode);
        }

        private static void KeyDownHandler(object sender, KeyEventArgs e)
        {
            KeysDown.Add(e.KeyCode);
            Console.WriteLine("Apretada Tecla " + e.KeyCode);
        }

        private static void KeyPressHandler(object sender, KeyPressEventArgs e)
        {
            LastFrameKeyEvents.Add(e);
            //Console.WriteLine ("Tecla " + e.KeyChar);
        }

        public static bool KeyPress(Keys KeyCode)
        {
            foreach(Keys k in KeysPressed.Keys)
            {
                if (k == KeyCode)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool KeyUp(Keys KeyCode)
        {
            foreach (Keys k in KeysUp)
            {
                if (k == KeyCode)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool KeyDown(Keys KeyCode)
        {
            foreach (Keys k in KeysDown)
            {
                if (k == KeyCode)
                {                   
                    return true;
                }
            }
            return false;
        }

        public static void Start()
        {

        }
        public static void GameLoop()
        {

            while (!EngineDrawForm.IsDisposed)
            {
                Thread.Sleep(1000 / 60);
                try
                {
                    EngineDrawForm.Refresh();
                    continue;
                }
                catch
                {
                    EngineDrawForm.Invalidate();
                    //continue; //Console.WriteLine("Cant");
                }
                PhysicsEngine.Update();

                Time.UpdateDeltaTime();
                GameObjectManager.Update();
                //Console.WriteLine("Begin Frame " + ++FrameCount);
                for (int i = 0; i < KeysUp.Count; i++)
                {
                    Keys k = KeysUp[i];
                    KeysPressed.Remove(k);
                }
                for (int i = 0; i < KeysDown.Count; i++)
                {
                    Keys k = KeysDown[i];
                    if (!KeysPressed.ContainsKey(k))
                    {
                        KeysPressed.Add(k, true);
                    }
                }
                
                for (int i = 0; i < KeysUp.Count; i++)
                {
                    Keys k = KeysUp[i];
                    KeysPressed.Remove(k);                  
                }
                KeysDown = new List<Keys>();
                KeysUp = new List<Keys>();
                LastFrameKeyEvents = new List<KeyPressEventArgs>();
                
                foreach (GameObject go in GameObjectManager.AllDeadGameObjects)
                {
                    GameObjectManager.AllGameObjects.Remove(go);
                }
                GameObjectManager.AllDeadGameObjects = new List<GameObject>();
            }
            
        }
        private static void Paint(Object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
            //Console.WriteLine("Frame");
        }
        public static void Draw(Graphics graphics)
        {
            for(int i=0; i<GameObjectManager.AllGameObjects.Count;i++){
                GameObject go = GameObjectManager.AllGameObjects[i];
                go.Draw(graphics, MainCamera);
            }
        }
    }
}
