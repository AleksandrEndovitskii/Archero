using UnityEngine;
using Views;

namespace Components
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BulletComponent : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            // instantiate effect of hit here
            // destroy effect of hit here

            var creatureView = other.gameObject.GetComponent<CreatureView>();
            if (creatureView != null)
            {
                // do damage to creature
            }

            Destroy(this.gameObject);
        }
    }
}
