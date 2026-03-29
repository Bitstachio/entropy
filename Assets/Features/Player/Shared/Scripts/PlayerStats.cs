using UnityEngine;

namespace Features.Player.Shared.Scripts
{
    [CreateAssetMenu(menuName = "Player/Stats Container")]
    public class PlayerStats : ScriptableObject
    {
        [Header("Movement")]
        public float movementSpeed = 5f;

        [Header("Attack")]
        public float bulletDamage = 10f;
        public float bulletSpeed = 5f;
        public float bulletInterval = 3;
    }
}
