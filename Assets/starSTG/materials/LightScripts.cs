using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

//[ExecuteInEditMode]  //普通的类，加上ExecuteInEditMode， 就可以在编辑器模式中运行

public class LightScripts : MonoBehaviour
{

    public float detail = 1;//增加后，线条数量会减少，每个线条会更长。  

    public float displacement = 15;//位移量，也就是线条数值方向偏移的最大值  

    public Transform EndPostion;//链接目标  

    public Transform StartPosition;

    public float yOffset = 0;

    private LineRenderer _lineRender;
    public Transform l, r;
    private Vector3 posl, posr;
    private List<Vector3> _linePosList;
    float t = 0;
    int stop = 0;
    private void Awake()
    {
        _lineRender = GetComponent<LineRenderer>();
        _linePosList = new List<Vector3>();
        posl = l.localPosition;
        posr = r.localPosition; 
    } 
    private void Update()
    {
        //判断是否暂停，未暂停则进入分支
        if (Time.timeScale != 0)
        {

            if (Time.time > t) //&& stop == 0)
            {
                stop = 1;
                t = Time.time + 0.2f;
                _linePosList.Clear();
                Vector3 startPos = Vector3.zero;
                Vector3 endPos = Vector3.zero;
                if (EndPostion != null)
                {
                    endPos = EndPostion.position + Vector3.up * yOffset;
                }
                if (StartPosition != null)
                {
                    startPos = StartPosition.position + Vector3.up * yOffset;
                }
                //获得开始点与结束点之间的随机生成点
                CollectLinPos(startPos, endPos, displacement);

                _linePosList.Add(endPos);

                //把点集合赋给LineRenderer
 _lineRender.enabled = true;
                _lineRender.positionCount = (_linePosList.Count);
                for (int i = 0, n = _linePosList.Count; i < n; i++)
                {
                    _lineRender.SetPosition(i, _linePosList[i]);
                }
               
                StartCoroutine(waittodel());
            }
        }
    } 
    IEnumerator waittodel()
    {   
            yield return new WaitForSeconds(0.5f);
            _lineRender.enabled = false;
            yield return new WaitForSeconds(0.05f); 
        _lineRender.enabled = true; 
        _lineRender.enabled = false;
        Vector3 v;
        v.x = posl.x + Random.Range(-10, 10); 
        v.y = posl.y + Random.Range(-10, 10);
        v.z = 0;
        l.localPosition = v;
        v.x = posr.x + Random.Range(-10, 10);
        v.y = posr.y + Random.Range(-10, 10);
        v.z = 0;
        r.localPosition = v;

    } 
    //收集顶点，中点分形法插值抖动  

    private void CollectLinPos(Vector3 startPos, Vector3 destPos, float displace)
    {
        //递归结束的条件
        if (displace < detail)
        {
            _linePosList.Add(startPos);
        }
        else
        {
            float midX = (startPos.x + destPos.x) / 2;

            float midY = (startPos.y + destPos.y) / 2;

            float midZ = (startPos.z + destPos.z) / 2;

            midX += (float)(UnityEngine.Random.value - 0.5) * displace;

            midY += (float)(UnityEngine.Random.value - 0.5) * displace;

            midZ += (float)(UnityEngine.Random.value - 0.5) * displace;

            Vector3 midPos = new Vector3(midX, midY, midZ);
            //递归获得点
            CollectLinPos(startPos, midPos, displace / 2);
            CollectLinPos(midPos, destPos, displace / 2);
        }
    }
}