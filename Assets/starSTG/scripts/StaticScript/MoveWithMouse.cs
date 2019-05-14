using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Camposition
{
    static public float width = 1366f/2,high = 768f/2;
}
public class MoveWithMouse : MonoBehaviour {
    public Transform row, col;
    public Text postext; 
    //private Vector3 truepos = new Vector3(0, 0, 0);
    private Vector3 posr =new Vector3(0,0,0),posc = new Vector3(0, 0, 0);
    private Vector3 texpos;
    public float texposoffset = 150f;
    // Update is called once per frame
    /*private void Awake()
    {
        StartCoroutine(movewith());
    }*/
    /*IEnumerator movewith()
    {
        while(true)
        {
            posr.y = Input.mousePosition.y - Camposition.high;
            posc.x = Input.mousePosition.x - Camposition.width;
            row.transform.localPosition = posr;
            col.transform.localPosition = posc;
        }
    }*/
    void Update () {
        // truepos = Input.mousePosition;
        //truepos.x -= Camposition.width / 2;
        //truepos.y -= Camposition.high / 2;
        posr.y = Input.mousePosition.y - Camposition.high ; 
        posc.x = Input.mousePosition.x - Camposition.width ;
        row.localPosition = posr; 
        col.localPosition = posc;
        texpos = new Vector3(posc.x,posr.y, 0);
        if (texpos.x < 0) texpos.x += 150;
        //else texpos.x -= texposoffset*4;
        if (texpos.y > 0) texpos.y -= 30;
       // else texpos.y += texposoffset;
        postext.transform.localPosition = new Vector3(texpos.x, texpos.y, 0);
        postext.text = string.Format("pos(<color=#19FD00>{0:F1}</color>,<color=#00AFFD>{1:F1}</color>)", Input.mousePosition.x, Input.mousePosition.y); //"pos:("+ Input.mousePosition.x+ ","+Input.mousePosition.y+")";
       
    }
}
