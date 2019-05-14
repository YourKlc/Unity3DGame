using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MyCof;
public class Canvas_Setting : MonoBehaviour {
    public GameObject Slider;
    public GameObject obj_canvas;
    public Button btn_back;

    public Scrollbar Scro_Quality;
    public Text tex_Quality;
    private float fScro_value;
    private Slider Slider_tep;
    private float fSlider_value;
    private AudioSource Audio_tep;
    
    public GameObject CS;
    private ChangeControl ControlScript;
    public MyConfig m_config;
    public Toggle tg;
    public Toggle tg_window;
    // Use this for initialization
    void Awake () {
        ControlScript = CS.GetComponent<ChangeControl>();
        Slider_tep = Slider.GetComponent<Slider>();
        Audio_tep = obj_canvas.GetComponent<AudioSource>();

        btn_back.onClick.AddListener(onClickBackButton);
        tg.isOn = m_config.GetFrame();

        tg_window.isOn = m_config.GetWindowed();
        if (tg_window.isOn) Screen.SetResolution(1366, 768, true);
        else Screen.SetResolution(1366, 768, false);
        fSlider_value = m_config.f_GetBGMval();/*BGM音量0~1*/
        Slider_tep.value = fSlider_value;
        Audio_tep.volume = fSlider_value;
        int d = (int)m_config.Quality_GetQuality();/* 画质 */
        QualitySettings.SetQualityLevel(d);
        switch (d)
        {
            case 0: tex_Quality.text = "低"; break;
            case 2: tex_Quality.text = "中"; break;
            case 4: tex_Quality.text = "高"; break;
            case 5: tex_Quality.text = "最高"; break;
            default:break;
        } 

        fScro_value = m_config.f_GetQualityPos();/* 画质滑块位置0~1 */
        Scro_Quality.value = fScro_value; 
    } 
    void Update () {
		if(Slider_tep.value!=fSlider_value)/*设置音量*/
        {
            fSlider_value = Slider_tep.value;
            Audio_tep.volume = fSlider_value;
            m_config.SetBGMval(fSlider_value); 
        }
        if(Scro_Quality.value!=fScro_value)/*画质*/
        {
            //Debug.Log(QualitySettings.GetQualityLevel());
            fScro_value = Scro_Quality.value;
            m_config.SetQualityPos(fScro_value);

            if (fScro_value<0.25)
            {
                tex_Quality.DOText("低",0.5f).SetEase(Ease.OutQuad);
                m_config.SetQuality(Quality.QualityLevel_low);
                QualitySettings.SetQualityLevel(0);
            }
            else if(fScro_value<0.5)
            { 
                tex_Quality.DOText("中", 0.5f).SetEase(Ease.OutQuad);
                m_config.SetQuality(Quality.QualityLevel_mid);
                QualitySettings.SetQualityLevel(2);
            }
            else if(fScro_value<0.75)
            {
                tex_Quality.DOText("高", 0.5f).SetEase(Ease.OutQuad);
                m_config.SetQuality(Quality.QualityLevel_high);
                QualitySettings.SetQualityLevel(4);
            }
            else
            {
                tex_Quality.DOText("最高", 0.5f).SetEase(Ease.OutQuad);
                m_config.SetQuality(Quality.QualityLevel_veryhigh);
                QualitySettings.SetQualityLevel(5);
            }
        }
        if(tg.isOn != m_config.GetFrame())
        {
            m_config.SetFrame(tg.isOn);  
        }
        if(tg_window.isOn != m_config.GetWindowed())
       {
         Debug.Log("windowed");
          m_config.SetWindowed(tg_window.isOn);
       }

	}

    void onClickBackButton()
    {
        ControlScript.UpdateChose(Chose.FirstC);/*返回主界面*/
    }

}
