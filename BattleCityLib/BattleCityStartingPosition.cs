using System;

namespace BattleCityLib
{
    /// <summary>
    /// A class that represents the starting positions for each level, in Battle City.
    /// </summary>
    public class BattleCityStartingPosition
    {
        /// <summary>
        /// The ID of the starting position. Obsolete?
        /// </summary>
        public byte ID { get; set; }
        /// <summary>
        /// The X co-ordinate, as stored in the ROM.
        /// </summary>
        public byte RealX { get; set; }
        /// <summary>
        /// The Y co-ordinate, as stored in the ROM.
        /// </summary>
        public byte RealY { get; set; }
        /// <summary>
        /// The offset of the X co-ordinate.
        /// </summary>
        public int XOffset { get; set; }
        /// <summary>
        /// The offset of the Y co-ordinate.
        /// </summary>
        public int YOffset { get; set; }
        /// <summary>
        /// The type of starting position.
        /// </summary>
        public BattleCityStartingPositionType Type { get; set; }

        /// <summary>
        /// The X co-ordinate of the starting position.
        /// </summary>
        public byte X
        {
            get
            {
                return Convert.ToByte((RealX >> 4) - 1);
            }
            set
            {
                byte val = value;
                if (value > 12)
                    val = 12;
                RealX = Convert.ToByte((RealX & 0x0F) + ((val + 1) << 4));
            }
        }

        /// <summary>
        /// The Y co-ordinate of the starting position.
        /// </summary>
        public byte Y
        {
            get
            {
                return Convert.ToByte((RealY >> 4) - 1);
            }
            set
            {
                byte val = value;
                if (value > 12)
                    val = 12;
                RealY = Convert.ToByte((RealY & 0x0F) + ((val + 1) << 4));
            }
        }
    }

    /// <summary>
    /// An enumerated type that represents the different types of starting positions.
    /// </summary>
    public enum BattleCityStartingPositionType
    {
        /// <summary>
        /// The starting position for player one.
        /// </summary>
        PlayerOne = 0,
        /// <summary>
        /// The starting position for player two.
        /// </summary>
        PlayerTwo = 1,
        /// <summary>
        /// The starting position for an enemy.
        /// </summary>
        Enemy = 2,
    }
}
