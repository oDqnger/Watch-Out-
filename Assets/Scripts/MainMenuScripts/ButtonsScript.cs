using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ShopPanel, Title, Information;

    [SerializeField]
    private TextMeshProUGUI moneyText;

    [SerializeField]
    private Button[] BuyButton, ApplyButton;

    [SerializeField]
    private TextMeshProUGUI[] applyText;

    int[] amount = new int[4];
    public static bool[] isApplied = new bool[7];

    int[] allItems = new int[]{50, 100, 20, 80, 100, 120, 150};

    public static int money = 0;

    void CheckIfEnough() {
        for (int x = 0; x<allItems.Count(); x++) {
            if (money < allItems[x]) {
                BuyButton[x].interactable = false;
                ApplyButton[x].interactable = false;
            } else {
                BuyButton[x].interactable = true;
                ApplyButton[x].interactable = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        money = Convert.ToInt32(moneyText.text);
        CheckIfEnough();
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log(money);
        moneyText.text = money.ToString();
    }

    public void PlayToGame() {
        SceneManager.LoadScene("MainScene");
    }

    public void Shop() {
        ShopPanel[0].SetActive(true);
        Title[0].SetActive(false);
    }

    public void Exit() {
        ShopPanel[0].SetActive(false);
        ShopPanel[1].SetActive(false);
        ShopPanel[2].SetActive(false);
        Title[0].SetActive(true);
    }

    public void Next() {
        ShopPanel[0].SetActive(false);
        ShopPanel[1].SetActive(true);
    }

    public void Back() {
        ShopPanel[0].SetActive(true);
        ShopPanel[1].SetActive(false);
    }

    public void BuySlowtime() {
        isApplied[0] = false;
        amount[0] = amount[0] + 1;
        money = money - allItems[0];   
        moneyText.text = money.ToString();
        CheckIfEnough();
        ApplyButton[0].interactable = true;
    }

    public void BuyTransparent() {
        isApplied[1] = false;
        amount[1] = amount[1] + 1;
        money = money - allItems[1];   
        moneyText.text = money.ToString();
        CheckIfEnough();
        ApplyButton[1].interactable = true;
    }

    public void BuyCoinBoost() {
        isApplied[2] = false;
        amount[2] = amount[2] + 1;
        money = money - allItems[2];   
        moneyText.text = money.ToString();
        CheckIfEnough();
        ApplyButton[2].interactable = true;
    }

    public void BuyExtraLives() {
        isApplied[3] = false;
        amount[3] = amount[3] + 1;
        money = money - allItems[3];   
        moneyText.text = money.ToString();
        CheckIfEnough();
        ApplyButton[3].interactable = true;
    }

    public void ApplySlowtime() {
        isApplied[0] = true;
        ApplyButton[0].interactable = false;
        Debug.Log(isApplied[0]);
    }

    public void ApplyTransparent() {
        isApplied[1] = true;
        ApplyButton[1].interactable = false;
    }

    public void ApplyCoinBoost() {
        isApplied[2] = true;
        ApplyButton[2].interactable = false;
    }

    public void ApplyExtraLives() {
        isApplied[3] = true;
        ApplyButton[3].interactable = false;
    }

    public void BuyElimToe() {
        isApplied[4] = false;
        BuyButton[4].interactable = false;    
        money = money - allItems[4];   
        moneyText.text = money.ToString();
        CheckIfEnough();
        ApplyButton[4].interactable = true;
    }

    public void BuyStrongToe() {
        isApplied[5] = false;
        ApplyButton[5].interactable = true;
        BuyButton[5].interactable = false;
        money = money - allItems[5];   
        moneyText.text = money.ToString();
        CheckIfEnough();
        ApplyButton[5].interactable = true;
    }

    public void BuyLongPP() {
        isApplied[6] = false;
        ApplyButton[6].interactable = true;
        BuyButton[6].interactable = false; 
        money = money - allItems[6];   
        moneyText.text = money.ToString(); 
        CheckIfEnough(); 
        ApplyButton[6].interactable = true;
    }

    public void ApplyElimToe() {
        if (!isApplied[4]) {
            isApplied[4] =  true;
            applyText[0].text = "Unapply";
        } else {
            isApplied[4] = false;
            applyText[0].text = "Apply";
        }
        Debug.Log(isApplied[4]);
    }

    public void ApplyStrongToe() {
        if (!isApplied[5]) {
            isApplied[5] =  true;
            applyText[1].text = "Unapply";
        } else {
            isApplied[5] = false;
            applyText[1].text = "Apply";
        }
    }

    public void ApplyLongPP() {
        if (!isApplied[6]) {
            isApplied[6] =  true;
            applyText[2].text = "Unapply";
        } else {
            isApplied[6] = false;
            applyText[2].text = "Apply";
        }
    }

    public void TurnPageTwo() {
        ShopPanel[1].SetActive(false);
        ShopPanel[2].SetActive(true);
    }

    public void BackPageOne() {
        ShopPanel[1].SetActive(true);
        ShopPanel[2].SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void InformationPanelExit() {
        Information[0].SetActive(false);
    }

    public void InforamtionPanelEnter() {
        Information[0].SetActive(true);
    }

}
