using UnityEngine;

namespace Project
{
    public class Crystal : MonoBehaviour
    {
        [SerializeField] private int _value;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerController>(out var controller))
            {
                EventBus.Instance.OnAddScore?.Invoke(_value);
                EventBus.Instance.OnGetCrystal?.Invoke();
                EventBus.Instance.OnViewAddScore?.Invoke(_value);
            }
        }
    }
}
