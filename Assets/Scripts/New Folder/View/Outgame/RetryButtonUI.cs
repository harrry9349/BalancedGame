using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButtonUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnPushRetry()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
