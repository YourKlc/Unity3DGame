using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    // Use this for initialization
    public float time = 2f;
	void Start()
    {
        StartCoroutine(des());
    }
    IEnumerator des()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
