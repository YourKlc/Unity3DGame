using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using MySql.Data.MySqlClient;
using MyCof;

namespace MyCof
{
    /// <summary>
    /// 玩家信息
    /// </summary>

    [System.Serializable]
    public class PlayerConfig
    {
        public int int_Lvl;
        public int Int_Gold;
        public int Int_NowLife;
        public int Int_MaxLife;
        public int Int_Def;
        public int Int_Exp;
        public float Int_Attack;
        public int idUser;
        public GameObject weapon_Normal;//三种武器
        public GameObject weapon_Storing;
        public GameObject weapon_Special;
        public int ID_Normal;//三种武器
        public int ID_Storing;
        public int ID_Special;
        public PlayerConfig()
        {
            int_Lvl = 1;
            Int_Gold = 0;
            Int_NowLife = 1;
            Int_MaxLife = 1;
            Int_Def = 0;
            Int_Exp = 0;
            Int_Attack = 0;
            idUser = 0;
        }
    }

    public class MapMessage
    {
    }

}

[System.Serializable]
public class MYWeapon
{
    public int weapon_kind;
    public string weapon_name;
    public bool b_Own;
    public GameObject weapon_prefab;
    public Sprite image;
}
public class MyConfig : MonoBehaviour
{
    /// <summary>
    /// 当前选择的关卡等级 
    /// </summary>
    public int int_NowMapLevel;
    public PlayerConfig m_player;
    public int[] Gamelvl;
    public Bullet m_StaticVal;
    public MYWeapon[] m_Weapon;
    MysqlScript data;
    /*
    /// <summary>
    /// 初始化静态数据,音量画质等
    /// </summary>
    private void Awake()
    {

    }*/
    public bool SearchWeapon(string name,ref MYWeapon x)
    {
        int d = m_Weapon.Length;
        for(int i=0;i<d;i++)
        {
            if (m_Weapon[i].weapon_name == name) { x = m_Weapon[i]; return true; }
        }
        return false;
    }
    public bool SearchWeaponID(int ID, ref MYWeapon x)
    {
        int d = m_Weapon.Length;
        if(ID<d) { x = m_Weapon[ID]; return true; } 
        return false;
    }
    public void SetBGMval(float t)
    {
        m_StaticVal.BGMVal = t;
    }
    public float f_GetBGMval()
    {
        return m_StaticVal.BGMVal;
    }
    public void SetQuality(Quality t)
    {
        m_StaticVal.MyQuality = t;
    }
    public Quality Quality_GetQuality()
    {
        return m_StaticVal.MyQuality;
    }
    public void SetQualityPos(float t)
    {
        m_StaticVal.QualityPos = t;
    }
    public float f_GetQualityPos()
    {
        return m_StaticVal.QualityPos;
    }
    public void SetFrame(bool t_s)
    {
        m_StaticVal.DisFrame = t_s;
        if (m_StaticVal.DisFrame == true)
            GetComponent<Frame>().show = true;
        else GetComponent<Frame>().show = false;
    }
    public bool GetFrame()
    {
        return m_StaticVal.DisFrame;
    }
    public bool GetWindowed()
    {
        return m_StaticVal.Windowed;
    }
    public void SetWindowed(bool t)
    {
        if (t == m_StaticVal.Windowed) return;
        Debug.Log("Set Windowed");
        if (t) Screen.SetResolution(1366, 768, true);
        else Screen.SetResolution(1366, 768, false);
        m_StaticVal.Windowed = t;
    }
    void Start()
    {

        data = GetComponent<MysqlScript>();
        m_player = new PlayerConfig();
        m_player = data.GetPlayer(0); //gold lvl attack weaponnormlname
        m_player.Int_Attack = 10f;
        m_player.Int_MaxLife = m_player.int_Lvl * 20;
        
        Debug.Log("Int_MaxLife"+m_player.Int_MaxLife);
        m_player.weapon_Normal = m_Weapon[0].weapon_prefab;
        m_player.weapon_Storing = m_Weapon[6].weapon_prefab;
        m_player.weapon_Special = m_Weapon[5].weapon_prefab;
        int_NowMapLevel = 1;
        Gamelvl = new int[16];
        for (int i = 0; i < 16; i++)
            Gamelvl[i] = 0;
        for (int i = 0; i <= 1; i++)
            Gamelvl[i] = 1;
        if(m_StaticVal.DisFrame == true)
        { 
            GetComponent<Frame>().show = true;
        }
    }
    public int i_Getlvl()
    {
        return m_player.int_Lvl;
    }
    public int i_GetGold()
    {
        return m_player.Int_Gold;
    }
    public int i_GetExp()
    {
        return m_player.Int_Exp;
    }

    public void AddExp(int tf_Exp)
    {
        m_player.Int_Exp += tf_Exp;
        if (m_player.Int_Exp > m_player.int_Lvl * m_player.int_Lvl * m_player.int_Lvl)
        {
            m_player.Int_Exp %= m_player.int_Lvl * m_player.int_Lvl * m_player.int_Lvl;
            lvlup();
        }

    }
    public void lvlup()
    {
        m_player.Int_Exp = 0;
        m_player.int_Lvl++;
        m_player.Int_MaxLife = m_player.int_Lvl * 20;
        m_player.Int_NowLife = m_player.Int_MaxLife;
    }
    /// <summary>
    /// 判断关卡等级是否解锁
    /// </summary>
    /// <param name="t_ilvl"></param>
    /// <returns></returns>
    public int i_GetGameMaplvl(int t_ilvl)
    {
        return Gamelvl[t_ilvl];
    }
    /// <summary>
    /// level从1开始
    /// </summary>
    /// <param name="level"></param>
    public void SolveNowLevel(int t_level)
    {
        if(t_level <= 14)
        {
            Gamelvl[t_level+1] = 1;
        }
    }
    public void AddGold(int t_gold)
    {
        if (t_gold > 0)
        {
            m_player.Int_Gold += t_gold;
            Debug.Log("now gold=" + m_player.Int_Gold);
        }
    }
    public int i_GetNowLife()
    {
        return m_player.Int_NowLife;
    }
    public int i_GetMaxLife()
    {
        return m_player.Int_MaxLife;
    }


    public bool b_GetAlive()
    {
        if (m_player.Int_NowLife <= 0)
        {
            return false;
        }
        return true;
    }
    public void Damage(int t_fdamage)//受到伤害
    {
        m_player.Int_NowLife -= t_fdamage;
    }
    /// <summary>
    /// 初始化玩家数据
    /// </summary>
    public void Reset()
    {
        m_player = new PlayerConfig();
        m_player.Int_Gold = 10; //gold lvl attack weaponnormlname
        m_player.int_Lvl = 1;
        m_player.Int_Def = 10;
        m_player.Int_Attack = 1f;
        m_player.Int_MaxLife = m_player.int_Lvl * 20;

        int_NowMapLevel = 1;
        Gamelvl = new int[16];
        for (int i = 0; i < 16; i++)
            Gamelvl[i] = 0;
        for (int i = 0; i <= 1; i++)
            Gamelvl[i] = 1;
        m_player.weapon_Normal = m_Weapon[0].weapon_prefab;
        m_player.weapon_Storing = m_Weapon[6].weapon_prefab;
        m_player.weapon_Special = m_Weapon[5].weapon_prefab; 
    }

    //等下写，如果勾选自动存档按钮每10秒存档
}
