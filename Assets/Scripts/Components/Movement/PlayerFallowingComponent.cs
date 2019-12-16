using Components.Raycast;
using UnityEngine;
using Views;

namespace Components.Movement
{
    public class PlayerFallowingComponent : MonoBehaviour
    {
        protected PlayerView _target;

        private float _speed;

        private RaycastHitComponent _raycastHitComponent;

        private bool _isNeedToMove;

        protected virtual void Awake()
        {
            _speed = 1f;

            _target = FindObjectOfType<PlayerView>();
            if (_target == null)
            {
                Debug.LogError("No PlayerView was found.");

                return;
            }

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

        private void TargetChanged(GameObject o)
        {
            if (o == null)
            {
                _isNeedToMove = false;

                return;
            }

            var playerView = o.GetComponent<PlayerView>();
            if (playerView != null)
            {
                _isNeedToMove = false;
            }
            else
            {
                _isNeedToMove = true;
            }
        }

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            if (!_isNeedToMove)
            {
                return;
            }

            transform.position = Vector2.MoveTowards(
                transform.position,
                _target.transform.position,
                _speed * Time.deltaTime);
        }
    }
}
