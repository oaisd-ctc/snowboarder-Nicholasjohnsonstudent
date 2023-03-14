using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    [SerializeField] float torque = 2f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float baseSpeed = 10f;
    [SerializeField] ParticleSystem boostEffect;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RespondToBoost();
            RotatePlayer();
        }
        
    }

    public void DisableControls()
    {
        
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!boostEffect.isPlaying )
            {
                boostEffect.Play();
            }
            surfaceEffector2D.speed = boostSpeed;
        }
        else 
        {
            if (boostEffect.isPlaying )
            {
                boostEffect.Stop();
            }
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torque);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torque);
        }
    }
}
