using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCore
{
    #region Health
    float maxHP = 100.0f;
    float currentHP = 100.0f;

    public float Health
    {
        get => currentHP;
        set
        {
            if(value < 0.0f)
            {
                currentHP = 0.0f;
            }
            else if (value > maxHP)
            {
                currentHP = maxHP;
            }
            else
            {
                currentHP = value;
            }
        }
    }

    public bool IsDead()
    {
        return currentHP == 0.0f;
    }
    #endregion

    #region Move direction
    Vector3 moveDirection = new Vector3(1.0f, 0.0f);
    public Vector3 MoveDirection
    {
        get => moveDirection;
        set => moveDirection = value.normalized;
    }
    public enum MoveDirections
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    public void SetMoveDirection(MoveDirections direction)
    {
        switch(direction)
        {
            case MoveDirections.UP:
                moveDirection = new Vector3(0.0f, 1.0f);
                break;
            case MoveDirections.DOWN:
                moveDirection = new Vector3(0.0f, -1.0f);
                break;
            case MoveDirections.LEFT:
                moveDirection = new Vector3(-1.0f, 0.0f);
                break;
            case MoveDirections.RIGHT:
                moveDirection = new Vector3(1.0f, 01.0f);
                break;
        }
    }
    #endregion

    #region Speed
    public readonly float maxWalkingSpeed = 5.0f;
    public readonly float maxRunningSpeed = 12.0f;

    bool isRunning = false;

    float currentSpeed = 0.0f;
    public float Speed
    {
        get => currentSpeed;
        set
        {
            if(value < 0.0f)
            {
                currentSpeed = 0.0f;
            }
            else if(!isRunning && value > maxWalkingSpeed)
            {
                currentSpeed = maxWalkingSpeed;
            }
            else if(isRunning && value > maxRunningSpeed)
            {
                currentSpeed = maxRunningSpeed;
            }
            else
            {
                currentSpeed = value;
            }
        }
    }

    #endregion

}
