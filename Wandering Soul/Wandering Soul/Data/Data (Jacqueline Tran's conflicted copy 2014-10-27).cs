using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SFML.Graphics;

namespace Lost_Soul
{
    public class Data
    {
        int _tileSizeX;
        int _tileSizeY;
        List<TerrainData> _myTerrain;
        List<TileData> _myTileData;
        List<Sprite> _mySprites;
        List<LivingObject> _myLivingThings;
        List<PlayerData> _playerDatas;
        List<Items> _myItems;
        List<Spawnable> _mySpawnable;
        Font _font;

        public Data()
        {
            _tileSizeX = 16;
            _tileSizeY = 16;
            _myTerrain = new List<TerrainData>();
            _myTileData = new List<TileData>();
            _mySprites = new List<Sprite>();
            _myLivingThings = new List<LivingObject>();
            _playerDatas = new List<PlayerData>();
            _myItems = new List<Items>();
            _mySpawnable = new List<Spawnable>();
            _font = new Font("Georgia.ttf");
        }

        public void CreateTerrain()
        {
            _myTerrain.Add(new TerrainData(Enum.GetName(typeof(TerrainTypeEnum), 0), 0, 0, 0, 0));
            _myTerrain.Add(new TerrainData(Enum.GetName(typeof(TerrainTypeEnum), 1), 1, 0, 1, 0));
            _myTerrain.Add(new TerrainData(Enum.GetName(typeof(TerrainTypeEnum), 2), 2, 0, 2, 0));
        }

        public void CreateSpawnable()
        {
            List<SpawnItems> give = new List<SpawnItems>(){new SpawnItems(0)};
            _mySpawnable.Add(new TreeResource("Pine Tree", 0, 1, 1, 3, give, new List<int>(){(int)TerrainTypeEnum.Forest}, 1, 0, (int)ToolType.Hatchet));
            _mySpawnable.Add(new BuildFire("Tinder", 1, 1, 1, 0, 1, -1, -1, -1, 1, new List<int>(), new Dictionary<SpawnItems, int>() { { new SpawnItems(0), 3 } }, new List<SpawnItems>(), 1));
        }

        public void CreateItems()
        {
            _myItems.Add(new ResourceItem("Log", 0, (int)ItemType.Resource, 1));
            _myItems.Add(new ToolItem("Wooden Hatchet", (int)ToolType.Hatchet, 1, 0));
        }

        public void CreateTileData()
        {
            _myTileData.Add(new TileData(32, 32, 0));
            _myTileData.Add(new TileData(114, 32, 0));
            _myTileData.Add(new TileData(190, 32, 0));
        }

        public void CreateLivingObjectData()
        {
            _myLivingThings.Add(new NPC("Jacqueline", (int)LivingObjectType.NPC, 1, 0, (int)MapType.MainMap, true, 1, 1, (int)JobType.Novice));
            _myLivingThings.Add(new NPC("Jacqueline", (int)LivingObjectType.NPC, 1, 0, (int)MapType.MainMap, true, 1, 1, (int)JobType.Novice));
            _myLivingThings.Add(new Hostile("Jacqueline clone", (int)LivingObjectType.Hostile, 0, (int)MapType.MainMap, 1, 1, 1));
        }

        public void CreateSpriteData()
        {
            _mySprites.Add(new Sprite("Tileset.png", (int)SpriteType.Tileset)); //0
            _mySprites.Add(new Sprite("Jacqueline.png", (int)SpriteType.Sprite)); //0
            _mySprites.Add(new Sprite("MainMenuGUI.png", (int)SpriteType.GUI)); //0
            _mySprites.Add(new Sprite("ButtonGUI New Game.png", (int)SpriteType.Button)); //0
            _mySprites.Add(new Sprite("ButtonGUI Close Game.png", (int)SpriteType.Button)); //1
            _mySprites.Add(new Sprite("ButtonGUI Load Game.png", (int)SpriteType.Button)); //2
            _mySprites.Add(new Sprite("ButtonGUI Option.png", (int)SpriteType.Button)); //3
            _mySprites.Add(new Sprite("InGameMainGUI.png", (int)SpriteType.GUI)); //1
            _mySprites.Add(new Sprite("InGameButton Character.png", (int)SpriteType.Button)); //4
            _mySprites.Add(new Sprite("InGameButton Inventory.png", (int)SpriteType.Button)); //5
            _mySprites.Add(new Sprite("InGameButton Equipment.png", (int)SpriteType.Button)); //6
            _mySprites.Add(new Sprite("Inventory Background.png", (int)SpriteType.GUI)); //2
            _mySprites.Add(new Sprite("InventorySpace.png", (int)SpriteType.Button)); //7
            _mySprites.Add(new Sprite("Locked Inventory Space.png", (int)SpriteType.Button)); //8
            _mySprites.Add(new Sprite("Log.png", (int)SpriteType.Items)); // 0
            _mySprites.Add(new Sprite("TreeLastStage.png", (int)SpriteType.Resource)); // 0
            _mySprites.Add(new Sprite("Equipment Background.png", (int)SpriteType.GUI)); // 3
            _mySprites.Add(new Sprite("Ammunition Slot.png", (int)SpriteType.Button)); // 9
            _mySprites.Add(new Sprite("Armor Slot.png", (int)SpriteType.Button)); // 10
            _mySprites.Add(new Sprite("Boot Slot.png", (int)SpriteType.Button)); // 11
            _mySprites.Add(new Sprite("Bracelet Slot.png", (int)SpriteType.Button)); // 12
            _mySprites.Add(new Sprite("Cape Slot.png", (int)SpriteType.Button)); // 13
            _mySprites.Add(new Sprite("Helmet Slot.png", (int)SpriteType.Button)); // 14
            _mySprites.Add(new Sprite("Necklace Slot.png", (int)SpriteType.Button)); // 15
            _mySprites.Add(new Sprite("Offhand Slot.png", (int)SpriteType.Button)); // 16
            _mySprites.Add(new Sprite("Ring Slot.png", (int)SpriteType.Button)); // 17
            _mySprites.Add(new Sprite("Storage Slot.png", (int)SpriteType.Button)); // 18
            _mySprites.Add(new Sprite("Weapon Slot.png", (int)SpriteType.Button)); // 19
            _mySprites.Add(new Sprite("Close Button.png", (int)SpriteType.Button)); // 20
            _mySprites.Add(new Sprite("Inventory Head.png", (int)SpriteType.Button)); // 21
            _mySprites.Add(new Sprite("Equipment Head.png", (int)SpriteType.Button)); // 22
            _mySprites.Add(new Sprite("Wooden Hatchet.png", (int)SpriteType.Items)); // 1
            _mySprites.Add(new Sprite("Wooden Hatchet_drop.png", (int)SpriteType.DropSprite)); // 0
            _mySprites.Add(new Sprite("Log drop.png", (int)SpriteType.DropSprite)); // 1
            _mySprites.Add(new Sprite("HUD.png", (int)SpriteType.GUI)); // 4
            _mySprites.Add(new Sprite("Health Bar.png", (int)SpriteType.Button)); // 23
            _mySprites.Add(new Sprite("Mana Bar.png", (int)SpriteType.Button)); // 24
            _mySprites.Add(new Sprite("Experience Bar.png", (int)SpriteType.Button)); // 25
            _mySprites.Add(new Sprite("System Log.png", (int)SpriteType.GUI)); // 5
            _mySprites.Add(new Sprite("ArrowUp.png", (int)SpriteType.Button)); // 26
            _mySprites.Add(new Sprite("ArrowDown.png", (int)SpriteType.Button)); // 27
            _mySprites.Add(new Sprite("CloseChat.png", (int)SpriteType.Button)); // 28
            _mySprites.Add(new Sprite("OpenChat.png", (int)SpriteType.Button)); // 29
            _mySprites.Add(new Sprite("LogEnter.png", (int)SpriteType.Button)); // 30
            _mySprites.Add(new Sprite("Log Head.png", (int)SpriteType.Button)); // 31
            _mySprites.Add(new Sprite("MouseNormal.png", (int)SpriteType.Mouse)); // 0
            _mySprites.Add(new Sprite("MouseDrag.png", (int)SpriteType.Mouse)); // 1
            _mySprites.Add(new Sprite("Inventory Quick Craft.png", (int)SpriteType.Button)); // 32
            _mySprites.Add(new Sprite("Inventory Drop All.png", (int)SpriteType.Button)); // 33
            _mySprites.Add(new Sprite("Inventory Destroy.png", (int)SpriteType.Button)); // 34
            _mySprites.Add(new Sprite("Drop GUI background.png", (int)SpriteType.GUI)); // 6
            _mySprites.Add(new Sprite("Drop Head.png", (int)SpriteType.Button)); // 35
            _mySprites.Add(new Sprite("Drop Pick All.png", (int)SpriteType.Button)); // 36
            _mySprites.Add(new Sprite("Right Click base.png", (int)SpriteType.Button)); // 37
            _mySprites.Add(new Sprite("ActionGUI Background.png", (int)SpriteType.GUI)); // 7
            _mySprites.Add(new Sprite("Action GUI Build.png", (int)SpriteType.Button)); // 38
            _mySprites.Add(new Sprite("Action GUI Craft.png", (int)SpriteType.Button)); // 39
            _mySprites.Add(new Sprite("Action GUI Left Arrow.png", (int)SpriteType.Button)); // 40
            _mySprites.Add(new Sprite("Action GUI Right Arrow.png", (int)SpriteType.Button)); // 41
            _mySprites.Add(new Sprite("ActionGUI Head.png", (int)SpriteType.Button)); // 42
            _mySprites.Add(new Sprite("InGameButton Action.png", (int)SpriteType.Button)); // 43
            _mySprites.Add(new Sprite("BuildGUI.png", (int)SpriteType.GUI)); // 8
            _mySprites.Add(new Sprite("BuildGUI Arrow Left.png", (int)SpriteType.Button)); // 44
            _mySprites.Add(new Sprite("BuildGUI Arrow Right.png", (int)SpriteType.Button)); // 45
            _mySprites.Add(new Sprite("BuildGUI Class left.png", (int)SpriteType.Button)); // 46
            _mySprites.Add(new Sprite("BuildGUI class right.png", (int)SpriteType.Button)); // 47
            _mySprites.Add(new Sprite("BuildGUI Head.png", (int)SpriteType.Button)); // 48
            _mySprites.Add(new Sprite("BuildGUI Ok.png", (int)SpriteType.Button)); // 49
            _mySprites.Add(new Sprite("BuildGUI Pick ArrowDown.png", (int)SpriteType.Button)); // 50
            _mySprites.Add(new Sprite("BuildGUI Pick ArrowUp.png", (int)SpriteType.Button)); // 51
            _mySprites.Add(new Sprite("BuildGUI Square.png", (int)SpriteType.Button)); // 52
            _mySprites.Add(new Sprite("BuildFire.png", (int)SpriteType.BuildSprite)); // 0
            _mySprites.Add(new Sprite("BuildFireSprite.png", (int)SpriteType.BuildingSprite)); // 0
            _mySprites.Add(new Sprite("ConstructionGUI Background.png", (int)SpriteType.GUI)); // 9
            _mySprites.Add(new Sprite("Construction GUI Head.png", (int)SpriteType.Button)); // 53
            _mySprites.Add(new Sprite("ConstructionGUI Build.png", (int)SpriteType.Button)); // 54
            _mySprites.Add(new Sprite("Default 1x1 construct.png", (int)SpriteType.BuildingSprite)); // 1
            _mySprites.Add(new Sprite("ConstructionGUI Item.png", (int)SpriteType.Button)); // 55
        }

        public List<Buildable> GetBuildableList()
        {
            List<Buildable> b = new List<Buildable>();
            foreach (Spawnable s in MySpawnable)
                if (s is Buildable)
                    b.Add((Buildable)s);
            return b;
        }

        public List<Resource> GetResourceList()
        {
            List<Resource> b = new List<Resource>();
            foreach (Spawnable s in MySpawnable)
                if (s is Resource)
                    b.Add((Resource)s);
            return b;
        }

        public List<Texture> SpriteBasedOnType(SpriteType s)
        {
            List<Texture> _sprite = new List<Texture>();
            for (int i = 0; i < _mySprites.Count; i++)
            {
                if (_mySprites[i].Type == (int)s)
                    _sprite.Add(_mySprites[i].Texture);
            }
            return _sprite;
        }

        public List<TerrainData> MyTerrain
        {
            get { return _myTerrain; }
        }

        public List<Sprite> MySprites
        {
            get { return _mySprites; }
        }

        public List<TileData> MyTileData
        {
            get { return _myTileData; }
        }

        public List<LivingObject> MyLivingObject
        {
            get { return _myLivingThings; }
        }

        public List<PlayerData> MyPlayerData
        {
            get { return _playerDatas; }
        }

        public List<Items> MyItems
        {
            get { return _myItems; }
        }

        public List<Spawnable> MySpawnable
        {
            get { return _mySpawnable; }
        }

        public int TileSizeX
        {
            get { return _tileSizeX; }
            set { _tileSizeX = value; }
        }

        public int TileSizeY
        {
            get { return _tileSizeY; }
            set { _tileSizeY = value; }
        }

        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }
    }
}
