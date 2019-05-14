using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;  
	private Done_GameController gameController;

	void Start ()
	{
		/* GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		} */
	}

	void OnTriggerEnter (Collider other)
	{
        Debug.Log("EnemyTruggerEnter:objname= " + other.name);
		if (other.tag == "Boundary")
		{
            Destroy(this.gameObject);
            return;
		}

		

		if (other.tag == "Player")
		{
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();
            return;
		}
        if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);//自爆
		} 
        Destroy(this.gameObject);
    }
}