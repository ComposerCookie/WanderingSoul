using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class KnowledgeGUIBarButton : GUIButton
    {
        RenderWindow _screen;
        public KnowledgeGUIBarButton(RenderWindow rw, int id, int x, int y, int slotid)
        {
            _screen = rw;
            ID = id;
            X = x;
            Y = y;
            SlotID = slotid;
            Visibility = true;
        }
        public void Clicked()
        {
        }
        public void Picked()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                KnowledgeGUI g = (KnowledgeGUI)Program.SM.States[1].GameGUI[11];
                if (g.KnowledgeDown + SlotID < Program.Data.MyKnowledge.Count)
                {
                    if (Mouse.GetPosition(_screen).X > X + 152 && Mouse.GetPosition(_screen).X < X + 176 && Mouse.GetPosition(_screen).Y > Y + 12 && Mouse.GetPosition(_screen).Y < Y + 26)
                    {
                        if (!Logic.CurrentParty.MainParty.MyParty[0].KnowledgeKnown.Contains(g.KnowledgeDown + SlotID))
                        {
                            if (Logic.CurrentParty.MainParty.MyParty[0].LearningPoint >= Program.Data.MyKnowledge[g.KnowledgeDown + SlotID].Cost)
                            {
                                Logic.CurrentParty.MainParty.MyParty[0].KnowledgeKnown.Add(g.KnowledgeDown + SlotID);
                                Logic.CurrentParty.MainParty.MyParty[0].LearningPoint -= Program.Data.MyKnowledge[g.KnowledgeDown + SlotID].Cost;
                            }
                        }
                    }
                }
            }
        }
        public bool isMouseHover()
        {
            return false;
        }
        public void Draw()
        {
            SFML.Graphics.Sprite s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[ID]);
            s.Position = new Vector2f(X, Y);
            _screen.Draw(s);

            Text t = new Text();
            t.Font = Program.Data.Font;
            t.CharacterSize = 11;
            t.Color = Color.Yellow;

            KnowledgeGUI g = (KnowledgeGUI)Program.SM.States[1].GameGUI[11];
            switch (g.CurView)
            {
                case 0:
                    if (g.KnowledgeDown + SlotID < Program.Data.MyKnowledge.Count)
                    {
                        s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Knowledge)[g.KnowledgeDown + SlotID]);
                        s.Position = new Vector2f(X + 1, Y + 1);
                        _screen.Draw(s);

                        t.DisplayedString = Program.Data.MyKnowledge[g.KnowledgeDown + SlotID].Name;
                        t.Position = new Vector2f(X + 30, Y + 5);
                        _screen.Draw(t);

                        if (Logic.CurrentParty.MainParty.MyParty[0].KnowledgeKnown.Contains(g.KnowledgeDown + SlotID))
                            s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[62]);
                        else
                            s = new SFML.Graphics.Sprite(Program.Data.SpriteBasedOnType(SpriteType.Button)[59]);
                        s.Position = new Vector2f(X + 152, Y + 12);
                        _screen.Draw(s);
                    }
                    break;
            }
        }
        public void Update()
        {
        }
        public bool isFocused()
        {
            return false;
        }
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Visibility { get; set; }
        public int SlotID { get; set; }
    }
}
