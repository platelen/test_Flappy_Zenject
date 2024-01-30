using UnityEngine;

namespace Paralax
{
    public class ParalaxController : MonoBehaviour
    {
        [SerializeField] private float _animationSpeed = 0.05f;

        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            Paralaxed();
        }

        private void Paralaxed()
        {
            _meshRenderer.material.mainTextureOffset += new Vector2(_animationSpeed * Time.deltaTime, 0);
        }
    }
}