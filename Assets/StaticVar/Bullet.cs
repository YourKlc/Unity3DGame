using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Quality
{
    QualityLevel_low = 0,
    QualityLevel_mid = 2,
    QualityLevel_high = 4,
    QualityLevel_veryhigh = 5
}
//类继承自ScriptableObject
public class Bullet : ScriptableObject
{
    public Quality MyQuality = Quality.QualityLevel_low;
    [Range(0, 1)]
    public float QualityPos;
    [Range(0, 1)]
    public float BGMVal = 0.77f;

    public bool DisFrame;
    public bool Windowed;
}
