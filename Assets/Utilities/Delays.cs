using System;
using System.Collections;
using UnityEngine;

namespace Utilities
{
    public abstract class Delays
    {
        public static IEnumerator DelayedAction(float time, Action func)
        {
            yield return new WaitForSeconds(time);
            func?.Invoke();
        }
    }
}
