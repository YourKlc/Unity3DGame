using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// 自身淡入淡出效果，只针对有image物体
/// </summary>
[ExecuteInEditMode]
public class fadeself : MonoBehaviour {
    public float fadetime = 1f;
	 
	// Update is called once per frame
	void Start () {
        //一直循环
        this.GetComponent<Image>().DOFade(0,1f).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo).SetAutoKill(false); ;
	}
}
