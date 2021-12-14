using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    class CarStateSwitcher : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<CarState> OnSwitch;

        public CarState State { get; private set; }

        private void Start()
        {
            OnSwitch.AddListener(Switch);
        }

        private void Switch(CarState state)
        {
            State = state;
        }
    }

    public enum CarState
    {
        Empty,
        PlayerControling,
        AIControling,
        Broken
    }
}