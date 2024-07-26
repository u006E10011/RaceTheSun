using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class ViewCrystal : MonoBehaviour
    {
        [SerializeField] private Color32 _full;
        [SerializeField] private Color32 _empty;

        [SerializeField, Space(10)] private List<Image> _images = new();

        private void OnEnable() => EventBus.Instance.OnViewCountCrystal += Changed;
        private void OnDisable() => EventBus.Instance.OnViewCountCrystal -= Changed;

        public void Changed(int maxHealth, int currentHealth)
        {
            for (int i = 0; i < _images.Count; i++)
            {
                if (i < currentHealth)
                    _images[i].color = _full;
                else
                    _images[i].color = _empty;

                if (i < maxHealth)
                    _images[i].enabled = true;
                else
                    _images[i].enabled = false;
            }
        }
    }
}
