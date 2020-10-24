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
* Description        : Controls which type of bullet is instantiated.
* 
* Source file        : BulletFactory.cs
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

/** Class to control player behaviour, inherits from MonoBehaviour. */
public class BulletFactory : MonoBehaviour
{
    [Header("Bullet Types")]
    public GameObject regularBullet;
    public GameObject fatBullet;
    public GameObject pulsingBullet;

    /** Creates a bullet depending on the random number generated. Applies the appropriate damage. */
    public GameObject createBullet(BulletType type = BulletType.RANDOM)
    {
        if (type == BulletType.RANDOM)
        {
            var randomBullet = Random.Range(0, 3);
            type = (BulletType) randomBullet;
        }

        GameObject tempBullet = null;
        switch (type)
        {
            case BulletType.REGULAR:
                tempBullet = Instantiate(regularBullet);
                tempBullet.GetComponent<BulletController>().damage = 10;
                break;
            case BulletType.FAT:
                tempBullet = Instantiate(fatBullet);
                tempBullet.GetComponent<BulletController>().damage = 20;
                break;
            case BulletType.PULSING:
                tempBullet = Instantiate(pulsingBullet);
                tempBullet.GetComponent<BulletController>().damage = 30;
                break;
        }

        tempBullet.transform.parent = transform;
        tempBullet.SetActive(false);

        return tempBullet;
    }
}
