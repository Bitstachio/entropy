using UnityEngine;

namespace Features.Environment
{
    public sealed class Parallax : MonoBehaviour
    {
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");

        [SerializeField] [Range(0f, 0.5f)] private float speed = 0.2f;

        private Material _material;
        private float distance;

        // TODO: Consider using `Awake` instead of `Start`
        private void Start() => _material = GetComponent<Renderer>().material;

        private void Update()
        {
            distance += Time.deltaTime * speed;
            _material.SetTextureOffset(MainTex, Vector2.right * distance);
        }
    }
}