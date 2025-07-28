using UnityEngine;
using System.Collections.Generic;



public class DataHolder : MonoBehaviour
{
    
    public static string currentType = "Ball type";
    public static GameObject currentObj = null;
    public static Texture textureType = null;
    public static Color color = Color.white;
    public static Camera Cam;
    public static Dictionary<string,int> countData = new Dictionary<string, int>();
    public static Dictionary<string,Material> groundData;
    public static Dictionary<string, Texture[]> textureList = new Dictionary<string, Texture[]>();
    public static bool conStatus = true;
    public static string IPaddress = "10.32.144.56";
    public static int port = 5500;

    public GameObject[] ballList;
    public GameObject[] waterList;
    public GameObject[] grassList;

    
    public Texture[] ballTextures;
    public Texture[] LeafTextures;
    public Texture[] FeatherTextures;
    public Texture[] grassTextures;


    private void Start()
    {
        Cam = Camera.main;
        conStatus = true;
        if (currentObj == null)
        {
            currentObj = ballList[0];
        }
        addDictionarys();
        if (textureType == null)
        {
           textureType = textureList[currentObj.name][0];
        }
        
    }

    private void addDictionarys()
    {
        countData.Clear();
        textureList.Clear();
        if (this.gameObject.name == "EventSystem")
        {
            countData.Add("ball", 400);
            countData.Add("Leaf 1", 600);
            countData.Add("Leaf 2", 600);
            countData.Add("feather", 600);
            countData.Add("Leaf 3", 600);
            countData.Add("petal", 600);
        }
        if (this.gameObject.name == "EventSystem")
        {

            textureList.Add("ball", ballTextures);
            textureList.Add("Leaf 1", LeafTextures);
            textureList.Add("Leaf 2", LeafTextures);
            textureList.Add("Leaf 3", LeafTextures);
            textureList.Add("feather", FeatherTextures);
            textureList.Add("petal", ballTextures);



            textureList.Add("grass1", grassTextures);
            textureList.Add("grass2", grassTextures);
        }
        
    }

    // Getters
    //public int colorLength()
    //{
    //   return colorList.Length;
    //}
    public int textureLength()
    {
        return textureList[currentObj.name].Length;
    }
    public int objLength()
    {

        if (currentType == "Ball type")
        {
            return ballList.Length;
        }
        if (currentType == "Grass type")
        {
            return grassList.Length;

        }
        if (currentType == "Water type")
        {
            return waterList.Length;
        }
        else
            return 5;

    }

}