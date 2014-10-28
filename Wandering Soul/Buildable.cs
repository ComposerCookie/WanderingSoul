using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lost_Soul
{
    public interface Buildable : Spawnable
    {
        string Name { get; set; }
        int MaxHealth { get; set; }
        int SizeX { get; set; }
        int SizeY { get; set; }
        int PickSprite { get; set; }
        int Sprite { get; set; }
        int StartSprite { get; set; }
        int StageOneSprite { get; set; }
        int StageTwoStage { get; set; }
        int DestroyedStage { get; set; }
        byte Blocked { get; set; }
        List<int> Classification { get; set; }
        Dictionary<SpawnItems, int> RequiredItems { get; set; }
        List<SpawnItems> DestroyDrop { get; set; }
        bool Destroyable { get; set; }
        List<int> BuildableOnType { get; set; }
    }
}
