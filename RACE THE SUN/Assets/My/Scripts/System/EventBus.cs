using System;

namespace Project
{
    public class EventBus
    {
        private static EventBus _instance;
        public static EventBus Instance
        {
            get => _instance ??= new EventBus();
        }

        // Game
        public Action OnGameOver;

        // Score
        public Action<int> OnAddScore;
        public Action<int> OnViewUpdateScore;
        public Action<int> OnViewAddScore;

        // Crystal
        public Action OnGetCrystal;
        public Action<int, int> OnViewCountCrystal;

    }
}
