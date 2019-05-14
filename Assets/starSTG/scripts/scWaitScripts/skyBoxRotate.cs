using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyBoxRotate : MonoBehaviour {
    public Material skybox;
    private Vector4 m_Offset,tep;
    // Update is called once per frame
    private void Start()
    {
        m_Offset = new Vector4(0, 0, 0, 0);
        tep = new Vector4(Random.Range(0.00001f, 0.000015f), Random.Range(0.00001f, 0.000015f), Random.Range(0.00001f, 0.000012f), 0);
    }
    void Update()
    {
        skybox.SetVector("_Offset",m_Offset);
        m_Offset += tep/50; 
    } 
}
