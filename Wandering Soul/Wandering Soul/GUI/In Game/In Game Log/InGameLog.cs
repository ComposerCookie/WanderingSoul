using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Window;
using SFML.Graphics;

namespace Lost_Soul
{
    public class InGameLog
    {
        RenderWindow _screen;
        public InGameLog(IntRect _res, RenderWindow rw)
        {
            Log = new List<InGameLogMessage>();
            _screen = rw;
            Restriction = _res;
            MinMsg = 0;

            Program.Log = this;
        }

        public void AddMessage(int type, string msg)
        {
            switch ((InGameLogMessageType)type)
            {
                case InGameLogMessageType.Notification:
                    Log.Add(new InGameLogMessage(_screen, "[Notification] " + msg, Restriction.Width, type));
                    break;
                case InGameLogMessageType.BadCombat:
                    Log.Add(new InGameLogMessage(_screen, "[Combat] " + msg, Restriction.Width, type));
                    break;
                case InGameLogMessageType.GoodCombat:
                    Log.Add(new InGameLogMessage(_screen, "[Combat] " + msg, Restriction.Width, type));
                    break;
                case InGameLogMessageType.Event:
                    Log.Add(new InGameLogMessage(_screen, "[Event] " + msg, Restriction.Width, type));
                    break;
                case InGameLogMessageType.System:
                    Log.Add(new InGameLogMessage(_screen, "[System] " + msg, Restriction.Width, type));
                    break;
            }

            if (MinMsg + 8 < GetMaxMessageFromLog() && Log.Count - 9 >= 0 && !IsScrolling)
                MinMsg = GetMaxMessageFromLog() - 8;
        }

        public void Draw(int logstart, int logend, int start, int end)
        {
            int offset = 0;
            for (int i = logstart; i <= logend; i++)
            {
                if (i == logend)
                {
                    Log[i].Draw(Restriction.Left, Restriction.Top + 11 * (i - logstart + offset), 0, end);
                    offset += Log[i].CuttedMessage.Count - 1 - end;
                }
                else if (i == logstart)
                {
                    Log[i].Draw(Restriction.Left, Restriction.Top + 11 * (i - logstart + offset), start, Log[i].CuttedMessage.Count - 1);
                    offset += Log[i].CuttedMessage.Count - 1 - start;
                }
                else
                {
                    Log[i].Draw(Restriction.Left, Restriction.Top + 11 * (i - logstart + offset));
                    offset += Log[i].CuttedMessage.Count - 1;
                }
            }
        }

        public void DrawMessage()
        {
            if (GetMaxMessageFromLog() < 1)
                return;
            else if (GetMaxMessageFromLog() < 9)
            {
                IsScrolling = false;
                Draw(0, Log.Count - 1, 0, Log[Log.Count - 1].CuttedMessage.Count - 1);
            }
            else if (GetMaxMessageFromLog() >= 9)
            {
                if (MinMsg < 0)
                    MinMsg = 0;
                else if (MinMsg + 8 > GetMaxMessageFromLog() && Log.Count - 9 >= 0)
                {
                    MinMsg = GetMaxMessageFromLog() - 8;
                    IsScrolling = false;
                }
                KeyValuePair<int, int> start = FigureLocationBasedFromTotalMessage(MinMsg + 1);
                KeyValuePair<int, int> end = FigureLocationBasedFromTotalMessage(MinMsg + 8);

                Draw(start.Key, end.Key, start.Value, end.Value);
            }
        }

        public KeyValuePair<int, int> FigureLocationBasedFromTotalMessage(int loc)
        {
            int log = 0;
            int msg = 0;

            while (loc > 0)
            {
                if (Log[log].CuttedMessage.Count >= loc)
                {
                    msg = loc - 1;
                    break;
                }
                else
                    loc -= (Log[log].CuttedMessage.Count);
                log++;
            }
            
            return new KeyValuePair<int, int>(log, msg);
        }

        int GetMaxMessageFromLog()
        {
            int count = 0;
            foreach(InGameLogMessage m in Log)
            {
                foreach (string s in m.CuttedMessage)
                    count++;
            }
            return count;
        }

        public int MinMsg { get; set; }
        public List<InGameLogMessage> Log { get; set; }
        public IntRect Restriction { get; set; }
        public bool IsScrolling { get; set; }
    }
}
