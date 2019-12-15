using System;
using System.Collections;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class IdleShootingComponent : MonoBehaviour
    {
        private FirePointComponent _firePointComponent;

        private Rigidbody2D _rigidbody2D;

        private Vector3 currentPosition;
        private Vector3 lastPosition;

        private float _secondsCount;

        private Coroutine shootingCoroutine;

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
                if (shootingCoroutine == null) // not started shooting eat - start it
                {
                    shootingCoroutine = StartCoroutine(RepeatActionEverySecondsCoroutine(
                        _secondsCount,
                        () =>
                        {
                            _firePointComponent.Shoot(); 
                        }));
                }
            }
            else // moving
            {
                if (shootingCoroutine != null) // started shooting - stop it
                {
                    StopCoroutine(shootingCoroutine);
                    shootingCoroutine = null;
                }
            }
            lastPosition = currentPosition;
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
