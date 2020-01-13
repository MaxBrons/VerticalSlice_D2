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

    private GameObject[] weapon_Gameobjects;
    private GameObject weapon_Slot;

    public virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeapon(0, ConstClass.SHOTGUN_SWAP_TRIGGER);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeWeapon(1, ConstClass.SHOVEL_SWAP_TRIGGER);
    }

    private void ChangeWeapon(int index, string trigger)
    {
        if (weapon_Slot != null)
        {
            Transform current = fpsCamera.transform.GetChild(0).transform;
            Destroy(weapon_Slot.gameObject);
            animator.SetTrigger(trigger);
            weapon_Slot = weapon_Gameobjects[index];
            Instantiate(weapon_Slot, current.position, current.rotation, fpsCamera.transform);
        }
        else
        {
            weapon_Slot = weapon_Gameobjects[0];
            ChangeWeapon(index, trigger);
        }
    }
}
