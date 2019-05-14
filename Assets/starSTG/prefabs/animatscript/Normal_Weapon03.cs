using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Weapon03 : MonoBehaviour {

    public int num = 3;
    public GameObject m_weapon;
    // Use this for initialization
    void Awake()
    {
        Vector3 v = new Vector3(0, -45, 0);
        Instantiate(m_weapon, this.transform.position, Quaternion.Euler(v));
         v = new Vector3(0, 0, 0);
        Instantiate(m_weapon, this.transform.position, Quaternion.Euler(v));
         v = new Vector3(0, 45, 0);
        Instantiate(m_weapon, this.transform.position, Quaternion.Euler(v));

        Destroy(this.gameObject);
    }
}
