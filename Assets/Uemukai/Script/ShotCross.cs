using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShotCross : MonoBehaviour
{  
   public int count;
    [SerializeField]
    [Tooltip("’e")]
    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //count += 1;
        //if (count == 1000)
        ////”­ŽËŠÔŠuF
        //{

        //    Vector3 bulletPosition = firingPoint.transform.position;
        //    GameObject newBall = Instantiate(bullet, bulletPosition, Quaternion.identity);
        //    Vector3 direction = newBall.transform.up;
        //    newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        //    newBall.name = bullet.name;
        //    Destroy(newBall, 2f);
        //}
        count += 1;
        if (count == 1000)
        //”­ŽËŠÔŠuF
        {
            GameObject Shell = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody shellRb = Shell.GetComponent<Rigidbody>();
           
            shellRb.AddForce(-transform.forward *4500);

            //’e‘¬Ý’è
            count = 0;
            //AudioSource.PlayClipAtPoint(sound, transform.position);

            Destroy(Shell, 5.0f);
        }
        if (count > 1000)
        {
            count = 0;
        }
       
    }
}
