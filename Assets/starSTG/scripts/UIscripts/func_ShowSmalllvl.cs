using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyCof;
using DG.Tweening; 
using UnityEngine.SceneManagement;
public class SizeTable
{
    public static float min_Smalllvl_x = 153f, min_Smalllvl_y = 82f, max_Smalllvl_x = 1230f, max_Smalllvl_y = 674f;

    //public static float min_Smallvl_x { get; internal set; }
}
public class func_ShowSmalllvl : MonoBehaviour {

    // Use this for initialization
    public Canvas can_big, can_small;
    public Image img_block;
    int T;//0 means main canvas,1means small canvas has opend
    //private bool b_IsFirstClick = true;
    private Vector2 downpos,uppos; 
    //目标点
    public Text tex;
    public MyConfig obj_config;
    public GameObject toSmall_Switch;//小关卡显示物体 指针
    public GameObject Small_canvas;
    public Button[] btn_right;//0 1装备栏 2退出游戏
    public GameObject obj_Equip;
    public GameObject obj_RightPanel;
    int Rightbtn = 1;
    private void LoadConfig()
    {
        obj_config = GameObject.Find("GameConfig").GetComponent<MyConfig>();

    }
    void Start () {
        T = 0;
        LoadConfig();//读取资源
        can_big.gameObject.SetActive(true);
        can_small.gameObject.SetActive(false);
        img_block.gameObject.SetActive(false);
        btn_right[0].onClick.AddListener(onClickRight);
        btn_right[1].onClick.AddListener(onClickEquip);
        btn_right[2].onClick.AddListener(onClickQuit);
        btn_right[3].onClick.AddListener(onClickBack);
    }
    void onClickRight()
    { 
        if(Rightbtn == 1)
        {
            Rightbtn = 0;
            obj_RightPanel.transform.DOScaleX(0, 0);
            obj_RightPanel.SetActive(true);
            obj_RightPanel.transform.DOScaleX(1, 1).SetEase(Ease.OutCirc);
        }
        else
        {
            obj_RightPanel.transform.DOScaleX(0, 1).SetEase(Ease.OutCirc).onComplete
                =(()=> {  obj_RightPanel.SetActive(false); Rightbtn = 1;});
        }
    }
    void onClickEquip()
    { 
        obj_Equip.SetActive(true); 
    }
    void onClickQuit()
    { 
        Application.Quit();
    }
    void onClickBack()
    { 
        SceneManager.LoadScene(0);
    }



    void Select1()//select main lvl 1
    { 
        Intosmall();
        UpdateSmall(1);//更新small界面的按钮 
        T = 1; 
    }
    void Select2()//select main lvl 2
    {
        Intosmall();
        UpdateSmall(2); 
        T = 1;
    }
    void Select3()//select main lvl 3
    {
        Intosmall();
        UpdateSmall(3);
        T = 1;
    }

    void Update()
    {
        if(1 == T)
        {
            
           // uppos行列英文
            if(Input.GetMouseButtonDown(0))
            {
                //Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//屏幕坐标转换世界坐标
                //Vector2 uiPos = can_small.transform.InverseTransformPoint(worldPos);//世界坐标转换位本地坐标
                downpos = Input.mousePosition;
                //Debug.Log("mouse down "+ Input.mousePosition);
                
            }
            else if(Input.GetMouseButtonUp(0))
            {
               // Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//屏幕坐标转换世界坐标
             //   Vector2 uiPos = can_small.transform.InverseTransformPoint(worldPos);//世界坐标转换位本地坐标
                uppos = Input.mousePosition;

                //Debug.Log("mouse up "+ Input.mousePosition); 
                if (boIsOutUseful(downpos,uppos) == true)
                { 
                    QuitSmall();
                    T = 0;
                } 

            }
           
        }
    }
    /// <summary>
    /// 切换到小关卡选择界面
    /// </summary>
    void Intosmall()
    {
        Debug.Log("intosmall");
        img_block.gameObject.SetActive(true);
        Small_canvas.transform.localScale = new Vector3(1, 0, 1);
        Small_canvas.transform.DOScaleY(1f,0.5f).SetEase(Ease.InOutCirc);
        can_small.gameObject.SetActive(true);
        
    }
    /// <summary>
    /// 退出小关卡选择界面
    /// </summary>
    void QuitSmall()
    {
        Debug.Log("quitsmall");
        //退出小关卡时，先执行动画
        Small_canvas.transform.DOScaleY(0, 0.5f).SetEase(Ease.InOutCirc).onComplete =
            (()=> {can_small.gameObject.SetActive(false);
                img_block.gameObject.SetActive(false); });
        
    }

    void UpdateSmall(int t_index)
    {
        Debug.Log("Switch");
        /*while(toSmall_Switch.GetComponent<Small_Switch>().obj_config == false)
        {

        }*/
        toSmall_Switch.GetComponent<Small_Switch>().UpdateMainlvl(t_index);
    }
    bool boIsOutUseful(Vector2 t1, Vector2 t2)
    {
        if(boIsInside(t1) == false && false == boIsInside(t2))
            return true;
        return false;
    }
    bool boIsInside(Vector2 tep)
    {
        if (tep.x > SizeTable.min_Smalllvl_x && tep.x < SizeTable.max_Smalllvl_x && tep.y > SizeTable.min_Smalllvl_y && tep.y < SizeTable.max_Smalllvl_y)
            return true;
        return false;
    }
    //test
    void onClickButton()
    {
        
    }
}
