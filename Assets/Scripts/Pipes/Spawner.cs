using UnityEngine;
using Random = UnityEngine.Random;

namespace Pipes
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabPipes;
        [SerializeField] private float _spawnRate = 1f;
        [SerializeField] private float _minHeight = -1f;
        [SerializeField] private float _maxHeight = 1f;

        private void OnEnable()
        {
            InvokeRepeating(nameof(SpawnPipes), _spawnRate, _spawnRate);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(SpawnPipes));
        }

        private void SpawnPipes()
        {
            GameObject pipes = Instantiate(_prefabPipes, transform.position, Quaternion.identity);
            pipes.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
        }
    }
}