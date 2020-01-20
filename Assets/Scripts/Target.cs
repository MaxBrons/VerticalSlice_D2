using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public void Hit()
    { 
        Debug.Log("Hit");
        //Hit text appears
        //Target death animation starts playing
        //Target disappears;
        Destroy(gameObject);
    }
}
