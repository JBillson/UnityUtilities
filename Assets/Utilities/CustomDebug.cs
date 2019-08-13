using System;
using UnityEngine;

namespace UnityUtilities.Assets.Utilities
{
    public abstract class CustomDebug
    {
        public static void Print(string message)
        {
            Debug.Log(message);
        }

        public static void Print(string message, string color)
        {
            color = color.ToLower();
            try
            {
                Debug.Log($"<color={color}>{message}</color>");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}