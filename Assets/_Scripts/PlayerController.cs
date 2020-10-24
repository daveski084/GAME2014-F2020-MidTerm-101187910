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
* Description        : Controls the behaviour of the player (ship).
* 
* Source file        : PlayerController.cs
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
using System.ComponentModel;
using UnityEditor;
using UnityEngine;


/** Class to control player behaviour, inherits from MonoBehaviour. */
public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    [Header("Boundary Check")]
    public float verticalBoundary;

    [Header("Player Speed")]
    public float horizontalSpeed;
    public float maxSpeed;
    public float horizontalTValue;

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    /** Moves, checks if the player is within bounds, and fires bullets with each update call. */
    void Update()
    {
        // Update is called once per frame
        _Move();
        _CheckBounds();
        _FireBullet();
    }

    /** Fires the players bullet from the ship. */
    private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }


    /** Moves the players ship. */
    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }


        if (m_touchesEnded.y != 0.0f)
        {
          transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, m_touchesEnded.y, horizontalTValue));
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
           m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    /** Checks to see if the players ship has hit the top or bottom of the screen. */
    private void _CheckBounds()
    {
        // check upper bounds
        if (transform.position.y >= verticalBoundary)
        {
           transform.position = new Vector3(transform.position.x, verticalBoundary, 0.0f);
        }

         //check lower bounds
        if (transform.position.y <= -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, -verticalBoundary, 0.0f);
        }

    }
}
