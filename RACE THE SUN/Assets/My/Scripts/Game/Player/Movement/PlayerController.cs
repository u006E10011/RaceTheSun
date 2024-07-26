using UnityEngine;

namespace Project
{
    public class PlayerController : MonoBehaviour, IMoveble, ITurning
    {
        [SerializeField] private float _speed = 15f;
        [SerializeField] private float _speedRotation = 10;

        [Space(10)] public PlayerConfiguration _config;

        [SerializeField, Space(10)] private Rigidbody _rb;
        [SerializeField] private Transform _body;

        private void OnValidate()
        {
            _rb = _rb != null ? _rb : GetComponent<Rigidbody>();
            _body = _body != null ? _body : GetComponentInChildren<Transform>();
        }

        private void Start() => GetData();

        private void GetData()
        {

        }

        private void Update()
        {
            Limit();

            float turnTo = InputPlayer.Input.Value == Side.Right ? -_config.LimitTurn : _config.LimitTurn;

            if (InputPlayer.IsAndroid && Input.GetMouseButton(0))
                TurningBody(new Vector3(_body.transform.rotation.x, _body.transform.rotation.y, InputPlayer.Input.Direction() * turnTo), _config.Smoothing);
            else if (!InputPlayer.IsAndroid && InputPlayer.Input.Direction() != 0)
                TurningBody(new Vector3(_body.transform.rotation.x, _body.transform.rotation.y, InputPlayer.Input.Direction() * turnTo), _config.Smoothing);
            else
                TurningBody(Vector3.zero, _config.SmoothingToDefaultRotation);
        }

        private void FixedUpdate()
        {
            Move();

            Turn();
        }

        public void Move() => _rb.AddForce(Vector3.forward * _speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        public void Turn()
        {
            if ((InputPlayer.IsAndroid && Input.GetMouseButton(0)) || (!InputPlayer.IsAndroid && InputPlayer.Input.Direction() != 0))
            {
                var turnTo = InputPlayer.Input.Value == Side.Right ? Vector3.right : Vector3.left;
                _rb.AddForce(turnTo * (InputPlayer.Input.Direction() * _speedRotation * Time.fixedDeltaTime), ForceMode.VelocityChange);
            }
        }

        public void TurningBody(Vector3 direction, float speed)
        {
            _body.transform.rotation = Quaternion.Lerp(
                _body.transform.rotation,
                Quaternion.Euler(direction), speed * Time.deltaTime);
        }

        private void Limit()
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);

            transform.position = new Vector3(
                transform.position.x, 
                Mathf.Clamp(transform.position.y, _config.LimitY, Mathf.Infinity), 
                transform.position.z);
        }
    }

}