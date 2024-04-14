using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI text;


    public void UpdateTimeText(string str)
    {
        text.text = str;
    }
}
