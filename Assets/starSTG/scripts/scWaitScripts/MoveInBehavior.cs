using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MoveInBehavior : MonoBehaviour ,
    IPointerEnterHandler, IPointerExitHandler
{
    public ParticleSystem m_rot;

    
    public void OnPointerEnter(PointerEventData eventData)
    {var m = m_rot.main; 
        m.simulationSpeed = 3f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var m = m_rot.main;
        m.simulationSpeed = 0.5f;
    } 
}
