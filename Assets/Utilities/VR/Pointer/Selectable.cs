using UnityEngine;

namespace Utilities.VR.Pointer
{
    public class Selectable : MonoBehaviour
    {

        public void IsHovering()
        {
            print("Is Hovering");
        }
        
        public void Selected()
        {
            print("Object Selected");
        }

        public void Reset()
        {
            print("Reset");
        }
    }
}