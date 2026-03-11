using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MultiMouseClickButton : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent leftClick;
    public UnityEvent middleClick;
    public UnityEvent rightClick;

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
}