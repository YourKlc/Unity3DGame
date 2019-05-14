using UnityEngine;
using UnityEditor;
using System.IO;
public class AssetTest : Editor
{ 
    [MenuItem("CreateAsset/king")]
    static void Create()
    {
        //创建一个ScriptableObject的实例
        ScriptableObject bullet = CreateInstance<Bullet>();

        if (!bullet)
        {
            Debug.LogError("bulletTest not found");
            return;
        }
        string path = Application.dataPath + @"/StaticVar";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);//创建指定目录
        }
        //后缀必须是.asset ； 文件名必须和类名一致
        path = string.Format(@"Assets/StaticVar/{0}.asset", typeof(Bullet).ToString());

        AssetDatabase.CreateAsset(bullet, path); //在指定路径下创建一个asset配置文件
    }

}
