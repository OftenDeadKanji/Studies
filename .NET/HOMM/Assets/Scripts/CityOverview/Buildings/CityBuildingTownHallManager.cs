using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuildingTownHallManager : MonoBehaviour
{
    [SerializeField]
    CityOverviewManager owner = null;
    [SerializeField]
    CityHallGUIManager gui;

    CityBuilding building;
    public CityBuilding Building
    {
        get { return building; }
        set { building = value; }
    }

    [SerializeField]
    CityBuilding.Type buldingType;
    public CityBuilding.Type BuldingType
    {
        get { return buldingType; }
        set { buldingType = value; }
    }

    Outline outline;

    [SerializeField]
    Material[] buildingMaterial_NotExisting;
    [SerializeField]
    Material[] buildingMaterial_Built;
    [SerializeField]
    Material[] buildingMaterial_Upgraded;    
    
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        if (outline == null)
        {
            throw new Exception("outline component not found!");
        }

        if (transform.parent != null)
        {
            owner = transform.parent.GetComponent<CityOverviewManager>();
            if (owner == null)
            {
                throw new Exception("CityOverviewManager component not found!");
            }
        }
        else
        {
            throw new Exception("Parent is null!");
        }
    }

    public void SetCityBuilding(CityBuilding building)
    {
        this.building = building;
        this.buldingType = building.BuildingType;
        switch (building.BuildingLevel)
        {
            case CityBuilding.Level.NotExisting:
                gameObject.GetComponent<MeshRenderer>().materials = buildingMaterial_NotExisting;
                break;
            case CityBuilding.Level.Built:
                gameObject.GetComponent<MeshRenderer>().materials = buildingMaterial_Built;
                break;
            case CityBuilding.Level.Upgraded:
                gameObject.GetComponent<MeshRenderer>().materials = buildingMaterial_Upgraded;
                break;
        }
    }

    private void OnMouseEnter()
    {
        if (!owner.IsAnyDialogBoxOpen)
        {
            outline.OutlineWidth = 10.0f;
        }
    }

    private void OnMouseExit()
    {
        if (!owner.IsAnyDialogBoxOpen)
        {
            outline.OutlineWidth = 0.0f;
        }
    }

    private void OnMouseUpAsButton()
    {
        if(!owner.IsAnyDialogBoxOpen)
        {
            outline.OutlineWidth = 0.0f;
            owner.IsAnyDialogBoxOpen = true;

            PrepareGUI();

            gui.dialogbox_Main.SetActive(true);
            if(building.BuildingLevel == CityBuilding.Level.Built)
            {
                gui.dialogBox_Built.SetActive(true);
            }
            else
            {
                gui.dialogBox_Upgraded.SetActive(true);
            }
        }
    }

    void PrepareGUI()
    {
        gui.buildingName.text = "City Hall";
        gui.text_profitValue_Built.text = building.IncomePerDay.Gold.ToString();
        gui.button_close_Built.onClick.RemoveAllListeners();
        gui.button_close_Built.onClick.AddListener(callback_CloseBuilt);
        gui.button_goToUpgrade.onClick.RemoveAllListeners();
        gui.button_goToUpgrade.onClick.AddListener(callback_GoToUpgrade);

        gui.text_profitValue_Upgraded.text = building.IncomePerDayUpgraded.Gold.ToString();
        gui.button_close_Upgraded.onClick.RemoveAllListeners();
        gui.button_close_Upgraded.onClick.AddListener(callback_CloseUpgraded);

        gui.text_goldProfitFrom.text = building.IncomePerDay.Gold.ToString();
        gui.text_goldProfitTo.text = building.IncomePerDayUpgraded.Gold.ToString();
        gui.text_costGoldValue.text = building.UpgradeCost.Gold.ToString();
        gui.button_confirmUpgrade.onClick.RemoveAllListeners();
        gui.button_confirmUpgrade.onClick.AddListener(callback_ConfirmUpgrade);
        gui.button_goBackFromUpgrade.onClick.RemoveAllListeners();
        gui.button_goBackFromUpgrade.onClick.AddListener(callback_GoBackFromUpgrade);
    }

    void callback_CloseBuilt()
    {
        gui.dialogBox_Built.SetActive(false);
        gui.dialogbox_Main.SetActive(false);

        owner.IsAnyDialogBoxOpen = false;
    }

    void callback_GoToUpgrade()
    {
        if (owner.City.Owner.Resources >= building.UpgradeCost)
        {
            gui.button_confirmUpgrade.interactable = true;
        }
        else
        {
            gui.button_confirmUpgrade.interactable = false;
        }

        gui.dialogBox_Built.SetActive(false);
        gui.dialogBox_Upgrade.SetActive(true);
    }

    void callback_CloseUpgraded()
    {
        gui.dialogBox_Upgraded.SetActive(false);
        gui.dialogbox_Main.SetActive(false);

        owner.IsAnyDialogBoxOpen = false;
    }

    void callback_ConfirmUpgrade()
    {
        owner.City.Owner.Resources.SubtractResources(building.UpgradeCost);
        
        building.BuildingLevel = CityBuilding.Level.Upgraded;

        gameObject.GetComponent<MeshRenderer>().materials = buildingMaterial_Upgraded;

        gui.dialogBox_Upgrade.SetActive(false);
        gui.dialogBox_Upgraded.SetActive(true);
    }

    void callback_GoBackFromUpgrade()
    {
        gui.dialogBox_Upgrade.SetActive(false);
        gui.dialogBox_Built.SetActive(true);
    }
}
