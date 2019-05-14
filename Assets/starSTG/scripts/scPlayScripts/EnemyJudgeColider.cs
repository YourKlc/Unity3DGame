using UnityEngine;
using System.Collections;
using Chance;

public class EnemyJudgeColider : MonoBehaviour
{
    public GameObject explosion;
    //public WeaponSet m_weapon; 
    private WeaponVal weaponval_tep;
    private prefabAttribute m_attribute;
    private GameObject Goldprefab;//Resources目录下的Gold预制体
    private GameControl m_GM;
    private void Awake()
    {
        m_GM = GameObject.Find("GameControl").GetComponent<GameControl>();
    }
    void Start()
    {
        m_attribute = GetComponent<prefabAttribute>();
        Goldprefab = Resources.Load("Gold",typeof(GameObject)) as GameObject;//得到Resources目录下的Gold预制体
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("EnemyTruggerEnter:objname= " + other.name);
        if (other.tag == "Boundary")
        { 
            return;
        }
        if(other.tag == "weapon")
        {
            weaponval_tep = other.gameObject.GetComponent<WeaponVal>();
            Debug.Log("EnemyTruggerEnter:objtag=" + other.tag); 
            Debug.Log("EnemyTruggerEnter:weaponval=" + weaponval_tep.Weapon_Flag);
            if (weaponval_tep.Weapon_Flag == 0)//如果是玩家武器，进入if，否则无视武器
            {
                m_attribute.Damage(weaponval_tep.Weapon_Attack);
                if (weaponval_tep.Destroy_Collide == 1)//判断这个武器与物体碰撞后是否销毁，若是则销毁
                {
                    Destroy(other.gameObject);
                }
                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);//受伤 动画
                }
                if (m_attribute.bGetAlive() == false)//死亡
                {
                    if (explosion != null)
                    {
                        Instantiate(explosion, transform.position, transform.rotation);//自爆 动画
                    }
                    m_GM.AddEXP(2*m_attribute.Getlvl());
                    if (probability.GetChance(1f)==true)
                    { 
                        Debug.Log("生成金币");
                        Goldprefab.GetComponent<GoldAndEquip>().Gold = m_attribute.GetGainGold();
                        Instantiate(Goldprefab, transform.position, transform.rotation);//爆金币
                    }
                    Destroy(this.gameObject); 
                }
            }
            return;
        }
         

        if (other.tag == "Player")
        {
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();
            return;
        } 
    }
}