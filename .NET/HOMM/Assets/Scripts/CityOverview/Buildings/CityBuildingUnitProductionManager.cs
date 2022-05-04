using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityBuildingUnitProductionManager : MonoBehaviour
{
    [SerializeField]
    CityOverviewManager owner = null;

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
    MeshRenderer meshRenderer;

    [SerializeField]
    Material[] buildingMaterial_NotExisting;
    [SerializeField]
    Material[] buildingMaterial_Built;
    [SerializeField]
    Material[] buildingMaterial_Upgraded;

    [SerializeField]
    UnitProductionGUIManager gui;

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        if (outline == null)
        {
            throw new Exception("outline component not found!");
        }

        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            throw new Exception("meshRenderer component not found!");
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

        if(gui == null)
        {
            throw new Exception("unitProductionGUIManager (gui) is null!");
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
        if (!owner.IsAnyDialogBoxOpen)
        {
            PrepareGUI();

            gui.dialogBox_Main.SetActive(true);
            if(building.BuildingLevel == CityBuilding.Level.NotExisting)
            {
                gui.dialogBox_MainMenu_NotExisting.SetActive(true);
            }
            else if(building.BuildingLevel == CityBuilding.Level.Built)
            {
                gui.dialogBox_MainMenu_Built.SetActive(true);
            }
            else
            {
                gui.dialogBox_MainMenu_Upgraded.SetActive(true);
            }

            owner.IsAnyDialogBoxOpen = true;
            outline.OutlineWidth = 0.0f;
        }
    }

    void PrepareGUI()
    {
        gui.buildingName.text = this.buldingType.ToString() + " units building";

        gui.goToBuild_NotExisting.onClick.RemoveAllListeners();
        gui.goToBuild_NotExisting.onClick.AddListener(callback_GoToBuild);
        gui.closeMainMenu_NotExisting.onClick.RemoveAllListeners();
        gui.closeMainMenu_NotExisting.onClick.AddListener(callback_closeMainMenu_NotExisting);

        gui.closeMainMenu_Built.onClick.RemoveAllListeners();
        gui.closeMainMenu_Built.onClick.AddListener(callback_closeMainMenu_Built);
        gui.goToUpgrade_Built.onClick.RemoveAllListeners();
        gui.goToUpgrade_Built.onClick.AddListener(callback_goToUpgrade_Built);
        gui.goToRecruit_Built.onClick.RemoveAllListeners();
        gui.goToRecruit_Built.onClick.AddListener(callback_goToRecruit_Built);

        gui.closeMainMenu_Upgraded.onClick.RemoveAllListeners();
        gui.closeMainMenu_Upgraded.onClick.AddListener(callback_closeMainMenu_Upgraded);
        gui.goToRecruit_Upgraded.onClick.RemoveAllListeners();
        gui.goToRecruit_Upgraded.onClick.AddListener(callback_goToRecruit_Upgraded);

        gui.confirmBuild.onClick.RemoveAllListeners();
        gui.confirmBuild.onClick.AddListener(callback_confirmBuild);
        gui.backFromBuild.onClick.RemoveAllListeners();
        gui.backFromBuild.onClick.AddListener(callback_backFromBuild);
        gui.cost_gold_Build.text = building.BuildingCost.Gold.ToString();
        gui.cost_wood_Build.text = building.BuildingCost.Wood.ToString();
        gui.cost_stone_Build.text = building.BuildingCost.Stone.ToString();
        gui.profit_unitsName_Build.text = building.BuildingType.ToString();
        gui.profit_unitsFrom_Build.text = "0";
        gui.profit_unitsTo_Build.text = building.MaxRecruted.ToString();

        gui.confirmUpgrade.onClick.RemoveAllListeners();
        gui.confirmUpgrade.onClick.AddListener(callback_confirmUpgrade);
        gui.backFromUpgrade.onClick.RemoveAllListeners();
        gui.backFromUpgrade.onClick.AddListener(callback_backFromUpgrade);
        gui.cost_gold_Upgrade.text = building.UpgradeCost.Gold.ToString();
        gui.cost_wood_Upgrade.text = building.UpgradeCost.Wood.ToString();
        gui.cost_stone_Upgrade.text = building.UpgradeCost.Stone.ToString();
        gui.profit_unitsName_Upgrade.text = building.BuildingType.ToString() + " -> upgraded";
        gui.profit_unitsFrom_Upgrade.text = "0";
        gui.profit_unitsTo_Upgrade.text = building.MaxUpgradedRecruted.ToString();

        gui.confirmRecruit.onClick.RemoveAllListeners();
        gui.confirmRecruit.onClick.AddListener(callback_confirmRecruit);
        gui.backFromRecruit.onClick.RemoveAllListeners();
        gui.backFromRecruit.onClick.AddListener(callback_backFromRecruit);
        gui.recruit_slider.onValueChanged.RemoveAllListeners();
        gui.recruit_slider.onValueChanged.AddListener(callback_SliderValueChanged);
        gui.recruit_slider.value = 0;
        gui.recruit_gold.text = "0";
        gui.recruit_unitsName.text = building.BuildingType.ToString() + (building.BuildingLevel == CityBuilding.Level.Built ? "" : " upgraded");
    }

    #region MainMenu NotExisting
    void callback_GoToBuild()
    {
        var player = owner.City.Owner;
        if(player.Resources >= building.BuildingCost)
        {
            gui.confirmBuild.interactable = true;
        }
        else
        {
            gui.confirmBuild.interactable = false;
        }

        gui.dialogBox_MainMenu_NotExisting.SetActive(false);
        gui.dialogBox_Build.SetActive(true);
    }
    void callback_closeMainMenu_NotExisting()
    {
        gui.dialogBox_Main.SetActive(false);
        gui.dialogBox_MainMenu_NotExisting.SetActive(false);

        owner.IsAnyDialogBoxOpen = false;
    }
    #endregion

    #region MainMenu Built
    void callback_closeMainMenu_Built()
    {
        gui.dialogBox_MainMenu_Built.SetActive(false);
        gui.dialogBox_Main.SetActive(false);

        owner.IsAnyDialogBoxOpen = false;
    }
    void callback_goToUpgrade_Built()
    {
        var player = owner.City.Owner;
        if (player.Resources >= building.UpgradeCost)
        {
            gui.confirmUpgrade.interactable = true;
        }
        else
        {
            gui.confirmUpgrade.interactable = false;
        }

        gui.dialogBox_MainMenu_Built.SetActive(false);
        gui.dialogBox_Upgrade.gameObject.SetActive(true);
    }
    void callback_goToRecruit_Built()
    {
        gui.dialogBox_MainMenu_Built.SetActive(false);
        gui.dialogBox_Recruit.SetActive(true);

        int currentMax = building.BuildingLevel == CityBuilding.Level.Built ? building.MaxRecruted : building.MaxUpgradedRecruted;
        int newMax = currentMax - building.RecrutedThisTurn;
        gui.recruit_unitsTo.text = newMax.ToString();
        gui.recruit_slider.maxValue = newMax;
    }
    #endregion

    #region MainMenu Upgraded
    void callback_closeMainMenu_Upgraded()
    {
        gui.dialogBox_Main.SetActive(false);
        gui.dialogBox_MainMenu_Upgraded.SetActive(false);

        owner.IsAnyDialogBoxOpen = false;
    }

    void callback_goToRecruit_Upgraded()
    {
        gui.dialogBox_MainMenu_Upgraded.SetActive(false);
        gui.dialogBox_Recruit.SetActive(true);

        int currentMax = building.BuildingLevel == CityBuilding.Level.Built ? building.MaxRecruted : building.MaxUpgradedRecruted;
        int newMax = currentMax - building.RecrutedThisTurn;
        gui.recruit_unitsTo.text = newMax.ToString();
        gui.recruit_slider.maxValue = newMax;
    }
    #endregion

    #region Build
    void callback_confirmBuild()
    {
        building.BuildingLevel = CityBuilding.Level.Built;

        var player = owner.City.Owner;
        player.Resources.SubtractResources(building.BuildingCost);
        gameObject.GetComponent<MeshRenderer>().materials = buildingMaterial_Built;

        if(player.Resources >= building.UpgradeCost)
        {
            gui.confirmUpgrade.interactable = true;
        }
        else
        {
            gui.confirmUpgrade.interactable = false;
        }

        gui.dialogBox_Build.SetActive(false);
        gui.dialogBox_Upgrade.SetActive(true);
    }

    void callback_backFromBuild()
    {
        gui.dialogBox_Build.SetActive(false);
        gui.dialogBox_MainMenu_NotExisting.SetActive(true);
    }
    #endregion

    #region Upgrade
    void callback_confirmUpgrade()
    {
        building.BuildingLevel = CityBuilding.Level.Upgraded;

        var player = owner.City.Owner;
        player.Resources.SubtractResources(building.UpgradeCost);
        gameObject.GetComponent<MeshRenderer>().materials = buildingMaterial_Upgraded;

        gui.dialogBox_Upgrade.SetActive(false);
        gui.dialogBox_MainMenu_Upgraded.SetActive(true);
    }
    void callback_backFromUpgrade()
    {
        gui.dialogBox_Upgrade.SetActive(false);
        gui.dialogBox_MainMenu_Built.SetActive(true);
    }
    #endregion

    #region Recruit
    void callback_confirmRecruit()
    {
        if (gui.recruit_slider.value > 0)
        {
            UnitType unitType = building.GetCompatibleUnitTypeToBuilding();
            int count = (int)gui.recruit_slider.value;

            if (!owner.City.Inside.IsFull())
            {
                Resources cost = (int)gui.recruit_slider.value * building.GetRecruitCost();
                owner.City.Owner.Resources.SubtractResources(cost);

                building.RecrutedThisTurn += count;

                int currentMax = building.BuildingLevel == CityBuilding.Level.Built ? building.MaxRecruted : building.MaxUpgradedRecruted;
                int newMax = currentMax - building.RecrutedThisTurn;
                gui.recruit_unitsTo.text = newMax.ToString();
                gui.recruit_slider.maxValue = newMax;

                gui.recruit_slider.value = 0;

                foreach (var unitformation in owner.City.Inside.UnitFormations)
                {
                    if (unitformation != null)
                    {
                        if (unitformation.Unit.Type == unitType)
                        {
                            unitformation.Count += count;

                            owner.UpdateGarrision();

                            return;
                        }
                    }
                }

                owner.City.Inside.TryToAddUnitFormation(new UnitFormation(Unit.CreateUnitOfTypeAndFaction(unitType), count));
                owner.UpdateGarrision();
            }
            else
            {
                //not enough space in city
            }
        }
    }
    void callback_backFromRecruit()
    {
        gui.recruit_slider.value = 0.0f;
        gui.dialogBox_Recruit.SetActive(false);

        if(building.BuildingLevel == CityBuilding.Level.Built)
        {
            gui.dialogBox_MainMenu_Built.SetActive(true);
        }
        else
        {
            gui.dialogBox_MainMenu_Upgraded.SetActive(true);
        }
    }

    public void callback_SliderValueChanged(float value)
    {
        var player = owner.City.Owner;
        UnitType unitType = building.GetCompatibleUnitTypeToBuilding();

        if (player.Resources >= (int)value * building.GetRecruitCost())
        {
            gui.recruit_gold.text = ((int)value * building.GetRecruitCost()).Gold.ToString();
        }
        else
        {
            gui.recruit_slider.value = value - 1;
        }
    }
    #endregion
}
