using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Events
{
    public class StringBasedEvents : MonoBehaviour
    {
        private Dictionary<string, UnityEvent> _eventDictionary;

        private static StringBasedEvents _stringBasedEvents;

        private static StringBasedEvents Instance
        {
            get
            {
                if (_stringBasedEvents)
                    return _stringBasedEvents;

                _stringBasedEvents = FindObjectOfType(typeof(StringBasedEvents)) as StringBasedEvents;

                if (_stringBasedEvents != null) _stringBasedEvents.Init();

                return _stringBasedEvents;
            }                
        }

        private void Init()
        {
            if (_eventDictionary == null)            
                _eventDictionary = new Dictionary<string, UnityEvent>();            
        }

        public static void StartListening(string eventName, UnityAction listener)
        {
            if (Instance._eventDictionary.TryGetValue(eventName, out var thisEvent))
                thisEvent.AddListener(listener);
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Instance._eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, UnityAction listener)
        {
            if (_stringBasedEvents == null) return;
            if (Instance._eventDictionary.TryGetValue(eventName, out var thisEvent))            
                thisEvent.RemoveListener(listener);            
        }

        public static void TriggerEvent(string eventName)
        {
            if (Instance._eventDictionary.TryGetValue(eventName, out var thisEvent))            
                thisEvent.Invoke();            
        }
    }
}