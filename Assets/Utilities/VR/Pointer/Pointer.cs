using System;
using UnityEngine;

namespace Utilities.VR.Pointer
{
    public class Pointer : MonoBehaviour
    {
        private Selectable _selectable;
        
        //TODO: Change keycode to UnityXRInput
        [SerializeField] private KeyCode select;

        private void Update()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit,
                Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                    Color.white);

                if (hit.transform.GetComponent<Selectable>())
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                        Color.yellow);

                    _selectable = hit.transform.GetComponent<Selectable>();

                    if (_selectable == null) return;

                    _selectable.IsHovering();

                    if (Input.GetKeyDown(select))
                        _selectable.Selected();
                }
                else
                {
                    try
                    {
                        _selectable.Reset();
                        _selectable = null;
                    }
                    catch (Exception)
                    {
                        _selectable = null;
                    }
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                try
                {
                    _selectable.Reset();
                    _selectable = null;
                }
                catch (Exception)
                {
                    _selectable = null;
                }
            }
        }
    }
}