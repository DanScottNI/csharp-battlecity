using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BattleCityLib
{
    /// <summary>
    /// Used to determine which elements to render over the level data.
    /// </summary>
    [FlagsAttribute]
    public enum LevelDisplayFlag : int
    {
        /// <summary>
        /// Whether to display the enemies.
        /// </summary>
        ViewEnemy = 1,
        /// <summary>
        /// Whether to display the player's icons.
        /// </summary>
        ViewPlayer = 2,
        /// <summary>
        /// Whether to view the normal flag.
        /// </summary>
        ViewNormalFlag = 4,
        /// <summary>
        /// Whether to view the fortified flag.
        /// </summary>
        ViewFortifiedFlag = 8
    }

}
