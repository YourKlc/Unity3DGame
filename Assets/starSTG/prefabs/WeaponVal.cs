using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponVal : MonoBehaviour {
    /// <summary>
    /// 武器信息，0代表玩家武器,1代表敌人武器
    /// </summary>
    public int Weapon_Flag;
    public int Destroy_Collide;//与物体碰撞后是否立即销毁0否,1是
    public int Weapon_Attack;
    
	void Start () {
		
	}
	 
}
