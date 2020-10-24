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
* Description        : Controls the behaviour of the bullets but object pooling.
* 
* Source file        : BulletManager.cs
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


/** Class to control bullet behaviour, inherits from MonoBehaviour. Used object pooling design method.*/
[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public BulletFactory bulletFactory;
    public int MaxBullets;

    private Queue<GameObject> m_bulletPool;


    // Start is called before the first frame update

    /** Calls the Build bullet pool method. */
    void Start()
    {
        _BuildBulletPool();
    }

    /** Method to build the bullet pool. Creates a Queue of GameObjects. */
    private void _BuildBulletPool()
    {
        // create empty Queue structure
        m_bulletPool = new Queue<GameObject>();

        for (int count = 0; count < MaxBullets; count++)
        {
            var tempBullet = bulletFactory.createBullet();
            m_bulletPool.Enqueue(tempBullet);
        }
    }

    /** Getter for the bullets. Used by fire bullet method in PlayerController. */
    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    /** Checks to see if the player has bullets in te bullet pool. */
    public bool HasBullets()
    {
        return m_bulletPool.Count > 0;
    }

    /** Returns the bullet to the bulletpool. */
    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_bulletPool.Enqueue(returnedBullet);
    }
}
