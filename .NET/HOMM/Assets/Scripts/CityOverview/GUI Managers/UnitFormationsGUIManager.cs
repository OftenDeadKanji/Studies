using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitFormationsGUIManager : MonoBehaviour
{
    public Image heroInsideImage;
    public Image[] unitsInside = new Image[10];
    public TMPro.TMP_Text[] unitsInsideCount = new TMPro.TMP_Text[10];
    public Image heroOutsideImage;
    public Image[] unitsOutside = new Image[10];
    public TMPro.TMP_Text[] unitsOutsideCount = new TMPro.TMP_Text[10];
}
