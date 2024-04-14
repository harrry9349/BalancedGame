using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    public Timer timer;

    public TimerUI timerUI;
    private int CONST_FRAME = 60;

    // Start is called before the first frame update
    void Start()
    {
        InitializeTimer();
    }

    // Update is called once per frame
    void Update()
    {
        CountTimeFrame();
        timerUI.UpdateTimeText(GetTimeSecond());
    }
    private void InitializeTimer()
    {
        timer.timerCountSecond = 0;
        timer.timerCountFrame = 0;
    }

    private void ConvertFrameToSecond()
    {
        timer.timerCountSecond = timer.timerCountFrame / CONST_FRAME;
    }

    public void CountTimeFrame()
    {
        timer.timerCountFrame++;
        ConvertFrameToSecond();
    }

    public string GetTimeSecond()
    {
        return timer.timerCountSecond.ToString();
    }
}
