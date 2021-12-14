using UnityEngine;

namespace Assets.Scripts
{
    class InputHandler : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private RaycastHit _clickInfo;

        public Vector3 CursorPosition { get; private set; }
        public RaycastHit CursorInfo => _clickInfo;
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private void Update()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            EmitRay();
        }

        private void EmitRay()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _clickInfo))
            {
                CursorPosition = new Vector3(CursorInfo.point.x, 0, CursorInfo.point.z);
            }
        }
    }
}
