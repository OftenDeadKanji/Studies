using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitProductionGUIManager : MonoBehaviour
{
    [Header("GUI")]
    public GameObject dialogBox_Main;
    public TMPro.TMP_Text buildingName;

    [Header("GUI MainMenu NotExisting")]
    public GameObject dialogBox_MainMenu_NotExisting;
    public Button closeMainMenu_NotExisting;
    public Button goToBuild_NotExisting;

    [Header("GUI MainMenu Built")]
    public GameObject dialogBox_MainMenu_Built;
    public Button closeMainMenu_Built;
    public Button goToUpgrade_Built;
    public Button goToRecruit_Built;

    [Header("GUI MainMenu Upgraded")]
    public GameObject dialogBox_MainMenu_Upgraded;
    public Button closeMainMenu_Upgraded;
    public Button goToRecruit_Upgraded;

    [Header("GUI Build")]
    public GameObject dialogBox_Build;
    public TMPro.TMP_Text cost_gold_Build;
    public TMPro.TMP_Text cost_wood_Build;
    public TMPro.TMP_Text cost_stone_Build;
    public TMPro.TMP_Text profit_unitsName_Build;
    public TMPro.TMP_Text profit_unitsFrom_Build;
    public TMPro.TMP_Text profit_unitsTo_Build;
    public Button confirmBuild;
    public Button backFromBuild;

    [Header("GUI Upgrade")]
    public GameObject dialogBox_Upgrade;
    public TMPro.TMP_Text cost_gold_Upgrade;
    public TMPro.TMP_Text cost_wood_Upgrade;
    public TMPro.TMP_Text cost_stone_Upgrade;
    public TMPro.TMP_Text profit_unitsName_Upgrade;
    public TMPro.TMP_Text profit_unitsFrom_Upgrade;
    public TMPro.TMP_Text profit_unitsTo_Upgrade;
    public Button confirmUpgrade;
    public Button backFromUpgrade;

    [Header("GUI Recruit")]
    public GameObject dialogBox_Recruit;
    public TMPro.TMP_Text recruit_gold;
    public TMPro.TMP_Text recruit_unitsName;
    public TMPro.TMP_Text recruit_unitsFrom;
    public TMPro.TMP_Text recruit_unitsTo;
    public Slider recruit_slider;
    public Button confirmRecruit;
    public Button backFromRecruit;
}
