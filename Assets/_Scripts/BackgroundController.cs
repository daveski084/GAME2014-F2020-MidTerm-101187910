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
* Description        : Controls the behaviour of the background.
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


/** Class to control background behaviour, inherits from MonoBehaviour. */
public class BackgroundController : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;

    /** Moves the position of the background and checks if it within bounds every update. */
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    /** Resets the postion of the background when called. */
    private void _Reset()
    {
        transform.position = new Vector3(horizontalBoundary, 0.0f);
    }

    /** Moves the position of the background by the horizontal speed. */
    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }

    /** Checks if the background is still within the horizontal boundary and calls reset if the background exceeds it. */
    private void _CheckBounds()
    {
        
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }
}
