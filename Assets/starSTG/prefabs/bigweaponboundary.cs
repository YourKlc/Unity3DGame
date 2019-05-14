using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigweaponboundary : MonoBehaviour
{ 
    public GameObject explosion;
    private void Awake()
    {
        //Debug.Log("special 01");
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if (explosion != null)
            {
                Instantiate(explosion, other.transform.position, other.transform.rotation);//自爆
            }
            Debug.Log("destroy "+ other.gameObject.name);
            Destroy(other.gameObject);
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();
            return;
        }
    } 
}
