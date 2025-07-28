using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public GameObject[] enviroment;

    private GameObject UI2;
    private GameObject UI3;
    private int enviromentNum;
    private TextMesh currentType;
    private TextMesh texture;
    private TextMesh obj;
    private float maxlength;
    private GameObject sampleObj;
    private GameObject blocker;
    private DataHolder data;
    private Renderer[] currEdit;

    private int intR, intG, intB, intA;

    void Start()
    {
        intR = int.Parse(GameObject.Find("modelColorR").GetComponents<TextMesh>()[0].text);
        intG = int.Parse(GameObject.Find("modelColorG").GetComponents<TextMesh>()[0].text);
        intB = int.Parse(GameObject.Find("modelColorB").GetComponents<TextMesh>()[0].text);
        intA = int.Parse(GameObject.Find("modelColorA").GetComponents<TextMesh>()[0].text);
        DataHolder.color = new Color32((byte)intR, (byte)intG, (byte)intB, (byte)intA);

        UI2 = GameObject.Find("UI2");
        UI3 = GameObject.Find("UI3");
        UI3.SetActive(false);


        enviromentNum = 0;
        currentType = GameObject.Find("selected").GetComponents<TextMesh>()[0];
        texture = GameObject.Find("modelTexture").GetComponents<TextMesh>()[0];
        obj = GameObject.Find("modelNum").GetComponents<TextMesh>()[0];
        data = GameObject.Find("EventSystem").GetComponent<DataHolder>();
        blocker = GameObject.Find("blockScreen");

        if (blocker != null)
        {
            blocker.SetActive(false);
        }

        reload();
    }
    private void Update()
    {

        intR = int.Parse(GameObject.Find("modelColorR").GetComponents<TextMesh>()[0].text);
        intG = int.Parse(GameObject.Find("modelColorG").GetComponents<TextMesh>()[0].text);
        intB = int.Parse(GameObject.Find("modelColorB").GetComponents<TextMesh>()[0].text);
        intA = int.Parse(GameObject.Find("modelColorA").GetComponents<TextMesh>()[0].text);

        if (DataHolder.color != new Color32((byte)intR, (byte)intG, (byte)intB, (byte)intA))
        {
            DataHolder.color = new Color32((byte)intR, (byte)intG, (byte)intB, (byte)intA);
            reload();
        }
    }

    public void updateData()
    {

        DataHolder.textureType = DataHolder.textureList[DataHolder.currentObj.name][int.Parse(texture.text) - 1];
        DataHolder.currentType = currentType.text;
        if (currentType.text == "Ball type")
        {
            DataHolder.currentObj = data.ballList[int.Parse(obj.text) - 1];
        }
        if (currentType.text == "Grass type") {
            DataHolder.currentObj = data.grassList[int.Parse(obj.text) - 1];
        }
        if (currentType.text == "Water type") {
            DataHolder.currentObj = data.waterList[int.Parse(obj.text) - 1];
        }
        
    }

    public void OnSaveClick(string ip, int port)
    {
        DataHolder.IPaddress = ip;
        DataHolder.port = port;
        UI2.transform.position += Vector3.up * 25;
        UI3.SetActive(false);
    }
    public void OnCancelClick()
    {
        UI2.transform.position += Vector3.up * 25;
        UI3.SetActive(false);
    }
    public void OnConfigClick()
    {
        UI2.transform.position -= Vector3.up * 25; ;
        UI3.SetActive(true);
    }

    public void OnCRandomClick()
    {
        Random ran = new Random();

        GameObject.Find("modelColorR").GetComponents<TextMesh>()[0].text = Random.Range(0, 255) + "";
        GameObject.Find("modelColorG").GetComponents<TextMesh>()[0].text = Random.Range(0, 255) + "";
        GameObject.Find("modelColorB").GetComponents<TextMesh>()[0].text = Random.Range(0, 255) + "";
        GameObject.Find("modelColorA").GetComponents<TextMesh>()[0].text = Random.Range(0, 255) + "";

        GameObject.Find("SlidersR").GetComponentInChildren<sliding>().setSlider();
        GameObject.Find("SlidersG").GetComponentInChildren<sliding>().setSlider();
        GameObject.Find("SlidersB").GetComponentInChildren<sliding>().setSlider();
        GameObject.Find("SlidersA").GetComponentInChildren<sliding>().setSlider();



    }

    public void OnThemeClick()
    {
        Destroy(GameObject.Find("Enviroment"));
        var newEnviroment = Instantiate(enviroment[enviromentNum]);
        newEnviroment.transform.name = "Enviroment";
        enviromentNum++;
        if(enviromentNum == enviroment.Length)
        {
            enviromentNum = 0;
        }
    }

    public void resetNumbers()
    {
        texture.text = 1 +"";
        obj.text = 1+ "";
    }


    public void OnBallClick()
    {
        currentType.text = "Ball type";
        resetNumbers();
        if (blocker != null)
        {
            blocker.SetActive(false);
        }
        updateData();
        reload();
    }
    public void OnGrassClick()
    {
        currentType.text = "Grass type";
        resetNumbers();
        if (blocker != null)
        {
            blocker.SetActive(true);
        }
        updateData();
        reload();
    }
    public void OnWaterClick()
    {
        currentType.text = "Water type";
        resetNumbers();
        if (blocker != null)
        {
            blocker.SetActive(false);
        }
        updateData();
        reload();
    }

    //public void OnColorLeftClick()
    //{
    //    if(int.Parse(color.text) > 1)
    //    {
    //        color.text = ""+(int.Parse(color.text) - 1);
    //    }
    //    else
    //    {
    //        color.text = "1";
    //    }
    //    updateData();
    //    reload();
    //}
    //public void OnColorRightClick()
    //{
    //    if (int.Parse(color.text) < data.colorLength())
    //    {
    //        color.text = "" + (int.Parse(color.text) + 1);
    //    }
    //    else
    //    {
    //        color.text = data.colorLength() + "";
    //    }
    //    updateData();
    //    reload();
    //}

    public void OnTextureLeftClick()
    {
        if (int.Parse(texture.text) > 1 && int.Parse(texture.text) < data.textureLength())
        {
            texture.text = "" + (int.Parse(texture.text) - 1);
        }
        else
        {
            texture.text = "1";
        }
        updateData();
        reload();
    }
    public void OnTextureRightClick()
    {
        if (int.Parse(texture.text) < data.textureLength())
        {
            texture.text = "" + (int.Parse(texture.text) + 1);
        }
        else
        {
            texture.text = data.textureLength() + "";
        }
        updateData();
        reload();
    }

    public void OnObjLeftClick()
    {
        if (int.Parse(obj.text) > 1)
        {
            obj.text = "" + (int.Parse(obj.text) - 1);
        }
        else
        {
            obj.text = "1";
        }
        updateData();
        reload();
    }
    public void OnObjRightClick()
    {
        if (int.Parse(obj.text) < data.objLength())
        {
            obj.text = "" + (int.Parse(obj.text) + 1);
        }
        else
        {
            obj.text = data.objLength() + "";
        }
        updateData();
        reload();
    }
    
    public void OnStartClick()
    {
        SceneManager.LoadScene("Simulation");
    }

    public void reload()
    {
        Destroy(sampleObj);
        GameObject.Find("casin").transform.rotation = new Quaternion(0, 0, 0, 0);

        if (currentType.text == "Ball type")
        {
            sampleObj = Instantiate(DataHolder.currentObj, GameObject.Find("casin").transform.position + DataHolder.currentObj.transform.position, DataHolder.currentObj.transform.rotation, GameObject.Find("casin").transform);
            sampleObj.transform.localScale = new Vector3(2.2f,2.2f, 2.2f);

            if (sampleObj.GetComponents<Renderer>().Length > 0)
            {
                currEdit = sampleObj.GetComponents<Renderer>();
            }
            else
            {
                currEdit = sampleObj.GetComponentsInChildren<Renderer>();
            }

            if (currEdit.Length >= 1)
            {
                for (int i = 0; i < currEdit.Length; i++)
                {
                    for (int j = 0; j < currEdit[i].materials.Length; j++)
                    {
                        currEdit[i].materials[j].mainTexture = DataHolder.textureType;
                        currEdit[i].materials[j].SetColor("_Color", DataHolder.color);
                        currEdit[i].materials[j].EnableKeyword("_ALPHAPREMULTIPLY_ON");
                    }
                }
            }

            sampleObj.GetComponent<selfDestroyBall>().enabled = false;
            sampleObj.GetComponent<Rigidbody>().useGravity = false;
            sampleObj.transform.name = "sample";
        }
        if (currentType.text == "Grass type")
        {
            sampleObj = Instantiate(DataHolder.currentObj,GameObject.Find("casin").transform);
            GameObject.Find("casin").transform.localScale = new Vector3(1f, 1f, 1f);

            for (int i = 0; i < sampleObj.GetComponentsInChildren<Animator>().Length; i++)
            {
                sampleObj.GetComponentsInChildren<Animator>()[i].enabled = false;
            }

            if (sampleObj.GetComponents<Renderer>().Length > 0)
            {
                currEdit = sampleObj.GetComponents<Renderer>();
            }
            else
            {
                currEdit = sampleObj.GetComponentsInChildren<Renderer>();
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
            sampleObj.transform.name = "sample";
        }

    }
    public void callCameras()
    {
        Destroy(GameObject.Find("sample"));
    }


}
