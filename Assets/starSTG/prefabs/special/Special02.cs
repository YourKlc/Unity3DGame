using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special02 : MonoBehaviour {
    public float waittime = 5f;
    public PlayerColider Sphere;
	// Use this for initialization
	void Awake () {
		StartCoroutine(doMaxLife());
	}
    IEnumerator doMaxLife()
    {
        Sphere = GameObject.Find(@"PlayerAttached/Sphere_Player").GetComponent<PlayerColider>();
        Sphere.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.transform.position = Sphere.gameObject.transform.position;
        Sphere.enabled = false;
        yield return new WaitForSeconds(5); 
        Sphere.enabled = true;
        Sphere.gameObject.GetComponent<SphereCollider>().enabled = true;
        Destroy(this.gameObject);
    }


}
