/***********************************************************************;
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
* Description        : Controls the behaviour of bullets.
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

/** Class to control bullet behaviour, inherits from MonoBehaviour and IApplyDamage. */
public class BulletController : MonoBehaviour, IApplyDamage
{
    public float verticalSpeed;
    public float horizontalBoundary;
    public BulletManager bulletManager;
    public int damage;

    
    /** Finds the Bulletmanager in the scene. */
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    /** Moves the position of the bullets and checks if they are within bounds every update. */
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    /** Takes the bullet's position and moves it to a new vector. */
    private void _Move()
    {
        transform.position += new Vector3(verticalSpeed, 0.0f, 0.0f) * Time.deltaTime;
    }

    /** Checks if the bullets are within the horizontal boundary at the right of the screen. */
    private void _CheckBounds()
    {
        if (transform.position.x > horizontalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    /** Event when another object enters a trigger collider attached to this object */
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        bulletManager.ReturnBullet(gameObject);
    }

    /** Applies damage from bullets.*/
    public int ApplyDamage()
    {
        return damage;
    }
}
