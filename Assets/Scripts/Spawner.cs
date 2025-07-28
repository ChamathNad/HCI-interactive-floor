using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject foot;
    private Vector3 position;
    private List<Vector3> positionList = new List<Vector3>();
    private float scaler = 1f;
    private int objectCount;
    private Renderer [] currEdit;


    void Start()
    {

        Debug.Log(DataHolder.currentType);
        if (DataHolder.currentType == "Ball type")
        {
            spawnTheBalls(this.gameObject.transform.localScale.z);
        }
    }


    void Update()
    {

    }


    public void spawner(string text)
    {
        string[] data = text.Split(':');
        Debug.Log(data[1].Substring(0, 4) + " " + data[2].Substring(0, 4)); 

        if (DataHolder.currentType == "Ball type" && data.Length > 2)
        {
            spawnfoot(float.Parse(data[1].Substring(0,4))/10, float.Parse(data[2].Substring(0, 4)) / 10, 1f);
        }
        if (DataHolder.currentType == "Grass type" && data.Length > 2)
        {
            spawnGrass(float.Parse(data[1].Substring(0, 4)) / 10, float.Parse(data[2].Substring(0, 4)) / 10, 2f);
        }
        if (DataHolder.currentType == "Water type" && data.Length > 2)
        {

        }
    }
    //GRASS FUNCTIONS
    //For the network spawner
    public void spawnfoot(float xVal, float yVal, float w)
    {
        position = new Vector3(yVal * scaler, 2, xVal * scaler);
        var newfoot = Instantiate(foot, position, Quaternion.identity);
        newfoot.transform.localScale = new Vector3(w, w, w);
    }
    //for the Mouse Click spawner
    public void spawnfoot(float xVal, float yVal, float zVal, float w)
    {
        position = new Vector3(xVal * scaler, yVal, zVal);
        var newfoot = Instantiate(foot, position, Quaternion.identity);
        newfoot.transform.localScale = new Vector3(w, w, w);
    }

    //GRASS FUNCTIONS
    //For the network spawner
    public void spawnGrass(float xVal, float yVal, float w)
    {

        Debug.Log("Passed");
        position = new Vector3((int)yVal * scaler, 0, (int)xVal * scaler);
        if (!positionList.Contains(position))
        {
            positionList.Add(position);
            var newgrass = Instantiate(DataHolder.currentObj, position, Quaternion.identity);
            newgrass.transform.localScale = new Vector3(w, w, w);
            if (newgrass.GetComponents<Renderer>().Length > 0)
            {
                currEdit = newgrass.GetComponents<Renderer>();
            }
            else
            {
                currEdit = newgrass.GetComponentsInChildren<Renderer>();
            }

            if (currEdit.Length > 1)
            {
                for (int i = 0; i < currEdit.Length; i++)
                {
                    currEdit[i].material.mainTexture = DataHolder.textureType;
                    currEdit[i].material.SetColor("_Color", DataHolder.color);
                    currEdit[i].material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                }
            }
        }
    }
    //for the Mouse Click spawner
    public void spawnGrass(float xVal, float yVal, float zVal, float w)
    {
        position = new Vector3((int)xVal, (int)yVal, (int)zVal);
        if (!positionList.Contains(position))
        {
            positionList.Add(position);
            var newgrass = Instantiate(DataHolder.currentObj, position, Quaternion.identity);
            newgrass.transform.localScale = new Vector3(w, w, w);

            if (newgrass.GetComponents<Renderer>().Length > 0)
            {
                currEdit = newgrass.GetComponents<Renderer>();
            }
            else
            {
                currEdit = newgrass.GetComponentsInChildren<Renderer>();
            }

            if (currEdit.Length > 1)
            {
                for (int i = 0; i < currEdit.Length; i++)
                {
                    currEdit[i].material.mainTexture = DataHolder.textureType;
                    currEdit[i].material.SetColor("_Color", DataHolder.color);
                    currEdit[i].material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                }
            }

        }
    }
    //Ball Spawner
    public void spawnTheBalls(float maxlength)
    {
        objectCount = DataHolder.countData[DataHolder.currentObj.name];
        for (int i = 1; i <= objectCount; i++)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(0, maxlength / 2), 2, UnityEngine.Random.Range(0, maxlength));
            var newBall = Instantiate(DataHolder.currentObj, position, Quaternion.identity);

            if (newBall.GetComponents<Renderer>().Length > 0)
            {
                currEdit = newBall.GetComponents<Renderer>();
            }
            else
            {
                currEdit = newBall.GetComponentsInChildren<Renderer>();
            }

            if (currEdit.Length > 0)
            {
                for (int j = 0; j < currEdit.Length; j++)
                {
                    for (int k = 0; k < currEdit[j].materials.Length; k++)
                    {
                        currEdit[j].materials[k].mainTexture = DataHolder.textureType;
                        currEdit[j].materials[k].SetColor("_Color", DataHolder.color);
                        currEdit[j].materials[k].EnableKeyword("_ALPHAPREMULTIPLY_ON");
                    }
                }
            }

            Instantiate(newBall);
        }
    }
}
