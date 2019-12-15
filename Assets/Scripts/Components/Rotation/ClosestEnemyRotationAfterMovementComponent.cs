using System.Linq;
using Components.Moving;
using Extensions;
using UnityEngine;
using Views;

namespace Components.Rotation
{
    [RequireComponent(typeof(IsMovingComponent))]
    public class ClosestEnemyRotationAfterMovementComponent : ObjectRotationAfterMovementComponent
    {
        protected override void SetTarget()
        {
            var enemyViews = FindObjectsOfType<EnemyView>();
            var enemyTransforms = enemyViews.ToList().ConvertAll(x => x.transform);
            _target = this.gameObject.transform.GetClosestTransform(enemyTransforms);
        }
    }
}
