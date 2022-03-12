using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance;

    private List<ICustomEventsListener> customEvents = new List<ICustomEventsListener>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Register(ICustomEventsListener evt)
    {
        if (!customEvents.Contains(evt))
        {
            customEvents.Add(evt);
        }
    }

    public void Deregister(ICustomEventsListener evt)
    {
        if (customEvents.Contains(evt))
        {
            customEvents.Remove(evt);
        }
    }

    public void PropagateEvent(CustomEvent evt, ICustomEventsListener eventsListener)
    {
        foreach (ICustomEventsListener customEvent in customEvents)
        {
            customEvent.OnEvent(evt);
        }
    }
}
