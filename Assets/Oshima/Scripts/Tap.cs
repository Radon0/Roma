using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tap : MonoBehaviour
{
    [SerializeField] Slider[] iineSlider;
    public List<GameObject> myList = new List<GameObject>();
    [SerializeField] Gimmick[] gimmick;
    private GameObject game = null;
    [SerializeField] GameObject[] games;
    private Vector3 mouse;
    private Vector3 target;
    public bool click=false;
    [SerializeField] Text text;
    public MainCameraMove cameraMove;
    // Update is called once per frame
    void Update()
    {
        if (gimmick[0].click == true)
        {
            click = true;
            if (gimmick[0].Open == true)
            {
                game = Instantiate(games[0], new Vector3(5.0f, 0.0f, 0.0f), Quaternion.identity);
                text.enabled = true;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Stage");
            RaycastHit hit = new RaycastHit();
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, layerMask))//レイキャストでマウスの位置を取得
                {
                    text.enabled = false;
                    click =false;
                    Destroy(game);
                    Debug.Log(hit.collider.gameObject.name);
                    Instantiate(myList[0], hit.point, Quaternion.identity);
                    gimmick[0].click = false;
                    iineSlider[0].value = 0;
                    gimmick[0].button.interactable = true;

                }
            }
        }
        if (gimmick[1].click == true)
        {
            click = true;
            if (gimmick[1].Open == true)
            {
                text.enabled = true;

                if (cameraMove.count == 1)
                {
                    game = Instantiate(games[1], new Vector3(5.0f, 0.0f, 0.0f), Quaternion.Euler(0,90,0));
                }
                else if (cameraMove.count == 2)
                {

                }
                else if (cameraMove.count == 3)
                {

                }
                else if (cameraMove.count == 4)
                {

                }
                else if (cameraMove.count == 0)
                {

                }
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Stage");
            RaycastHit hit = new RaycastHit();

            if (Input.GetMouseButtonDown(0))
            {

                if (Physics.Raycast(ray, out hit, layerMask))
                {
                    text.enabled = false;
                    click = false;
                    Destroy(game);
                    if (cameraMove.count == 1)
                    {
                        Instantiate(myList[1], hit.point, Quaternion.Euler(60,90,0));
                    }
                    else if (cameraMove.count == 2)
                    {

                    }
                    else if (cameraMove.count == 3)
                    {

                    }
                    else if (cameraMove.count == 4)
                    {

                    }
                    else if (cameraMove.count == 0)
                    {

                    }
                    
                    gimmick[1].click = false;
                    iineSlider[1].value = 0;
                    gimmick[1].button.interactable = true;

                }
        
            }
        }
        if (gimmick[2].click == true)
        {
            click = true;

            if (gimmick[2].Open == true)
            {
                text.enabled = true;
                game = Instantiate(games[2], new Vector3(5.0f, 0.0f, 0.0f), Quaternion.identity);
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layerMask = 1 << LayerMask.NameToLayer("Stage");
            RaycastHit hit = new RaycastHit();
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, layerMask))
                {
                    text.enabled = false;
                    click = false;
                    Destroy(game);
                    Instantiate(myList[2], hit.point, Quaternion.identity);
                    gimmick[2].click = false;
                    iineSlider[2].value = 0;
                    gimmick[2].button.interactable = true;

                }


            }
        }
        //マウスの移動
        mouse = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));
        if (game != null)
        {
            game.transform.position = target;
        }

        if (game == null)
        {
            return;
        }
    }
}

