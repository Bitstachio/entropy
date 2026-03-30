using UnityEngine;

namespace Features.Player.Shared.Scripts
{
    [CreateAssetMenu(menuName = "Player/Stats Container")]
    public class PlayerStats : ScriptableObject
    {
        [Header("Movement")] public float movementSpeed = 5f;

        [Header("Attack")] public float bulletDamage = 1f;
        public float bulletSpeed = 5f;
        public float bulletInterval = 3;

        // TODO: Improve this implementation later
        // For a game session, ideally a clone of the player stats should be created and used
        // For now, I'll just hardcode it because I don't want to deal with injecting scriptable object at runtime
        private void OnEnable()
        {
            movementSpeed = 5f;
            bulletDamage = 1f;
            bulletSpeed = 5f;
            bulletInterval = 3;
        }
    }
}