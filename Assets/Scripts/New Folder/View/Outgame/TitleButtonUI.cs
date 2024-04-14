using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonUI : MonoBehaviour
{
    public void OnPushStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnPushQuit()
    {
        Application.Quit();
    }


    public void OnPushRanking()
    {
        SceneManager.LoadScene("RankingScene");
    }


}
