using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StaticClass;
public class Equip : MonoBehaviour
{
    private GameControl m_GM;
    public float Goldway = staticclass.GoldToPlayer;
    public int Gold = 0;
    private void Awake()
    {
        m_GM = GameObject.Find("GameControl").GetComponent<GameControl>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Vector3.Distance(this.transform.position, other.gameObject.transform.position) <= Goldway)
            {
                Debug.Log("碰到金币");
                this.transform.DOMove(other.transform.position, 0.3f).onKill =
                    (() => {
                        m_GM.obj_config.AddGold(this.Gold);
                    //声音
                    Destroy(this.gameObject);
                    });
            }
        }
    }
}
