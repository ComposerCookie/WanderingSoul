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
        List<Knowledge> _myKnowledge;
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
            _myKnowledge = new List<Knowledge>();
            MyAnimation = new List<Animation>();
            MyAttack = new List<Attack>();
            FaceData = new List<Face>();
            HairData = new List<Hair>();
            BodyData = new List<Body>();
            _font = new Font("Georgia.ttf");
            GraphicPath = new List<string>();
            PartySlotUnlock = 2;
            MyVariation = new List<TileVariation>();
            MyWorldData = new List<World>();
            
        }

        public void CreateTileVariation()
        {
            MyVariation.Add(new TileVariation(0));
            MyVariation.Add(new TileVariation(1));
            MyVariation.Add(new TileVariation(2));
            MyVariation.Add(new TileVariation(3));
            MyVariation.Add(new TileVariation(4));
            MyVariation.Add(new TileVariation(5));
            MyVariation.Add(new TileVariation(6));
            MyVariation.Add(new TileVariation(7));
            MyVariation.Add(new TileVariation(8));
            MyVariation.Add(new TileVariation(9));
            MyVariation.Add(new TileVariation(10));
        }

        public void LoadPlayerData()
        {
            PlayerData p = new PlayerData();
            NPC n = new NPC("ASD", 0, 0, 0, false, 0, 0, 0, 0, 0, false, 8, 0, 0, 0);
            n.Inventory[0] = new SpawnItems(1);
            n.Inventory[1] = new SpawnItems(0);
            n.Inventory[2] = new SpawnItems(0);
            n.Inventory[3] = new SpawnItems(0);
            n.Inventory[4] = new SpawnItems(0);
            p.MainParty.MyParty.Add(n);
            MyPlayerData.Add(p);
        }

        public void LoadWorldData()
        {
            World w = new World();
            Hostile h = new Hostile("Fiora", (int)LivingObjectType.Hostile, 0, (int)MapType.MainMap, 4, 4, 30, new List<int>(){0}, 60);
            //h.CurMap = w.OverWorld;
            //w.OverWorld.AddLivingThing(h, 0, 0);
            MyWorldData.Add(w);
        }

        public void CreateGraphicPath()
        {
            GraphicPath.Add("Gfx\\"); // 0: core graphic path;

            // **Gfx/**
            GraphicPath.Add("Animation\\"); // 1: animation path;
            GraphicPath.Add("Buildable\\"); // 2: buildable path;
            GraphicPath.Add("Face\\"); // 3: Face path;
            GraphicPath.Add("GUI\\"); // 4: GUI path;
            GraphicPath.Add("Item\\"); // 5: item path;
            GraphicPath.Add("Knowledge\\"); // 6: Knowledge path;
            GraphicPath.Add("Miscellaneous\\"); // 7: Miscellaneous path;
            GraphicPath.Add("Mouse\\"); // 8: mouse path;
            GraphicPath.Add("Resource\\"); // 9: Resource path;
            GraphicPath.Add("Sprite\\"); // 10: Sprite path;
            GraphicPath.Add("Tile\\"); // 11: core graphic path;
            GraphicPath.Add("Weather\\"); // 12: core graphic path;

            // **Buildable/**
            GraphicPath.Add("Representation\\"); // 13: Representation for building path;
            GraphicPath.Add("Sprite\\"); // 14: Building Sprite path;

            // **GUI/**
            GraphicPath.Add("In Game\\"); // 15: In game GUI path;
            GraphicPath.Add("Main Menu\\"); // 16: Main Menu GUI path;

            // **Item/**
            GraphicPath.Add("Drop\\"); // 17: item drop sprite path;
            GraphicPath.Add("Sprite\\"); // 18: item sprite path;

            // **Sprites/**
            GraphicPath.Add("Female\\"); // 19: Female sprite path;
            GraphicPath.Add("Male\\"); // 20: Male Sprite path;
            GraphicPath.Add("Body\\"); // 21: Female sprite path;
            GraphicPath.Add("Face\\"); // 22: Face path;
            GraphicPath.Add("Hair\\"); // 23: Hair path;

            // **GUI/In Game**
            GraphicPath.Add("Action\\"); // 24: action GUI
            GraphicPath.Add("Build\\"); // 25: build gui
            GraphicPath.Add("Character\\"); // 26: character gui;
            GraphicPath.Add("Construction\\"); // 27: construction GUI ;
            GraphicPath.Add("Craft\\"); // 28: craft gui
            GraphicPath.Add("Drop\\"); // 29: drop gui;
            GraphicPath.Add("Equipment\\"); // 30: equipment gui;
            GraphicPath.Add("HUD\\"); // 31: hud gui;
            GraphicPath.Add("Inventory\\"); // 32: inventory gui;
            GraphicPath.Add("Knowledge\\"); // 33: knowledge path;
            GraphicPath.Add("Log\\"); // 34: log gui path;
            GraphicPath.Add("MiniHUD\\"); // 35: minihud path;
            GraphicPath.Add("Right Click\\"); // 36: right click path;

            // GUI/Main Menu
            GraphicPath.Add("Main\\"); // 37: right click path;
            GraphicPath.Add("Title Screen\\"); // 38 Title Screen Path;

            GraphicPath.Add("Character Creation\\"); // Character Creation Path; 39
            GraphicPath.Add("Pick Party\\"); // Pick Party path 40
            GraphicPath.Add("View Party\\"); // View Party path 41

            GraphicPath.Add("Hostile\\"); // 42: GFX\Sprite\Hostile;
            GraphicPath.Add("Pick World\\"); // 43 GFX\GUI\Main Menu\Pick World
            GraphicPath.Add("New World\\"); // 44 GFX\GUI\Main Menu\New World

            GraphicPath.Add("Base\\"); // 45 GFX\Tile\Base\
            GraphicPath.Add("Variation\\"); // 46 GFX\Tile\Variation\
        }

        public List<Face> GetFaceBasedOnGender(byte g)
        {
            List<Face> List = new List<Face>();
            foreach (Face f in Program.Data.FaceData)
                if (f.Gender == g)
                    List.Add(f);
            return List;
        }

        public List<Hair> GetHairBasedOnGender(byte g)
        {
            List<Hair> List = new List<Hair>();
            foreach (Hair h in Program.Data.HairData)
                if (h.Gender == g)
                    List.Add(h);
            return List;
        }

        public List<Body> GetBodyBasedOnGender(byte g)
        {
            List<Body> List = new List<Body>();
            foreach (Body b in Program.Data.BodyData)
                if (b.Gender == g)
                    List.Add(b);
            return List;
        }

        public void CreateFaceData()
        {
            FaceData.Add(new Face(0, 0, 1));
            FaceData.Add(new Face(1, 0, 1));
            FaceData.Add(new Face(2, 0, 0));
            FaceData.Add(new Face(3, 0, 0));
        }

        public void CreateHairData()
        {
            HairData.Add(new Hair(new List<int>() { 0 }, 0, 1));
            HairData.Add(new Hair(new List<int>() { 1, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 0, 1));
            HairData.Add(new Hair(new List<int>() { 2 }, 0, 0));
            HairData.Add(new Hair(new List<int>() { 3, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 }, 0, 0));
            HairData.Add(new Hair(new List<int>() { 4, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 }, 0, 1));
            HairData.Add(new Hair(new List<int>() { 5, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 }, 0, 0));
        }

        public void CreateBodyData()
        {
            BodyData.Add(new Body(0, 0, 1));
            BodyData.Add(new Body(1, 1, 1));
            BodyData.Add(new Body(2, 2, 0));
            BodyData.Add(new Body(3, 3, 0));
            BodyData.Add(new Body(4, 0, 1));
            BodyData.Add(new Body(5, 1, 1));
            BodyData.Add(new Body(6, 0, 1));
            BodyData.Add(new Body(7, 1, 0));
            BodyData.Add(new Body(8, 0, 0));
            BodyData.Add(new Body(9, 1, 0));
        }

        public void CreateAnimation()
        {
            MyAnimation.Add(new Animation("Punch", 1, 16, 16, 0, 3));
            MyAnimation.Add(new Animation("Slash", 3, 16, 16, 1, 3));
            MyAnimation.Add(new Animation("Bash", 3, 16, 16, 2, 3));
            MyAnimation.Add(new Animation("Hack", 3, 16, 16, 3, 3));
            MyAnimation.Add(new Animation("Shield", 1, 16, 16, 4, 20));
        }

        public void CreateAttack()
        {
            MyAttack.Add(new BasicAttack("Slash", 9, 1, 1));
            MyAttack.Add(new BasicAttack("Punch", 5, 1, 0));
            MyAttack.Add(new BasicAttack("Bash", 7, 1, 2));
            MyAttack.Add(new BasicAttack("Hack", 9, 1, 3));
            MyAttack.Add(new ShieldAttack("Shield", 10, 4, 0, false, 3));
        }

        public void CreateKnowledge()
        {
            _myKnowledge.Add(new Knowledge("Dejavu", new List<int>(), new List<int>() { }, 0, 0));
            _myKnowledge.Add(new Knowledge("Lumberjacking", new List<int>(){1}, new List<int>() { 0 }, 30, 1));
        }

        public void CreateTerrain()
        {
            _myTerrain.Add(new TerrainData(Enum.GetName(typeof(TerrainTypeEnum), 0), 0, 0, 0, 0));
            _myTerrain.Add(new TerrainData(Enum.GetName(typeof(TerrainTypeEnum), 1), 1, 0, 1, 0));
            _myTerrain.Add(new TerrainData(Enum.GetName(typeof(TerrainTypeEnum), 2), 2, 0, 2, 0));
            _myTerrain.Add(new TerrainData(Enum.GetName(typeof(TerrainTypeEnum), 3), 2, 0, 3, 0));
        }

        public void CreateSpawnable()
        {
            _mySpawnable.Add(new TreeResource("Pine Tree", 0, 1, 1, 3, new List<SpawnItems>(){new SpawnItems(0)}, new List<int>(){(int)TerrainTypeEnum.Forest}, 1, 0, (int)ToolType.Hatchet));
            _mySpawnable.Add(new BuildFire("Tinder", 3, 1, 1, 0, 1, -1, -1, -1, 1, new List<int>() { 0 }, new Dictionary<SpawnItems, int>() { { new SpawnItems(0), 3 } }, new List<SpawnItems>(), 600, new List<int>() { (int)MapType.MainMap }, new List<int>() { 2, 3, 4, 5 }, 5));
            List<List<List<int>>> house = new List<List<List<int>>>();
            List<List<int>> Floor = new List<List<int>>();
            Floor.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 });
            Floor.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 });
            Floor.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 });
            Floor.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 });
            Floor.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 });
            house.Add(Floor);
            _mySpawnable.Add(new BuildableHouse("Wooden 3x2 House", 10, 3, 2, 1, 7, 6, 6, 6, 6, 1, new List<int> { 0 }, new Dictionary<SpawnItems, int>() { { new SpawnItems(0), 3 } }, new List<SpawnItems>(), true, house, new List<int>() { 0 }, new List<List<HouseAttribute>>() { new List<HouseAttribute>() { new HouseAttributeWarp(3, 4, (int)MapType.MainMap, 0) } }, new List<KeyValuePair<int, int>>() { new KeyValuePair<int, int>(1, 1)}));
        }

        public void CreateItems()
        {
            _myItems.Add(new ResourceItem("Log", 0, (int)ItemType.Resource, 1, true));
            _myItems.Add(new ToolItem("Wooden Hatchet", (int)ItemType.Weapon, 1, 0, false, new Dictionary<int, int>(){{0, 3}}, (int)ToolType.Hatchet, new List<int>(){0}, MyAttack[0], 90, (int)WeaponType.Axe));
            _myItems.Add(new ShieldWeaponItem("Shield", 2, (int)ItemType.Weapon, 2, false, MyAttack[4], 75, (int)WeaponType.Shield));
        }

        public void CreateTileData()
        {
            _myTileData.Add(new TileData(new List<int>()));
            _myTileData.Add(new TileData(new List<int>()));
            _myTileData.Add(new TileData(new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
            _myTileData.Add(new TileData(new List<int>()));
        }

        public void CreateLivingObjectData()
        {
            
        }

        public void CreateSpriteData()
        {
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[42] + "Jacqueline.png", (int)SpriteType.Sprite)); //0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[42] + "Ragged Jackryder.png", (int)SpriteType.Sprite)); //1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[37] + "MainMenuGUI.png", (int)SpriteType.GUI)); //0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[37] + "ButtonGUI New Game.png", (int)SpriteType.Button)); //0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[37] + "ButtonGUI Close Game.png", (int)SpriteType.Button)); //1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[37] + "ButtonGUI Load Game.png", (int)SpriteType.Button)); //2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[37] + "ButtonGUI Option.png", (int)SpriteType.Button)); //3
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + "InGameMainGUI.png", (int)SpriteType.GUI)); //1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[26] + "InGameButton Character.png", (int)SpriteType.Button)); //4
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[32] + "InGameButton Inventory.png", (int)SpriteType.Button)); //5
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "InGameButton Equipment.png", (int)SpriteType.Button)); //6
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[32] + "Inventory Background.png", (int)SpriteType.GUI)); //2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[32] + "InventorySpace.png", (int)SpriteType.Button)); //7
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[32] + "Locked Inventory Space.png", (int)SpriteType.Button)); //8
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[5] + GraphicPath[18] + "Log.png", (int)SpriteType.Items)); // 0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[9] + "TreeLastStage.png", (int)SpriteType.Resource)); // 0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Equipment Background.png", (int)SpriteType.GUI)); // 3
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Ammunition Slot.png", (int)SpriteType.Button)); // 9
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Armor Slot.png", (int)SpriteType.Button)); // 10
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Boot Slot.png", (int)SpriteType.Button)); // 11
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Bracelet Slot.png", (int)SpriteType.Button)); // 12
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Cape Slot.png", (int)SpriteType.Button)); // 13
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Helmet Slot.png", (int)SpriteType.Button)); // 14
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Necklace Slot.png", (int)SpriteType.Button)); // 15
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Offhand Slot.png", (int)SpriteType.Button)); // 16
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Ring Slot.png", (int)SpriteType.Button)); // 17
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Storage Slot.png", (int)SpriteType.Button)); // 18
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Weapon Slot.png", (int)SpriteType.Button)); // 19
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + "Close Button.png", (int)SpriteType.Button)); // 20
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[32] + "Inventory Head.png", (int)SpriteType.Button)); // 21
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[30] + "Equipment Head.png", (int)SpriteType.Button)); // 22
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[5] + GraphicPath[18] + "Wooden Hatchet.png", (int)SpriteType.Items)); // 1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[5] + GraphicPath[17] + "Wooden Hatchet_drop.png", (int)SpriteType.DropSprite)); // 0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[5] + GraphicPath[17] + "Log drop.png", (int)SpriteType.DropSprite)); // 1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[31] + "HUD.png", (int)SpriteType.GUI)); // 4
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[31] + "Health Bar.png", (int)SpriteType.Button)); // 23
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[31] + "Mana Bar.png", (int)SpriteType.Button)); // 24
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[31] + "Stamina Bar.png", (int)SpriteType.Button)); // 25
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[34] + "System Log.png", (int)SpriteType.GUI)); // 5
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[34] + "ArrowUp.png", (int)SpriteType.Button)); // 26
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[34] + "ArrowDown.png", (int)SpriteType.Button)); // 27
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[34] + "CloseChat.png", (int)SpriteType.Button)); // 28
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[34] + "OpenChat.png", (int)SpriteType.Button)); // 29
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[34] + "LogEnter.png", (int)SpriteType.Button)); // 30
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[34] + "Log Head.png", (int)SpriteType.Button)); // 31
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[8] + "MouseNormal.png", (int)SpriteType.Mouse)); // 0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[8] + "MouseDrag.png", (int)SpriteType.Mouse)); // 1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[32] + "Inventory Quick Craft.png", (int)SpriteType.Button)); // 32
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[32] + "Inventory Drop All.png", (int)SpriteType.Button)); // 33
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[32] + "Inventory Destroy.png", (int)SpriteType.Button)); // 34
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[29] + "Drop GUI background.png", (int)SpriteType.GUI)); // 6
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[29] + "Drop Head.png", (int)SpriteType.Button)); // 35
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[29] + "Drop Pick All.png", (int)SpriteType.Button)); // 36
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[36] + "Right Click base.png", (int)SpriteType.Button)); // 37
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[24] + "ActionGUI Background.png", (int)SpriteType.GUI)); // 7
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[24] + "Action GUI Build.png", (int)SpriteType.Button)); // 38
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[24] + "Action GUI Craft.png", (int)SpriteType.Button)); // 39
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[24] + "Action GUI Left Arrow.png", (int)SpriteType.Button)); // 40
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[24] + "Action GUI Right Arrow.png", (int)SpriteType.Button)); // 41
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[24] + "ActionGUI Head.png", (int)SpriteType.Button)); // 42
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[24] + "InGameButton Action.png", (int)SpriteType.Button)); // 43
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[25] + "BuildGUI Background.png", (int)SpriteType.GUI)); // 8
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[25] + "BuildGUI Arrow Left.png", (int)SpriteType.Button)); // 44
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[25] + "BuildGUI Arrow Right.png", (int)SpriteType.Button)); // 45
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[25] + "BuildGUI Class Left.png", (int)SpriteType.Button)); // 46
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[25] + "BuildGUI Class Right.png", (int)SpriteType.Button)); // 47
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[25] + "BuildGUI Head.png", (int)SpriteType.Button)); // 48
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[25] + "BuildGUI Ok.png", (int)SpriteType.Button)); // 49
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[25] + "BuildGUI Pick Down.png", (int)SpriteType.Button)); // 50
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[25] + "BuildGUI Pick Up.png", (int)SpriteType.Button)); // 51
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[2] + GraphicPath[13] + "BuildFire.png", (int)SpriteType.BuildSprite)); // 0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[2] + GraphicPath[14] + "BuildFireSprite.png", (int)SpriteType.BuildingSprite)); // 0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[27] + "ConstructionGUI Background.png", (int)SpriteType.GUI)); // 9
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[27] + "Construction GUI Head.png", (int)SpriteType.Button)); // 52
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[27] + "ConstructionGUI Build.png", (int)SpriteType.Button)); // 53
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[2] + "Default 1x1 construct.png", (int)SpriteType.BuildingSprite)); // 1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[27] + "ConstructionGUI Item.png", (int)SpriteType.Button)); // 54
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[28] + "Crafting GUI Background.png", (int)SpriteType.GUI)); // 10
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[28] + "CraftGUI Head.png", (int)SpriteType.Button)); // 55
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "Knowledge GUI Background.png", (int)SpriteType.GUI)); // 11
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "KnowledgeGUI Head.png", (int)SpriteType.Button)); // 56
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "KnowledgeGUI Bar.png", (int)SpriteType.Button)); // 57
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "KnowledgeGUI Blueprint Button.png", (int)SpriteType.Button)); // 58
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "KnowledgeGUI Buy Button.png", (int)SpriteType.Button)); // 59
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "KnowledgeGUI Craft Button.png", (int)SpriteType.Button)); // 60
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "KnowledgeGUI Knowledge Button.png", (int)SpriteType.Button)); // 61
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "KnowledgeGUI Own Button.png", (int)SpriteType.Button)); // 62
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "KnowledgeGUI Scroll Bar.png", (int)SpriteType.Button)); // 63
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "KnowledgeGUI Scroll Down Button.png", (int)SpriteType.Button)); // 64
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "KnowledgeGUI Scroll Up Button.png", (int)SpriteType.Button)); // 65
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "InGameButton Knowledge.png", (int)SpriteType.Button)); // 66
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[33] + "KnowledgeGUI Divisor.png", (int)SpriteType.Button)); // 67
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[6] + "Dejavu Knowledge.png", (int)SpriteType.Knowledge)); // 0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[6] + "Lumberjacking Knowledge.png", (int)SpriteType.Knowledge)); // 1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[35] + "MiniHUD.png", (int)SpriteType.SmallHUD)); // 0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[1] + "Punch Animation.png", (int)SpriteType.Animation)); // 0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[1] + "Slash Animation.png", (int)SpriteType.Animation)); // 1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[1] + "Bash Animation.png", (int)SpriteType.Animation)); // 2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[1] + "Hack Animation.png", (int)SpriteType.Animation)); // 3
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[1] + "Shield Animation.png", (int)SpriteType.Animation)); // 3
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[5] + GraphicPath[18] + "Shield Item.png", (int)SpriteType.Items)); // 2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[5] + GraphicPath[17] + "Shield Drop Sprite.png", (int)SpriteType.DropSprite)); // 2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[38] + "Title Scene.png", (int)SpriteType.TitleBackground)); //0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[38] + "Fire 1.png", (int)SpriteType.TitleBackground)); //1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[38] + "Fire 2.png", (int)SpriteType.TitleBackground)); //2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[38] + "Fire 3.png", (int)SpriteType.TitleBackground)); //3
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[38] + "Fire 4.png", (int)SpriteType.TitleBackground)); //4
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[38] + "Shade 1.png", (int)SpriteType.TitleBackground)); //5
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[38] + "Shade 2.png", (int)SpriteType.TitleBackground)); //6
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[38] + "Shade 3.png", (int)SpriteType.TitleBackground)); //7
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[38] + "Shade 4.png", (int)SpriteType.TitleBackground)); //8
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[39] + "CCPickLeft.png", (int)SpriteType.Button)); //68
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[39] + "CCPickRight.png", (int)SpriteType.Button)); //69
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[39] + "Character Creation GUI.png", (int)SpriteType.GUI)); //12
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[40] + "Pick Party GUI.png", (int)SpriteType.GUI)); //13
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[40] + "MorePartyBar.png", (int)SpriteType.Button)); //70
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[40] + "MorePartyDown.png", (int)SpriteType.Button)); //71
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[40] + "MorePartyUp.png", (int)SpriteType.Button)); //72
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[40] + "NewParty.png", (int)SpriteType.Button)); //73
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[40] + "PartyLoading.png", (int)SpriteType.Button)); //74
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[40] + "PartySelection.png", (int)SpriteType.Button)); //75
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[41] + "View Party GUI.png", (int)SpriteType.GUI)); //14
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[41] + "ViewPartyLocked.png", (int)SpriteType.Button)); //76
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[41] + "ViewPartySummonerPlatform.png", (int)SpriteType.Button)); //77
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + "MainMenuDelete.png", (int)SpriteType.Button)); //78
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + "MainMenuOk.png", (int)SpriteType.Button)); //79
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[31] + "FaceSlot.png", (int)SpriteType.Button)); // 80
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[31] + "Party HP Bar.png", (int)SpriteType.Button)); // 81
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[31] + "Party Mana Bar.png", (int)SpriteType.Button)); // 82
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[31] + "Party Stamina Bar.png", (int)SpriteType.Button)); // 83
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[31] + "Party Hunger Bar.png", (int)SpriteType.Button)); // 84
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[31] + "Party EXP Bar.png", (int)SpriteType.Button)); // 85
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[15] + GraphicPath[31] + "EXP Bar.png", (int)SpriteType.Button)); // 86
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[40] + "CurrentSelection.png", (int)SpriteType.Button)); //87
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[21] + "Body 1.png", (int)SpriteType.Body)); //0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[21] + "Body 2.png", (int)SpriteType.Body)); //1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[21] + "Body 1.png", (int)SpriteType.Body)); //2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[21] + "Body 2.png", (int)SpriteType.Body)); //3
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[22] + "Face 1.png", (int)SpriteType.Face)); //0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[22] + "Face 2.png", (int)SpriteType.Face)); //1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[22] + "Face 1.png", (int)SpriteType.Face)); //2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[22] + "Face 2.png", (int)SpriteType.Face)); //3
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 1.png", (int)SpriteType.Hair)); //0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 2 Black.png", (int)SpriteType.Hair)); //1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 1.png", (int)SpriteType.Hair)); //2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 2 Black.png", (int)SpriteType.Hair)); //3
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[39] + "Edit Character.png", (int)SpriteType.Button)); //88
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[39] + "Name Text Field.png", (int)SpriteType.Button)); //89
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[39] + "Gender Square.png", (int)SpriteType.Button)); //90
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + "NewPartyOK.png", (int)SpriteType.Button)); //91
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[43] + "Pick World GUI.png", (int)SpriteType.GUI)); // 15
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[4] + GraphicPath[16] + GraphicPath[44] + "New World GUI.png", (int)SpriteType.GUI)); // 16
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[45] + "Dirt.png", (int)SpriteType.Tile)); // 0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[45] + "Forest.png", (int)SpriteType.Tile)); // 1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[45] + "Grass.png", (int)SpriteType.Tile)); // 2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[45] + "Plain.png", (int)SpriteType.Tile)); // 3
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[46] + "1 White Flower A.png", (int)SpriteType.Variation)); // 0
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[46] + "1 White Flower B.png", (int)SpriteType.Variation)); // 1
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[46] + "1 White Flower C.png", (int)SpriteType.Variation)); // 2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[46] + "1 White Flower D.png", (int)SpriteType.Variation)); // 3
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[46] + "1 White Flower E.png", (int)SpriteType.Variation)); // 4
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[46] + "2 White Flower A.png", (int)SpriteType.Variation)); // 5
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[46] + "2 White Flower B.png", (int)SpriteType.Variation)); // 6
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[46] + "2 White Flower C.png", (int)SpriteType.Variation)); // 7
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[46] + "2 White Flower D.png", (int)SpriteType.Variation)); // 8
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[46] + "3 White Flower A.png", (int)SpriteType.Variation)); // 9
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[11] + GraphicPath[46] + "3 White Flower B.png", (int)SpriteType.Variation)); // 10
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 3 Black.png", (int)SpriteType.Hair)); //4
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 3 Black.png", (int)SpriteType.Hair)); //5
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[21] + "Body 4.png", (int)SpriteType.Body)); //4
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[21] + "Body 5.png", (int)SpriteType.Body)); //5
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[21] + "Body 6.png", (int)SpriteType.Body)); //6
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[21] + "Body 4.png", (int)SpriteType.Body)); //7
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[21] + "Body 5.png", (int)SpriteType.Body)); //8
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[21] + "Body 6.png", (int)SpriteType.Body)); //9
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 2 Blue.png", (int)SpriteType.Hair)); //6
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 2 Brown.png", (int)SpriteType.Hair)); //7
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 2 Gray.png", (int)SpriteType.Hair)); //8
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 2 Green.png", (int)SpriteType.Hair)); //9
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 2 Orange.png", (int)SpriteType.Hair)); //10
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 2 Pink.png", (int)SpriteType.Hair)); //11
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 2 Purple.png", (int)SpriteType.Hair)); //12
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 2 Red.png", (int)SpriteType.Hair)); //13
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 2 White.png", (int)SpriteType.Hair)); //14
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 2 Yellow.png", (int)SpriteType.Hair)); //15
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 3 Blue.png", (int)SpriteType.Hair)); //16
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 3 Brown.png", (int)SpriteType.Hair)); //17
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 3 Gray.png", (int)SpriteType.Hair)); //18
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 3 Green.png", (int)SpriteType.Hair)); //19
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 3 Orange.png", (int)SpriteType.Hair)); //20
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 3 Pink.png", (int)SpriteType.Hair)); //21
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 3 Purple.png", (int)SpriteType.Hair)); //22
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 3 Red.png", (int)SpriteType.Hair)); //23
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 3 White.png", (int)SpriteType.Hair)); //24
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[19] + GraphicPath[23] + "Hair 3 Yellow.png", (int)SpriteType.Hair)); //25
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 2 Blue.png", (int)SpriteType.Hair)); //26
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 2 Brown.png", (int)SpriteType.Hair)); //27
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 2 Gray.png", (int)SpriteType.Hair)); //28
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 2 Green.png", (int)SpriteType.Hair)); //29
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 2 Orange.png", (int)SpriteType.Hair)); //30
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 2 Pink.png", (int)SpriteType.Hair)); //31
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 2 Purple.png", (int)SpriteType.Hair)); //32
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 2 Red.png", (int)SpriteType.Hair)); //33
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 2 White.png", (int)SpriteType.Hair)); //34
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 2 Yellow.png", (int)SpriteType.Hair)); //35
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 3 Blue.png", (int)SpriteType.Hair)); //36
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 3 Brown.png", (int)SpriteType.Hair)); //37
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 3 Gray.png", (int)SpriteType.Hair)); //38
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 3 Green.png", (int)SpriteType.Hair)); //39
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 3 Orange.png", (int)SpriteType.Hair)); //40
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 3 Pink.png", (int)SpriteType.Hair)); //41
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 3 Purple.png", (int)SpriteType.Hair)); //42
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 3 Red.png", (int)SpriteType.Hair)); //43
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 3 White.png", (int)SpriteType.Hair)); //44
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[10] + GraphicPath[20] + GraphicPath[23] + "Hair 3 Yellow.png", (int)SpriteType.Hair)); //45
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[2] + GraphicPath[14] + "Build Fire Sprite Anim 1.png", (int)SpriteType.BuildingSprite)); // 2
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[2] + GraphicPath[14] + "Build Fire Sprite Anim 2.png", (int)SpriteType.BuildingSprite)); // 3
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[2] + GraphicPath[14] + "Build Fire Sprite Anim 3.png", (int)SpriteType.BuildingSprite)); // 4
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[2] + GraphicPath[14] + "Build Fire Sprite Anim 4.png", (int)SpriteType.BuildingSprite)); // 5
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[2] + "Default 3x2 construct.png", (int)SpriteType.BuildingSprite)); // 6
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[2] + GraphicPath[14] + "Wooden 3x2 House.png", (int)SpriteType.BuildingSprite)); // 7
            _mySprites.Add(new Sprite(GraphicPath[0] + GraphicPath[2] + GraphicPath[13] + "Wooden 3x2 House.png", (int)SpriteType.BuildSprite)); // 1
        }

        public List<Animation> MyAnimation
        {
            get;
            set;
        }

        public List<Attack> MyAttack
        {
            get;
            set;
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

        public List<Knowledge> MyKnowledge
        {
            get { return _myKnowledge; }
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

        public int PartySlotUnlock { get; set; }

        public List<string> GraphicPath { get; set; }
        public List<Face> FaceData { get; set; }
        public List<Hair> HairData { get; set; }
        public List<Body> BodyData { get; set; }
        public List<World> MyWorldData { get; set; }
        public List<TileVariation> MyVariation { get; set; }
    }
}
