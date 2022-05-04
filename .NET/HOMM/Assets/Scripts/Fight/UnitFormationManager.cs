using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFormationManager : MonoBehaviour
{
    [SerializeField]
    UnitFormation unitFormation = null;
    public UnitFormation UnitFormation
    {
        get { return unitFormation; }
        set { unitFormation = value; }
    }

    [SerializeField]
    TextMesh unitsCountText;
    [SerializeField]
    Camera fightCamera;
    public Camera FightCamera
    {
        set { fightCamera = value; }
    }

    private void Update()
    {
        if(unitFormation != null)
        {
            unitsCountText.text = unitFormation.Count.ToString();
            if (fightCamera != null)
            {
                unitsCountText.transform.rotation = fightCamera.transform.rotation;
            }
        }
    }
}
