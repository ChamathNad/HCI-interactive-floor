using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnControl : MonoBehaviour
{
    public GameObject normal;
    public GameObject overred;
    public GameObject clicked;

    private buttons scrt;

    private void Start()
    {
        scrt = GameObject.Find("EventSystem").GetComponent<buttons>();

    }

    

    private void OnMouseEnter()
    {
        overred.SetActive(true);
        normal.SetActive(false);
        GameObject.Find("modelCount").GetComponents<TextMesh>()[0].text = GameObject.Find("EventSystem").GetComponent<DataHolder>().objLength() + " Models Available";
        GameObject.Find("textureCount").GetComponents<TextMesh>()[0].text = GameObject.Find("EventSystem").GetComponent<DataHolder>().textureLength() + " Textures Available";

    }
    private void OnMouseExit()
    {
        normal.SetActive(true);
        overred.SetActive(false);
        GameObject.Find("modelCount").GetComponents<TextMesh>()[0].text = GameObject.Find("EventSystem").GetComponent<DataHolder>().objLength() + " Models Available";
        GameObject.Find("textureCount").GetComponents<TextMesh>()[0].text = GameObject.Find("EventSystem").GetComponent<DataHolder>().textureLength() + " Textures Available";

    }
    private void OnMouseDown()
    {
        clicked.SetActive(true);
        overred.SetActive(false);

        GameObject.Find("modelCount").GetComponents<TextMesh>()[0].text = GameObject.Find("EventSystem").GetComponent<DataHolder>().objLength() + " Models Available";
        GameObject.Find("textureCount").GetComponents<TextMesh>()[0].text = GameObject.Find("EventSystem").GetComponent<DataHolder>().textureLength() + " Textures Available";


        if (this.name == "Format1")
        {
            scrt.OnBallClick();
        }
        if (this.name == "Format2")
        {
            scrt.OnGrassClick();
        }
        if (this.name == "Format3")
        {
            scrt.OnWaterClick();
        }
        if (this.name == "leftModel")
        {
            scrt.OnObjLeftClick();
        }
        if (this.name == "rightModel")
        {
            scrt.OnObjRightClick();
        }
        if (this.name == "colorrandom")
        {
            scrt.OnCRandomClick();
        }
        if (this.name == "theme")
        {
            scrt.OnThemeClick();
        }
        if (this.name == "Config")
        {
            scrt.OnConfigClick();
        }
        if (this.name == "leftTexture")
        {
            scrt.OnTextureLeftClick();
        }
        if (this.name == "rightTexture")
        {
            scrt.OnTextureRightClick();
        }
        if (this.name == "Start")
        {
            scrt.OnStartClick();
        }



    }
    private void OnMouseUp()
    {
        clicked.SetActive(false);
        overred.SetActive(true);

        GameObject.Find("modelCount").GetComponents<TextMesh>()[0].text = GameObject.Find("EventSystem").GetComponent<DataHolder>().objLength() + " Models Available";
        GameObject.Find("textureCount").GetComponents<TextMesh>()[0].text = GameObject.Find("EventSystem").GetComponent<DataHolder>().textureLength() + " Textures Available";

    }

}
