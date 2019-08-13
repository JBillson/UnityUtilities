using UnityEngine;

namespace UnityUtilities.Assets.Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {        
            DontDestroyOnLoad(gameObject);
        }
    }
}
