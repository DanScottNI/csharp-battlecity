using System;
using System.Collections.Generic;
using System.Drawing;
using Nini.Config;
using ROMClass;
using ROMClass.Graphics.NES;
using ROMClass.NES;
using System.IO;

namespace BattleCityLib
{
    /// <summary>
    /// Class used to manipulate a Battle City ROM.
    /// </summary>
    public unsafe class BattleCityData : ROMClass.NES.iNESROMAccessor, IDisposable
    {
        private Bitmap _PlayerOneBMP;
        private Bitmap _PlayerTwoBMP;
        private Bitmap _EnemyBMP;
        private NESRender _Tiles;
        private byte[] _PatternTable = new byte[8192];
        private int _CurrentLevel = -1;
        private string _AssetDirectory;
        private string _TypeIcon;
        /// <summary>
        /// The current level's palette.
        /// </summary>
        public byte[,] Palette = new byte[8, 4];

        /// <summary>
        /// Represents the levels in the ROM.
        /// </summary>
        public List<BattleCityLevel> Levels;
        /// <summary>
        /// The currently selected level.
        /// </summary>
        public BattleCityLevel CurrentLevel;

        /// <summary>
        /// The offset for the TSA data.
        /// </summary>
        public int TSAOffset { get; set; }
        /// <summary>
        /// The offset for the background pattern table.
        /// </summary>
        public int BGPatternTableOffset { get; set; }
        /// <summary>
        /// The offset for the sprite pattern table.
        /// </summary>
        public int SprPatternTableOffset { get; set; }
        /// <summary>
        /// The offset for the attribute data.
        /// </summary>
        public int AttributeOffset { get; set; }
        /// <summary>
        /// The offset for the level palette data.
        /// </summary>
        public int LevelPaletteOffset { get; set; }
        /// <summary>
        /// The offset for the sprite palette data.
        /// </summary>
        public int SpritePaletteOffset { get; set; }
        /// <summary>
        /// The offset for the palette frame 1 data.
        /// </summary>
        public int PaletteFrame1Offset { get; set; }
        /// <summary>
        /// The offset for the palette frame 2 data.
        /// </summary>
        public int PaletteFrame2Offset { get; set; }
        /// <summary>
        /// The offset for the title screen palette.
        /// </summary>
        public int TitleScrPaletteOffset { get; set; }
        /// <summary>
        /// The offset for the level selection palette.
        /// </summary>
        public int LevelSelectionPaletteOffset { get; set; }
        /// <summary>
        /// A miscellaneous palette data offset.
        /// </summary>
        public int PaletteMisc1Offset { get; set; }
        /// <summary>
        /// A miscellaneous palette data offset.
        /// </summary>
        public int PaletteMisc2Offset { get; set; }
        /// <summary>
        /// The offset for the normal flag.
        /// </summary>
        public int NormalFlagTSAOffset { get; set; }
        /// <summary>
        /// The offset for the fortified flag.
        /// </summary>
        public int FortifiedFlagTSAOffset { get; set; }
        /// <summary>
        /// The offset for the starting lives.
        /// </summary>
        public int StartingLivesOffset { get; set; }
        /// <summary>
        /// The offset for the starting tank status of player 1.
        /// </summary>
        public int TankStatus1Offset { get; set; }
        /// <summary>
        /// The offset for the starting tank status of player 2.
        /// </summary>
        public int TankStatus2Offset { get; set; }
        private const short BGPATTERNTABLE = 4096;

        /// <summary>
        /// Constructor for the class
        /// </summary>
        /// <param name="filename">The filename of the ROM.</param>
        /// <param name="dataFilename">The filename of the data file, to use in conjunction with this ROM.</param>
        /// <param name="paletteFilename">The filename of the palette file.</param>
        /// <param name="assetDirectory">The directory where the assets that are used by the editor reside.</param>
        public BattleCityData(string filename, string dataFilename, string paletteFilename, string assetDirectory)
        {
            ROM = new iNESROMImage(filename);

            // Set the initial defaults for the asset directory, and currentlevel
            _AssetDirectory = assetDirectory;

            // Create a new instance of the level list.
            Levels = new List<BattleCityLevel>();

            // Create a new instance of the tiles renderer.
            if (System.IO.File.Exists(paletteFilename))
            {
                //ROM.LoadPaletteFile(PaletteFilename);
                _Tiles = new NESRender(256, 16, paletteFilename);
            }
            else
            {
                //ROM.LoadDefaultPalette;
                _Tiles = new NESRender(256, 16);
            }
            LoadDataFile(dataFilename);
            // Load in the background pattern table.
            LoadPatternTable();
        }

        /// <summary>
        /// Gets/sets the starting lives of the player.
        /// </summary>
        public byte StartingLives
        {
            get
            {
                return Convert.ToByte(ROM[StartingLivesOffset] - 1);
            }
            set
            {
                ROM[StartingLivesOffset] = Convert.ToByte(value + 1);
            }
        }

        /// <summary>
        /// Gets/sets the starting status of player one's tank.
        /// </summary>
        public byte TankStatusPlayer1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets/sets the starting status of player two's tank.
        /// </summary>
        public byte TankStatusPlayer2
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Draws the background pattern table to a Bitmap object, using the specified palette colour.
        /// </summary>
        /// <param name="bitmap">The Bitmap object to draw the background pattern table to.</param>
        /// <param name="paletteIndex">The palette index to use when rendering the pattern table.</param>
        public void DrawBGPatternTable(ref Bitmap bitmap, byte paletteIndex)
        {
            NESRender pat = new NESRender(bitmap.Width, bitmap.Height);

            for (int i = 0; i < 16; i++)
            {
                for (int x = 0; x < 16; x++)
                {
                    fixed (byte* pPal = &Palette[paletteIndex, 0])
                    {
                        fixed (byte* pPat = &_PatternTable[BGPATTERNTABLE + (((i * 16) + x) * 0x10)])
                        {
                            pat.DrawTile(x * 8, i * 8, pPat, pPal);
                        }
                    }
                }
            }

            pat.DrawBitmap(ref bitmap);
        }

        /// <summary>
        /// Edits the TSA data of a specific tile.
        /// </summary>
        /// <param name="tileID">The ID of the tile to edit.</param>
        /// <param name="column">Specifies which column of the tile to edit.</param>
        /// <param name="row">Specifies which row of the tile to edit.</param>
        /// <param name="patternTableTileID">The ID of the pattern table tile to replace the existing data with.</param>
        public void EditTSA(byte tileID, byte column, byte row, byte patternTableTileID)
        {
            ROM[TSAOffset + (tileID * 4) + ((row * 2) + column)] = patternTableTileID;
            // Redraw the tile.
            DrawLevelTile(tileID);
        }

        /// <summary>
        /// Draws a specific tank to a bitmap at co-ordinates 0,0.
        /// </summary>
        /// <param name="bitmap">The bitmap to draw the tank object to.</param>
        /// <param name="tankIndex">The index of the tank to draw.</param>
        public void DrawTank(ref Bitmap bitmap, Byte tankIndex)
        {
            NESRender pat = new NESRender(bitmap.Width, bitmap.Height);
            fixed (byte* pPal = &Palette[4, 0])
            {
                fixed (byte* pPat = &_PatternTable[((tankIndex * 0x20) * 16)])
                {
                    pat.DrawTile(0, 0, pPat, pPal);
                }
                fixed (byte* pPat = &_PatternTable[((tankIndex * 0x20) * 16) + 0x10])
                {
                    pat.DrawTile(0, 8, pPat, pPal);
                }
                fixed (byte* pPat = &_PatternTable[((tankIndex * 0x20) * 16) + 0x20])
                {
                    pat.DrawTile(8, 0, pPat, pPal);
                }
                fixed (byte* pPat = &_PatternTable[((tankIndex * 0x20) * 16) + 0x30])
                {
                    pat.DrawTile(8, 8, pPat, pPal);
                }
            }
            pat.DrawBitmap(ref bitmap);
        }

        /// <summary>
        /// Draws a specific level's data to a bitmap.
        /// </summary>
        /// <param name="bitmap">The Bitmap object to draw the level data onto.</param>
        /// <param name="levelIndex">The index of the level to draw.</param>
        /// <param name="displayItemsFlag">Flag that specifics which objects to draw on top of the level data.</param>
        public void DrawLevelData(ref Bitmap bitmap, int levelIndex, LevelDisplayFlag displayItemsFlag)
        {
            for (int i = 0; i <= 12; i++)
            {
                for (int x = 0; x <= 12; x++)
                {
                    _Tiles.DrawBitmap(ref bitmap, new Rectangle(CurrentLevel.GetLevelData(i, x) * 16, 0, 16, 16),
                        new Rectangle(x * 16, i * 16, 16, 16));
                }
            }

            // load in the bitmaps that represent the objects.
            LoadAssets();

            // Declare the graphics object that will be used to draw images onto the source bitmap.
            Graphics g = Graphics.FromImage(bitmap);

            // If the user has chosen to render the enemy start positions, loop through
            // each one, and display them.
            if ((displayItemsFlag & LevelDisplayFlag.ViewEnemy) == LevelDisplayFlag.ViewEnemy)
            {
                for (int i = 0; i < CurrentLevel.StartingPositions.Count; i++)
                {
                    if (CurrentLevel.StartingPositions[i].Type == BattleCityStartingPositionType.Enemy)
                    {
                        g.DrawImage(_EnemyBMP, new Point(CurrentLevel.StartingPositions[i].X * 16, CurrentLevel.StartingPositions[i].Y * 16));
                    }
                }
            }

            // If the user has chosen to render the player start positions, loop through
            // each player, and display them.
            if ((displayItemsFlag & LevelDisplayFlag.ViewPlayer) == LevelDisplayFlag.ViewPlayer)
            {
                for (int i = 0; i < CurrentLevel.StartingPositions.Count; i++)
                {
                    if (CurrentLevel.StartingPositions[i].Type == BattleCityStartingPositionType.PlayerOne)
                    {
                        g.DrawImage(_PlayerOneBMP, new Point(CurrentLevel.StartingPositions[i].X * 16, CurrentLevel.StartingPositions[i].Y * 16));
                    }
                    else if (CurrentLevel.StartingPositions[i].Type == BattleCityStartingPositionType.PlayerTwo)
                    {
                        g.DrawImage(_PlayerTwoBMP, new Point(CurrentLevel.StartingPositions[i].X * 16, CurrentLevel.StartingPositions[i].Y * 16));
                    }
                }
            }

            // If the user has decided to display the level flag, call the DrawNormalFlag function.
            if ( ((displayItemsFlag & LevelDisplayFlag.ViewNormalFlag) == LevelDisplayFlag.ViewNormalFlag)
                || ((displayItemsFlag & LevelDisplayFlag.ViewFortifiedFlag) == LevelDisplayFlag.ViewFortifiedFlag))
            {
                DrawFlag(ref bitmap, displayItemsFlag);
            }


        }

        /// <summary>
        /// Draws the current level's data to a bitmap.
        /// </summary>
        /// <param name="bitmap">The Bitmap object to draw the level to.</param>
        /// <param name="displayItemsFlag">Flag that specifics which objects to draw on top of the level data.</param>
        public void DrawLevelData(ref Bitmap bitmap, LevelDisplayFlag displayItemsFlag)
        {
            DrawLevelData(ref bitmap, _CurrentLevel, displayItemsFlag);
        }

        /// <summary>
        /// Draws a tile selector.
        /// </summary>
        /// <param name="bitmap">The bitmap to draw the tile selector to.</param>
        public void DrawTileSelector(ref Bitmap bitmap)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int x = 0; x < 2; x++)
                {
                    _Tiles.DrawBitmap(ref bitmap, new Rectangle((i * 2 + x) * 16, 0, 16, 16), new Rectangle(x * 16, i * 16, 16, 16));
                }
            }
        }

        /// <summary>
        /// Draws the flag to a bitmap, at position 80x176.
        /// </summary>
        /// <param name="bitmap">The Bitmap object to draw the flag object to.</param>
        /// <param name="flag"></param>
        public void DrawFlag(ref Bitmap bitmap, LevelDisplayFlag flag)
        {
            NESRender pat = new NESRender(48, 32);
            int InitialX = 80;
            int InitialY = 176;

            byte PaletteIndex;

            // If the function is drawing the fortified flag, a different
            // palette index is needed.
            if ((flag & LevelDisplayFlag.ViewFortifiedFlag) == LevelDisplayFlag.ViewFortifiedFlag)
                PaletteIndex = 3;
            else
                PaletteIndex =0;

            for (byte i = 0; i < 4; i++)
            {
                for (byte x = 0; x < 6; x++)
                {
                    fixed (byte* pPal = &Palette[PaletteIndex, 0])
                    {
                        byte FlagData;
                        // If the flag we are drawing is the fortified flag, retrieve the TSA for it
                        if ((flag & LevelDisplayFlag.ViewFortifiedFlag) == LevelDisplayFlag.ViewFortifiedFlag)
                            FlagData = GetFortifiedFlagTSAData(i, x);
                        else
                            FlagData = GetFlagTSAData(i, x);

                        fixed (byte* pPat = &_PatternTable[BGPATTERNTABLE + (FlagData * 0x10)])
                        {
                            pat.DrawTile((x * 8), (i * 8), pPat, pPal);
                        }
                    }
                }
            }

            // Render the flags data to the main level bitmap at 80 x 176
            pat.DrawBitmap(ref bitmap, new Rectangle(0, 0, pat.Width, pat.Height),
                new Rectangle(InitialX, InitialY, pat.Width, pat.Height));
        }

        /// <summary>
        /// Loads a specific data file.
        /// </summary>
        /// <param name="dataFilename">The full filename of the data file to load.</param>
        public void LoadDataFile(string dataFilename)
        {
            IniConfigSource source = new IniConfigSource(@dataFilename);
            source.CaseSensitive = false;

            int cnt = source.Configs["general"].GetInt("numberoflevels");
            // TSA Data
            TSAOffset = source.Configs["general"].GetString("tsadata").HexValueToInt();
            // Attribute data
            AttributeOffset = source.Configs["general"].GetString("attributedata").HexValueToInt();
            // TypeIcon
            _TypeIcon = source.Configs["general"].GetString("icon");
            // Pattern Table Data
            BGPatternTableOffset = source.Configs["patterntable"].GetString("bg").HexValueToInt();
            SprPatternTableOffset = source.Configs["patterntable"].GetString("spr").HexValueToInt();
            // Palette data
            LevelPaletteOffset = source.Configs["palette"].GetString("levelpalette").HexValueToInt();
            SpritePaletteOffset = source.Configs["palette"].GetString("spritepalette").HexValueToInt();
            PaletteFrame1Offset = source.Configs["palette"].GetString("paletteframe1").HexValueToInt();
            PaletteFrame2Offset = source.Configs["palette"].GetString("paletteframe2").HexValueToInt();
            TitleScrPaletteOffset = source.Configs["palette"].GetString("titlescrpalette").HexValueToInt();
            LevelSelectionPaletteOffset = source.Configs["palette"].GetString("levelselpalette").HexValueToInt();
            PaletteMisc1Offset = source.Configs["palette"].GetString("palettemisc1").HexValueToInt();
            PaletteMisc2Offset = source.Configs["palette"].GetString("palettemisc2").HexValueToInt();
            // TSA data for the flags
            NormalFlagTSAOffset = source.Configs["flagtsa"].GetString("normaltsa").HexValueToInt();
            FortifiedFlagTSAOffset = source.Configs["flagtsa"].GetString("fortifiedtsa").HexValueToInt();
            // Player statistics
            StartingLivesOffset = source.Configs["player"].GetString("startinglives").HexValueToInt();
            TankStatus1Offset = source.Configs["player"].GetString("tankstatus1").HexValueToInt();
            TankStatus2Offset = source.Configs["player"].GetString("tankstatus2").HexValueToInt();

            // The level data.
            for (int i = 0; i < cnt; i++)
            {
                string LevelName = "level" + i.ToString();
                BattleCityLevel bcLevel = new BattleCityLevel();
                bcLevel.ID = i;
                bcLevel.LevelDataOffset = source.Configs[LevelName].GetString("offset").HexValueToInt();
                bcLevel.EnemyAmountOffset = source.Configs[LevelName].GetString("amount").HexValueToInt();
                bcLevel.EnemyDataOffset = source.Configs[LevelName].GetString("enemy").HexValueToInt();
                if (source.Configs["startingpositions"] != null)
                {
                    bcLevel.StartingPositions = new List<BattleCityStartingPosition>();
                    BattleCityStartingPosition sp;
                    for (byte x = 0; x < 3; x++)
                    {
                        sp = new BattleCityStartingPosition();
                        sp.ID = x;
                        sp.XOffset = source.Configs["startingpositions"].GetString("enemy" + Convert.ToString(x + 1) + "x").HexValueToInt();
                        sp.YOffset = source.Configs["startingpositions"].GetString("enemy" + Convert.ToString(x + 1) + "y").HexValueToInt();
                        sp.Type = BattleCityStartingPositionType.Enemy;
                        bcLevel.StartingPositions.Add(sp);
                    }

                    sp = new BattleCityStartingPosition();
                    sp.ID = 3;
                    sp.XOffset = source.Configs["startingpositions"].GetString("player1x").HexValueToInt();
                    sp.YOffset = source.Configs["startingpositions"].GetString("player1y").HexValueToInt();
                    sp.Type = BattleCityStartingPositionType.PlayerOne;
                    bcLevel.StartingPositions.Add(sp);

                    sp = new BattleCityStartingPosition();
                    sp.ID = 4;
                    sp.XOffset = source.Configs["startingpositions"].GetString("player2x").HexValueToInt();
                    sp.YOffset = source.Configs["startingpositions"].GetString("player2y").HexValueToInt();
                    sp.Type = BattleCityStartingPositionType.PlayerTwo;
                    bcLevel.StartingPositions.Add(sp);
                }
                Levels.Add(bcLevel);
            }
        }

        /// <summary>
        /// Renders a specific tile.
        /// </summary>
        /// <param name="index">The index of the tile to draw.</param>
        public void DrawLevelTile(Byte index)
        {
            int TileDataOffset;
            TileDataOffset = TSAOffset + (index * 4);

            fixed (byte* pPal = &Palette[ROM[AttributeOffset + index], 0])
            {
                fixed (byte* pPat = &_PatternTable[BGPATTERNTABLE + (ROM[TileDataOffset] * 0x10)])
                {
                    _Tiles.DrawTile(index * 16, 0, pPat, pPal);
                }
                fixed (byte* pPat = &_PatternTable[BGPATTERNTABLE + (ROM[TileDataOffset + 1] * 0x10)])
                {
                    _Tiles.DrawTile((index * 16) + 8, 0, pPat, pPal);
                }
                fixed (byte* pPat = &_PatternTable[BGPATTERNTABLE + (ROM[TileDataOffset + 2] * 0x10)])
                {
                    _Tiles.DrawTile(index * 16, 8, pPat, pPal);
                }
                fixed (byte* pPat = &_PatternTable[BGPATTERNTABLE + (ROM[TileDataOffset + 3] * 0x10)])
                {
                    _Tiles.DrawTile((index * 16) + 8, 8, pPat, pPal);
                }
            }
        }

        /// <summary>
        /// Renders every tile to a bitmap.
        /// </summary>
        public void DrawLevelTiles()
        {
            // Loop through the 16 available tiles, drawing them to a bitmap.
            for (byte i = 0; i < 16; i++)
            {
                DrawLevelTile(i);
            }
        }

        /// <summary>
        /// Increments a specific tile's attribute data.
        /// </summary>
        /// <param name="tileID">The ID of the tile for which to increment its attribute data.</param>
        public void IncrementTileAttribute(Byte tileID)
        {
            // Take the current attribute, and if it's 3 (as 3 is the NES's max), then
            // reset it back to zero. Otherwise, increment it by 1.
            byte CurAtt;
            CurAtt = ROM[AttributeOffset + tileID];
            if (CurAtt == 3)
                CurAtt = 0;
            else
                CurAtt++;
            ROM[AttributeOffset + tileID] = CurAtt;
            // Now redraw the tile.
            DrawLevelTile(tileID);
        }

        /// <summary>
        /// Retrieves the normal flag's TSA data.
        /// </summary>
        /// <param name="row">The row for which to retrieve the data from.</param>
        /// <param name="column">The column for which to retrieve the data from.</param>
        public byte GetFlagTSAData(byte row, byte column)
        {
            return ROM[NormalFlagTSAOffset + (row * 7) + column];
        }

        /// <summary>
        /// Retrieves fortified flag TSA data.
        /// </summary>
        /// <param name="row">The row for which to retrieve the data from.</param>
        /// <param name="column">The column for which to retrieve the data from.</param>
        public byte GetFortifiedFlagTSAData(byte row, byte column)
        {
            return ROM[FortifiedFlagTSAOffset + (row * 7) + column];
        }

        /// <summary>
        /// Sets the flag TSA data.
        /// </summary>
        /// <param name="row">The row to edit.</param>
        /// <param name="column">The column to edit.</param>
        /// <param name="value">The new value of the specific flag TSA byte.</param>
        public void SetFlagTSAData(Byte row, Byte column, byte value)
        {
            ROM[NormalFlagTSAOffset + (row * 7) + column] = value;
        }

        /// <summary>
        /// Sets the fortified flag TSA data.
        /// </summary>
        /// <param name="row">The row to edit.</param>
        /// <param name="column">The column to edit.</param>
        /// <param name="value">The new value of the specific flag TSA byte.</param>
        public void SetFortifiedFlagTSAData(Byte row, byte column, byte value)
        {
            ROM[FortifiedFlagTSAOffset + (row * 7) + column] = value;
        }

        /// <summary>
        /// Loads the asset bitmaps, used for rendering the players, and the various enemies.
        /// </summary>
        public void LoadAssets()
        {
            // Populate the player bitmaps with assets from the assetdirectory.
            _PlayerOneBMP = new Bitmap(_AssetDirectory + Path.DirectorySeparatorChar + "playerone.bmp");
            _PlayerTwoBMP = new Bitmap(_AssetDirectory + Path.DirectorySeparatorChar + "playertwo.bmp");
            // Populate the enemy bitmap with the bitmap in the assetdirectory.
            _EnemyBMP = new Bitmap(_AssetDirectory + Path.DirectorySeparatorChar + "enemy.bmp");
        }

        /// <summary>
        /// Loads both the background palettes, and the sprite palettes.
        /// </summary>
        public void LoadPalette()
        {
            // load in the level palette.
            for (int i = 0; i < 4; i++)
            {
                for (int x = 0; x < 4; x++)
                {
                    Palette[i, x] = ROM[LevelPaletteOffset + (i * 4) + x];
                }
            }

            // Load in the sprite palette.
            for (int i = 0; i < 4; i++)
            {
                for (int x = 0; x < 4; x++)
                {
                    Palette[i + 4, x] = ROM[SpritePaletteOffset + (i * 4) + x];
                }
            }
        }

        /// <summary>
        /// Returns the index of the current level.
        /// </summary>
        public int Level
        {
            get
            {
                return _CurrentLevel;
            }
            set
            {
                // If the current level is set, then
                // save the starting positions.
                if (_CurrentLevel != -1)
                    CurrentLevel.SaveStartingPositions();

                // Set the current level to the new level index.
                _CurrentLevel = value;
                CurrentLevel = Levels[_CurrentLevel];

                // Load the starting positions for the specific level.
                CurrentLevel.LoadStartingPositions();

                // Load the palette for the current level.
                LoadPalette();

                // Draw all the level tiles.
                DrawLevelTiles();

            }
        }


        /// <summary>
        /// Loads both the background pattern tables, and sprite pattern tables.
        /// </summary>
        public void LoadPatternTable()
        {
            int CHRBankOffset;
            CHRBankOffset = BGPatternTableOffset;

            for (int i = 0; i < 4096; i++)
            {
                _PatternTable[i + BGPATTERNTABLE] = ROM[CHRBankOffset + i];
            }

            CHRBankOffset = SprPatternTableOffset;

            for (int i = 0; i < 4096; i++)
            {
                _PatternTable[i] = ROM[CHRBankOffset + i];
            }
        }


        /// <summary>
        /// Method that disposes of bitmap objects.
        /// </summary>
        public void Dispose()
        {
            if (_PlayerOneBMP != null)
                _PlayerOneBMP.Dispose();
            if (_PlayerTwoBMP != null)
                _PlayerTwoBMP.Dispose();
            if (_EnemyBMP != null)
                _EnemyBMP.Dispose();
        }

        /// <summary>
        /// Saves the ROM to a given filename.
        /// </summary>
        /// <param name="Filename">The filename to save the ROM to.</param>
        public void SaveAs(string Filename)
        {
            ROM.SaveAs(Filename);
        }

        /// <summary>
        /// Saves the ROM.
        /// </summary>
        public void Save()
        {
            SaveAs(ROM.Filename);
        }

        /// <summary>
        /// Returns the ROMs filename.
        /// </summary>
        public string Filename
        {
            get
            {
                return ROM.Filename;
            }

        }

        /// <summary>
        /// Gets or sets the value as to whether the ROM has been changed.
        /// </summary>
        public bool IsChanged
        {
            get
            {
                return ROM.IsChanged;
            }
            set
            {
                ROM.IsChanged = value;
            }
        }

        /// <summary>
        /// The icon to use for this datafile.
        /// </summary>
        public string TypeIcon
        {
            get
            {
                return _AssetDirectory + Path.DirectorySeparatorChar + _TypeIcon;
            }
        }

    }
}