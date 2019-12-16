using System;
using System.Collections;
using Components.Raycast;
using UnityEngine;
using Views;

namespace Components.Shooting
{
    public class FirePointComponent : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private GameObject bulletPrefab;
#pragma warning restore 0649

        private RaycastHitComponent _raycastHitComponent;

        private float _bulletForce;

        private float _secondsCount;

        private Coroutine _shootingCoroutine;

        private void Awake()
        {
            _bulletForce = 10f;

            _secondsCount = 1f;

            _raycastHitComponent = this.gameObject.GetComponentInParent<RaycastHitComponent>();
            if (_raycastHitComponent == null)
            {
                Debug.LogError("No RaycastHitComponent in parent object was found.");

                return;
            }

            TargetChanged(_raycastHitComponent.Target);
            _raycastHitComponent.TargetChanged += TargetChanged;
        }
        private void OnDestroy()
        {
            if (_raycastHitComponent == null)
            {
                return;
            }

            _raycastHitComponent.TargetChanged -= TargetChanged;
        }

        public void StartShooting()
        {
            if (_shootingCoroutine == null) // not started shooting yet - start it
            {
                _shootingCoroutine = StartCoroutine(RepeatActionEverySecondsCoroutine(
                    _secondsCount,
                    () => { Shoot(); }));
            }
        }
        public void StopShooting()
        {
            if (_shootingCoroutine != null) // started shooting - stop it
            {
                StopCoroutine(_shootingCoroutine);
                _shootingCoroutine = null;
            }
        }

        public void Shoot()
        {
            var bulletInstance = Instantiate(
                bulletPrefab,
                this.gameObject.transform.position,
                this.gameObject.transform.rotation);

            var bulletInstanceRigidbody2D = bulletInstance.GetComponent<Rigidbody2D>();

            bulletInstanceRigidbody2D.AddForce(
                this.gameObject.transform.up * _bulletForce,
                ForceMode2D.Impulse);
        }

        private void TargetChanged(GameObject o)
        {
            if (o == null)
            {
                StopShooting();

                return;
            }

            if (o.GetComponent<CreatureView>() != null)
            {
                StartShooting();
            }
            else
            {
                StopShooting();
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
