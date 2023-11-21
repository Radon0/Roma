using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour
{
    private Vector3 lastMousePosition;
    private Vector3 newAngle = new Vector3(0, 0, 0);
    public float y_rotate;
    public float x_reverce;
    public float x_rotate;
    public float y_reverce;

    void Start()
    {
        newAngle = this.transform.localEulerAngles;
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        newAngle.y += (Input.mousePosition.x - lastMousePosition.x) * y_rotate * x_reverce;
        newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * x_rotate * y_reverce;
        this.gameObject.transform.localEulerAngles = newAngle;
        lastMousePosition = Input.mousePosition;
    }

}
