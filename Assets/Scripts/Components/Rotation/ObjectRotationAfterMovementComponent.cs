using Components.Movement;
using UnityEngine;

namespace Components.Rotation
{
    public class ObjectRotationAfterMovementComponent : MonoBehaviour
    {
        protected Transform _target;

        private float _speed;

        private IsMovingComponent _isMovingComponent;

        protected virtual void Awake()
        {
            _speed = 1f;

            _isMovingComponent = this.gameObject.GetComponent<IsMovingComponent>();
            if (_isMovingComponent == null)
            {
                Debug.LogError("No IsMovingComponent on this object was found.");

                return;
            }

            IsMovingChanged(_isMovingComponent.IsMoving);
            _isMovingComponent.IsMovingChanged += IsMovingChanged;
        }
        private void OnDestroy()
        {
            if (_isMovingComponent == null)
            {
                return;
            }

            _isMovingComponent.IsMovingChanged -= IsMovingChanged;
        }

        protected virtual void SetTarget()
        {

        }

        private void Update()
        {
            if (_target == null)
            {
                return;
            }

            var direction = _target.position - this.gameObject.transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            this.gameObject.transform.rotation = Quaternion.Slerp(
                this.gameObject.transform.rotation,
                rotation,
                _speed * Time.deltaTime);
        }

        private void IsMovingChanged(bool isMoving)
        {
            if (isMoving)
            {
                _target = null;
            }
            else
            {
                SetTarget();
            }
        }
    }
}
