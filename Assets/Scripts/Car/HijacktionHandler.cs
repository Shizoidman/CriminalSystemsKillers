using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CarStateSwitcher), typeof(CameraDrager))]
    class HijacktionHandler : MonoBehaviour
    {
        [SerializeField] private Transform _map;
        [SerializeField] private Transform _player;
        [SerializeField] private float _hijacktDistance;
        [SerializeField] private Transform _exitPoint;

        private CarStateSwitcher _stateSwitcher;
        private CameraDrager _cameraDrager;

        private void Start()
        {
            _stateSwitcher = GetComponent<CarStateSwitcher>();
            _cameraDrager = GetComponent<CameraDrager>();
        }

        private void Update()
        {
            if (_stateSwitcher.State == CarState.PlayerControling && Input.GetKeyDown(KeyCode.Space))
            {
                Leave();
            }
        }

        private void OnMouseDown()
        {
            Hijackt();
        }

        private void Hijackt()
        {
            float distance = Vector3.Distance(transform.position, _player.position);

            if (distance <= _hijacktDistance)
            {
                _stateSwitcher.OnSwitch.Invoke(CarState.PlayerControling);
                _player.SetParent(transform);
                _player.position = Vector3.zero;
                _player.gameObject.SetActive(false);
                _cameraDrager.enabled = true;
            }
        }

        private void Leave()
        {
            _stateSwitcher.OnSwitch.Invoke(CarState.Empty);
            _player.SetParent(_map);
            _player.position = _exitPoint.position;
            _player.gameObject.SetActive(true);
            _cameraDrager.enabled = false;
        }
    }
}
