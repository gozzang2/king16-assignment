using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private Vector3 startPosition;
    private Vector3 oldPosition;
    private bool isTurn = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        oldPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            CharTurn();
        } else if (Input.GetMouseButtonDown(0))
        {
            CharMove();
        }
    }

    private void CharTurn()
    {
        isTurn = isTurn == true ? false : true;
        spriteRenderer.flipX = isTurn;
    }

    private void CharMove()
    {
        if(isTurn) //left
        {
            oldPosition += new Vector3(-0.75f, 0.5f, 0);
        }
        else
        {
            oldPosition += new Vector3(0.75f, 0.5f, 0);
        }

        transform.position = oldPosition;
        anim.SetTrigger("Move");
    }
}
