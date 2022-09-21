using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Waypoint : MonoBehaviour, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] Tower towerPf;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    void IPointerClickHandler.OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPf.CreateTower(towerPf, transform.position);
            if (isPlaced)
            {
                isPlaceable = false;
            }
        }
    }

    void IPointerExitHandler.OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
    {
        Debug.Log("Exit");
    }




}
