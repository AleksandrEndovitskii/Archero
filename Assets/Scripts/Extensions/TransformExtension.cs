using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class TransformExtension
    {
        public static Transform GetClosestTransform(this Transform transform, List<Transform> transforms)
        {
            Transform closestTransform = null;
            var closestDistanceSqr = Mathf.Infinity;
            var currentPosition = transform.position;
            foreach (var potentialTarget in transforms)
            {
                var directionToTarget = potentialTarget.position - currentPosition;
                var dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    closestTransform = potentialTarget;
                }
            }

            return closestTransform;
        }
    }
}