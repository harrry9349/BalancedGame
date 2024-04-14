using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using TMPro;

public class RankingUI : MonoBehaviour
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
    public TextMeshProUGUI text;
    public void OnPushGET()
    {
        var req = WebRequest.Create("http://localhost:3000/Get");
        var res = req.GetResponse();

        using (Stream stm = res.GetResponseStream())
        using (StreamReader str = new StreamReader(stm))
        {
            string json = str.ReadToEnd();
            Debug.Log(json);

            Json j = JsonUtility.FromJson<Json>(json);

            string s = "result\n";
            foreach (Data data in j.data)
            {
                s += "[" + data.name + "] Score:" + data.score + "\n";
            }
             text.text = s;
        }
    }

    public void OnPushPOST()
    {
        var send = "{ \"id\":\"a004\" , \"action\" : \"ADD\" ,\"name\":\"MyUser\" ,\"score\": 35000 }";
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

}
