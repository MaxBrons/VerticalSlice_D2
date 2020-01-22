using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapons
{
    private float shoot_Timer = 0;
    private int bullets_Magazine = 6;
    private int bullets_Reserve = 50;
    private UserInterface UI;

    private void Awake()
    {
        this.fpsCamera = Camera.main;
        this.animator = GetComponent<Animator>();
        this.range = ConstClass.SHOTGUN_RANGE;
        this.damage = ConstClass.SHOTGUN_DAMAGE;
        this.attackSpeed = ConstClass.SHOTGUN_ATACKSPEED;
        this.name = ConstClass.SHOTGUN_NAME;

        UI = GameObject.Find(ConstClass.UI).GetComponent<UserInterface>();
    }

    public override void Update()
    {
        base.Update();
        shoot_Timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && shoot_Timer >= attackSpeed && bullets_Magazine > 0)
        {
            StartCoroutine(Shoot());
            shoot_Timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());

        UI.Ammo.text = bullets_Magazine.ToString();
        UI.Reserve.text = bullets_Reserve.ToString();
    }

    public void LoadBullet()
    {
        bullets_Magazine++;
        bullets_Reserve--;
    }

    private IEnumerator Reload()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0) && bullets_Magazine < 6)
        {
            //Start reload animation
            animator.SetBool("Reloading", true);
            animator.SetTrigger("Reload");

            while (animator.GetBool("Reloading") == true)
            {
                if(bullets_Magazine >= 6)
                    animator.SetBool("Reloading", false);

                yield return null;
            }  
        }
        yield return null;
    }

    private IEnumerator Shoot()
    {
        if (bullets_Magazine > 0)
        {
            while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
                yield return null;

            //Start shotgun shoot animation
            animator.SetTrigger("Shoot");

            animator.SetBool("Reloading", false);
            bullets_Magazine--;

            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
            {
                Vector3 forward = fpsCamera.transform.TransformDirection(Vector3.forward) * 10;
                if (hit.transform.gameObject.tag == ConstClass.TARGET_NAME)
                    hit.transform.gameObject.GetComponent<Target>().Hit();
            }
        }
        yield return null;
    }
}
