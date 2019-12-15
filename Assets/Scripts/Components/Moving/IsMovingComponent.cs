using System;
using UnityEngine;

namespace Components.Moving
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class IsMovingComponent : MonoBehaviour
    {
        public Action<bool> IsMovingChanged = delegate { };

        public bool IsMoving
        {
            get
            {
                return _isMoving;
            }
            set
            {
                if (_isMoving == value)
                {
                    return;
                }

                _isMoving = value;

                IsMovingChanged.Invoke(_isMoving);
            }
        }

        private bool _isMoving;

        private Vector3 currentPosition;
        private Vector3 lastPosition;

        private void Update()
        {
            currentPosition = this.gameObject.transform.position;
            if (currentPosition == lastPosition) // stopped
            {
                IsMoving = false;
            }
            else // moving
            {
                IsMoving = true;
            }
            lastPosition = currentPosition;
        }
    }
}
