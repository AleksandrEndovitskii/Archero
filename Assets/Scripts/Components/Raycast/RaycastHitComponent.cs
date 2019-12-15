using System;
using System.Collections;
using Components.Shooting;
using UnityEngine;
using Views;

namespace Components.Raycast
{
    public class RaycastHitComponent : MonoBehaviour
    {
        private FirePointComponent _firePointComponent;

        private float _secondsCount;

        private Coroutine _shootingCoroutine;

        private void Awake()
        {
            _firePointComponent = this.gameObject.GetComponentInChildren<FirePointComponent>();

            _secondsCount = 1f;
        }

        private void FixedUpdate()
        {
            var hit = Physics2D.Raycast(transform.position,  transform.up * 1000, Mathf.Infinity);
            if (hit.collider != null) // have a target
            {
                var playerView = hit.collider.gameObject.GetComponent<PlayerView>();
                if (playerView != null) // have clean view on player
                {
                    Debug.DrawRay(transform.position, transform.up * hit.distance, Color.red);

                    if (_shootingCoroutine == null) // not started shooting yet - start it
                    {
                        _shootingCoroutine = StartCoroutine(RepeatActionEverySecondsCoroutine(
                            _secondsCount,
                            () =>
                            {
                                _firePointComponent.Shoot();
                            }));
                    }
                }
            }
            else // no target
            {
                Debug.DrawRay(transform.position, transform.up * 1000, Color.white);

                if (_shootingCoroutine != null) // started shooting - stop it
                {
                    StopCoroutine(_shootingCoroutine);
                    _shootingCoroutine = null;
                }
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