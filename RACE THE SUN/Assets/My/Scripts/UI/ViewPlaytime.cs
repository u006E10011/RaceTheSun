using System;
using TMPro;
using UnityEngine;

namespace Project
{
    public class ViewPlaytime : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private void Update() => UpdateText(Time.time);

        private void UpdateText(float value)
        {
            int minites = Mathf.FloorToInt(value / 60);
            int seconds = Mathf.FloorToInt(value % 60);

            _text.text = string.Format("{0:00}:{1:00}", minites, seconds);
        }

    }
}