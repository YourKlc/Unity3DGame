using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoringWeapon02 : MonoBehaviour {
   public int num = 5;
    public GameObject m_weapon;
	// Use this for initialization
	void Awake () {
        Vector3 v = new Vector3(0, 0, 0);
        float delta = 360/num;
		for(int i=0;i<num;i++)
        {
            v.y += delta;
            Instantiate(m_weapon, this.transform.position,Quaternion.Euler(v));
        }
        Destroy(this.gameObject);
	} 
}
