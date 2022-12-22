using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{   
    [SerializeField] private TextMeshProUGUI moneyTextM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyTextM.text = $"{ButtonsScript.money}";
    }
}
