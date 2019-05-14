using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
 
public class uimov : MonoBehaviour {
    public Image img_select;
    public RectTransform[] rectpos;
    private int pos = 0,End;
    public Text Tex_ShowState;
    public GameObject Eventobj; 
    //private Tweener tw;
    void Start()
    {
        // Button_Main1.DOLocalMove(new Vector3(0,0,0),3f).SetAutoKill(false).Pause();
        // DOTween.RestartAll(); 
        End = 1; 
    }   
    public void Update()
    {
        //int index = pos;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {

            switch (pos)
            {
                case 0: OnclickedButton1(); break;
                case 1: OnclickedButton2(); break;
                case 2: OnclickedButton3(); break;
                default: break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pos--;
            if (pos < 0) pos = rectpos.Length - 1;
            img_select.rectTransform.DOMove(rectpos[pos].position, 1f);
            // doButton();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pos = (pos + 1) % rectpos.Length;
            img_select.rectTransform.DOMove(rectpos[pos].position, 1f);
        }
    }
    public void OnclickedButton1()
    { 
        if (End == 1)
        {
            End = 0;
            Tex_ShowState.text = "";
            Tex_ShowState.DOText("you have clicked button 1", 1f).SetEase(Ease.InOutCirc).onComplete = delegate ()
            { End = 1; };
            img_select.rectTransform.DOMove(rectpos[0].position, 1f);
            Eventobj.SendMessage("Select1");
        }
    
    }
    public void OnclickedButton2()
    {
        if (End == 1)
        {
            End = 0;
            Tex_ShowState.text = "";
            Tex_ShowState.DOText("you have clicked button 2", 1f).SetEase(Ease.InOutCirc).onComplete = delegate ()
            { End = 1; };
            img_select.rectTransform.DOMove(rectpos[1].position, 1f);
            Eventobj.SendMessage("Select2");
        }
        
    }
    public void OnclickedButton3()
    {
        if (End == 1)
        {
            End = 0;
            Tex_ShowState.text = "";
         Tex_ShowState.DOText("you have clicked button 3", 1f).SetEase(Ease.InOutCirc).onComplete = delegate ()
         { End = 1; };
            img_select.rectTransform.DOMove(rectpos[2].position, 1f);
            Eventobj.SendMessage("Select3");
        }

    }
}