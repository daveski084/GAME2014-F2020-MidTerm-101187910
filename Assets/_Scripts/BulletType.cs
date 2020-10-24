/************************************************************************
* Project            : GAME2014 Midterm
*
* Program name       : "GAME2014-F2020-MidTerm-101187910"
*
* Author             : Tom Tsiliopoulos / David Gasinec
* 
* Student Number     : 101187910
*
* Date created       : 20/10/03
*
* Description        : Enum class for the diffrent types of bullets.
* 
* Source file        : BulletType.cs
*
* Last modified      : 20/10/20
*
*
* Revision History   :
*
* Date        Author Ref    Revision (Date in YYYYMMDD format) 
* 20/10/20    David Gasinec        Edited script.  
*
|**********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum BulletType
{
    REGULAR,
    FAT,
    PULSING,
    RANDOM
}
