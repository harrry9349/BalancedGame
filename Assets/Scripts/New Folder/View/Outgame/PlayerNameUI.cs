using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameUI : MonoBehaviour
{
    [SerializeField]
    public Timer timer;

    private void Start()
    {
        timer.userName = "Player";
    }
    public void SetInputName()
    {
        TMP_InputField inputField = GetComponent<TMP_InputField>();
        string name = inputField.text;
        timer.userName = name;
    }
}
