using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    public float runSpeed;
    public float maxGroundTeleport;
    float speed;
    Vector3 localScale;
    GameObject standingOn;
    Vector3 lastStandingOnPosition;
    public bool useSpawn;

    public LayerMask standUponLayer;
    Rigidbody2D rb;

    PlayerMovement controller;
    ParentConstraint parentConstraint;

    public Vector3 upsideDownStart;

    void Awake()
    {
        controller = GetComponent<PlayerMovement>();
        parentConstraint = GetComponent<ParentConstraint>();
        rb = GetComponent<Rigidbody2D>();
        speed = controller.maxSpeed;

        localScale = transform.localScale;

        if (controller.upsideDown)
        {
            if (useSpawn)
                transform.position = upsideDownStart;

            controller.animator.transform.localScale = new Vector3(localScale.x, -1 * localScale.y, localScale.z);
            controller.animator.transform.position = new Vector3(transform.localPosition.x, -0.075f + transform.position.y, transform.localPosition.z);
        }
    }

    void FixedUpdate()
    {
        ModifyController();

        ParentToGround();
    }

    void ParentToGround()
    {
        if (Physics2D.OverlapBox(transform.position - new Vector3(0, controller.defaultLocalScale.y / 2) * controller.ud, new Vector2(controller.defaultLocalScale.x - 0.5001f, .4f), 0, standUponLayer))
        {
            GameObject setting = Physics2D.OverlapBox(transform.position - new Vector3(0, controller.defaultLocalScale.y / 2) * controller.ud, new Vector2(controller.defaultLocalScale.x - 0.001f, .4f), 0, standUponLayer).gameObject;

            if (controller.standingOn != null)
            {
                if (Vector3.Distance(controller.standingOn.transform.position, lastStandingOnPosition) <= maxGroundTeleport)
                    transform.Translate(controller.standingOn.transform.position - lastStandingOnPosition, Space.World);
            }
                
            controller.standingOn = setting;
            
            lastStandingOnPosition = controller.standingOn.transform.position;
        }
        else
        {
            controller.standingOn = null;
        }
    }

    void ModifyController()
    {
        controller.maxSpeed = data.running ? speed + runSpeed : speed;
    }
}