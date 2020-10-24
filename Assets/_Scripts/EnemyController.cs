
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
* Description        : Controls the behaviour of the enemies.
* 
* Source file        : EnemyController.cs
*
* Last modified      : 20/10/20
*
*
* Revision History   :
*
* Date        Author Ref    Revision (Date in YYYYMMDD format) 
* 20/10/20    David Gasinec        Edited script.  
*
|**********************************************************************/using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Class to control enemy behaviour and ensure they stay within bounds.*/
public class EnemyController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public float direction;

    // Update is called once per frame

    /** Calls the move and checkbounds methods. */
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    /** Moves the position of the enemies. */
    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f);
    }

    /** Check to see if the enemy has reached the top or bottom of the screen. */
    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.y >= verticalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
}
