using UnityEngine;

namespace Assets.Scripts
{
    class CameraDrager : MonoBehaviour
    {
        [SerializeField] private Camera _dragableCamera;
        [SerializeField] [Range(5, 30)] private float _distance;
        [SerializeField] [Range(1, 10)] private float _smoothSpeed;

        private void FixedUpdate()
        {
            Vector3 offset = new Vector3(transform.position.x, _distance, transform.position.z);
            _dragableCamera.transform.position = Vector3.Lerp(_dragableCamera.transform.position, offset, _smoothSpeed * Time.fixedDeltaTime);
        }
    }
}
