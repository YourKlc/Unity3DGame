using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class imgchangeScript : MonoBehaviour
{
    //Image是UI命名空间下的类，public后拖进一个已经建好的Image控件即可使用。
    public Image m_image;

    //定义一个计时器
    float timeCounter = 0;
    //设定一个时间总长，此处为3秒
    public float timeAmount = 3;

    // Use this for initialization
    void Start()
    {
        //设定图片为filled模式，填充方式为螺旋式，从0开始。
        m_image.type = Image.Type.Filled;
        m_image.fillMethod = Image.FillMethod.Radial360;
        m_image.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //进度条会在5秒内逐渐填满
        if (timeCounter < timeAmount)
        {
            //计时器会不断累加当前这一帧的时间
            timeCounter += Time.deltaTime;
            //image图片会按照前时间/总时间的比例展开
            m_image.fillAmount = timeCounter / timeAmount;
        }
        //当时间超过了总时间，清空画面，变换图片的展开方式为水平从左向右再次展开
        else
        {
            m_image.fillMethod = Image.FillMethod.Horizontal;
            // fillOrigin的枚举中： 0为左边、1为右边，具体请按 F12 查看。
            m_image.fillOrigin = 0;
            timeCounter = 0;
        }
    }
}