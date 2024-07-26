

namespace Project
{
    public class Score
    {
        public int Total { get; private set; }

        public void Add(int value)
        {
            Total += UnityEngine.Mathf.Clamp(value, 0, int.MaxValue);

            EventBus.Instance.OnViewUpdateScore?.Invoke(Total);
        }
    }
}