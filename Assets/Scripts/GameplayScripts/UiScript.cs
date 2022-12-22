using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiScript : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoHome() {
        ResetVar();
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart() {
        ResetVar();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ResetVar() {
        RocketController.time = 0;
        RocketController.coinsCollected = 0;
        RocketController.tempMoney = 0;
        RocketController.points = 0;
    }
}
