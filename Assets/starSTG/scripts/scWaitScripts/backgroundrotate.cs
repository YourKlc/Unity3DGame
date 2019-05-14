using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class backgroundrotate : MonoBehaviour {
    Vector3 trans,transto;
    Vector3 rotrans, rotransto;
    // Use this for initialization
    void Start () {
        transto = new Vector3(4.9f,77.4f,4.1f);
        trans = new Vector3(-12.9f,99.2f,4.1f);
        T();
        
        //  transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * 2);
    }
    void T()
    {
        this.transform.DOMove(transto,100f).SetEase(Ease.Linear).onComplete=delegate() { R(); };
    }
    void R()
    {
        this.transform.DOMove(trans, 100f).SetEase(Ease.Linear).onComplete = delegate () { T(); };
    }
}
