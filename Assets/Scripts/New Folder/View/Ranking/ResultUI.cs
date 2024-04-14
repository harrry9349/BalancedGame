using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;
using static RankingUI;

public class ResultUI : MonoBehaviour
{
    [Serializable]
    public class Json
    {
        public string status;
        public Data[] data;
    }

    [Serializable]
    public class Data
    {
        public string id;
        public string name;
        public int score;
        public string date;
    }

    [SerializeField]
    public TextMeshProUGUI rankingText;

    [SerializeField]
    public TextMeshProUGUI resultText;

    [SerializeField]
    public Timer TimerObject;

    private int dataCount;

    private readonly int c_maxShowRank = 5;
    // Start is called before the first frame update
    void Start()
    {
        POSTScore();
        GETScore();
        ShowScore();
    }


    public void GETScore()
    {
        var req = WebRequest.Create("http://localhost:3000/Get");
        var res = req.GetResponse();

        using (Stream stm = res.GetResponseStream())
        using (StreamReader str = new StreamReader(stm))
        {
            string json = str.ReadToEnd();
            Debug.Log(json);

            Json j = JsonUtility.FromJson<Json>(json);
            dataCount = j.data.Length;

            string s = "result\n";

            for (int cnt = 0; cnt < c_maxShowRank; cnt++)
            {
                Data data = j.data[cnt];
                int rank = cnt + 1;
                float score = data.score / 60;
                s +="Rank " + rank + " :[" + data.name + "] Score:" + score + "\n";
            }

            rankingText.text = s;
        }
    }
    private void POSTScore()
    {
        var score = TimerObject.timerCountFrame;
        var username = TimerObject.userName;
        var wkdataCount = dataCount + 1;
        var userid = "a" + wkdataCount;
        var send = "{ \"id\":\" " + userid + " \" , \"action\" : \"ADD\" ,\"name\":\" " + username + " \" ,\"score\":\" "  + score+ "\"}";
        var bytes = System.Text.Encoding.UTF8.GetBytes(send);

        var req = WebRequest.Create("http://localhost:3000/Post");
        req.Method = "POST";
        req.ContentType = "application/json; charset=utf-8";
        req.ContentLength = bytes.Length;
        req.Timeout = 3000;

        Stream reqStm = req.GetRequestStream();
        reqStm.Write(bytes, 0, bytes.Length);

        var res = req.GetResponse();
        using (Stream stm = res.GetResponseStream())
        using (StreamReader str = new StreamReader(stm))
        {
            string json = str.ReadToEnd();
            Debug.Log(json);
        }

        Debug.Log("Send POST:" + bytes.Length);

        reqStm.Close();
        res.Close();

    }

    private void ShowScore()
    {
        float cnt = TimerObject.timerCountFrame / 60;
        string s = cnt.ToString();
        resultText.text = s;
    }
}
