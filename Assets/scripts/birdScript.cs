using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.EnhancedTouch;

public class birdScript : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Boolean game_over = false;
    private Vector2 swipe_start, swipe_end;
    [SerializeField] private float birdVel = 5f;
    [SerializeField] private GameObject arrow;
    [SerializeField] private LogicScript logic;

    public PlayerInput player;
    
    private InputAction jump_action,arrow_button;

    void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myRigidBody.velocity = Vector3.up * birdVel;

        jump_action = player.actions["Click"];
        arrow_button = player.actions["Arrow_button"];
    }

    // Update is called once per frame
    void Update()
    {
        if(jump_action.WasPressedThisFrame() && !game_over)
            myRigidBody.velocity = Vector3.up * birdVel;

        if (transform.position.y > 8 || transform.position.y < -4.7)
        {
            game_over = true;
            logic.game_over();
            Destroy(gameObject);
        }

        if (arrow_button.WasPressedThisFrame() && !game_over)
            shoot_arrow();
    }

    public void shoot_arrow()
    {
        Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, -90));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        logic.addScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        game_over = true;
        logic.game_over();
    }
}
