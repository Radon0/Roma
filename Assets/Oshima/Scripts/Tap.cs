using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tap : MonoBehaviour
{
    [SerializeField] Slider iineSlider;
    public List<GameObject> myList = new List<GameObject>();
    [SerializeField] Gimmick gimmick;
    private GameObject game = null;
    [SerializeField] GameObject[] games;
    private Vector3 mouse;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
   
        //{&& iineSlider.value == iineSlider.maxValue
        switch (iineSlider.value)
        {
            case 10:
                if (  gimmick.click == true)
                {
                  
                        
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        int layerMask = 1 << LayerMask.NameToLayer("Stage");
                        RaycastHit hit = new RaycastHit();

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Physics.Raycast(ray, out hit, layerMask))
                        {
                            Debug.Log(hit.collider.gameObject.name);
                            Instantiate(myList[0], hit.point, Quaternion.identity);
                            gimmick.click = false;
                            iineSlider.value = 0;
                            gimmick.button.interactable = true;

                        }
                    }
                }
                break;
            case 20:
                if (gimmick.click == true)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit = new RaycastHit();
                    int layerMask = 1 << LayerMask.NameToLayer("Stage");
                    if (Input.GetMouseButtonDown(0))
                    {

                        if (Physics.Raycast(ray, out hit, layerMask))
                        {
                            Instantiate(myList[1], hit.point, Quaternion.identity);
                            gimmick.click = false;
                            iineSlider.value = 0;
                        }
                    }
                }
                break;
            case 30:
                if (gimmick.click == true)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit = new RaycastHit();
                    int layerMask = 1 << LayerMask.NameToLayer("Stage");
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Physics.Raycast(ray, out hit, layerMask))
                        {
                            Instantiate(myList[2], hit.point, Quaternion.identity);
                            gimmick.click = false;
                            iineSlider.value = 0;
                        }
                    }
                }
                break;
        }
        //game = Instantiate(games[0], transform.position, Quaternion.identity);
        //if (gimmick.click == true)
        //{
        //    mouse = Input.mousePosition;
        //    target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));
        //    game.transform.position = target;
        //}
        //else if (gimmick.click == false)
        //{
        //    Destroy(game);
        //}
        //switch (iineSlider.value)
        //{
        //    case 10:
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //int layerMask = 1 << LayerMask.NameToLayer("Stage");
        //RaycastHit hit2D = Physics.Raycast();
        //if (hit2D && hit2D.transform.gameObject == gameObject)
        //{
        //    clickPosition = Input.mousePosition;
        //    // Vector3でマウスがクリックした位置座標を取得する
        //    // Z軸修正
        //    clickPosition.z = 10f;
        //    //スクリーン座標をワールド座標に変換する
        //    Instantiate(myList[0], Camera.main.ScreenToWorldPoint(clickPosition), myList[0].transform.rotation);
        //    iineSlider.value = 0;
        //}
        //break;
        //}
    }
}

