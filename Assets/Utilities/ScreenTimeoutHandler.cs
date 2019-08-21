using UnityEngine;

namespace UnityUtilities
{
    public static class ScreenTimeoutHandler
    {
        public static void NeverSleep()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        public static void SystemSetting()
        {
            Screen.sleepTimeout = SleepTimeout.SystemSetting;
        }
    }
}