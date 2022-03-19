using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalenderController : MonoBehaviour, ICustomEventsListener
{
    public void OnEvent(CustomEvent evt)
    {

    }

    private void OnEnable()
    {
        EventsManager.Instance.Register(this);
    }

    private void OnDisable()
    {
        EventsManager.Instance.Deregister(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
