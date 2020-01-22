using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapons
{
    private float shoot_Timer = 0;
    private int bullets_Magazine = 10;
    private int bullets_Reserve;

    private void Awake()
    {
        this.fpsCamera = Camera.main;
        //this.animator = GetComponent<Animator>();
        this.range = ConstClass.SHOTGUN_RANGE;
        this.damage = ConstClass.SHOTGUN_DAMAGE;
        this.attackSpeed = ConstClass.SHOTGUN_ATACKSPEED;
        this.name = ConstClass.SHOTGUN_NAME;
    }

    public override void Update()
    {
        base.Update();
        shoot_Timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && shoot_Timer >= attackSpeed && bullets_Magazine > 0)
        {
            Shoot();
            shoot_Timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        /*if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            //Start reload animation

            while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
                yield return null;

            bullets_Reserve--;
        }*/
        bullets_Magazine++;
        yield return null;
    }

    private void Shoot()
    {
        //Start shotgun shoot animation
        //Start shotgun muzzleflash animation/particle system
        bullets_Magazine--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Vector3 forward = fpsCamera.transform.TransformDirection(Vector3.forward) * 10;
            if (hit.transform.gameObject.tag == ConstClass.TARGET_NAME)
                hit.transform.gameObject.GetComponent<Target>().Hit();
        }
    }
}
