using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DarkEvent
{
    public enum Type
    {
        LightsOut,
        ChangeFlameColors
    }

    Type type;
    public Type EventType
    { 
        get => type; 
        set => type = value; 
    }

    float totalDurationTime = 20.0f;
    float durationTime = 0.0f;
    float explorationToFightConversionFactor = 2f; // min -> turns e.g. 4 mins left -> 8 turns (0.1min left -> 1 turn)

    public DarkEvent(Type type)
    {
        this.type = type;
    }

    public void UpdateDarkEventInExplorationMode(float deltaTime)
    {
        if(durationTime < totalDurationTime)
        {
            durationTime += deltaTime;
        }
        else
        {
            durationTime = totalDurationTime;
        }
    }

    public void UpdateDarkEventInFightMode(int numOfTurns = 1)
    {
        if (durationTime < totalDurationTime)
        {
            durationTime += numOfTurns / explorationToFightConversionFactor;
        }
        else
        {
            durationTime = totalDurationTime;
        }
    }

    public bool IsFinished()
    {
        return durationTime >= totalDurationTime;
    }

    static public DarkEvent GetRandomEvent()
    {
        var values = Enum.GetValues(typeof(Type));
        Type rndType = (Type)UnityEngine.Random.Range(0, values.Length);

        return new DarkEvent(rndType);
    }

    int GetLeftTimeInTurns()
    {
        return (int)Mathf.Ceil(durationTime * explorationToFightConversionFactor);
    }
}
