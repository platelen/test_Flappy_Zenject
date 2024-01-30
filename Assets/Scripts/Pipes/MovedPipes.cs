using System;
using UnityEngine;

namespace Pipes
{
    public class MovedPipes : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private float _leftEdge;

        private void Start()
        {
            _leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        }

        private void Update()
        {
            Move();

            if (transform.position.x < _leftEdge)
            {
                Destroy(gameObject);
            }
        }

        private void Move()
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
    }
}