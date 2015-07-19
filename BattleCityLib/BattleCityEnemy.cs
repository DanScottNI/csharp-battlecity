using System;
using System.Collections.Generic;
using System.Text;
using ROMClass.NES;

namespace BattleCityLib
{
    /// <summary>
    /// Class that represents an enemy in Battle City.
    /// </summary>
    public class BattleCityEnemy : iNESROMAccessor
    {
        /// <summary>
        /// The type of the enemy.
        /// </summary>
        public byte EnemyType { get; set; }
        /// <summary>
        /// An unused bit in the enemy byte.
        /// </summary>
        public byte Unused1 { get; set; }
        /// <summary>
        /// Another unused bit in the enemy byte.
        /// </summary>
        public byte Unused2 { get; set; }
        /// <summary>
        /// The powerups that the enemy has.
        /// </summary>
        public byte Powerups { get; set; }
        /// <summary>
        /// The strength of the enemy's shield.
        /// </summary>
        public byte ShieldStrength { get; set; }
        /// <summary>
        /// The amount of this enemy.
        /// </summary>
        public byte Amount { get; set; }

        /// <summary>
        /// Loads in the enemy statistics.
        /// </summary>
        /// <param name="dataOffset">The offset for the enemy data.</param>
        /// <param name="amountOffset">The offset for the enemy amount data.</param>
        public BattleCityEnemy(int dataOffset, int amountOffset)
        {
            byte EnemyByte;
            EnemyByte = ROM[dataOffset];
            EnemyType = Convert.ToByte(EnemyByte >> 5);
            Unused1 = Convert.ToByte((EnemyByte >> 4) & 1);
            Unused2 = Convert.ToByte((EnemyByte >> 3) & 1);
            Powerups = Convert.ToByte((EnemyByte >> 2) & 1);
            ShieldStrength = Convert.ToByte(EnemyByte & 3);
            Amount = ROM[amountOffset];
        }
    }
}
