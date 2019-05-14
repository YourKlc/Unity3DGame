using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public GameObject m_obj;
    Vector3 v = new Vector3(90,0,0);
	void Update () {
        v.y++;
        m_obj.transform.rotation = Quaternion.Euler(v);
        if (v.y == 360) v.y = 1;
	}
}
