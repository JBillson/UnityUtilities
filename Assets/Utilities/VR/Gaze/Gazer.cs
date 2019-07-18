using System;
using UnityEngine;

namespace Utilities.VR.Gaze
{
    public class Gazer : MonoBehaviour
    {
        private Gazeable _gazeable;

        private void Update()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit,
                Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                    Color.white);
                if (hit.transform.GetComponent<Gazeable>())
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                        Color.yellow);
                    _gazeable = hit.transform.GetComponent<Gazeable>();
                    if (_gazeable != null)
                        _gazeable.TriggerGaze();
                }
                else
                {
                    try
                    {
                        _gazeable.CancelGaze();
                        _gazeable = null;
                    }
                    catch (Exception)
                    {
                        _gazeable = null;
                    }
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                try
                {
                    _gazeable.CancelGaze();
                    _gazeable = null;
                }
                catch (Exception)
                {
                    _gazeable = null;
                }
            }
        }
    }
}