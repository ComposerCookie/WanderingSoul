using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Lost_Soul
{
    public class InGameLogMessage
    {
        string Message;
        int _type;
        RenderWindow _screen;

        public InGameLogMessage(RenderWindow rw, string msg, int length, int type)
        {
            CuttedMessage = new List<string>();
            Message = msg;
            _screen = rw;
            _type = type;
            CutMessageToBoxSize(length);
        }

        public void CutMessageToBoxSize(int length)
        {
            CuttedMessage = new List<string>();
            Text test = new Text(Message, Program.Data.Font, 10);
            int count = 1;
            int lasti = 0;
            for (int i = 0; i < Message.Length; i++)
            {
                int asdf = (int)test.FindCharacterPos((uint)i).X;
                if ((int)test.FindCharacterPos((uint)i).X > length * count)
                {
                    count++;
                    CuttedMessage.Add(Message.Substring(lasti, i - lasti));
                    lasti = i;
                }

                else if (i == Message.Length - 1)
                {
                    CuttedMessage.Add(Message.Substring(lasti, i - lasti + 1));
                }
            }

        }

        public void Draw(int X, int Y)
        {
            Text t = new Text();
            t.Font = Program.Data.Font;
            t.CharacterSize = 10;

            SetTextColor(t);

            for (int i = 0; i < CuttedMessage.Count; i++)
            {
                t.DisplayedString = CuttedMessage[i];
                t.Position = new Vector2f(X, Y + (11 * i));
                _screen.Draw(t);
            }
        }

        public void SetTextColor(Text t)
        {
            switch ((InGameLogMessageType)_type)
            {
                case InGameLogMessageType.Notification:
                    t.Color = new Color(Color.Magenta);
                    break;
                case InGameLogMessageType.BadCombat:
                    t.Color = new Color(Color.Red);
                    break;
                case InGameLogMessageType.GoodCombat:
                    t.Color = new Color(Color.Green);
                    break;
                case InGameLogMessageType.Event:
                    t.Color = new Color(Color.Yellow);
                    break;
                case InGameLogMessageType.System:
                    t.Color = new Color(Color.White);
                    break;
            }
        }

        public void Draw(int X, int Y, int startat, int endat)
        {
            Text t = new Text();
            t.Font = Program.Data.Font;
            t.CharacterSize = 10;

            SetTextColor(t);
            
            for (int i = startat; i <= endat; i++)
            {
                t.DisplayedString = CuttedMessage[i];
                t.Position = new Vector2f(X, Y + (11 * (i - startat)));
                _screen.Draw(t);
            }
        }

        public List<string> CuttedMessage { get; set; }
    }
}
