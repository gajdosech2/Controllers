using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    float rotation = 0;
    float move_speed = 4;
    float rotation_speed = 80;

    Vector3 move_direction = Vector3.zero;
    CharacterController controller;
    Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            move_direction = new Vector3(0, 0, 1) * move_speed * Time.deltaTime;
            move_direction = transform.TransformDirection(move_direction);
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            move_direction = Vector3.zero;
            animator.SetBool("Walk", false);
        }
        rotation += Input.GetAxis("Horizontal") * rotation_speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        controller.Move(move_direction);
    }
}
