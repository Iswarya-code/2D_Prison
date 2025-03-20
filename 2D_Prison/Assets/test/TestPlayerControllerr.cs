using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerControllerr : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Animator animator;
    public Transform modelTransform;

    float sprintMultiplier;
    Vector2 axis;

    TestPlayerControllerr controller;


    private void Start()
    {
        var objects = Resources.FindObjectsOfTypeAll(typeof(TestPlayerControllerr));


        foreach (var obj in objects)
        {
            if (this.name != obj.name)
                print(obj.name);
            else
                print($"Mathc found : {obj.name}");
        }






        //if (controller != null && controller.GetComponent<SpriteRenderer>() != null)
        //{
        //    print("controller works");
        //}
        //else
        //    print("controller not there");
    }

    private bool condition_1()
    {
        print("Condition 1");
        return true;
    }

    private bool condition_2()
    {
        print("Condition 2");
        return false;
    }

    private void Update()
    {
        axis = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        sprintMultiplier = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;

        if (axis.x < 0)
            modelTransform.eulerAngles = new Vector3(0, 180, 0);
        else if (axis.x > 0)
            modelTransform.eulerAngles = Vector3.zero;

        animator.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));

        if (Input.GetKeyDown(KeyCode.F))
            print("Pressed F");
    }


    private void FixedUpdate()
    {
        rb.velocity = axis * moveSpeed * sprintMultiplier + Vector2.up * rb.velocity.y;
    }
}
