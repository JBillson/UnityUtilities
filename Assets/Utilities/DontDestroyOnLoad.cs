using UnityEngine;

namespace UnityUtilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {        
            DontDestroyOnLoad(gameObject);
        }
    }
}
