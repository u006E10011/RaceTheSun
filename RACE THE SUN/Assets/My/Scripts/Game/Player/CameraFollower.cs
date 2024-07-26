using System;
using UnityEngine;

namespace Project
{ 
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private float _smoothing = 5;
        [SerializeField] private Vector3 _offset;

        [SerializeField] private Transform _target;

        private void OnValidate() => _target = _target != null ? _target : FindObjectOfType<PlayerController>().transform;

        private void FixedUpdate() => Follow(_target);

        private void Follow(Transform target) => transform.position = Vector3.Lerp(transform.position, target.position + _offset, _smoothing * Time.deltaTime);
    }
}