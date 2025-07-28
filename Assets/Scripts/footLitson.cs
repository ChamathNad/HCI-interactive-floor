//using UnityEngine;
//using LitJson;
//using System.Collections.Generic;
//using System;
//using System.Collections;
//using UnityEngine.UI;
//using UnityEngine.Networking;

//public class footLitson : MonoBehaviour
//{
//    public GameObject foot;
//    public GameObject grass;
//    public Text currentType;

//    private Vector3 position;
//    private List<Vector3> positionList = new List<Vector3>();

//    public class parseJSON
//    {
//        public string xValue;
//        public string yValue;
//        public string height;
//        public string width;
//        public ArrayList but_title;
//        public ArrayList but_image;
//    }
//    IEnumerator Start()
//    {
//        while (true)
//        {
//            string url = "http://10.32.145.92:3000/";
//            WWW www = new WWW(url);
//            yield return www;
//            if (www.error == null)
//            {
//                Processjson(www.text);
//            }
//            else
//            {
//                Debug.Log("ERROR: " + www.error);
//            }
//            yield return new WaitForSeconds(0.1f);
//        }
//    }
//    private void Processjson(string jsonString)
//    {
//        JsonData jsonvale = JsonMapper.ToObject(jsonString);
//        parseJSON parsejson;
//        parsejson = new parseJSON();
//        parsejson.xValue = jsonvale["xVal"].ToString();
//        parsejson.yValue = jsonvale["yVal"].ToString();
//        parsejson.height = jsonvale["height"].ToString();
//        parsejson.width = jsonvale["width"].ToString();

//        Debug.Log(parsejson.xValue + "," + parsejson.yValue);
//        Debug.Log(parsejson.height + "," + parsejson.width);

//        if (currentType.text == "Ball type")
//        {
//            spawnfoot(int.Parse(parsejson.xValue), int.Parse(parsejson.yValue), int.Parse(parsejson.width));
//        }
//        if (currentType.text == "Grass type")
//        {
//            spawnGrass(int.Parse(parsejson.xValue), int.Parse(parsejson.yValue), int.Parse(parsejson.width));
//        }
//    }

//    private void spawnfoot(float xVal, float yVal, float w)
//    {
//        position = new Vector3(xVal, 4, yVal);
//        var newfoot = Instantiate(foot, position, Quaternion.identity);
//        newfoot.transform.localScale = new Vector3(w,w,w);
//    }

//    private void spawnGrass(float xVal, float yVal, float w)
//    {
//        position = new Vector3((int)xVal, - 6, (int)yVal);
//        if (!positionList.Contains(position)){
//            positionList.Add(position);
//            var newgrass = Instantiate(grass, position, Quaternion.identity);
//            newgrass.transform.localScale = new Vector3(w, w, w);
//        }
//    }
//}
