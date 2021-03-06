﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPopup : MonoBehaviour
{
    [Header("Targets")]
    [SerializeField] private GameObject target1;
    [SerializeField] private GameObject target2;
    [SerializeField] private GameObject target3;

    //Back row spawnpoints
    [Header("Back Row")]
    [SerializeField] private Transform leftBack;
    [SerializeField] private Transform midBack;
    [SerializeField] private Transform rightBack;

    //Middle row spawnpoints
    [Header("Middle Row")]
    [SerializeField] private Transform leftMid;
    [SerializeField] private Transform midMid;
    [SerializeField] private Transform rightMid;

    //front row spawnpoint
    [Header("Front Row")]
    [SerializeField] private Transform midFront;
    
    public int totalTargetsShot = 0;
    public bool spawned = false;
    // Start is called before the first frame update

    private void Update()
    {
        var rot = Quaternion.Euler(0, 90, 0);
        if (totalTargetsShot == 0 && spawned == false)
        {
            Instantiate(target1, midFront.transform.position, rot);
            spawned = true;
        }
        if (totalTargetsShot == 1 && spawned == false)
        {
            Instantiate(target3, leftBack.transform.position, rot);
            Instantiate(target3, rightBack.transform.position, rot);
            spawned = true;
        }
        if (totalTargetsShot == 3 && spawned == false)
        {
            Instantiate(target2, leftMid.transform.position, rot);
            spawned = true;
        }
        if (totalTargetsShot == 4 && spawned == false)
        {
            Instantiate(target2, rightMid.transform.position, rot);
            spawned = true;
        }
        if (totalTargetsShot == 5 && spawned == false)
        {
            Instantiate(target3, midBack.transform.position, rot);
            spawned = true;
        }
        if (totalTargetsShot == 6 && spawned == false)
        {
            Instantiate(target2, midMid.transform.position, rot);
            spawned = true;
            totalTargetsShot = 0;
        }
    }
}
