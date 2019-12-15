using System;
using UnityEngine;
using Views;

namespace Managers
{
    public class GameObjectManager : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private PlayerView playerView;
#pragma warning restore 0649

        [NonSerialized]
        public PlayerView PlayerViewInstance;

        public void Initialize()
        {
            PlayerViewInstance = Instantiate(playerView);
        }
    }
}
