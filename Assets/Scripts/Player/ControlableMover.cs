using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    class ControlableMover : MonoBehaviour
    {
        [SerializeField] [Range(0, 100)] private float _moveSpeed;
        [SerializeField] private InputHandler _inputHandler;

        private CharacterController _controller;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            Vector3 moveDirection = new Vector3(_inputHandler.Horizontal, 0, _inputHandler.Vertical);
            _controller.Move(moveDirection * _moveSpeed * Time.fixedDeltaTime);
        }
    }
}
