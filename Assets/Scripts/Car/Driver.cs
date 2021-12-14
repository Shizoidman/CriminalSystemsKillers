using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CarStateSwitcher), typeof(Rigidbody))]
    class Driver : MonoBehaviour
    {
        [SerializeField] [Range(1, 100)] float _moveSpeed;
        [SerializeField] [Range(1, 100)] float _turnSpeed;

        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private List<Transform> _waypoints = new List<Transform>();

        private CarStateSwitcher _stateSwitcher;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _stateSwitcher = GetComponent<CarStateSwitcher>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            switch (_stateSwitcher.State)
            {
                case CarState.PlayerControling:
                    PlayerDrive();
                    break;

                case CarState.AIControling:
                    AIDrive();
                    break;
            }
        }

        private void PlayerDrive()
        {
            float velocity = _rigidbody.velocity.magnitude / 1000;
            Vector3 direction = _inputHandler.CursorInfo.point - transform.position;
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, rotationAngle, 0);
            float accelerationInput = _moveSpeed * _inputHandler.Vertical;

            transform.rotation = Quaternion.Lerp
            (
                transform.rotation,
                targetRotation,
                _turnSpeed * Mathf.Clamp(velocity, -1, 1) * Time.fixedDeltaTime
            );

            _rigidbody.AddRelativeForce(Vector3.forward * accelerationInput);
        }

        private void AIDrive()
        {

        }
    }
}
