using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Project
{
    public class ViewScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _totalText;
        [SerializeField] private TMP_Text _addText;
        [SerializeField] private TMP_Text _MenuText;

        private void OnEnable()
        {
            EventBus.Instance.OnViewAddScore += Add;
            EventBus.Instance.OnViewUpdateScore += Total;
        }

        private void OnDisable()
        {
            EventBus.Instance.OnViewAddScore -= Add;
            EventBus.Instance.OnViewUpdateScore -= Total;
        }

        private void Total(int value) => _totalText.text = value.ToString();
        private void Add(int value) => _addText.text = value.ToString();
    }
}