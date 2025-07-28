using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroyFoot : MonoBehaviour
{
    public float blastPower;
    public float blastRadi;

    private Rigidbody Rb;
    private Vector3 blast;


    // Start is called before the first frame update
    void Start()
    {
        Rb = this.GetComponent<Rigidbody>();
        blast = new Vector3(1, 1, 1);
        Rb.AddExplosionForce(blastPower, blast, blastRadi);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("selfDestruct", 0.005f);
        
    }


    public void selfDestruct()
    {
        Destroy(this.gameObject);
    }
}
