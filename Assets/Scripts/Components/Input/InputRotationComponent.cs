using UnityEngine;

namespace Components.Input
{
    public class InputRotationComponent : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private Vector2 _rotationVector2;

        private void Awake()
        {
            _rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rotationVector2.x = UnityEngine.Input.GetAxisRaw("Horizontal");
            _rotationVector2.y = UnityEngine.Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            var direction = Vector2.zero;

            if (_rotationVector2.x > 0)
            {
                direction = Vector2.right;
            }
            if (_rotationVector2.x < 0)
            {
                direction = Vector2.left;
            }
            if (_rotationVector2.y > 0)
            {
                direction = Vector2.up;
            }
            if (_rotationVector2.y < 0)
            {
                direction = Vector2.down;
            }

            if (direction != Vector2.zero)
            {
                var angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg - 90f;
                _rigidbody2D.rotation = angle;
            }
        }
    }
}
