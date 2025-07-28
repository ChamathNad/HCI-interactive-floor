using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroyBall : MonoBehaviour
{
    GameObject smpler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        smpler = GameObject.Find("sample");
        if (this.name == "casin" && smpler != null)
        {
            this.transform.Rotate(new Vector3(0,1,0),0.2f);
        }

        else if (this.gameObject.transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
