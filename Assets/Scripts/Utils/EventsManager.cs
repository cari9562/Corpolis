using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance;

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

    public void PropagateEvent(CustomEvent evt, ICustomEventsListener eventsListener)
    {
        eventsListener.OnEvent(evt);
    }
}
