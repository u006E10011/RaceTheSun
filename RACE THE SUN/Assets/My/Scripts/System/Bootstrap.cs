using UnityEngine;

namespace Project
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerController _player;
        [SerializeField] private ScoreDistance _scoreDistance;

        private Score _score;
        private CrystalBonusController _crystalController;

        private void Awake()
        {
            _score = new();
            _crystalController = new();

            _scoreDistance.Init(_player.transform);
        }

        private void OnEnable()
        {
            EventBus.Instance.OnAddScore += _score.Add;
            EventBus.Instance.OnGetCrystal += _crystalController.ShowBonus;
        }

        private void OnDisable()
        {
            EventBus.Instance.OnAddScore -= _score.Add;
            EventBus.Instance.OnGetCrystal -= _crystalController.ShowBonus;
        }
    }
}