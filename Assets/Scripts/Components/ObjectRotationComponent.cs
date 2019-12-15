using UnityEngine;
using Views;

namespace Components
{
    public class ObjectRotationComponent : MonoBehaviour
    {
        private Transform _target;

        private float _speed;

        private void Awake()
        {
            _target = FindObjectOfType<PlayerView>().transform;

            _speed = 1f;
        }

        private void Update()
        {
            var direction = _target.position - this.gameObject.transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            this.gameObject.transform.rotation = Quaternion.Slerp(
                this.gameObject.transform.rotation,
                rotation,
                _speed * Time.deltaTime);
        }
    }
}
