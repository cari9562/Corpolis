using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPhoneController : MonoBehaviour, ICustomEventsListener
{
    // Start is called before the first frame update
    private void Start()
    {
        EventsManager.Instance.PropagateEvent(new SmartPhoneControllerEvent { Id = 2, Content = "new phone message!" }, this);
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
