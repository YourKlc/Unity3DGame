using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animat : MonoBehaviour {
    public AnimationCurve anim;
    Vector3 scale_initial,scale; 
    // Use this for initialization
    void Start()
    {
      /*  scale_initial = this.transform.localScale;
        scale = scale_initial;
        transform.localScale = new Vector3(0,0,0);*/
    }
    void Awake () {
        //scale = scale_initial; 
    }
	
	// Update is called once per frame
	void Update () {
       /* Debug.Log(anim.Evaluate(Time.time));
        //transform.localPosition = new Vector3(Time.time, anim.Evaluate(Time.time), 0);
        transform.localScale=scale*anim.Evaluate(Time.time);*/
    }
}
