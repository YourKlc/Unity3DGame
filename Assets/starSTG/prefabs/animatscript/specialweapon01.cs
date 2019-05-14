using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class specialweapon01 : MonoBehaviour {
    public GameObject nextWeapon;//爆炸武器
    public GameObject imag;
    public Light m_Light;
    private float scale;
    private GameObject desobj;
	// Use this for initialization
	void Awake () {
        scale = m_Light.range;
        StartCoroutine(weapon());
        StartCoroutine(music());
        m_Light.range=0;

    } 
    
    IEnumerator weapon()
    {
        yield return new WaitForSeconds(0.8f); 
        imag.SetActive(false);
        this.GetComponent<VerMove>().speed = 0;
        desobj=Instantiate(nextWeapon, nextWeapon.transform.position, nextWeapon.transform.rotation);//生成碰撞体
        Debug.Log(nextWeapon.transform.position);
        StartCoroutine(Animat());
    }
    IEnumerator Animat()
    {
        for (int i = 10; i >= 1; i--)
        {
            m_Light.range = scale / i;
            yield return new WaitForSeconds(0.08f);
        }
        Tween te =  m_Light.transform.DOShakePosition(0.3f,1,20,60).SetLoops(-1,LoopType.Yoyo);
        yield return new WaitForSeconds(3f);
        te.Kill();
        for (int i = 1; i <=10; i++)
        {
            m_Light.range = scale / i;
            yield return new WaitForSeconds(0.08f);
        }
        Destroy(desobj);
        Destroy(this.gameObject);
    }
    IEnumerator music()
    {
        yield return new WaitForSeconds(6f);
        GetComponent<AudioSource>().enabled = false; //结束声音
    }
}
