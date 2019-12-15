using Views;

namespace Components.Rotation
{
    public class PlayerRotationAfterMovementComponent : ObjectRotationAfterMovementComponent
    {
        protected override void SetTarget()
        {
            _target = FindObjectOfType<PlayerView>().transform;
        }
    }
}
