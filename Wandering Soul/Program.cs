using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    static class Program {
 
   static void OnClose(object sender, EventArgs e) {
      // Close the window when OnClose event is received
      RenderWindow window = (RenderWindow)sender;
      window.Close();
   }

   static void OnKeyPressed(object sender, KeyEventArgs e)
   {
       RenderWindow window = (RenderWindow)sender;

       //if (e.Code == Keyboard.Key.Something)
       State[InState].HandleKey(e.Code);

   }

   static void OnMousePress(object sender, MouseButtonEventArgs e)
   {
       RenderWindow window = (RenderWindow)sender;
       if (UsingButton != null)
       {
           UsingButton.Picked();
           //UsingButton = null;
       }
       else
       {
           State[InState].HandleMouse(e.Button);
           LastMouseType = Mouse.Button.Left;
       }
       
   }

   static void OnMouseMove(object sender, MouseMoveEventArgs e)
   {
       RenderWindow window = (RenderWindow)sender;
       //State[InState].HandleMouse(e.Button);
       //LastMouseType = Mouse.Button.Left;
       State[InState].HandleMouseMove();
   }

   static void OnMouseRelease(object sender, MouseButtonEventArgs e)
   {
       RenderWindow window = (RenderWindow)sender;
       if (UsingButton != null)
       {
           UsingButton.Picked();
           //UsingButton = null;
       }
       else
       {
           State[InState].HandleMouse(e.Button);
           LastMouseType = Mouse.Button.Right;
       }
   }

   static void OnScreenResize(object sender, SizeEventArgs e)
   {
       VisibleMaxX = (int)RW.Size.X / Program.Data.TileSizeX;
       VisibleMaxY = (int)RW.Size.Y / Program.Data.TileSizeY;
   }

   static public int CurrentSaveData
   {
       get;
       set;
   }

   static public Map MyMap
   {
       get;
       set;
   }

   static public MapGenerator Generator
   {
       get;
       set;
   }

   static public Data Data
   {
       get;
       set;
   }

   static public RenderWindow RW
   {
       get;
       set;
   }

   static public int InState
   {
       get;
       set;
   }

   static public List<GameState> State
   {
       get;
       set;
   }

   static Mouse.Button LastMouseType
   {
       get;
       set;
   }

   static public GUIButton UsingButton
   {
       get;
       set;
   }

   static public InGameLog Log
   {
       get;
       set;
   }

   static public int MouseState
   {
       get;
       set;
   }

   static public int VisibleMaxX
   {
       get;
       set;
   }

   static public int VisibleMaxY
   {
       get;
       set;
   }

   static void Main() {
      // Create the main window
       CurrentSaveData = 0;
       Data d = new Data();
       Data = d;

       d.CreateGraphicPath();
       d.CreateTerrain();
       d.CreateSpriteData();
       d.CreateTileData();
       d.CreateAnimation();
       d.CreateAttack();
       d.CreateItems();
       d.CreateSpawnable();
       d.CreateKnowledge();
       d.CreateFaceData();
       d.CreateBodyData();
       d.CreateHairData();
       d.CreateTileVariation();
       d.LoadPlayerData();
       d.LoadWorldData();
       
       List<GameState> _gameState = new List<GameState>();
       State = _gameState;

       MainMap m;
       MouseState = 0;
       InState = 0;
       MapGenerator mg = new MapGenerator();
       m = mg.NewMap();

       MyMap = m;
       Generator = mg;

       Font font = new Font("Georgia.ttf");
       List<string> stuff = new List<string>();

       RenderWindow Screen = new RenderWindow(new VideoMode(1040, 768), "Wandering Soul - The Legacy");
       VisibleMaxX = 1040 / 16;
       VisibleMaxY = 768 / 16;
       RW = Screen;
       Screen.SetFramerateLimit(60);
       Screen.Closed += new EventHandler(OnClose);
       Screen.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
       Screen.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(OnMousePress);
       Screen.MouseMoved += new EventHandler<MouseMoveEventArgs>(OnMouseMove);
       Screen.MouseButtonReleased += new EventHandler<MouseButtonEventArgs>(OnMouseRelease);
       Screen.Resized +=new EventHandler<SizeEventArgs>(OnScreenResize);

       Screen.SetMouseCursorVisible(false);

       _gameState.Add(new MainMenuState(Screen));
       _gameState.Add(new InGameState(Screen));
 
       Color windowColor = new Color(0, 0, 0);

       Text t;
       SFML.Graphics.Sprite s;
 
       // Start the game loop
       while (Screen.IsOpen()) {
         // Process events        


         Screen.DispatchEvents();
 
         // Clear screen
         Screen.Clear(windowColor);

         

         _gameState[InState].Update();
         _gameState[InState].Draw();
         

         /*for (int i = 0; i < stuff.Count; i++)
         {
             t = new Text(stuff[i], font);
             t.Position = new Vector2f(50, i * 20 + 50);
             Screen.Draw(t);
         }*/

         //t = new Text("Min X: " + MyMap.MinX + ", Min Y: " + MyMap.MinY + ", Max X: " + MyMap.MaxX + ", Max Y: " + MyMap.MaxY + ", " + MyMap.SpawnedTerrain[0].Size.ToString() + ", Spawned Terrain Count: " + MyMap.SpawnedTerrain.Count, font);
         //t.Position = new Vector2f(0, 0);
         //Screen.Draw(t);

         Screen.SetView(new View(new FloatRect(0, 0, Screen.Size.X, Screen.Size.Y)));

         s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Mouse)[MouseState]);
         switch ((MouseStateType)MouseState)
         {
             case MouseStateType.Normal:
                 s.Position = new Vector2f(Mouse.GetPosition(Screen).X - 3, Mouse.GetPosition(Screen).Y);
                 break;
             case MouseStateType.Dragging:
                  s.Position = new Vector2f(Mouse.GetPosition(Screen).X - 2, Mouse.GetPosition(Screen).Y + 3);
                  break;
         }
         Screen.Draw(s);
         // Update the window
         Screen.Display();
      } //End game loop
    } //End Main()
  } //End Program
}
