using System;
using System.Collections;
using UnityEngine;

namespace Utilities
{
    public class CustomDebug
    {
        public void Print(string message, string color)
        {
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