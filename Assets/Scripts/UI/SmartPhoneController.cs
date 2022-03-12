using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhoneController : MonoBehaviour, ICustomEventsListener
{
    // Start is called before the first frame update
    private void Start()
    {
        EventsManager.Instance.PropagateEvent(new TVControllerEvent { Id = 1, Name = "tv news!" }, this);

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
            case SmartPhoneControllerEvent smartPhoneEvt:
                Debug.Log(smartPhoneEvt.Id);
                Debug.Log(smartPhoneEvt.Content);
                break;
        }
    }
}

public class SmartPhoneControllerEvent : CustomEvent
{
    public int Id;
    public string Content;
}
