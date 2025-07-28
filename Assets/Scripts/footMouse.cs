using UnityEngine;

public class footMouse : MonoBehaviour
{   
    private bool clicked;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
        }

        if(clicked == true)
        {
            if (DataHolder.currentType == "Ball type") {
                spawnfoot();
            }
            if (DataHolder.currentType == "Grass type")
            {
                spawnGrass();
            }
        }

    }

    private void spawnfoot()
    {
        RaycastHit hit;
        var ray = DataHolder.Cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody != null)
            {
                this.GetComponent<Spawner>().spawnfoot((int)hit.point.x, hit.point.y - 4, (int)hit.point.z, 1.5f);
            }
        }
        
    }
    private void spawnGrass()
    {
        RaycastHit hit;
        var ray = DataHolder.Cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody != null)
            {
                this.GetComponent<Spawner>().spawnGrass((int)hit.point.x, hit.point.y - 6, (int)hit.point.z, 1.5f);
            }
        }

    }


}
