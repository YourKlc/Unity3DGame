using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening; 
using UnityEngine.SceneManagement;
using MyCof;
public class Small_Switch : MonoBehaviour {
    public Button[] btn;
    public int mainlvl;
    private int Chose = 0;
    Image ChangeImage;

    public MyConfig obj_config;//Add 
    void Awake () {
        Debug.Log("Small_Switch start");
        mainlvl = 0;//第一大关 
        ChangeImage = this.gameObject.GetComponent<Image>();
        ChangeImage.enabled = false;//不显示过渡图片
        int d = btn.Length;
        ShowImage(0); 
        for (int i=1;i<d;i++)
        {
            btn[i].transform.GetChild(1).gameObject.SetActive(false); 
        }
       
        
        btn[0].onClick.AddListener(onClickbtn1);
        btn[1].onClick.AddListener(onClickbtn2);
        btn[2].onClick.AddListener(onClickbtn3);
        btn[3].onClick.AddListener(onClickbtn4);
        btn[4].onClick.AddListener(onClickbtn5);
        obj_config = GameObject.Find("GameConfig").GetComponent<MyConfig>();//Add 
    }
    private void Start()
    {
    }
    void onClickbtn1()
    {
        obj_config.int_NowMapLevel = 1+5*(mainlvl - 1);
        SceneManager.LoadSceneAsync(2);
    }
    void onClickbtn2()
    {
        obj_config.int_NowMapLevel = 2 + 5 * (mainlvl - 1);
        SceneManager.LoadSceneAsync(2);
    }
    void onClickbtn3()
    {
        obj_config.int_NowMapLevel = 3 + 5 * (mainlvl - 1);
        SceneManager.LoadSceneAsync(2);
    }
    void onClickbtn4()
    {
        obj_config.int_NowMapLevel = 4 + 5 * (mainlvl - 1);
        SceneManager.LoadSceneAsync(2);
    }
    void onClickbtn5()
    {
        obj_config.int_NowMapLevel = 5 + 5 * (mainlvl - 1);
        Debug.Log("main lvl"+mainlvl+" load level "+obj_config.int_NowMapLevel);
        SceneManager.LoadSceneAsync(2);
    }

    void ShowImage(int index)
    {
        btn[index].transform.GetChild(1).gameObject.SetActive(true);
    } 
    /// <summary>
    /// 更新主关卡
    /// </summary>
    /// <param name="index"></param>
    public void UpdateMainlvl(int index)
    {
        if(mainlvl != index)
        {
            #region 初始化选择框
            Chose = 0;
            this.transform.position = btn[0].transform.position;
            #endregion
            mainlvl = index;
            for(int i=0;i<5;i++)
            {
                btn[i].transform.Find("Text").GetComponent<Text>().text = @"关卡 "+mainlvl+@"-"+(i+1);
                Debug.Log("OK1"); 
                if(obj_config.i_GetGameMaplvl(5*(mainlvl-1)+i+1) == 0)
                {
                    btn[i].interactable = false;
                }
                else  btn[i].interactable = true;
                Debug.Log("OK2");
            }
            Debug.Log("UpdateMainlvl(), mainlvl=" + index);
        }
    }
    public void SetChose(int nextindex)
    {
        if(nextindex!=Chose)
        { /*
            btn[Chose].transform.GetChild(1).gameObject.SetActive(false);//禁用按钮自带外框图片
            ChangeImage.transform.position = btn[Chose].transform.position;//过渡图片坐标与以前位置相同
            ChangeImage.enabled = true;//显示过渡图片
            Chose = nextindex; 
            this.transform.DOMove(btn[nextindex].transform.position,1f).SetEase(Ease.OutCubic).onComplete=delegate() {
                ChangeImage.enabled = false;
                btn[Chose].transform.GetChild(1).gameObject.SetActive(true);
            };//显示结束后禁用过渡图片并显示按钮自带外框图片*/
            btn[Chose].transform.GetChild(1).gameObject.SetActive(false);
            ChangeImage.transform.position = btn[Chose].transform.position;//过渡图片坐标与以前位置相同
            ChangeImage.enabled = true;//显示过渡图片
            Chose = nextindex;
            this.transform.DOMove(btn[nextindex].transform.position, 0.8f).SetEase(Ease.OutCubic);/*.onComplete = delegate () {
                ChangeImage.enabled = false;
                btn[Chose].transform.GetChild(1).gameObject.SetActive(true);*/
           // };显示结束后禁用过渡图片并显示按钮自带外框图片*/;
            //ShowImage(nextindex);
        }
    }
}
