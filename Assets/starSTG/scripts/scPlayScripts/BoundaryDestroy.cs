using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroy : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("BoundaryDestroy:" + other.name);
        Destroy(other.gameObject);
    }
}
