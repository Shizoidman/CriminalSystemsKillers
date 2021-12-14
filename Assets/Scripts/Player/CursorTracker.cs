using UnityEngine;

namespace Assets.Scripts
{
    class CursorTracker : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;

        private void Update()
        {
            transform.LookAt(_inputHandler.CursorPosition);
        }
    }
}
