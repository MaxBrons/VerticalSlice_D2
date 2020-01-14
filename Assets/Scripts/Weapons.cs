using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapons : MonoBehaviour
{
    protected Camera fpsCamera;
    protected Animator animator;
    protected float range;
    protected float damage;
    protected float attackSpeed;
    protected string weaponName;

    [SerializeField] private GameObject[] weapon_Gameobjects;
    private GameObject weapon_Slot;
    private int weapon_selected = 0;

    public virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeapon(0, ConstClass.SHOTGUN_SWAP_TRIGGER);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeWeapon(1, ConstClass.SHOVEL_SWAP_TRIGGER);
    }

    private void ChangeWeapon(int index, string trigger)
    {
        weapon_Slot = weapon_Gameobjects[index];
        weapon_selected = index;
        int i = 0;
        foreach (Transform w in fpsCamera.transform)
        {
            if (i == weapon_selected)
            {
                weapon_Slot = weapon_Gameobjects[index];
                weapon_Slot.SetActive(true);
            }
            else { w.gameObject.SetActive(false); }
            i++;
        }
        //animator.SetTrigger(trigger);
    }
}
