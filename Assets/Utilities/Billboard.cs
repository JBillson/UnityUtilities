using UnityEngine;

namespace UnityUtilities
{
    public class Billboard : MonoBehaviour
    {
        public bool isEnabled;
        private Camera _camera;

        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();
        }

        private void LateUpdate()
        {
            if (!isEnabled) return;

            var cameraRotation = _camera.transform.rotation;
            transform.LookAt(transform.position + cameraRotation * Vector3.forward,
                cameraRotation * Vector3.up);
        }
    }
}