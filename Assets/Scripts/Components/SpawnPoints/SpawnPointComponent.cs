using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Components.SpawnPoints
{
    public class SpawnPointComponent : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private CreatureView creatureView;

        [SerializeField]
        private int spawnCount = 1;
#pragma warning restore 0649

        [NonSerialized]
        public List<CreatureView> CreatureViewInstances = new List<CreatureView>();

        private Coroutine _spawningCoroutine = null;

        private float _secondsCount = 1f;

        private void Awake()
        {
            StartSpawning();
        }

        public void StartSpawning()
        {
            if (_spawningCoroutine == null) // not started yet - start it
            {
                _spawningCoroutine = StartCoroutine(RepeatActionEverySecondsCoroutine(
                    _secondsCount,
                    () =>
                    {
                        var creatureViewInstance = Instantiate(creatureView, this.gameObject.transform);
                        CreatureViewInstances.Add(creatureViewInstance);
                        if (CreatureViewInstances.Count >= spawnCount)
                        {
                            StopCoroutine(_spawningCoroutine);
                            _spawningCoroutine = null;
                        }
                    }));
            }
        }

        private IEnumerator RepeatActionEverySecondsCoroutine(float secondsCount, Action action)
        {
            while (enabled)
            {
                yield return new WaitForSeconds(secondsCount);

                action.Invoke();
            }
        }
    }
}
