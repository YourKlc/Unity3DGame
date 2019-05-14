using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using MyCof;

namespace Chance
{
    class probability
    {
        static float chane;
        /// <summary>
        /// 判断在t_fprob几率下是否成功
        /// </summary>
        /// <param name="t_fprob"></param>
        /// <returns></returns>
       public static bool GetChance(float t_fprob)
        {
            if (t_fprob >= 1) return true; 
            if(t_fprob<= Random.Range(0f, 1f)) return true;
            return false;
        }
    }
}

namespace StaticClass
{
    public class staticclass
    {
       public static float GoldToPlayer = 2f;//吸金币距离
    }
    public class EnemyBoundary
    {
        public static Vector2 bd_L1 = new Vector2(tb_Boundary.xMin, tb_Boundary.zMax);//左上
        public static Vector2 bd_L2 = new Vector2(tb_Boundary.xMin, tb_Boundary.zMin+tb_Boundary.zLength/2f);//左中
        public static Vector2 bd_R1 = new Vector2(tb_Boundary.xMax, tb_Boundary.zMax);//右上
        public static Vector2 bd_R2 = new Vector2(tb_Boundary.xMax, tb_Boundary.zMin + tb_Boundary.zLength / 2f);//右中
        public static Vector2 bd_R3 = new Vector2(tb_Boundary.xMax, tb_Boundary.zMin);//右下

        public static Vector2 bd_M1 = new Vector2(tb_Boundary.xMin+tb_Boundary.xLength/2, tb_Boundary.zMax);//中上
        public static Vector2 bd_M2 = new Vector2(tb_Boundary.xMin + tb_Boundary.xLength / 2, tb_Boundary.zMin+tb_Boundary.zLength / 2f);//中中
        public static Vector2 bd_M3 = new Vector2(tb_Boundary.xMin + tb_Boundary.xLength / 2, tb_Boundary.zMin);//中下
        public static void RandomBd(out Vector2 X1, out Vector2 X2)
        {
            int a = Random.Range(0,2);
            if (a == 0)
            { X1 = bd_L1; a = Random.Range(0, 2);if (a == 0) X2 = bd_M2; else if (a == 1) X2 = bd_R2; else X2 = bd_R2; }
            else if (a == 1)
            { X1 = bd_L1; a = Random.Range(0, 1); if (a == 0) X2 = bd_M2; else if (a == 1) X2 = bd_R2; else X2 = bd_R2; }
            else 
            {
                X1 = bd_M1;
                a = Random.Range(0, 1); if (a == 0) X2 = bd_R2; else if (a == 1) X2 = bd_R2; else X2 = bd_R2;
            } 
        }
    }
}
/// <summary>
/// 游戏控制,控制金币经验道具,顶部文字显示
/// </summary>
public class GameControl : MonoBehaviour {

    public GameObject obj_UI;
    private UIControlScript script_UI; 
    string str_GameMission; 

    public MyConfig obj_config;//Add 
    public int DisSetting;
    //public GameObject Missionlvl;
    float nextinput = 0f;
    float inputblock = 1f;

    private PlayerConfig lastPlayerInf = new PlayerConfig();//Add
    /// <summary>
    /// 初始化右侧数值
    /// </summary>
    private void Start()
    {
        DisSetting = 0;
        script_UI = obj_UI.GetComponent<UIControlScript>(); 
        obj_config = GameObject.Find("GameConfig").GetComponent<MyConfig>();//Add

        str_GameMission = "关卡: "+ ((obj_config.int_NowMapLevel - 1)/5+1) + @"-" + ((obj_config.int_NowMapLevel - 1)%5+1);
        script_UI.SetNowlvl(((obj_config.int_NowMapLevel - 1) / 5 + 1) + @"-" + ((obj_config.int_NowMapLevel - 1) % 5 + 1));
        
        script_UI.UpdateGoldText(obj_config.i_GetGold());
       
        lastPlayerInf.Int_MaxLife = obj_config.i_GetMaxLife();
        lastPlayerInf.int_Lvl = obj_config.i_Getlvl();
        lastPlayerInf.Int_Exp = obj_config.i_GetExp();
        obj_config.m_player.Int_NowLife = obj_config.i_GetMaxLife();
        script_UI.SetDisExp(obj_config.i_GetExp(), (float)obj_config.i_GetExp()/(obj_config.i_Getlvl()* obj_config.i_Getlvl()* obj_config.i_Getlvl()));
        StartCoroutine(UpdateByTime(str_GameMission));
       // Missionlvl.SetActive(true);
    }
    IEnumerator UpdateByTime(string tep)
    {
        //测试顶部文字动画
        /*for(int i=0;i<100;i++)
        {
   
        int_GameMission++;
        str_GameMission = "关卡: " + int_GameMission;*/
        PostNewTopMessage(tep);
            yield return new WaitForSeconds(4); 
       // }
    }
    public void DisEnd(int a)//0失败 >=1成功
    {
        if(a == 0)
        {
            script_UI.DisEndPanel(0);
        } 
        else
        {
            script_UI.DisEndPanel(1);//显示成功面板并解锁关卡
            obj_config.SolveNowLevel(a);
        }
    }
    public void PostNewTopMessage(string str_mes)
    { 
        script_UI.UpdateTopText(str_mes);
    } 
    public void AddEXP(int a)
    {
        obj_config.AddExp(a);
        script_UI.DisAddExp(a);
    }
    private void Update()
    {
        if (Input.GetButton("Quit") && Time.unscaledTime > nextinput)
        {
            Debug.Log("Setting");
            nextinput = Time.unscaledTime + inputblock;
            if (DisSetting == 1) { Time.timeScale = 1; DisSetting = 0; }
            else { Time.timeScale = 0; DisSetting = 1; }
            script_UI.DisSettring(DisSetting);
        }
        if(lastPlayerInf.Int_Gold!=obj_config.i_GetGold())
        {
            lastPlayerInf.Int_Gold = obj_config.i_GetGold();
            script_UI.UpdateGoldText(lastPlayerInf.Int_Gold);
        }
        if(lastPlayerInf.int_Lvl!= obj_config.i_Getlvl())
        {
            lastPlayerInf.int_Lvl = obj_config.i_Getlvl();
            script_UI.LevelUp(lastPlayerInf.int_Lvl);
        }
        if (lastPlayerInf.Int_Exp != obj_config.i_GetExp())
        {
            lastPlayerInf.Int_Exp = obj_config.i_GetExp();
            script_UI.SetDisExp(lastPlayerInf.Int_Exp, (float)lastPlayerInf.Int_Exp/(obj_config.i_Getlvl()* obj_config.i_Getlvl()* obj_config.i_Getlvl()));
        }
        if (lastPlayerInf.Int_NowLife!= obj_config.i_GetNowLife())
        {
            lastPlayerInf.Int_NowLife = obj_config.i_GetNowLife(); 
            script_UI.SetLife((float)lastPlayerInf.Int_NowLife/ obj_config.i_GetMaxLife());
        }
        /*if (obj_config.i_GetGold() != pre_Config.Int_Gold)
        {
            Debug.Log("changegold " + pre_Config.Int_Gold + " to " + obj_config.i_GetGold());
            pre_Config.Int_Gold = obj_config.i_GetGold();
            script_UI.UpdateGoldText(pre_Config.Int_Gold);
        }*/
    } 
}
