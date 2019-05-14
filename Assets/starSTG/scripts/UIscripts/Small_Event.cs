using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Small_Event : MonoBehaviour {
    
    void PlaySound()
    {
        this.GetComponent<AudioSource>().Play(); 
    } 
}
