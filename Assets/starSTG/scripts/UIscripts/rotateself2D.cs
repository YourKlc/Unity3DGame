using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class rotateself2D : MonoBehaviour {
    /// <summary>
    /// 旋转周期时间
    /// </summary>
    public float RotateSpeed = 5f;
    // Use this for initialization
    /* void Start() {
         doRotate(circletime);
     }
     void doRotate(float circletime)
     {
         Debug.Log(this.name+"start rotate");
         this.transform.DORotate(new Vector3(0,0,359),circletime).SetEase(Ease.Linear).onComplete = (()=> { this.transform.rotation = Quaternion.Euler( new Vector3(0, 0, 0)); doRotate(circletime); });
     }*/
    private void Update()
    {
        transform.Rotate(new Vector3(0,0,-1)*RotateSpeed,Space.World);
    }
}
