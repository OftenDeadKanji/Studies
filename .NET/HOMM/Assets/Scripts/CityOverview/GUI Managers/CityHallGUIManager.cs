using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityHallGUIManager : MonoBehaviour
{
    public GameObject dialogbox_Main;
    public TMPro.TMP_Text buildingName;

    public GameObject dialogBox_Built;
    public TMPro.TMP_Text text_profitValue_Built;
    public Button button_close_Built;
    public Button button_goToUpgrade;

    public GameObject dialogBox_Upgraded;
    public TMPro.TMP_Text text_profitValue_Upgraded;
    public Button button_close_Upgraded;

    public GameObject dialogBox_Upgrade;
    public TMPro.TMP_Text text_goldProfitFrom;
    public TMPro.TMP_Text text_goldProfitTo;
    public TMPro.TMP_Text text_costGoldValue;
    public Button button_confirmUpgrade;
    public Button button_goBackFromUpgrade;
}
