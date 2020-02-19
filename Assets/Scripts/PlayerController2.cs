using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public bool mouse = false;
    string axis;
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
            move_direction = controller.transform.forward * move_speed;
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            move_direction = Vector3.zero;
            animator.SetBool("Walk", false);
        }
        controller.SimpleMove(move_direction);
        controller.transform.Rotate(new Vector3(0, Input.GetAxis(axis), 0) * rotation_speed * Time.deltaTime);
    }
}
