using System.Collections.Generic;
using UnityEngine.Events;

namespace UnityUtilities.Events
{
    public static class StringBasedEvents
    {
        private static Dictionary<string, UnityEvent> _eventDictionary;

        public static void Init()
        {
            if (_eventDictionary == null)
                _eventDictionary = new Dictionary<string, UnityEvent>();
        }

        public static void StartListening(string eventName, UnityAction listener)
        {
            if (_eventDictionary.TryGetValue(eventName, out var thisEvent))
                thisEvent.AddListener(listener);
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                _eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, UnityAction listener)
        {
            if (_eventDictionary.TryGetValue(eventName, out var thisEvent))
                thisEvent.RemoveListener(listener);
        }

        public static void TriggerEvent(string eventName)
        {
            if (_eventDictionary.TryGetValue(eventName, out var thisEvent))
                thisEvent.Invoke();
        }
    }
}