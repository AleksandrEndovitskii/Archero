using UnityEngine;

namespace Components.Input
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class InputMovementComponent : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private float _movementSpeed;

        private Vector2 _movementVector2;

        private void Awake()
        {
            _rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

            _movementSpeed = 10;
        }

        private void Update()
        {
            _movementVector2.x = UnityEngine.Input.GetAxisRaw("Horizontal");
            _movementVector2.y = UnityEngine.Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + _movementSpeed * Time.fixedDeltaTime * _movementVector2);
        }
    }
}
