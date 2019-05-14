using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
public class UseEquip : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public GameObject Normal, Storing, Special;
    MyConfig m_config;
    MYWeapon m_weapon;
    Tween tw;
    int onanimat;
    float Yval;
    public void Start()
    {
        m_config = GameObject.Find("GameConfig").GetComponent<MyConfig>();
       if( m_config.SearchWeapon(this.name,ref m_weapon) ==false)
        { Debug.Log("wrong load weapon " + this.name); }
        Yval = transform.localPosition.y;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(m_weapon.weapon_kind == 0)
        {
            Normal.GetComponent<Image>().sprite = m_weapon.image;
            m_config.m_player.weapon_Normal = m_weapon.weapon_prefab;
        }
        else if (m_weapon.weapon_kind == 1)
        {
            Storing.GetComponent<Image>().sprite = m_weapon.image;
            m_config.m_player.weapon_Storing = m_weapon.weapon_prefab;
        }
        else if (m_weapon.weapon_kind == 2)
        {
            Special.GetComponent<Image>().sprite = m_weapon.image;
            m_config.m_player.weapon_Special = m_weapon.weapon_prefab;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    { 
            tw = transform.DOLocalMoveY(Yval + 10, 0.5f);
           // tw.onComplete= (()=> { onanimat = 0; });
          //  tw.onKill=(() => { onanimat = 0; }); 
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tw.Kill();
        tw = transform.DOLocalMoveY(Yval, 0.5f);
    } 
}