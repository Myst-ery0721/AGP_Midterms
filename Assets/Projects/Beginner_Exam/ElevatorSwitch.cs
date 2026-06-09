using System.Threading;
using UnityEngine;

public class ElevatorSwitch : MonoBehaviour
{
    enum elevatorState
    {
        IDLE, MOVING_UP, MOVING_DOWN, WAITING
    }
    [SerializeField] private float waitTimer;
    [SerializeField] private float waitDuration;
    [SerializeField] private float movesTimer;
    [SerializeField] private float movesDuration;
    private elevatorState currentState = elevatorState.IDLE;
    private elevatorState previousState;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1) && currentState == elevatorState.IDLE)
        {
            currentState = elevatorState.MOVING_UP;
            
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) && currentState == elevatorState.IDLE)
        {
            currentState = elevatorState.MOVING_DOWN;
            
        }
        StateCheck();
        StateHandler();

    }

    void StateCheck()
    {
        if (currentState != previousState)
        {
            Debug.Log("ENTERED STATE: " + currentState);

            previousState = currentState;
        }
    }
    void StateHandler()
    {
        switch (currentState)
        {
            case elevatorState.MOVING_UP:
                movesTimer += Time.deltaTime;
                //Debug.Log("Elavator is Moving UP for " + movesTimer + " Seconds");
                if (movesTimer >= movesDuration)
                {
                    //Debug.Log("DONE MOVING UP");
                    currentState = elevatorState.WAITING;
                    movesTimer = 0;
                }
                break;
            case elevatorState.MOVING_DOWN:
                movesTimer += Time.deltaTime;
                //Debug.Log("Elavator is Moving DOWN for " + movesTimer + " Seconds");
                if (movesTimer >= movesDuration)
                {
                    //Debug.Log("DONE MOVING DOWN");
                    currentState = elevatorState.WAITING;
                    movesTimer = 0;
                }
                break;
            case elevatorState.WAITING:
                waitTimer += Time.deltaTime;
                //Debug.Log("Elavator is WATING for " + waitTimer + " Seconds");
                if (waitTimer >= waitDuration)
                {
                    currentState = elevatorState.IDLE;
                    waitTimer = 0;
                }
                break;
            case elevatorState.IDLE:
                //Debug.Log("ELEVATOR IS IDLE");
                break;
        }
    }


}
