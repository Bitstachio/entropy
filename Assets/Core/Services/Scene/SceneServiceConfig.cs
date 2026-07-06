using UnityEngine;

namespace Core.Services.Scene
{
    [CreateAssetMenu(menuName = "Services/Scene Service/Scene Service Config")]
    public class SceneServiceConfig : ScriptableObject
    {
        [SerializeField] private int delay;
        
        public int Delay => delay;
    }
}