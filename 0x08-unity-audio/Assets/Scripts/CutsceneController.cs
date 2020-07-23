using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    
    public GameObject MainCamera;
    public GameObject Timer;
    public GameObject Player;

    // Start is called before the first frame update
    public void StartGame()
    {
        MainCamera.SetActive(true);
        Timer.SetActive(true);
        Player.GetComponent<PlayerController>().enabled = true;
        gameObject.SetActive(false);
    }
}
