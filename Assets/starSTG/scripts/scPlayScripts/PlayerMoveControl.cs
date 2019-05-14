using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
static public class tb_Boundary
{
    static public float xMin= -6.1f, xMax= 6.14f, zMin= -1.6f, zMax= 9.1f;
    static public float xLength = xMax - xMin;
    static public float zLength = zMax - zMin;
}
public class PlayerMoveControl : MonoBehaviour {
    public float speed = 5f;
    Vector2 downpos;
    public GameObject shot_normal;//普通子弹
    public GameObject shot_storing;//蓄力子弹
    public GameObject shot_speciall;//特殊子弹

    public Transform shotposition;//子弹生成坐标
    public float fireRate; //普通攻击每发子弹间隔
    private float normal_nextFire = 0f;// 下次普通攻击最少时间

    public float Storing_Time = 0f;//当前蓄力时间
    public float Storing_interval = 2f;//蓄满力时间
    public float Storing_nextFire = 0f;// 下次蓄力计算时间

    public int Special_Num = 3;//特殊攻击次数

    public GameObject obj_UI;
    private UIControlScript script_UI;//得到UI脚本，调用脚本函数
    public MyConfig m_conf;
    private void Awake()
    {
        m_conf = GameObject.Find("GameConfig").GetComponent<MyConfig>();
        shot_normal = m_conf.m_player.weapon_Normal;
        shot_storing = m_conf.m_player.weapon_Storing;
        shot_speciall = m_conf.m_player.weapon_Special;
    }
    void Start () {
        script_UI = obj_UI.GetComponent<UIControlScript>();
        script_UI.UpdateSpecialFire(Special_Num);
    }
    private void Update()
    { 
        if (Input.GetButton("Fire1") && Time.time > normal_nextFire)//普通攻击
        {
            Storing_Time = 0;
            script_UI.UpdateStoringFire(0);
            normal_nextFire = Time.time + fireRate;  
            Instantiate(shot_normal, shotposition.position, shotposition.rotation);
            GetComponent<AudioSource>().Play();
        }
        else if(Input.GetButton("Fire2") && Time.time > Storing_nextFire)/*蓄力,0.1秒检查一次*/
        {
            Debug.Log("out"); 
            Storing_nextFire = Time.time + 0.1f;
            Storing_Time += 0.1f; 
            script_UI.UpdateStoringFire(Storing_Time/Storing_interval); 
        }
         else if(Input.GetButtonUp("Fire2"))//蓄力攻击
        { 
            if(Storing_Time >= Storing_interval)
            {
                Instantiate(shot_storing, shotposition.position, shotposition.rotation);
                GetComponent<AudioSource>().Play();
            }
            Storing_Time = 0;
            script_UI.UpdateStoringFire(0);
        } 
        else if(Input.GetButtonUp("Fire3"))//特殊攻击
        {
            if(Special_Num>0)
            {
                Special_Num--;
                script_UI.UpdateSpecialFire(Special_Num);
                Instantiate(shot_speciall, shotposition.position, shotposition.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, tb_Boundary.xMin, tb_Boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, tb_Boundary.zMin, tb_Boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -5);
    }
}
