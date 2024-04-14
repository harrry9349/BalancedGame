using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;

public class GetRankingUI : MonoBehaviour
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

    private readonly int c_maxShowRank = 5;

    // Start is called before the first frame update
    void Start()
    {
        GETScore();
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

            string s = "Ranking\n";

            for (int cnt = 0; cnt < c_maxShowRank; cnt++)
            {
                Data data = j.data[cnt];
                int rank = cnt + 1;
                float score = data.score / 60;
                s += "Rank " + rank + " :[" + data.name + "] Score:" + score + "\n";
            }

            rankingText.text = s;
        }
    }
}
