using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MultiMouseClickButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent leftClick;
    public UnityEvent middleClick;
    public UnityEvent rightClick;
    public UnityEvent startHover;
    public UnityEvent stopHover;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                leftClick.Invoke();
                break;
            case PointerEventData.InputButton.Middle:
                middleClick.Invoke();
                break;
            case PointerEventData.InputButton.Right:
                rightClick.Invoke();
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        startHover.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        stopHover.Invoke();
    }
}