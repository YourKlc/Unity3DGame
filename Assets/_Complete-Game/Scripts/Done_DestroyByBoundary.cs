using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {

        Destroy(other.gameObject);
    } 
}