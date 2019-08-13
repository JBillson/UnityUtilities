using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace UnityUtilities.Assets.Utilities.VR.Gaze
{
    public class Gazeable : MonoBehaviour
    {
        [Header("Settings")] public float gazeTime;
        public bool canReset;
        [ShowIf("canReset")] public float resetTime;
        
        [Header("Events")] [SerializeField] private UnityEvent onGazeCompleted;
        [ShowIf("canReset")][SerializeField] private UnityEvent onGazeableReset;
        
        private bool _isGazing;
        private float _counter;
        private bool _gazeCompleted;
        private Collider _collider;


        private void Awake()
        {
            _collider = GetComponent<Collider>();
            ResetGazeable();
        }

        private void Update()
        {
            if (_isGazing)
            {
                _counter -= Time.deltaTime;

                if (_counter <= 0)
                {
                    GazeCompleted();
                }
            }
            
            if (!_gazeCompleted || !canReset) return;
            
            _counter -= Time.deltaTime;

            if (_counter <= 0)
            {
                ResetGazeable();
            }
        }

        private void GazeCompleted()
        {
            _gazeCompleted = true;
            _isGazing = false;
            _collider.enabled = false;

            if (canReset)
            {
                _counter = resetTime;
            }
                
            onGazeCompleted.Invoke();
        }

        public void TriggerGaze()
        {
            _isGazing = true;
        }

        public void CancelGaze()
        {
            if (_gazeCompleted) return;
            _isGazing = false;
            _counter = gazeTime;
        }

        private void ResetGazeable()
        {
            _counter = gazeTime;
            _gazeCompleted = false;
            _collider.enabled = true;
            onGazeableReset.Invoke();
        }
    }
}