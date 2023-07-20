using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spectator : MonoBehaviour
{
    // Start is called before the first frame update
    public void ClickStartButton()
    {
        SceneManager.LoadScene("Vote");//Ÿ‚ÉˆÚs‚·‚éƒV[ƒ“
    }
}
