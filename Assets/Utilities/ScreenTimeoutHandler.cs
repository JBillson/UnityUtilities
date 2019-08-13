using UnityEngine;

namespace UnityUtilities.Assets.Utilities
{
    public class ScreenTimeoutHandler : MonoBehaviour
    {
        private void OnEnable()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        private void OnDisable()
        {
            Screen.sleepTimeout = SleepTimeout.SystemSetting;
        }
    }
}