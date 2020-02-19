using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public bool mouse = false;
    string axis;
    float rotation = 0;
    float move_speed = 5;
    float rotation_speed = 80;

    Vector3 move_direction = Vector3.zero;
    CharacterController controller;
    Animator animator;

    void Start()
    {
        axis = mouse ? "Mouse X" : "Horizontal";
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            move_direction = Vector3.forward * move_speed;
            move_direction = transform.TransformDirection(move_direction);
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            move_direction = Vector3.zero;
            animator.SetBool("Walk", false);
        }
        controller.SimpleMove(move_direction);
        rotation += Input.GetAxis(axis) * rotation_speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);
    }
}
