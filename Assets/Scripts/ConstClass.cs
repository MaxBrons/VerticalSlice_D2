using System;
using System.Collections.Generic;
using UnityEngine;

class ConstClass : MonoBehaviour
{
    public const string TARGET_NAME = "Target";
    public const string UI = "UI";
    #region Player
    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
    public const string MOUSEX = "Mouse X";
    public const string MOUSEY = "Mouse Y";
    #endregion

    #region Weapons
    #region Weapons.Shotgun
    public const string SHOTGUN_NAME = "Shotgun";
    public const float SHOTGUN_RANGE = 50;
    public const float SHOTGUN_DAMAGE = 300;
    public const float SHOTGUN_ATACKSPEED = 0.6f;
    #endregion Weapons.Shotgun
    #region Weapons.Shovel
    public const string SHOVEL_NAME = "Shovel";
    public const float SHOVEL_RANGE = 5;
    public const float SHOVEL_DAMAGE = 300;
    public const float SHOVEL_ATACKSPEED = 1f;
    #endregion
    #endregion Weapons

    #region Animation
    public const string SHOTGUN_SWAP_TRIGGER = "Swap_Shotgun";
    public const string SHOTGUN_RELOAD_TRIGGER = "Reload";
    public const string SHOTGUN_RELOAD_BOOLEAN = "Reloading";
    public const string SHOTGUN_SHOOT_TRIGGER = "Shoot";
    public const string SHOVEL_SWAP_TRIGGER = "Swap_Shovel";
    public const string SHOVEL_SWING_TRIGGER = "Swing_Shovel";
    #endregion

    #region Tags
    #region Tags.Environment
    public const string GROUND_TAG = "Ground";
    public const string BUILDING_TAG = "Building";
    #endregion
    #endregion
}
