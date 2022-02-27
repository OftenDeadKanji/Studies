using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LightSource
{
    #region Properties
    public enum Color
    {
        Yellow,
        Blue,
        Green
    }
    [SerializeField]
    Color color;
    public Color FlameColor
    {
        get => color;
        set => color = value;
    }
    [SerializeField]
    float fuel;
    readonly float maxFuel = 100.0f;
    public float MaxFuel
    {
        get => maxFuel;
    }

    public float Fuel
    {
        get => fuel;
        set => fuel = value > maxFuel ? maxFuel : value;
    }
    readonly float fuelConsumptionSpeed_default = 1.0f; //per sec
    public float FuelConsumptionSpeed_default
    {
        get => fuelConsumptionSpeed_default;
    }
    [SerializeField]
    float fuelConsumptionSpeed = 1.0f; //per sec
    public float FuelConsumptionSpeed
    {
        get => fuelConsumptionSpeed;
        set => fuelConsumptionSpeed = value;
    }
    [SerializeField]
    bool isActive = true;
    public bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }
    #endregion

    public LightSource()
    {
        this.color = Color.Yellow;
        this.fuel = maxFuel;
    }
    public LightSource(Color color)
    {
        this.color = color;
        this.fuel = maxFuel;
    }
    public LightSource(Color color, float fuel)
    {
        this.color = color;
        this.fuel = fuel > maxFuel ? maxFuel : fuel;
    }

    public void UpdateFlame(float deltaTime)
    {
        if (isActive)
        {
            if (fuel > 0.0f)
            {
                fuel -= fuelConsumptionSpeed * deltaTime;
            }
            else
            {
                fuel = 0.0f;
            }
        }
    }

    public bool IsProducingLight()
    {
        return isActive && fuel > 0.0f;
    }
}
