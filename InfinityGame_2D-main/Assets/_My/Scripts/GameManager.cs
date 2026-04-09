using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("계단")]
    [Space(10)]
    public GameObject[] Stairs;
    public bool[] isTurn;

    private enum State {Start, Left, Right};
    private State state;
    private Vector3 oldPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Instance = this; 
       
       Init();
       InitStairs();
    }

    private void Init()
    {
        state = State.Start;
        oldPosition = Vector3.zero;
        isTurn = new bool[Stairs.Length];

        for(int i = 0; i < Stairs.Length; i++)
        {
            Stairs[i].transform.position = Vector3.zero;
            isTurn[i] = false;
        }
    }

    private void InitStairs()
    {
        for(int i = 0; i < Stairs.Length; i++)
        {
            switch (state)
            {
                case State.Start:
                    Stairs[i].transform.position = new Vector3(0.75f, -0.1f, 0);
                    state = State.Right;
                    break;
                
                case State.Left:
                    Stairs[i].transform.position = oldPosition + new Vector3(-0.75f, 0.5f, 0);
                    isTurn[i] = true;
                    break;
                
                case State.Right:
                    Stairs[i].transform.position = oldPosition + new Vector3(0.75f, 0.5f, 0);
                    isTurn[i] = false;
                    break;
            }

            oldPosition = Stairs[i].transform.position;

            if(i != 0)
            {
                int ran = Random.Range(0, 5);

                if(ran < 2 && i < Stairs.Length -1)
                {
                    state = state == State.Left ? State.Right : State.Left;
                }
            }


        }
    }
}