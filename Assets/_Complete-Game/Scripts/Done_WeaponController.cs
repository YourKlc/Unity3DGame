using UnityEngine;
using System.Collections;
public class Done_WeaponController : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
    public float WeaponPosDelta = 1f;
    Vector3 tpos;
    public int HowtoCreate = 1;//1每次生成一个，2每次生成两个垂直的，3每次生成三个,8圆形,9三角形
    Quaternion trot;
    public int CircleNum = 0;
    private int Lastcreate = 0; 
    private prefabAttribute m_attribute;
    void Start()
    {
        m_attribute = GetComponent<prefabAttribute>();
    }
    private void Update()
    {
        if (Lastcreate != HowtoCreate)
        {
            Lastcreate = HowtoCreate;
            CancelInvoke();
            switch (Lastcreate)
            {
                case 1: InvokeRepeating("mFire1", delay, fireRate); break;
                case 2: InvokeRepeating("mFire2", delay, fireRate); break;
                case 3: InvokeRepeating("mFire3", delay, fireRate); break;
                case 4: InvokeRepeating("mFire4", delay, fireRate); break;
                case 5: InvokeRepeating("mFire5", delay, fireRate); break;
                case 6: InvokeRepeating("mFire6", delay, fireRate); break;
                case 7: InvokeRepeating("mFire7", delay, fireRate); break;
                case 8: InvokeRepeating("mFire8", delay, fireRate); break;
                case 9: InvokeRepeating("mFire9", delay, fireRate); break;
            }
        }

    }
    void mFire1()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        GetComponent<AudioSource>().Play();
    }
    void mFire2()
    {
        Debug.Log("mFire2");
        tpos = shotSpawn.position;
        tpos.x += WeaponPosDelta;
        Instantiate(shot, tpos, shotSpawn.rotation).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();

        tpos.x -= 2 * WeaponPosDelta;
        Instantiate(shot, tpos, shotSpawn.rotation).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        GetComponent<AudioSource>().Play();
    }
    void mFire3()
    {
        Debug.Log("mFire3");

        Instantiate(shot, shotSpawn.position, shotSpawn.rotation).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        trot.eulerAngles = new Vector3(0, 210, 0);
        Instantiate(shot, shotSpawn.position, trot).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        trot.eulerAngles = new Vector3(0, 150, 0);
        Instantiate(shot, shotSpawn.position, trot).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        //Instantiate(shot, tpos, shotSpawn.rotation);
        GetComponent<AudioSource>().Play();
    }
    void mFire4()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        GetComponent<AudioSource>().Play();
    }
    void mFire5()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        GetComponent<AudioSource>().Play();
    }
    void mFire6()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        GetComponent<AudioSource>().Play();
    }
    void mFire7()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        GetComponent<AudioSource>().Play();
    }
    void mFire8()//8圆形
    {
        if (CircleNum == 0) return;
        float rot = 360 / CircleNum, nowr = 0;
        for (int i = 1; i <= CircleNum; i++)
        {
            trot.eulerAngles = new Vector3(0, nowr, 0);
            nowr += rot;
            Instantiate(shot, shotSpawn.position, trot).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        }
        GetComponent<AudioSource>().Play();
    }
    void mFire9()//9三角形
    {
        Debug.Log("mFire3");
        trot.eulerAngles = new Vector3(0, 0, 0);
        Instantiate(shot, shotSpawn.position, trot).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        trot.eulerAngles = new Vector3(0, 210, 0);
        Instantiate(shot, shotSpawn.position, trot).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        trot.eulerAngles = new Vector3(0, 150, 0);
        Instantiate(shot, shotSpawn.position, trot).GetComponent<WeaponVal>().Weapon_Attack = m_attribute.iGetAttack();
        //Instantiate(shot, tpos, shotSpawn.rotation);
        GetComponent<AudioSource>().Play();
    }
}
