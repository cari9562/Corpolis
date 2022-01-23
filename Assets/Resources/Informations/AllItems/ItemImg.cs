using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemImg : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image icon;

    public void OnPointerEnter(PointerEventData eventData)
    {        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        icon = GetComponent<Image>();
    }
}
