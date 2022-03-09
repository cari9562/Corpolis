using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICustomEventsListener
{
    void OnEvent(CustomEvent evt);
}
