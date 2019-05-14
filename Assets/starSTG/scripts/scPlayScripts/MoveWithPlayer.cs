using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour {
    // Use this for initialization
    Vector3 v,playerpos;
    public Transform playertrans;
    float Y;
    void Awake () {
        //Debug.Log(this.gameObject.name);
        if (this.gameObject.tag == "weapon")
        {
            playertrans = GameObject.Find("player/player").transform;
        }
        playerpos = playertrans.position;
        
    }
	
	// Update is called once per frame
	void Update () { 

        v = transform.position;
        v+= (playertrans.position - playerpos);
        transform.position = v;
        playerpos = playertrans.position;
    }
}
