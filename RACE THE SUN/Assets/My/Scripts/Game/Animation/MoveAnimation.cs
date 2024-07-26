using DG.Tweening;
using UnityEngine;

namespace Project
{
    public enum Move
    {
        Local,
        World
    }

    public class MoveAnimation : MonoBehaviour
    {

        [SerializeField] private float _duration = 2;
        [SerializeField] private float _interval = 2;
        [SerializeField] private int _setLoops = -1;

        [SerializeField, Space(10)] private Move _type;

        [SerializeField, Space(10)] private Vector3 _firstPosition;
        [SerializeField] private Vector3 _secondPosition;

        [SerializeField, Space(10)] private Transform _target;

        private void OnValidate() => _target = _target != null ? _target : GetComponent<Transform>();

        private void OnEnable()
        {
            var tween1 = _type == Move.Local ? _target.DOLocalMove(_firstPosition, _duration) : _target.DOMove(_firstPosition, _duration);
            var tween2 = _type == Move.Local ? _target.DOLocalMove(_secondPosition, _duration) : _target.DOMove(_secondPosition, _duration);

            DOTween.Sequence().
                Append(tween1).
                AppendInterval(_interval).
                Append(tween2).
                AppendInterval(_interval).
                SetLoops(_setLoops);

        }
    }
}