using UnityEngine;

namespace Project
{
    public class CrystalBonusController
    {
        private const int MAX_COUNT = 5;

        [SerializeField] private int _addScore = 1500;

        public int CurrentCountCrystal { get; private set; }

        public void ShowBonus()
        {
            if (CurrentCountCrystal >= MAX_COUNT)
            {
                EventBus.Instance.OnAddScore?.Invoke(_addScore);
                CurrentCountCrystal = 0;
            }
            else
                CurrentCountCrystal++;

            EventBus.Instance.OnViewCountCrystal?.Invoke(MAX_COUNT, CurrentCountCrystal);
        }
    }
}