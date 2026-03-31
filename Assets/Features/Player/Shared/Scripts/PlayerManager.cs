using UnityEngine;

namespace Features.Player.Shared.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerStats baselineStats;

        public PlayerStats CurrentStats { get; private set; }
        
        private void Awake() => CurrentStats = Instantiate(baselineStats);
    }
}