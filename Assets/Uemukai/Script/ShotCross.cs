using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCross : MonoBehaviour
{
    public int count;
    //public GameObject ShellPrefab;
    [SerializeField]
    [Tooltip("íeÇÃî≠éÀèÍèä")]
    private GameObject firingPoint;

    [SerializeField]
    [Tooltip("íe")]
    private GameObject bullet;

    [SerializeField]
    [Tooltip("íeÇÃë¨Ç≥")]
    private float speed = 35f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        count += 1;
        if (count == 1000)
        //î≠éÀä‘äuF
        {
          
            Vector3 bulletPosition = firingPoint.transform.position;
            GameObject newBall = Instantiate(bullet, bulletPosition, Quaternion.Euler(-90, 0, 0));
            Vector3 direction = newBall.transform.up;
            newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
            newBall.name = bullet.name;
            Destroy(newBall, 2f);
        }
        if (count > 1000)
        {
            count = 0;
        }
       
    }
}
