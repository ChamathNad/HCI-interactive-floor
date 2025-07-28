using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliding : MonoBehaviour
{
    public TextMesh value;

    private Vector3 screenPoint;
    private Vector3 offset;

    private float minval = -12.5f;
    private float maxval = 12.5f;
    private float curval = 12.5f;

    private void Start()
    {
        value.text = (int)(curval * 10) + 125 + "";
        this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, maxval);
    }

    public void setSlider()
    {
        this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, int.Parse(value.text)/10 - 12.5f);
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = new Vector3(cursorPosition.x, transform.position.y, cursorPosition.z);
        if (this.transform.localPosition.x != 0)
        {
            this.transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        }
        if (this.transform.localPosition.z < minval)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, minval);
        }
        if (this.transform.localPosition.z > maxval)
        {
            this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, maxval);
        }
        curval = this.transform.localPosition.z;
        value.text = (int)(curval*10) + 125 +"";
    }
}
