using System;
using System.Collections.Generic;
using ROMClass.NES;
namespace BattleCityLib
{
    /// <summary>
    /// Class that represents a level in Battle City.
    /// </summary>
    public class BattleCityLevel : iNESROMAccessor
    {
        /// <summary>
        /// The unique identifier for this level.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The offset of the level data.
        /// </summary>
        public int LevelDataOffset { get; set; }
        /// <summary>
        /// The offset of the enemy data.
        /// </summary>
        public int EnemyDataOffset { get; set; }
        /// <summary>
        /// The offset of the enemy amount data.
        /// </summary>
        public int EnemyAmountOffset { get; set; }
        /// <summary>
        /// A List of BattleCityEnemy objects, that represent the enemies for this level.
        /// </summary>
        public List<BattleCityEnemy> EnemyList { get; set; }
        /// <summary>
        /// A List of BattleCityStartingPosition objects, that represent the starting positions for this level.
        /// </summary>
        public List<BattleCityStartingPosition> StartingPositions { get; set; }

        /// <summary>
        /// Creates an enemy for the level.
        /// </summary>
        public void CreateEnemy()
        {
            if (EnemyList != null)
                EnemyList = new List<BattleCityEnemy>();

            EnemyList.Add(new BattleCityEnemy(this.EnemyDataOffset, this.EnemyAmountOffset));
            EnemyList.Add(new BattleCityEnemy(this.EnemyDataOffset + 1, this.EnemyAmountOffset + 1));
            EnemyList.Add(new BattleCityEnemy(this.EnemyDataOffset + 2, this.EnemyAmountOffset + 2));
            EnemyList.Add(new BattleCityEnemy(this.EnemyDataOffset + 3, this.EnemyAmountOffset + 3));
        }

        /// <summary>
        /// Loads starting positions for this level, from the ROM.
        /// </summary>
        public void LoadStartingPositions()
        {
            for (int x = 0; x < 5; x++)
            {
                StartingPositions[x].RealX = ROM[StartingPositions[x].XOffset];
                StartingPositions[x].RealY = ROM[StartingPositions[x].YOffset];
                StartingPositions[x].X = Convert.ToByte((StartingPositions[x].RealX >> 4) - 1);
                StartingPositions[x].Y = Convert.ToByte((StartingPositions[x].RealY >> 4) - 1);
            }
        }

        /// <summary>
        /// Saves starting positions for this level to the ROM.
        /// </summary>
        public void SaveStartingPositions()
        {
            for (int x = 0; x < 5; x++)
            {
                StartingPositions[x].RealX = Convert.ToByte(((StartingPositions[x].X + 1) << 4) + (StartingPositions[x].RealX & 0x0F));
                StartingPositions[x].RealY = Convert.ToByte(((StartingPositions[x].Y + 1) << 4) + (StartingPositions[x].RealY & 0x0F));
                ROM[StartingPositions[x].XOffset] = StartingPositions[x].RealX;
                ROM[StartingPositions[x].YOffset] = StartingPositions[x].RealY;
            }
        }

        /// <summary>
        /// Gets level data from the ROM.
        /// </summary>
        /// <param name="row">The row to retrieve the level data from.</param>
        /// <param name="column">The column to retrieve the level data from.</param>
        public byte GetLevelData(int row, int column)
        {
            int LevelByte = ROM[LevelDataOffset + (row * 7) + (column / 2)];

            if (column % 2 == 1)
            {
                LevelByte = LevelByte & 0x0F;
            }
            else
            {
                LevelByte = (LevelByte >> 4) & 0x0F;
            }

            return Convert.ToByte(LevelByte & 0xFF);
        }

        /// <summary>
        /// Sets level data.
        /// </summary>
        /// <param name="row">The row to set level data to.</param>
        /// <param name="column">The column to set level data to.</param>
        /// <param name="tileID">The new tile ID for the level data.</param>
        public void SetLevelData(int row, int column, byte tileID)
        {
            int LevelByte;
            int Offset;

            Offset = this.LevelDataOffset + (row * 7) + (column / 2);
            LevelByte = ROM[Offset];

            if (column % 2 == 1)
            {
                LevelByte = (LevelByte & 0xF0) + (tileID & 0x0F);
            }
            else
            {
                LevelByte = (LevelByte & 0x0F) + ((tileID & 0x0F) << 4);
            }

            ROM[Offset] = Convert.ToByte(LevelByte & 0xFF);
        }
    }
}