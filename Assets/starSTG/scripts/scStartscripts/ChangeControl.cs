using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using MyCof;
public enum Chose
{
    FirstC = 0,
    Save,
    Setting,
    About,
    Quit,
    CNum
}
public struct Control_SizeTable
{
    public static float min_x = 174f, min_y = 113f, max_x = 1215f, max_y = 518f;

    //public static float min_Smallvl_x { get; internal set; }
}
public class ChangeControl : MonoBehaviour {
    public GameObject[] obj_All;
    public GameObject LoadScene;
    public GameObject MyCanvas;
    private Chose chs;
    private Vector2 downpos, uppos;
    public GameObject obj_config;
    int NUL_jug;
    // Use this for initialization
    void Start () {
        NUL_jug = 0;
        chs = Chose.FirstC;
        obj_All[(int)Chose.FirstC].SetActive(true);

        obj_All[(int)Chose.Setting].SetActive(false);
        DontDestroyOnLoad(obj_config);
    }

    /// <summary>
    /// 进入游戏，参数0时继续游戏，参数1时新的开始
    /// </summary>
    /// <param name="a"></param>
    public void EnterGame(int a)
    {
        Debug.Log("function call-> ChangeControl EnterGame()");
        
        LoadScene.SetActive(true);
        if (a == 0) ;
        else if(a == 1)//1时,初始化玩家数据
        {
            obj_config.GetComponent<MyConfig>().Reset();
            Debug.Log("function(EnterGame), Resetsuccess ");
        }
        StartCoroutine(Wait2s()); 
        Debug.Log("function(EnterGame):join scene after 2s");

        //MyCanvas.SetActive(false);
    }
    IEnumerator Wait2s()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(1);
    }
    public void UpdateChose(Chose tep)
    {
        if (chs != tep && NUL_jug == 0)
        {
            NUL_jug = 1;
            int temp = (int)chs;
            chs = tep;
            //此时temp为以前选择,chs为改变选择
            //temp绕 y 轴顺时针旋转90度后设置为false后设置为-90,chs绕y轴顺时针90度后rotate设置为0
            StartCoroutine(Rotate(temp, (int)chs));

            //obj_All[(int)chs] 设为true 后旋转90度 
            //allobj.transform. 
        }
    }
    IEnumerator Rotate(int indexa, int indexb)//
    {
        int timer = 90, count = 90,sub = 2;
        float second = 0.01f;
        Vector3 vecrotate = new Vector3(0, sub, 0);
        //indexa 轴顺时针旋转90度后设置为false
        while ((timer) > 0)
        {
            timer -= sub;
            obj_All[indexa].transform.Rotate(vecrotate);
            yield return new WaitForSeconds(second);
        }
        obj_All[indexa].SetActive(false);
        obj_All[indexa].transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        obj_All[indexb].SetActive(true);
        timer = count;
        while ((timer) > 0)
        {
            timer -= sub;
            obj_All[indexb].transform.Rotate(vecrotate);
            yield return new WaitForSeconds(second);
        }
        obj_All[indexb].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        NUL_jug = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            downpos = Input.mousePosition;
        } 
        else if (Input.GetMouseButtonUp(0))
        { 
            uppos = Input.mousePosition;
            // Debug.Log( "x:"+downpos.x+"y:"+downpos.y);
            if (boIsOutUseful(downpos, uppos) == true)//鼠标在界面外点击,返回主界面
            {
                UpdateChose(Chose.FirstC);
            } 
        }
        else if(Input.GetKeyUp(KeyCode.Escape))
        {
            UpdateChose(Chose.FirstC);
        }
           
    }

    bool boIsOutUseful(Vector2 t1, Vector2 t2)
    {
        if (boIsInside(t1) == false && false == boIsInside(t2))
            return true;
        return false;
    }
    bool boIsInside(Vector2 tep)
    {
        if (tep.x > Control_SizeTable.min_x && tep.x < Control_SizeTable.max_x && tep.y > Control_SizeTable.min_y && tep.y < Control_SizeTable.max_y)
            return true;
        return false;
    }
}
