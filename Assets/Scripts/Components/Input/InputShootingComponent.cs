using UnityEngine;

namespace Components.Input
{
    public class InputShootingComponent : MonoBehaviour
    {
        private FirePointComponent _firePointComponent;

        private void Awake()
        {
            _firePointComponent = this.gameObject.GetComponentInChildren<FirePointComponent>();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Fire1"))
            {
                _firePointComponent.Shoot();
            }
        }
    }
}
