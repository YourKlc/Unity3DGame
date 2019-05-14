using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKey : MonoBehaviour {
 
	void Update () {
		if(Input.GetButton("Quit"))
        {
            this.gameObject.SetActive(false);
        }
	}
}
