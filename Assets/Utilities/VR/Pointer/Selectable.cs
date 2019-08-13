using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace UnityUtilities.Assets.Utilities.VR.Pointer
{
    public class Selectable : MonoBehaviour
    {
        [Header("Settings")] public bool canReset;
        [ShowIf("canReset")] public float resetTime = 2f;

        [Header("Events")] public UnityEvent onHoverStarted;
        public UnityEvent onHoverStopped;
        public UnityEvent onSelected;
        public UnityEvent onSelectableReset;

        private bool _isHovering;
        private bool _hasBeenSelected;

        public void StartHovering()
        {
            if (_isHovering) return;
            _isHovering = true;
            onHoverStarted?.Invoke();
        }

        public void Selected()
        {
            if (_hasBeenSelected) return;

            _isHovering = false;
            _hasBeenSelected = true;
            onSelected?.Invoke();
            StartCoroutine(Delays.DelayedAction(ResetSelectable, resetTime));
        }

        public void StopHovering()
        {
            _isHovering = false;
            onHoverStopped?.Invoke();
        }

        public void ResetSelectable()
        {
            _hasBeenSelected = false;
            onSelectableReset?.Invoke();
        }
    }
}