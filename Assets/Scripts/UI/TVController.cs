using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVController : MonoBehaviour, ICustomEventsListener
{
    // Start is called before the first frame update
    void Start()
    {
        EventsManager.Instance.PropagateEvent(new TVControllerEvent { Id = 1, Name = "tv news!" }, this);
    }

    public void OnEvent(CustomEvent evt)
    {
        switch (evt)
        {
            case TVControllerEvent tvEvent:
                Debug.Log(tvEvent.Id);
                Debug.Log(tvEvent.Name);
                break;
        }
    }
}

public class TVControllerEvent : CustomEvent
{
    public int Id;
    public string Name;
}
