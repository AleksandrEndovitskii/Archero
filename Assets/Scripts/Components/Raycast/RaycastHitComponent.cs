using System;
using UnityEngine;

namespace Components.Raycast
{
    public class RaycastHitComponent : MonoBehaviour
    {
        public Action<GameObject> TargetChanged = delegate { };

        public GameObject Target
        {
            get
            {
                return _target;
            }
            set
            {
                if (_target == value)
                {
                    return;
                }

                _target = value;

                TargetChanged.Invoke(_target);
            }
        }

        private GameObject _target;

        private void FixedUpdate()
        {
            var hit = Physics2D.Raycast(transform.position,  transform.up * 1000, Mathf.Infinity);
            if (hit.collider != null) // have a target
            {
                var o = hit.collider.gameObject;
                if (o != null) // have clean view on player
                {
                    Debug.DrawRay(transform.position, transform.up * hit.distance, Color.red);

                    Target = o;
                }
            }
            else // no target
            {
                Debug.DrawRay(transform.position, transform.up * 1000, Color.white);

                Target = null;
            }
        }
    }
}
