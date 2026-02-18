using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<Event> events;

    public static EventManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public Event FindEventByName(string name)
    {
        foreach (Event evente in events)
        {
            if (evente.eventName == name) return evente;
        }

        return null; //if can't find then return null
    }

    public void RunEvent(Event newEvent)
    {
        newEvent.Run();
    }

    public void RunEvent(string eventName)
    {
        Event newEvent = FindEventByName(eventName);

        newEvent.Run();
    }
}
