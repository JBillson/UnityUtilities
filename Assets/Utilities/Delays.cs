﻿using System;
using System.Collections;
using UnityEngine;

namespace UnityUtilities.Assets.Utilities
{
    public static class Delays
    {
        public static IEnumerator DelayedAction(Action func, float time)
        {
            yield return new WaitForSeconds(time);
            func?.Invoke();
        }
    }
}
