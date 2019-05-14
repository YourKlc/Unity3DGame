using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public GameObject explosion; 
     

    void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.gameObject.tag);
        /*if (other.tag == "Boundary")
        {
            Destroy(this.gameObject);
            return;
        } */
        if (other.tag == "Player")
        {
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();
            return;
        }
        if (other.tag == "weapon")
        {
            if (other.gameObject.GetComponent<WeaponVal>().Weapon_Flag == 1) return;
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);//自爆
            }
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();
            return;
        }

    }//物体检测碰撞，子弹不检测
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }
    }
}
