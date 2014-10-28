using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;

using Sprite = SFML.Graphics.Sprite;

namespace Lost_Soul
{
    public interface LivingObject
    {
        bool Moved{ get; set; }
        int LastX{ get; set; }
        int LastY{ get; set; }
        int SideMapID{ get; set; }
        Map CurMap{ get; set; }
        LivingObject Targeting{ get; set; }
        int LeftAttackCooldown{ get; set; }
        int RightAttackCooldown{ get; set; }
        int AttackSpeed{ get; set; }
        AttackAction CurrentDefenseAction{ get; set; }
        string Name{ get; set; }
        int Type{ get; set; }
        int Sprite{ get; set; }
        int OnMapType{ get; set; }
        int X{ get; set; }
        int Y{ get; set; }
        int TargetX{ get; set; }
        int TargetY{ get; set; }
        int Dir{ get; set; }
        int TargetDir{ get; set; }
        int Speed{ get; set; } //Please make it factor of 16 like 1 2 4 8
        int Range{ get; set; }
        int Level{ get; set; }
        int Index{ get; set; }
        int Behavior{ get; set; }
        int CurHP{ get; set; }
        int CurMana{ get; set; }
        bool Lefted{ get; set; }
        bool IsWalking{ get; set; }
        List<Action> ActionQueue{ get; set; }

        int Strength{ get; set; }
        int Endurance{ get; set; }
        int Agility{ get; set; }
        int Dexterity{ get; set; }
        int Willpower{ get; set; }
        int Intelligence{ get; set; }
        int Luck{ get; set; }
        int Defense{ get; set; }
        int Resistance{ get; set; }

        void PutOnMap();
        void Update();
        void Draw(RenderWindow rw, int x, int y);
        void Die();
        void Action();

    }
}
