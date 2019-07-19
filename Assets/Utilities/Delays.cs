using System;
using System.Collections;
using UnityEngine;

namespace Utilities
{
    public abstract class Delays
    {
        public static IEnumerator DelayedAction(Action func, float time)
        {
            yield return new WaitForSeconds(time);
            func?.Invoke();
        }
    }
}
