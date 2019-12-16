using System;
using Components.SpawnPoints;
using UnityEngine;

namespace Managers
{
    public class GameObjectManager : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private PlayerSpawnPointComponent playerSpawnPointComponent;
        [SerializeField]
        private EnemySpawnPointComponent enemySpawnPointComponent;
#pragma warning restore 0649

        [NonSerialized]
        public PlayerSpawnPointComponent PlayerSpawnPointComponentInstance;
        [NonSerialized]
        public EnemySpawnPointComponent EnemySpawnPointComponentInstance;

        public void Initialize()
        {
            PlayerSpawnPointComponentInstance = Instantiate(
                playerSpawnPointComponent,
                new Vector3(-10f, -10f, 0f),
                Quaternion.identity);
            EnemySpawnPointComponentInstance = Instantiate(
                enemySpawnPointComponent,
                new Vector3(10f, 10f, 0f),
                Quaternion.identity);
        }
    }
}
