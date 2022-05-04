using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Image image;
    bool wasClicked = false;

    CityOverviewManager manager;

    void Awake()
    {
        image = GetComponent<Image>();
        image.color = new Color(1.0f, 1.0f, 1.0f);

        manager = GameObject.Find("CityOverview").GetComponent<CityOverviewManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        
        if(wasClicked)
        {
            image.color = new Color(1.0f, 1.0f, 1.0f);
        }
        else
        {
            image.color = new Color(1.0f, 1.0f, 0.75f);
        }

        wasClicked = !wasClicked;
    }
}
