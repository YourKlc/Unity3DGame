using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 
using UnityEngine.SceneManagement;
using MyCof;
public enum btn_set
{
    btn_quit = 0,
    btn_back,
    btn_Yes,
    btn_Not,
    btn_allnum
}
public class UIControlScript : MonoBehaviour
{

    public Text NowLevel;//当前关卡
    public Text tex_Life;//生命text
    public Slider slider_Life;//生命slider
    public Text text_NowStoring;//蓄力值text
    public Slider slider_NowStoring;//蓄力值slider
    public Text text_Gold;
    public Text specialNum;
    public Text tex_TopDis;//顶部显示文字 
    public GameObject obj_End;//死亡面板
    public GameObject obj_Success;//成功面板
    public GameObject obj_Setting;//设置面板 
    public GameObject obj_Confirm;
    public Button[] btn_setting;
    public Button btn_End_back;
    public Button btn_Success_back;
    public GameObject gamecontrol;
    public Text text_Exp;
    public Slider slider_Exp;
    public MyConfig obj_config;//Add
    // btn_set e_btn_set;
    string str_tep; 
    private void Start()
    {
        obj_config = GameObject.Find("GameConfig").GetComponent<MyConfig>();//Add
        SetLife(1);
        SetStoring(0); 
        btn_setting[(int)btn_set.btn_quit].onClick.AddListener(onClickQuitButton);
        btn_setting[(int)btn_set.btn_back].onClick.AddListener(onClickBackButton); 
        btn_setting[(int)btn_set.btn_Yes].onClick.AddListener(onClickYesButton);
        btn_setting[(int)btn_set.btn_Not].onClick.AddListener(onClickNotButton);
        btn_End_back.onClick.AddListener(onClickYesButton);
        btn_Success_back.onClick.AddListener(onClickYesButton);
    }
   /* private void Update()
    {
        if (pre_Gold != obj_config.i_GetGold())
        {
            pre_Gold = obj_config.i_GetGold();
            UpdateGoldText(pre_Gold);
        }
    }*/
    public void SetLife(float life_ratio)
    {
        if (life_ratio > 1) life_ratio = 1;
        slider_Life.DOValue(life_ratio, 0.2f).SetEase(Ease.OutQuad); 
        life_ratio *= 100;
        tex_Life.DOText(((int)life_ratio).ToString() + "%", 0.2f).SetEase(Ease.OutQuad);
    }
    void SetStoring(float Storing_ratio)
    {
        if (Storing_ratio > 1) Storing_ratio = 1;
        slider_NowStoring.DOValue(Storing_ratio, 0.2f).SetEase(Ease.OutQuad);
        Storing_ratio *= 100;
        text_NowStoring.DOText(((int)Storing_ratio).ToString() + "%", 0.2f).SetEase(Ease.OutQuad);
    } 
    void SetSpecial(int tep)
    {
        if (tep >= 0)
        {
            specialNum.DOText(tep.ToString(), 1f).SetEase(Ease.OutQuad);
        }
    }
    public void UpdateGoldText(int t_gold)
    {
        text_Gold.DOText(t_gold.ToString(), 0.3f).SetEase(Ease.InOutCirc);
    }
    public void SetNowlvl(string t_s)//更新当前关卡
    {
        NowLevel.DOText("当前关卡 "+t_s, 1f).SetEase(Ease.OutQuad);
    }
    public void UpdateSpecialFire(int special_num)//更新特殊次数
    {
        SetSpecial(special_num);
    }
    public void UpdateStoringFire(float ratio)//根据比率更新蓄力值
    {
        SetStoring(ratio);
    }
    public void DisAddExp(int b)
    {
        //
    }
    public void SetDisExp(int a,float b)//EXP数值，比例
    {
        text_Exp.text = a.ToString();
        slider_Exp.DOValue(b,0.2f);
    }
    public void LevelUp(int t_lvl)//显示升级信息
    {
        UpdateTopText("等级提升至:"+ t_lvl + "级");
    }
    public void UpdateTopText(string str_tep)//显示顶部文字
    {
        tex_TopDis.text = "";
        tex_TopDis.gameObject.SetActive(true);
        tex_TopDis.DOText(str_tep, 0.5f).SetEase(Ease.Linear);//0.5s 显示文字 
        StartCoroutine(destroyTexByTime());
    }
    IEnumerator destroyTexByTime()
    {
        yield return new WaitForSeconds(2);
        tex_TopDis.DOFade(0, 1f).SetEase(Ease.Linear).onComplete = delegate () { tex_TopDis.gameObject.SetActive(false); tex_TopDis.DOFade(1, 0); };//3秒后结束

    }
    public void DisSettring(int t_chose)
    {
        if (obj_Setting.activeInHierarchy == true && t_chose == 0)//关闭控制面板
        {
            Debug.Log("DisSettring false");
            obj_Setting.transform.localScale = new Vector3(1, 1, 1);
            obj_Setting.transform.DOScaleY(0f, 1f).SetEase(Ease.OutQuad).SetUpdate(true).onComplete = (()=> {obj_Setting.SetActive(false); });
        }

        if (obj_Setting.activeInHierarchy == false && t_chose == 1)//打开控制面板
        {
            Debug.Log("DisSettring true");
            obj_Setting.transform.localScale = new Vector3(1, 0, 1); obj_Setting.SetActive(true);
            obj_Setting.transform.DOScaleY(1f, 1f).SetEase(Ease.OutQuad).SetUpdate(true); 
        }
    }
    public void DisEndPanel(int a)
    {
        Debug.Log("DisEndPanel " + a);
        if(a == 0)//失败
        {
            Debug.Log("失败");
            obj_End.transform.DOScale(new Vector3(1, 1, 1), 0f); 
            obj_End.transform.DOMoveY(obj_End.transform.position.y + 10, 0f);
            obj_End.SetActive(true);
            obj_End.transform.DOMoveY(obj_End.transform.position.y - 10, 1f);


        }
        else if(a == 1)
        {
            Debug.Log("成功");
            obj_Success.transform.DOScale(new Vector3(1, 1, 1), 0f);
            obj_Success.transform.DOMoveY(obj_End.transform.position.y + 20, 0f);
            obj_Success.SetActive(true);
            obj_Success.transform.DOMoveY(obj_End.transform.position.y - 25, 1f).onComplete=
                (()=> { obj_Success.transform.DOMoveY(obj_End.transform.position.y + 5, 0.5f); });
        }
    }
    void onClickQuitButton()//返回主界面,弹出确认框
    {
        obj_Confirm.transform.localScale = new Vector3(1, 0, 1);
        obj_Confirm.SetActive(true);
        obj_Confirm.transform.DOScaleY(1f, 1f).SetEase(Ease.OutQuad).SetUpdate(true); 
    }
    void onClickBackButton()//回到游戏
    {
        Time.timeScale = 1f;
        gamecontrol.GetComponent<GameControl>().DisSetting = 0;
        DisSettring(0);
    }
    void onClickYesButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    void onClickNotButton()
    {
        obj_Confirm.transform.DOScaleY(0f, 1f).SetEase(Ease.OutQuad).SetUpdate(true).onComplete = (() => { obj_Confirm.SetActive(false); });
    }
}
