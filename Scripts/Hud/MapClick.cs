using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapClick : MonoBehaviour, IPointerClickHandler {

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button.Equals(PointerEventData.InputButton.Left))
        {
            CameraCradle.current.moveToPosition(Map.current.MapPositionToWorld(eventData.position));
        }
        
        if(eventData.button.Equals(PointerEventData.InputButton.Right))
        {
            Debug.Log("send units");
        }
    }
}
