using System;

namespace Models.Creatures
{
    public class EnemyModel : CreatureModel
    {
        public float RangeOfMovement;
        private TimeSpan ImmobilityTime;
    }
}
