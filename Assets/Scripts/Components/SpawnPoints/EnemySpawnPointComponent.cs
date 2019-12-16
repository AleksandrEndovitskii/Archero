using System;
using UnityEngine;
using Views;

namespace Components.SpawnPoints
{
    public class EnemySpawnPointComponent : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private CreatureView creatureView;
#pragma warning restore 0649

        [NonSerialized]
        public CreatureView CreatureViewInstance;

        private void Awake()
        {
            CreatureViewInstance = Instantiate(creatureView, this.gameObject.transform);
        }
    }
}
