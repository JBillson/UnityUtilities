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

                    _selectable.StartHovering();

                    if (Input.GetKeyDown(select))
                        _selectable.Selected();

                    var amount = Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger");
                    print(amount);
                    if (amount > 0.7f)
                    {
                        _selectable.Selected();
                    }
                }
                else
                {
                    try
                    {
                        _selectable.StopHovering();
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
                    _selectable.StopHovering();
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