using System;
using System.Collections;
using UnityEngine;

namespace Components.Shooting
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShootingComponent : MonoBehaviour
    {
        private FirePointComponent _firePointComponent;

        private Rigidbody2D _rigidbody2D;

        private Vector3 currentPosition;
        private Vector3 lastPosition;

        private float _secondsCount;

        private Coroutine _shootingCoroutine;

        private void Awake()
        {
            _firePointComponent = this.gameObject.GetComponentInChildren<FirePointComponent>();

            _rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

            _secondsCount = 1f;
        }

        private void Update()
        {
            currentPosition = this.gameObject.transform.position;
            if (currentPosition == lastPosition) // stopped
            {
                StartShooting();
            }
            else // moving
            {
                StopShooting();
            }
            lastPosition = currentPosition;
        }

        private void StartShooting()
        {
            if (_shootingCoroutine == null) // not started shooting yet - start it
            {
                _shootingCoroutine = StartCoroutine(RepeatActionEverySecondsCoroutine(
                    _secondsCount,
                    () => { _firePointComponent.Shoot(); }));
            }
        }

        private void StopShooting()
        {
            if (_shootingCoroutine != null) // started shooting - stop it
            {
                StopCoroutine(_shootingCoroutine);
                _shootingCoroutine = null;
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
