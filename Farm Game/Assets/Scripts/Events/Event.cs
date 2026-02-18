using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Event : MonoBehaviour
{
    public string eventName; //we can find events through their name, this should be all lowercase
    [SerializeField] private bool destroyOnLoad; //set to true if this event only works for this scene
    [SerializeField] private UnityEvent eventFunction;

    private void Start()
    {
        //if this isnt already in menus then add it to menus
        if (EventManager.Instance.FindEventByName(eventName) == null)
        {
            EventManager.Instance.events.Add(this);

            if (!destroyOnLoad) { DontDestroyOnLoad(this); }
        }
    }

    private void OnDisable()
    {
        //remove this from events if it gets disabled/removed
        EventManager.Instance.events.Remove(this);
    }

    public void Run() { eventFunction.Invoke(); }
}
