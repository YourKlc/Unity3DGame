using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SelectControl : MonoBehaviour {
    private int choice = 0;
    public Transform[] pos;
    public GameObject CS;
    // Use this for initialization 
    private ChangeControl ControlScript;
    private void Start()
    {  
        ControlScript = CS.GetComponent<ChangeControl>();
        GameObject btnobj = GameObject.Find("Canvas/FirstC/选择存档");
        Button btn = (Button)btnobj.GetComponent<Button>();
        btn.onClick.AddListener(onClickStartButton);

        btnobj = GameObject.Find("Canvas/FirstC/设置选项");
        btn = (Button)btnobj.GetComponent<Button>();
        btn.onClick.AddListener(onClickSetButton);

        btnobj = GameObject.Find("Canvas/FirstC/关于游戏");
        btn = (Button)btnobj.GetComponent<Button>();
        btn.onClick.AddListener(onClickAboutButton);

        btnobj = GameObject.Find("Canvas/FirstC/退出游戏");
        btn = (Button)btnobj.GetComponent<Button>();
        btn.onClick.AddListener(onClickEndButton); 
    } 
    void onClickStartButton()
    {
        transform.DOMove(pos[0].position, 0.5f).SetEase(Ease.OutCirc).onComplete = delegate () { transform.position = pos[0].position; };
        ControlScript.UpdateChose(Chose.Save);
        Debug.Log("onClickStartButton");
        //SceneManager.LoadScene(1);
    }
    void onClickSetButton()
    {
        transform.DOMove(pos[1].position, 0.5f).SetEase(Ease.OutCirc).onComplete = delegate() { transform.position = pos[1].position; };
        ControlScript.UpdateChose(Chose.Setting);
        Debug.Log("onClickSetButton");
    } 
    void onClickAboutButton()
    {
        transform.DOMove(pos[2].position, 0.5f).SetEase(Ease.OutCirc).onComplete = delegate () { transform.position = pos[2].position; };
        ControlScript.UpdateChose(Chose.About);
        Debug.Log("onClickAboutButton");
    }
    void onClickEndButton()
    {
        transform.DOMove(pos[3].position, 0.5f).SetEase(Ease.OutCirc).onComplete = delegate () { transform.position = pos[3].position; };
        Debug.Log("onClickEndButton");
        Application.Quit();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            choice++;
            choice %= 4;
            transform.DOMove(pos[choice].position,0.5f).SetEase(Ease.OutCirc);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            choice--;
            if (choice < 0) choice = 3;
            transform.DOMove(pos[choice].position, 0.5f).SetEase(Ease.OutCirc); 
        }
        else if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Return))
        {
            if(choice==0)
            {
                onClickStartButton();
            }
            else if(choice==1)
            {
                onClickSetButton();
            }
            else if(choice == 2)
            {
                onClickAboutButton();
            }
            else if (choice == 3)
            {
                onClickEndButton();
            }
        } 
    }
}
