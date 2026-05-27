using UnityEngine;

namespace Features.Menu.GameOver
{
    [CreateAssetMenu(menuName = "Menu Config/Game Over Menu Config")]
    public sealed class GameOverMenuConfig : ScriptableObject
    {
        [SerializeField] private int sceneLoadDelay;
        
        public int SceneLoadDelay => sceneLoadDelay;
    }
}