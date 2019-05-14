using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerMove : MonoBehaviour {
    public float speed=0.1f;//每0.1秒位移0.1m
    float nexttime=0;
    Vector3 v;
    void Update()
    {
        if (Time.time > nexttime)//普通攻击
        {
            nexttime = Time.time + 0.05f;
            v = transform.position;
            v.z += speed;
            transform.position = v;
        }
    }
}
