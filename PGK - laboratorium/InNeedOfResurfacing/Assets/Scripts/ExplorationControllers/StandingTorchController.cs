using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingTorchController : MonoBehaviour
{
    [SerializeField]
    LightSource lightSource = new LightSource();
    public LightSource LightSource
    {
        get { return lightSource; }
    }

    [SerializeField]
    SpriteRenderer flameRenderer;

    [SerializeField]
    GameObject fuelBar;
    float barMaxWidth;

    // Start is called before the first frame update
    void Start()
    {
        if (fuelBar == null)
        {
            throw new Exception("fuelBar gameObject is null!");
        }
        barMaxWidth = fuelBar.transform.localScale.x;
        
        if (flameRenderer == null)
        {
            throw new Exception("flameRenderer gameObject is null!");
        }

        SetFlameSpriteColor();
    }

    // Update is called once per frame
    void Update()
    {
        lightSource.UpdateFlame(Time.deltaTime);

        float percent = lightSource.Fuel / lightSource.MaxFuel;
        
        var scale = fuelBar.transform.localScale;
        scale.x = percent * barMaxWidth;
        
        fuelBar.transform.localScale = scale;


        if(lightSource.IsActive)
        {
            SetFlameSpriteColor();
            var barSpriteRenderer = fuelBar.GetComponent<SpriteRenderer>();
            if (barSpriteRenderer != null)
            {
                barSpriteRenderer.color = new Color(1.0f, 0.91f, 0.12f);
            }
        }
        else
        {
            flameRenderer.color = UnityEngine.Color.black;
            var barSpriteRenderer = fuelBar.GetComponent<SpriteRenderer>();
            if(barSpriteRenderer != null)
            {
                barSpriteRenderer.color = UnityEngine.Color.black;
            }
        }

        if(lightSource.Fuel <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void SetFlameSpriteColor()
    {
        switch(lightSource.FlameColor)
        {
            case LightSource.Color.Yellow:
                flameRenderer.color = UnityEngine.Color.yellow;
                break;
            case LightSource.Color.Blue:
                flameRenderer.color = UnityEngine.Color.blue;
                break;
            case LightSource.Color.Green:
                flameRenderer.color = UnityEngine.Color.green;
                break;
        }
    }

    public void SetOn()
    {
        lightSource.IsActive = true;
    }

    public void SetOff()
    {
        lightSource.IsActive= false;
    }
}
