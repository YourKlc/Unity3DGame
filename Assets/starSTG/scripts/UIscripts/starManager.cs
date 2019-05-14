using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starManager : MonoBehaviour {
    public GameObject pre;

    float time = 0.5f;
    float timer = 0;
   // int T = 0;
    void Update()
    {

        timer += Time.deltaTime;
        if (timer < time)//||T==1)
        {
            return;
        }
      //  T = 1;
        timer = 0;
        time = Random.Range(0, 5) * 0.3f;
        
        GameObject go = GameObject.Instantiate(pre);
        go.transform.SetParent(this.transform);
        go.transform.localPosition = new Vector2(random(), random());
       // go.transform.localPosition = new Vector2(50,100);
    }

    private float random()
    {
        return (Random.Range(-10, 4) * 0.7f) + 4f;
    }
}
