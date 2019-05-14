using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyMoveControl : MonoBehaviour
{
    /// <summary>
    /// Movelevel = 0垂直移动,1原地不动,2水平移动,3小幅移动,4 移动指定地点EndPostion 之后按区间范围移动
    /// 5按MovePart_LeftTop,MovePart_RightBottom间范围移动,>10 不改变当前状态
    /// </summary>
    public int Movelevel = 100;
    public Vector3 EndPostion;
    public Vector2 MovePart_LeftTop, MovePart_RightBottom;
    public float verSpeed = -1f;//初始入场速度
    public float moveSpeed = -2f;//移动速度
    public int nowState;//敌人当前状态,0:静止,1:移动
    private Rigidbody m_rig;
    private Vector3 movetopos;
    private int tep_movelvl;
    Tween mt;
    int T;
    void Awake()
    {
        m_rig = GetComponent<Rigidbody>();
        m_rig.velocity = new Vector3(0, 0, verSpeed);
        tep_movelvl = Movelevel;
        T = 0;//进场1秒后才开始动作
        //Movelevel = 100;
    }
    void Start()
    {
        StartCoroutine(Evade());
    }
    IEnumerator Evade()
    {
        yield return new WaitForSeconds(1f);
        T = 1;
        while (true)
        { 
            yield return new WaitForSeconds(1f);
             
        }
    }

    void FixedUpdate()
    {
        if (T == 0) return;
        Debug.Log(Movelevel);
        if (Movelevel == 0)//垂直逃逸
        { 
            mt.Kill();
            nowState = 0;
            m_rig.velocity = new Vector3(0, 0, moveSpeed);
        }
        else if (Movelevel == 1)//原地不动
        {
            mt.Kill();
            nowState = 0;
            m_rig.velocity = new Vector3(0, 0, 0);
            // float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
            // GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        }
        else if (Movelevel == 2)//水平移动
        {
            if (nowState == 0)
            {
                nowState = 1;
                float distance = Random.Range(tb_Boundary.xMin, tb_Boundary.xMax);
                mt = m_rig.DOMoveX(distance, Mathf.Abs(distance - transform.position.x) / Mathf.Abs(moveSpeed));
                mt.onComplete = (() => { nowState = 0; });
            } 
        }
        else if (Movelevel == 3)//小幅移动
        {
            if (nowState == 0)
            {
                nowState = 1;
                movetopos = new Vector3(Random.Range(this.transform.position.x-0.3f,this.transform.position.x+0.3f), 0, Random.Range(this.transform.position.z - 0.3f, this.transform.position.z + 0.3f));

                mt = m_rig.DOMove(movetopos, Vector3.Distance(this.transform.position, movetopos) / Mathf.Abs(moveSpeed)+2f).SetEase(Ease.InOutQuad);
                mt.onComplete = (() => { nowState = 0; });
                //m_rig.DOMoveX(Random.Range(tb_Boundary.xMin, tb_Boundary.xMax), 5f).onComplete = (() => { nowState = 0; });
            }
        }
        else if(Movelevel == 4)//移动指定地点 之后按区间范围移动
        {
            if (nowState == 0)
            {
                mt.Kill();
                nowState = 1;

                m_rig.velocity = new Vector3(0, 0, 0);
                mt = m_rig.DOMove(EndPostion, Vector3.Distance(this.transform.position, EndPostion) / Mathf.Abs(moveSpeed));
                mt.onComplete = (() => { Movelevel = 5; nowState = 0; });
            }
        }
        else if (Movelevel == 5)//区间范围移动
        {
            Debug.Log("Movelevel == 5");
            if (nowState == 0)
            {
                nowState = 1;

                m_rig.velocity = new Vector3(0, 0, 0);
                movetopos = new Vector3(Random.Range(MovePart_LeftTop.x, MovePart_RightBottom.x), 0, Random.Range(MovePart_RightBottom.y, MovePart_LeftTop.y));

                mt = m_rig.DOMove(movetopos, Vector3.Distance(this.transform.position, movetopos) / Mathf.Abs(moveSpeed)).SetEase(Ease.InOutQuad);
                mt.onComplete = (() => { nowState = 0; });
                //m_rig.DOMoveX(Random.Range(tb_Boundary.xMin, tb_Boundary.xMax), 5f).onComplete = (() => { nowState = 0; });
            }
        }
        {
#if false
            float newManeuver = Mathf.MoveTowards(GetComponent<Rigidbody>().velocity.x, targetManeuver, smoothing * Time.deltaTime);
            GetComponent<Rigidbody>().velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
            /*GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
                0.0f, 
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );*/
#endif
        }
    }
}
