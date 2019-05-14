using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class fadeindicateobj : MonoBehaviour {
    public Material[] fadem;
    public float fadetime=1f;
	// Use this for initialization
	void Start () {
        int d = fadem.Length;
        for (int i = 0; i < d; i++)
            fadem[i].DOFade(1, 0).SetEase(Ease.Linear);
        for (int i=0;i<d;i++)
            fadem[i].DOFade(0, fadetime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).SetAutoKill(false); 
    }
	 
}
