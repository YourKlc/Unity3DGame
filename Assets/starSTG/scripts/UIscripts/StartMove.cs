using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{

    Rigidbody2D rb;

    public float x = -5;
    public float y = -1;
    Vector2 vec = new Vector2(0,0);
    Camera cam;
    float size = -1;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(x, y);
        rb.transform.Find("GameObject").GetComponent<TrailRenderer>().time = Random.Range(0.8f,1.5f); 
        cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        size = height*3;
    }

    void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(CoUpdate());
    }

    IEnumerator CoUpdate()
    {
        while (true)
        {
            if (IsBehind())
            {
                break;
            }
            yield return new WaitForSeconds(1); ;
        }
        StopCoUpdate();
    }

    void StopCoUpdate()
    {
        GameObject.Destroy(gameObject);
        StopAllCoroutines();
    }

    bool IsBehind()
    {
        //判断是否超出屏幕一定距离
        float distance = Vector2.Distance(transform.localPosition, vec);
        // Debug.Log(transform.position + " ");
        
        if (distance > size )
        {
            return true;
        }
        return false;
    }
}
