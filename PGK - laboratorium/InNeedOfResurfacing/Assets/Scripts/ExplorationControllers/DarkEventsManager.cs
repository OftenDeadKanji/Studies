using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkEventsManager : MonoBehaviour
{
    [SerializeField]
    TMPro.TMP_Text info;

    [SerializeField]
    float avgInterval = 5.0f; //in mins

    float currentInterval;
    float currentTimePassed;

    bool isEventOn = false;
    [SerializeField]
    DarkEvent currentEvent;

    Dictionary<GameObject, LightSource.Color> previousColors = new Dictionary<GameObject, LightSource.Color>(); 
    
    // Start is called before the first frame update
    void Start()
    {
        currentInterval = avgInterval;

        if(info == null)
        {
            throw new Exception("info GUI Text is null!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEventOn)
        {
            currentTimePassed += Time.deltaTime / 1.0f;

            if (currentTimePassed > currentInterval)
            {
                currentTimePassed = 0.0f;

                StartNewEvent();
            }
        }
        else
        {
            switch (currentEvent.EventType)
            {
                case DarkEvent.Type.LightsOut:
                    SetTorchesOff();
                    break;
                case DarkEvent.Type.ChangeFlameColors:
                    ChangeFlamesColors();
                    break;
            }

            currentEvent.UpdateDarkEventInExplorationMode(Time.deltaTime);
            if (currentEvent.IsFinished())
            {
                EndCurrentEvent();
            }
        }
    }

    void StartNewEvent()
    {
        isEventOn = true;

        currentEvent = DarkEvent.GetRandomEvent();
        info.text = currentEvent.EventType.ToString();

        switch (currentEvent.EventType)
        {
            case DarkEvent.Type.LightsOut:
                SetTorchesOff();
                break;
            case DarkEvent.Type.ChangeFlameColors:
                ChangeFlamesColors();
                break;

        }
    }

    void EndCurrentEvent()
    {
        isEventOn = false;
        info.text = "";
        switch (currentEvent.EventType)
        {
            case DarkEvent.Type.LightsOut:
                SetTorchesOn();
                break;
            case DarkEvent.Type.ChangeFlameColors:
                ChangeFlamesColorsToNormal();
                previousColors.Clear();
                break;
        }
    }

    void SetTorchesOn()
    {
        var torches = GameObject.FindGameObjectsWithTag("Torch");

        foreach (var torch in torches)
        {
            var standingTorch = torch.GetComponent<StandingTorchController>();
            if (standingTorch != null)
            {
                standingTorch.SetOn();
            }
        }
    }

    void SetTorchesOff()
    {
        var torches = GameObject.FindGameObjectsWithTag("Torch");

        foreach (var torch in torches)
        {
            var standingTorch = torch.GetComponent<StandingTorchController>();
            if (standingTorch != null)
            {
                standingTorch.SetOff();
            }
        }
    }

    void ChangeFlamesColors()
    {
        var torches = GameObject.FindGameObjectsWithTag("Torch");

        foreach (var torch in torches)
        {
            if (!previousColors.TryGetValue(torch, out _))
            {
                var standingTorch = torch.GetComponent<StandingTorchController>();
                if (standingTorch != null)
                {
                    previousColors.Add(torch, standingTorch.LightSource.FlameColor);

                    var values = Enum.GetValues(typeof(LightSource.Color));
                    
                    LightSource.Color rndColor = (LightSource.Color)UnityEngine.Random.Range(0, values.Length);

                    standingTorch.LightSource.FlameColor = rndColor;
                }
            }

        }
    }

    void ChangeFlamesColorsToNormal()
    {
        var torches = GameObject.FindGameObjectsWithTag("Torch");
        LightSource.Color prevColor;

        foreach (var torch in torches)
        {
            if (previousColors.TryGetValue(torch, out prevColor))
            {
                var standingTorch = torch.GetComponent<StandingTorchController>();
                if (standingTorch != null)
                {
                    standingTorch.LightSource.FlameColor = prevColor;
                }
            }

        }
    }
}
