using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    private Dictionary<string, Action<string>> eventDictionary;

    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, Action<string>>();
        }
    }

    public static void StartListening(string eventName, Action<string> listener)
    {
        Action<string> thisEvent;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            //Add more event to the existing one
            thisEvent += listener;

            //Update the Dictionary
            instance.eventDictionary[eventName] = thisEvent;
        }
        else
        {
            //Add event to the Dictionary for the first time
            thisEvent += listener;
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, Action<string> listener)
    {
        if (eventManager == null) return;
        Action<string> thisEvent;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            //Remove event from the existing one
            thisEvent -= listener;

            //Update the Dictionary
            instance.eventDictionary[eventName] = thisEvent;
        }
    }

    public static void TriggerEvent(string eventName, string payload)
    {
        Action<string> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(payload);
            // OR USE instance.eventDictionary[eventName]();
        }
    }
}