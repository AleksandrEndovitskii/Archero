using UnityEngine;
using Views;

namespace Components
{
    public class FirePointComponent : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private GameObject bulletPrefab;
#pragma warning restore 0649

        private CreatureView _creatureView;

        private float _bulletForce;

        private void Awake()
        {
            _creatureView = this.gameObject.GetComponentInParent<CreatureView>();

            if (_creatureView == null)
            {
                Debug.LogError("No CreatureView in parent object was found.");
            }

            _bulletForce = 10f;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        private void Shoot()
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
    }
}
