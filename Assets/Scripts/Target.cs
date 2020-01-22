using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    Vector3 positionFrom;

    private void Awake()
    {
        positionFrom = this.transform.position;
    }

    private void Update()
    {
        if (transform.position.y - positionFrom.y < 1.95)
        {
            transform.Translate(Vector3.up * 0.1f);
        }
    }
    public void Hit()
    { 
        //Hit text appears
        //Target death animation starts playing
        //Target disappears;
        GameObject.Find("TargetSpawnpoints").GetComponent<TargetPopup>().totalTargetsShot++;
        GameObject.Find("TargetSpawnpoints").GetComponent<TargetPopup>().spawned = false;
        Destroy(gameObject);
    }
}
