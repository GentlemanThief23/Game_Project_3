using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class CombatStanceStats : State
    {
        public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats)
        {
            return this;
        }
    }
}
