/* GitHub project: https://github.com/danielcmcg/Unity-UI-Nested-Drag-and-Drop */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    Vector3 startPosition;
    Vector3 diffPosition;
    GameObject canvas_;
    static bool updateSize;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition - diffPosition;
        //Debug.Log(Input.mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        updateSize = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = transform.position;
        diffPosition = Input.mousePosition - startPosition;
        EventSystem.current.SetSelectedGameObject(gameObject);
        EventSystem.current.currentSelectedGameObject.transform.SetParent(canvas_.transform);
        EventSystem.current.currentSelectedGameObject.transform.SetAsFirstSibling();
        Debug.Log("start drag " + gameObject.name);
    }

    void Start()
    {
        canvas_ = GameObject.Find("Canvas");
        updateSize = false;
    }

    void Update()
    {
        if(updateSize == true)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
        }
    }

}
