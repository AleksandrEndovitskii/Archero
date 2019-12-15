using UnityEngine;

namespace Views
{
    public class CreatureView : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private GameObject bulletPrefab;
#pragma warning restore 0649
    }
}
