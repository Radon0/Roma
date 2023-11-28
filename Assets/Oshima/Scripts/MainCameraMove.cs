using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour
{
    public int count;    
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
                    transform.position = new Vector3(-60, 51, -80);
                    transform.eulerAngles = new Vector3(52, 0, 0);
                    break;
                case 1:
                    transform.position = new Vector3(0, 0, 0);           
                    transform.eulerAngles = new Vector3(90, 0, 0);
                    break;
                case 2:

                    break;
                case 3:
                    break;
                case 4:

                    break;

            }
        }

    }

}
