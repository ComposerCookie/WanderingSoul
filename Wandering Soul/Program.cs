using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
 
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    static class Program
    {
        static public Data Data { get; set; }
        static public RenderWindow RW { get; set; }
        static public StateManager SM { get; set; }
        static public InGameLog Log { get; set; }
        static public int VisibleMaxX { get; set; }
        static public int VisibleMaxY { get; set; }
        static public FPSCounter Timer { get; set; }
        static public Stopwatch Clock { get; set; }

        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;

            //if (e.Code == Keyboard.Key.Something)
        }

        static void OnMousePress(object sender, MouseButtonEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;

        }

        static void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            //State[InState].HandleMouse(e.Button);
            //LastMouseType = Mouse.Button.Left;
        }

        static void OnMouseRelease(object sender, MouseButtonEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
        }

        static void OnScreenResize(object sender, SizeEventArgs e)
        {
            VisibleMaxX = (int)RW.Size.X / Program.Data.TileSizeX;
            VisibleMaxY = (int)RW.Size.Y / Program.Data.TileSizeY;
        }

        static void Main()
        {
            Data = new Data();
            Clock = new Stopwatch();
            Clock.Start();

            RenderWindow Screen = new RenderWindow(new VideoMode(1040, 768), "Wandering Soul - The Legacy");
            VisibleMaxX = (int)Screen.Size.X / 16;
            VisibleMaxY = (int)Screen.Size.Y / 16;
            RW = Screen;
            Screen.SetFramerateLimit(60);
            Screen.Closed += new EventHandler(OnClose);
            Screen.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            Screen.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(OnMousePress);
            Screen.MouseMoved += new EventHandler<MouseMoveEventArgs>(OnMouseMove);
            Screen.MouseButtonReleased += new EventHandler<MouseButtonEventArgs>(OnMouseRelease);
            Screen.Resized += new EventHandler<SizeEventArgs>(OnScreenResize);
            Screen.SetMouseCursorVisible(false);

            Text FPS = new Text("", Data.Font, 12);

            while (Screen.IsOpen())
            {

                Screen.DispatchEvents();

                Screen.Clear(new Color(0, 0, 0));

                /***************FPS Counter*******************/
                Timer.Frame++;
                if (Timer.Timer.ElapsedMilliseconds >= 1000)
                {
                    FPS.DisplayedString = "FPS: " + Timer.Frame;
                    Timer.Reset();
                }
                FPS.Position = new Vector2f(0, 0);
                Screen.Draw(FPS);
                /*********************************************/

                Screen.Display();
            } 
        } 
    } 
}
