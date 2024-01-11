using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour
{
    public int count;
    private void Start()
    {
        transform.position = new Vector3(-9, 50, 4.9f);
        transform.eulerAngles = new Vector3(90, 0, 0);
    }
    void Update()
    {
        // ‚à‚µSpaceƒL[‚ª‰Ÿ‚³‚ê‚½‚È‚ç‚ÎA
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            if (count > 4)
            {
                count = 0;
            }
            switch (count)
            {
                case 0:             
                    transform.position = new Vector3(-9,50,4.9f);
                    transform.eulerAngles = new Vector3(90, 0, 0);
                    break;
                case 1:
                    transform.position = new Vector3(-9, 45, -72);           
                    transform.eulerAngles = new Vector3(60, 0, 0);
                    break;
                case 2:
                    transform.position = new Vector3(81, 45, -3.3f);
                    transform.eulerAngles = new Vector3(60, -90, 0);
                    break;
                case 3:
                    transform.position = new Vector3(0, 50, 90);
                    transform.eulerAngles = new Vector3(60, 180, 0);
                    break;
                case 4:
                    transform.position = new Vector3(-81, 50, 0);
                    transform.eulerAngles = new Vector3(60, 90, 0);
                    break;

            }
        }

    }

}
