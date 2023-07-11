using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Vector2 rotationSpeed = new Vector2(0.1f, 0.2f);
    public bool reverse;
    private Camera mainCamera;
    private Vector2 lastMousePosition;
    private GameObject targetObject;
    public Click GetClick;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetClick = GetClick.GetComponent<Click>();
    }
        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

   void OnCollisionEnter(Collision collision)
    {

       
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                if (!reverse)
                {
                    var x = (Input.mousePosition.y - lastMousePosition.y);
                    //var y = (lastMousePosition.x - Input.mousePosition.x);

                    var newAngle = Vector3.zero;
                    newAngle.x = x * rotationSpeed.x;
                    //newAngle.y = y * rotationSpeed.y;

                    targetObject.transform.Rotate(newAngle);
                    lastMousePosition = Input.mousePosition;
                }
                else
                {
                    var x = (lastMousePosition.y - Input.mousePosition.y);
                    //var y = (Input.mousePosition.x - lastMousePosition.x);

                    var newAngle = Vector3.zero;
                    newAngle.x = x * rotationSpeed.x;
                    //newAngle.y = y * rotationSpeed.y;

                    targetObject.transform.Rotate(newAngle);
                    lastMousePosition = Input.mousePosition;
                }
            }
        }
}


