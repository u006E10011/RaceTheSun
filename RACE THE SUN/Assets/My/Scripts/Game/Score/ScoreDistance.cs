using UnityEngine;

namespace Project
{
    public class ScoreDistance : MonoBehaviour
    {
        private float _oldPosition;

        private Transform _playerController;

        public void Init(Transform player) => _playerController = player;

        private void Update()
        {
            var value = _playerController.transform.position.z - _oldPosition;

            EventBus.Instance.OnAddScore?.Invoke(Mathf.FloorToInt(value));

            _oldPosition = _playerController.transform.position.z;
        }
    }
}