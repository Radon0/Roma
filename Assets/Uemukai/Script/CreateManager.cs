using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    public GameObject PrefabCannon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            float z = Random.Range(-50.0f, 50.0f);
            Vector3 pos = new Vector3(-150.0f, -58.0f, z);

            Instantiate(PrefabCannon, pos, Quaternion.Euler(0, 180, 90));
        }
    }
}
