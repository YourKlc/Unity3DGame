using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class Canvas_Save : MonoBehaviour {
    public MyConfig gamedata; 
    public Text level;
    public Text Gold;
    public Text weapon_Tex;
    public Image weaponimage;
    public Button SaveStart,NewStart; 
    public ChangeControl m_change;
    MYWeapon t;
    // Use this for initialization
    void Start()
    {
       level.text = gamedata.i_Getlvl().ToString();
       Gold.text = gamedata.i_GetGold().ToString();
        SaveStart.onClick.AddListener(DoSaveStart);
        NewStart.onClick.AddListener(DoNewStart);
       
        gamedata.SearchWeaponID(0,ref t);
        weapon_Tex.text = t.weapon_name; 
        weaponimage.sprite = t.image;
    }
    void DoSaveStart()
    {
        m_change.EnterGame(0);
    }
    void DoNewStart()
    {
        m_change.EnterGame(1);
    }
}
