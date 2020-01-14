using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : Weapons
{
    private float hit_Timer = 0;

    private void Awake()
    {
        this.fpsCamera = Camera.main;
        //this.animator = GetComponent<Animator>();
        this.range = ConstClass.SHOVEL_RANGE;
        this.damage = ConstClass.SHOVEL_DAMAGE;
        this.attackSpeed = ConstClass.SHOVEL_ATACKSPEED;
        this.name = ConstClass.SHOVEL_NAME;
    }

    public override void Update()
    {
        base.Update();
        hit_Timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && hit_Timer >= attackSpeed)
        {
            Swing();
            hit_Timer = 0;
        }
    }

    private void Swing()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            if (hit.transform.tag == ConstClass.TARGET_NAME)
                hit.transform.GetComponent<Target>().Hit();
        }
    }
}
