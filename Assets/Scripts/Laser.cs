using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;

    // Start is called before the first frame update
    void Awake()
    {
        // Connect the variable lr to the line renderer
        lr = GetComponent<LineRenderer>();
    }

    public void drawLaser(Vector3 endPoint)
    {
        // Set the line width
        lr.startWidth = .05f;
        lr.endWidth = .001f;

        // Set the start and end colors
        lr.startColor = Color.yellow;
        lr.endColor = Color.white;

        // Start of the line
        lr.SetPosition(0, transform.position);

        // End of line
        lr.SetPosition(1, endPoint);
    }


}
