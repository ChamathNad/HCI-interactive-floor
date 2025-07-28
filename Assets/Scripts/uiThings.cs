using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class uiThings : MonoBehaviour
{

    public InputField netID;
    public InputField portID;


    // Start is called before the first frame update
    void Start()
    {
        if (netID != null && portID !=null) {
            netID.text = DataHolder.IPaddress;
            portID.text = DataHolder.port + "";
        }
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(DataHolder.conStatus);
        if (DataHolder.conStatus == false)
        {
        //    OnStartClick();
        }
    }
    public void onSave()
    {
        GameObject.Find("EventSystem").GetComponent<buttons>().OnSaveClick(netID.text,int.Parse(portID.text));
    }
    public void OnStartClick()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnReturnClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
