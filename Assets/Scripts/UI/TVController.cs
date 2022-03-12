using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVController : MonoBehaviour, ICustomEventsListener
{
    // Start is called before the first frame update
    void Start()
    {
        EventsManager.Instance.PropagateEvent(new SmartPhoneControllerEvent { Id = 2, Content = "new phone message!" }, this);

    }

    private void OnEnable()
    {
        EventsManager.Instance.Register(this);
    }

    private void OnDisable()
    {
        EventsManager.Instance.Deregister(this);
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
