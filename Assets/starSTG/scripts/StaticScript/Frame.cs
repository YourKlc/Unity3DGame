﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    //更新的时间间隔
    public float UpdateInterval = 0.5F;
    //最后的时间间隔
    private float _lastInterval;
    //帧[中间变量 辅助]
    private int _frames = 0;
    //当前的帧率
    private float _fps;
    public bool show=false;
    void Start()
    {
        //Application.targetFrameRate=60;
        UpdateInterval = Time.realtimeSinceStartup;
        _frames = 0;
    }
    void OnGUI()
    {
        if(show == true)
        GUI.Label(new Rect(50, 50, 100, 100), "FPS:" + _fps.ToString("f2"));
    }
    void Update()
    {
        ++_frames;
        if (Time.realtimeSinceStartup > _lastInterval + UpdateInterval)
        {
            _fps = _frames / (Time.realtimeSinceStartup - _lastInterval);
            _frames = 0;
            _lastInterval = Time.realtimeSinceStartup;
        }
    }
}