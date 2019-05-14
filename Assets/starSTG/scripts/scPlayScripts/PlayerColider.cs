using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCof;
public class PlayerColider : MonoBehaviour
{
    public GameObject injury;//玩家受伤动画
    public GameObject explosion;//玩家爆炸动画
    public MyConfig m_conf;
    WeaponVal weaponval_tep;
    private void Start()
    {
        m_conf = GameObject.Find("GameConfig").GetComponent<MyConfig>();//Add
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("EnemyTruggerEnter:objname= " + other.name);
        if (other.tag == "Boundary")
        {
            return;
        }
        if(other.tag == "Enemy")
        {
            m_conf.Damage(other.gameObject.GetComponent<prefabAttribute>().iGetAttack());
            if (injury != null)//受伤 
            {
                Instantiate(injury, transform.position, transform.rotation);//受伤 动画
            }
            Debug.Log("Afteratack NowLife" + m_conf.i_GetNowLife());
            if (m_conf.b_GetAlive() == false)//死亡
            {
                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);//自爆 动画
                }
                this.gameObject.SetActive(false);//玩家设为false
            }
        }
        if (other.tag == "weapon")//判断是否碰到敌人武器
        {
            weaponval_tep = other.gameObject.GetComponent<WeaponVal>();
            Debug.Log("PlayerTruggerEnter:objtag=" + other.tag);
            Debug.Log("PlayerTruggerEnter:weaponval=" + weaponval_tep.Weapon_Flag);
            if (weaponval_tep.Weapon_Flag == 1)//如果是敌人武器，进入if，否则无视武器
            {
                Debug.Log("NowLife" + m_conf.i_GetNowLife());
                if (weaponval_tep.Destroy_Collide == 1)//判断这个武器与物体碰撞后是否销毁，若是则销毁
                {
                    Destroy(other.gameObject);
                } 
                 m_conf.Damage(weaponval_tep.Weapon_Attack);
                if (injury != null)//受伤 
                {
                    Instantiate(injury, transform.position, transform.rotation);//受伤 动画
                } 
                Debug.Log("Afteratack NowLife"+ m_conf.i_GetNowLife());
                if (m_conf.b_GetAlive() == false)//死亡
                {
                    if (explosion != null)
                    {
                        Instantiate(explosion, transform.position, transform.rotation);//自爆 动画
                    }
                    this.gameObject.SetActive(false);//玩家设为false
                }
            }
            return;
        }
    }
}
