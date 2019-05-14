using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BackGroundMove : MonoBehaviour {
    public GameObject back;
    public Transform moveto;
    float z;
    float movelength = 0;
    // Update is called once per frame
    private void Start()
    {
         domove();
        z = back.transform.position.z;
    }
    void domove()
    {
        back.transform.DOMoveZ(moveto.transform.position.z, 60f).onComplete =
       (() => { back.transform.DOMoveZ(z, 0); domove(); });
    }
}
