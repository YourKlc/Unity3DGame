using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChild : MonoBehaviour {

    public GameObject game;
    public GameObject player;
    public GameControl m_control; 
	// Update is called once per frame
	void Update () {
		if(game.activeInHierarchy == false)
        {
            this.gameObject.SetActive(false);
            if (player) { player.SetActive(false); }
            if (m_control) { m_control.DisEnd(0); }//失败 
        }
	}
}
