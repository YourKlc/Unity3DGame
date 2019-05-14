#define printlog

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCof;
using StaticClass;
/// <summary>
/// 波数、敌人刷新控制,只控制生成敌人时间以及属性值(HP,攻击力)和移动逻辑,敌人碰撞、射击等逻辑放在预制体里
/// </summary>
///
[System.Serializable]
public class Enemy_Attribute
{

    public int int_Lvl;
    public int int_Gold;
    public int Int_Attack;
    public int Int_NowLife;
    public int Int_MaxLife;
    public int Int_Def;
}
public class Enemy_Object
{
    public GameObject m_obj;
    public prefabAttribute m_Attribute; 
    public int Alive = 1;
    public Enemy_Object()
    {
        //m_obj = new GameObject(); 
    }
}
public struct NumDis
{
    public int prefabindex;
    public int EnemyAmount;
}

public class Wave : MonoBehaviour
{
    public GameObject[] Enemy_Prefab;//默认预制体
    //public Enemy_Attribute[] EnemyTable;//默认预制体属性
    private int weave_StartFlag;
    private Enemy_Object[] obj_Enemy;
    private NumDis[] Enemy_Dis;//敌人的预制体以及对应数量

    public MyConfig obj_config;//Add
    public GameControl m_control;
    // Use this for initialization
    void Start()
    {

        obj_config = GameObject.Find("GameConfig").GetComponent<MyConfig>();//Add
        weave_StartFlag = 1;
        switch (obj_config.int_NowMapLevel)
        {
            case 1: Wave1(); break;
            case 2: Wave2(); break;
            case 3: Wave3(); break;
            case 4: Wave4(); break;
            case 5: Debug.Log("wav5"); Wave5(); break;
            case 6: Wave6(); break;
            case 7: Wave7(); break;
            case 8: Wave8(); break;
            case 9: Wave9(); break;
            case 10: Debug.Log("wav10"); Wave10(); break;
            case 11: Wave11(); break;
            case 12: Wave12(); break;
            case 13: Wave13(); break;
            case 14: Wave14(); break;
            case 15: Wave15(); break;
            default: break;
        }

    }

    void Wave1()
    {
        log("Wave1");
        StartCoroutine(Diswave1());
        StartCoroutine(NextWave());
    }
    void log(string s)
    {
        Debug.Log(s);
    }
    IEnumerator Diswave1()
    {

        yield return new WaitForSeconds(4);
        obj_Enemy = new Enemy_Object[1];
        for (int i = 0; i < 1; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 1;//1个陨石

        InitialEnemy(Enemy_Dis);//生成对应敌军,即5个0号预制体 
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        m_control.DisEnd(obj_config.int_NowMapLevel);//0失败 >1成功 表示通过的关卡等级
    }
    void InitialEnemy(NumDis[] t_Enemydis)//第index的prefab有number个
    {
        int d = t_Enemydis.Length, allnum = 0;//prefab种类数量,按每个种类的对应敌人数量生成敌人

        for (int i = 0; i < d; i++)
        {
            int p = t_Enemydis[i].EnemyAmount;
            for (int j = 0; j < p; j++)//p个物体
            {
                obj_Enemy[allnum].m_obj =
                Instantiate(Enemy_Prefab[t_Enemydis[i].prefabindex],
                new Vector3(Random.Range(tb_Boundary.xMin, tb_Boundary.xMax), 0, tb_Boundary.zMax),
                Quaternion.Euler(new Vector3(0, 0, 0))
                ) as GameObject;//生成本关卡预制体 
                obj_Enemy[allnum].m_Attribute = obj_Enemy[allnum].m_obj.GetComponent<prefabAttribute>();//得到该预制体的prefabAttribute脚本指针
                obj_Enemy[allnum].Alive = 1;
                allnum++;
            }

        }
    }
    void Wave2()
    {
        log("Wave2");
        StartCoroutine(Diswave2());
        StartCoroutine(NextWave());
    }
    void Wave3()
    {
        StartCoroutine(Diswave3());
        StartCoroutine(NextWave());
    }
    void Wave4()
    {
        StartCoroutine(Diswave4());
        StartCoroutine(NextWave());
    }
    void Wave5()
    {
        StartCoroutine(Diswave5());
        StartCoroutine(NextWave());
    }
    void Wave6()
    {
        log("Wave6");
        StartCoroutine(Diswave1());
        StartCoroutine(NextWave());
    }
    void Wave7()
    {
        StartCoroutine(Diswave2());
        StartCoroutine(NextWave());
    }
    void Wave8()
    {
        StartCoroutine(Diswave3());
        StartCoroutine(NextWave());
    }
    void Wave9()
    {
        StartCoroutine(Diswave4());
        StartCoroutine(NextWave());
    }
    void Wave10()
    {
        StartCoroutine(Diswave5());
        StartCoroutine(NextWave());
    }
    void Wave11()
    {
        StartCoroutine(Diswave11());
        StartCoroutine(NextWave());
    }
    void Wave12()
    {
        StartCoroutine(Diswave11());
        StartCoroutine(NextWave());
    }
    void Wave13()
    {
        StartCoroutine(Diswave11());
        StartCoroutine(NextWave());
    }
    void Wave14()
    {
        StartCoroutine(Diswave11());
        StartCoroutine(NextWave());
    }
    void Wave15()
    {
        StartCoroutine(Diswave15());
        StartCoroutine(NextWave());
    }


    IEnumerator Diswave2()//第二关
    {
        yield return new WaitForSeconds(4);
        obj_Enemy = new Enemy_Object[5];
        for (int i = 0; i < 5; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 5;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即5个0号预制体
        for (int i = 0; i < 5; i++)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMin+i*(tb_Boundary.xLength/4),0,tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 1 + 0.3f * i;//第一波 把敌人速依次增加
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        obj_Enemy = new Enemy_Object[6];
        for (int i = 0; i < 6; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 6;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即6个0号预制体 
        for (int i = 5; i >= 0; i--)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMax - i * (tb_Boundary.xLength / 5), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 1 + 0.3f * i;//第一波 把敌人速依次增加
        }
        #region 等待进入下个波次
            weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        //显示通关面板
        m_control.DisEnd(obj_config.int_NowMapLevel);//0失败 >1成功 表示通过的关卡等级
    }
    IEnumerator Diswave3()//第三关
    {
        yield return new WaitForSeconds(4);
        obj_Enemy = new Enemy_Object[8];
        for (int i = 0; i < 8; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 8;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即8个0号预制体
        for (int i = 0; i < 8; i++)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMin + i * (tb_Boundary.xLength / 7), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 1 + 0.3f * i;//第一波 把敌人速依次增加
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        obj_Enemy = new Enemy_Object[10];
        for (int i = 0; i < 10; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 10;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即10个0号预制体 
        for (int i = 9; i >= 0; i--)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMax - i * (tb_Boundary.xLength / 9), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 1 + 0.3f * i;//第二波 把敌人速依次增加
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        obj_Enemy = new Enemy_Object[12];
        for (int i = 0; i < 12; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 12;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即12个0号预制体 
        for (int i = 11; i >= 0; i--)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMax - i * (tb_Boundary.xLength / 11), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 3f;//第三波 12个加速陨石
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        //显示通关面板
        m_control.DisEnd(obj_config.int_NowMapLevel);//0失败 >1成功 表示通过的关卡等级
    }
    IEnumerator Diswave4()//第四关
    {
        yield return new WaitForSeconds(4);
        
        obj_Enemy = new Enemy_Object[10];
        for (int i = 0; i < 10; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 10;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即10个0号预制体 
        for (int i = 9; i >= 0; i--)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMax - i * (tb_Boundary.xLength / 9), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 1 + 0.3f * i;//第二波 把敌人速依次增加
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        obj_Enemy = new Enemy_Object[12];
        for (int i = 0; i < 12; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 11; 
        InitialEnemy(Enemy_Dis);//生成对应敌军,即11个0号预制体 1个1号预制体 
        for (int i = 9; i >= 0; i--)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMax - i * (tb_Boundary.xLength / 9), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 3f;//第二波 11个加速陨石
        } 
        GameObject gm = Enemy_Prefab[1];
        EnemyMoveControl em = gm.GetComponent<EnemyMoveControl>(); 
        em.MovePart_LeftTop = EnemyBoundary.bd_L1;
        em.MovePart_RightBottom = EnemyBoundary.bd_R2;
        em.Movelevel = 0;
        em.moveSpeed = -8f;
        obj_Enemy[11].m_obj = Instantiate(gm, new Vector3(tb_Boundary.xMin+tb_Boundary.xLength/2, 0, tb_Boundary.zMax),
                Quaternion.Euler(new Vector3(0, 0, 0)));
        obj_Enemy[11].Alive = 1;

        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        //显示通关面板
        m_control.DisEnd(obj_config.int_NowMapLevel);//0失败 >1成功 表示通过的关卡等级
    }
    IEnumerator Diswave5()//第五关
    {
        yield return new WaitForSeconds(4);

        obj_Enemy = new Enemy_Object[10];
        for (int i = 0; i < 10; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 10;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即10个0号预制体 
        for (int i = 9; i >= 0; i--)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMax - i * (tb_Boundary.xLength / 9), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 1 + 0.3f * i;//第二波 把敌人速依次增加
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        obj_Enemy = new Enemy_Object[12];
        for (int i = 0; i < 12; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 10;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即11个0号预制体 1个1号预制体 
        for (int i = 9; i >= 0; i--)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMax - i * (tb_Boundary.xLength / 9), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 3f;//第二波 11个加速陨石
        }
        for (int i = 10; i <= 11; i++)
        {
            GameObject gm = Enemy_Prefab[1];
            EnemyMoveControl em = gm.GetComponent<EnemyMoveControl>();
            em.MovePart_LeftTop = EnemyBoundary.bd_L1;
            em.MovePart_RightBottom = EnemyBoundary.bd_R2;
            em.Movelevel = 5;
            em.moveSpeed = -4f;
            obj_Enemy[i].m_obj = Instantiate(gm, new Vector3(Random.Range(tb_Boundary.xMin, tb_Boundary.xMax), 0, tb_Boundary.zMax),
                    Quaternion.Euler(new Vector3(0, 0, 0)));
            obj_Enemy[i].Alive = 1;
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        //显示通关面板
        m_control.DisEnd(obj_config.int_NowMapLevel);//0失败 >1成功 表示通过的关卡等级
    }
    IEnumerator Diswave11()//第11关
    {
        yield return new WaitForSeconds(4);

        obj_Enemy = new Enemy_Object[3];
        for (int i = 0; i < 3; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 1;
        Enemy_Dis[0].EnemyAmount = 3;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即3个1号预制体 
        for (int i = 0; i <3; i++)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMin + i * (tb_Boundary.xLength / 2), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<EnemyMoveControl>().moveSpeed = -1f;//第1
            obj_Enemy[i].m_obj.GetComponent<EnemyMoveControl>().Movelevel = 3;
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        obj_Enemy = new Enemy_Object[12];
        for (int i = 0; i < 12; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 10;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即11个0号预制体 1个1号预制体 
        for (int i = 9; i >= 0; i--)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMax - i * (tb_Boundary.xLength / 9), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 3f;//第二波 11个加速陨石
        }
        for (int i = 10; i <= 11; i++)
        {
            GameObject gm = Enemy_Prefab[1];
            EnemyMoveControl em = gm.GetComponent<EnemyMoveControl>();
            em.MovePart_LeftTop = EnemyBoundary.bd_L1;
            em.MovePart_RightBottom = EnemyBoundary.bd_R2;
            em.Movelevel = 5;
            em.moveSpeed = -3f;
            obj_Enemy[i].m_obj = Instantiate(gm, new Vector3(Random.Range(tb_Boundary.xMin, tb_Boundary.xMax), 0, tb_Boundary.zMax),
                    Quaternion.Euler(new Vector3(0, 0, 0)));
            obj_Enemy[i].Alive = 1;
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        obj_Enemy = new Enemy_Object[12];
        for (int i = 0; i < 12; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 10;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即11个0号预制体 1个1号预制体 
        for (int i = 9; i >= 0; i--)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMax - i * (tb_Boundary.xLength / 9), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 3f;//第二波 11个加速陨石
        }
        for (int i = 10; i <= 11; i++)
        {
            GameObject gm = Enemy_Prefab[1];
            EnemyMoveControl em = gm.GetComponent<EnemyMoveControl>();
            em.MovePart_LeftTop = EnemyBoundary.bd_L1;
            em.MovePart_RightBottom = EnemyBoundary.bd_R2;
            em.Movelevel = 5;
            em.moveSpeed = -3f;
            obj_Enemy[i].m_obj = Instantiate(gm, new Vector3(Random.Range(tb_Boundary.xMin, tb_Boundary.xMax), 0, tb_Boundary.zMax),
                    Quaternion.Euler(new Vector3(0, 0, 0)));
            obj_Enemy[i].Alive = 1;
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        obj_Enemy = new Enemy_Object[12];
        for (int i = 0; i < 12; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 10;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即11个0号预制体 1个1号预制体 
        for (int i = 9; i >= 0; i--)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMax - i * (tb_Boundary.xLength / 9), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 3f;//第二波 11个加速陨石
        }
        for (int i = 10; i <= 11; i++)
        {
            GameObject gm = Enemy_Prefab[1];
            EnemyMoveControl em = gm.GetComponent<EnemyMoveControl>();
            em.MovePart_LeftTop = EnemyBoundary.bd_L1;
            em.MovePart_RightBottom = EnemyBoundary.bd_R2;
            em.Movelevel = 5;
            em.moveSpeed = -3f;
            obj_Enemy[i].m_obj = Instantiate(gm, new Vector3(Random.Range(tb_Boundary.xMin, tb_Boundary.xMax), 0, tb_Boundary.zMax),
                    Quaternion.Euler(new Vector3(0, 0, 0)));
            obj_Enemy[i].Alive = 1;
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        obj_Enemy = new Enemy_Object[13];
        for (int i = 0; i < 13; i++)
        {
            obj_Enemy[i] = new Enemy_Object();
        }
        Enemy_Dis = new NumDis[1];
        Enemy_Dis[0].prefabindex = 0;
        Enemy_Dis[0].EnemyAmount = 10;
        InitialEnemy(Enemy_Dis);//生成对应敌军,即11个0号预制体 1个1号预制体 
        for (int i = 9; i >= 0; i--)
        {
            obj_Enemy[i].m_obj.transform.position = new Vector3(tb_Boundary.xMax - i * (tb_Boundary.xLength / 9), 0, tb_Boundary.zMax);
            obj_Enemy[i].m_obj.GetComponent<Done_Mover>().speed *= 3f;//第二波 11个加速陨石
        }
        for (int i = 10; i <= 12; i++)
        {
            GameObject gm = Enemy_Prefab[1];
            EnemyMoveControl em = gm.GetComponent<EnemyMoveControl>();
            em.MovePart_LeftTop = EnemyBoundary.bd_L1;
            em.MovePart_RightBottom = EnemyBoundary.bd_R2;
            em.Movelevel = 5;
            em.moveSpeed = -2f;
            obj_Enemy[i].m_obj = Instantiate(gm, new Vector3(Random.Range(tb_Boundary.xMin, tb_Boundary.xMax), 0, tb_Boundary.zMax),
                    Quaternion.Euler(new Vector3(0, 0, 0)));
            obj_Enemy[i].Alive = 1;
        }
        #region 等待进入下个波次
        weave_StartFlag = 0;
        log("waitnext");
        yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
        log("startnext");
        #endregion
        //显示通关面板
        m_control.DisEnd(obj_config.int_NowMapLevel);//0失败 >1成功 表示通过的关卡等级
    }
    IEnumerator Diswave15()
    {
        int int_wave = 1;
        yield return new WaitForSeconds(4);

        while (true)
        {
            Debug.Log("start 15 wave");
            m_control.PostNewTopMessage("第 " + int_wave + " 波");
            int_wave++;
            int t_num = Random.Range(5, 10);
            obj_Enemy = new Enemy_Object[t_num];
            for (int i = 0; i < t_num; i++)
            {
                obj_Enemy[i] = new Enemy_Object();
            } 
            for (int i = 0; i < t_num; i++)
            {
                GameObject gm = Enemy_Prefab[Random.Range(1,Enemy_Prefab.Length)];
                EnemyMoveControl em = gm.GetComponent<EnemyMoveControl>();
                EnemyBoundary.RandomBd(out em.MovePart_LeftTop, out em.MovePart_RightBottom);
                if (i % 2 == 0) em.Movelevel = 0;
                    else em.Movelevel = 5;
                em.moveSpeed = Random.Range(-0.5f,-1f);
                if (i % 3 == 0)
                {
                    gm.GetComponent<Done_WeaponController>().CircleNum = Random.Range(5, 10);
                    gm.GetComponent<Done_WeaponController>().HowtoCreate = 8;
                }
                gm.GetComponent<prefabAttribute>().Setlife(80+20* int_wave); 
                gm.GetComponent<prefabAttribute>().SetAttack(10+5* int_wave);
                em.moveSpeed = Random.Range(-4f,-2f);
                obj_Enemy[i].m_obj = Instantiate(gm, new Vector3(Random.Range(tb_Boundary.xMin, tb_Boundary.xMax), 0, tb_Boundary.zMax),
                        Quaternion.Euler(new Vector3(0, 0, 0)));
                
                obj_Enemy[i].Alive = 1;
            }
            #region 等待进入下个波次
            weave_StartFlag = 0;
            log("waitnextwave");
            yield return new WaitUntil(() => weave_StartFlag == 1); //判断波次是否结束
            log("startnextwave");
            #endregion
            

        }
    }











    int bNextWave()//是否进行下一波 0 t,1 f
    {
        int d = obj_Enemy.Length;
#if (printlog)
        log("obj_Enemy.Length = " + d);
#endif
        for (int i = 0; i < d; i++)
            if ( obj_Enemy[i].m_obj == true) return 0;
            else { if (obj_Enemy[i].Alive == 1) { obj_Enemy[i].Alive = 0; } }//obj_config.AddGold(obj_Enemy[i].m_Attribute.m_Attribute.int_Gold); } }
        return 1;
    }
    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(6);
        while (true)
        {
            while (weave_StartFlag == 0)//不可进入时判断进入标志
            {
                weave_StartFlag = bNextWave();
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
