using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIDrop : MonoBehaviour, IDropHandler
{
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject);
        
        EventSystem.current.currentSelectedGameObject.transform.parent = transform;
        var sizey = GetComponent<RectTransform>().rect.size.y;
        int index = (int)((((transform.position.y+(sizey/2)) - Input.mousePosition.y))/35)+1;
        if(index <= 0)
        {
            index = 1;
        }
        Debug.Log(index);
        EventSystem.current.currentSelectedGameObject.transform.SetSiblingIndex(index);
        //transform.parent

        Debug.Log("drop " + gameObject.name);
    }

}
