using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabAttribute : MonoBehaviour {
    public Enemy_Attribute m_Attribute;
    public int int_Tag;
    // Use this for initialization
    void Start () {
		
	}
    public int Getlvl()
    {
        return m_Attribute.int_Lvl;
    }
    public int Getlife()
    {
        return m_Attribute.Int_NowLife;
    }
    public void Setlife(int a)
    {
         m_Attribute.Int_NowLife =a;
    }
    public void Damage(int t_idamage)
    {
        m_Attribute.Int_NowLife -= t_idamage;
    }
    public void Damage(float t_idamage)
    {
        m_Attribute.Int_NowLife -= (int)(t_idamage+0.5f);
    }
    public bool bGetAlive()
    {
        if (m_Attribute.Int_NowLife <= 0) return false;
        return true;
    }
    public int GetGainGold()
    {
        return m_Attribute.int_Gold;
    }
    public int iGetAttack()
    {
        return m_Attribute.Int_Attack;
    }
    public void SetAttack(int b)
    {
        m_Attribute.Int_Attack =b;
    }
}
