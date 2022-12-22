// all imports
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{   
    
    Rigidbody2D rbr;

    // all tags to check collision
    private string SPIKESTAG = "Spikes";
    private string GROUNDTAG = "Ground";
    private string COINTAG = "Coins";

    // players stats (gameplay)
    private Vector3 targetPos, playerPos;
    public float speed;

    private List<GameObject> clonedObjs = new List<GameObject>();
    [SerializeField]
    private GameObject bi1;

    GameObject coin, pipe1, pipe2, pipe3, pipe4;
    int count = 0;

    int randomNumberOne;
    float randomPoleOne, randomNumberTwo;

    public static int points, tempMoney;

    // GUI varibales
    public TextMeshProUGUI pointsText;
    [SerializeField] private GameObject deathParticles, playerParticles;

    public GameObject DeathScreen, EscapeScreen;
    [SerializeField] TextMeshProUGUI tempCoinsCollectedText, totalTimePlayed, pointsCollectedText, TotalCoinsText;

    // more stats
    public static int coinsCollected = 0;
    public static float time = 0;

    bool isPause = false;

    [SerializeField] private Sprite[] skins;

    // Start is called before the first frame update
    void Start()
    {   
        // initalisations before game starts
        rbr = GetComponent<Rigidbody2D>();
        targetPos = new Vector3(transform.position.x + 10f, 0f, 0f);
        clonedObjs.Add(bi1);
        playerPos = transform.position;
        DeathScreen.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // controls
        if (Input.GetKey(KeyCode.Space)) {
            rbr.velocity = new Vector2(1f * speed * 2 * Time.deltaTime, 1f * speed * 2 * Time.deltaTime);
        } 

        if (ButtonsScript.isApplied[4]) {
            GetComponent<SpriteRenderer>().sprite = skins[0];
        } else if (ButtonsScript.isApplied[5]) {
            GetComponent<SpriteRenderer>().sprite = skins[1];
        } else if (ButtonsScript.isApplied[6]) {
            GetComponent<SpriteRenderer>().sprite = skins[2];
        } 
    }

    void Update() {
        // infinite generation
        playerPos = transform.position;
        if (transform.position.x >= targetPos.x) {     
            clonedObjs.Add(Instantiate(clonedObjs.Last(), new Vector3(clonedObjs.Last().transform.position.x + 24f, -1f, 0f), clonedObjs.Last().transform.rotation));

            pipe1 = clonedObjs.Last().transform.GetChild(2).gameObject;
            pipe2 = clonedObjs.Last().transform.GetChild(3).gameObject;
            pipe3 = clonedObjs.Last().transform.GetChild(4).gameObject;
            pipe4 = clonedObjs.Last().transform.GetChild(5).gameObject;

            RandomNumberGen();

            pipe1.transform.position = new Vector3(pipe1.transform.position.x, randomPoleOne, 0f);
            RandomNumberGen();
            pipe2.transform.position = new Vector3(pipe2.transform.position.x, randomPoleOne, 0f);
            RandomNumberGen();
            pipe3.transform.position = new Vector3(pipe3.transform.position.x, randomPoleOne, 0f);
            RandomNumberGen();
            pipe4.transform.position = new Vector3(pipe4.transform.position.x, randomPoleOne, 0f);

            coin = clonedObjs.Last().transform.GetChild(7).gameObject;

            randomNumberTwo = Random.Range(2f, 5f);
            randomPoleOne = Random.Range(-7f, 2.5f);
            coin.transform.position = new Vector3(coin.transform.position.x + randomNumberTwo, randomPoleOne, 0f);
            targetPos = new Vector3(targetPos.x + 15, 0f, 0f);

            points++;
            pointsText.text = $"{points}";
        }

        if (clonedObjs.Count >= 5 + count) {
            Destroy(clonedObjs[0]);
            clonedObjs.RemoveAt(0);
            count++;
        }

        // checking if the player wants to pause game
        if (Input.GetKey(KeyCode.Escape)) {
            isPause = !isPause;
        }

        // check to see if it is paused
        if (isPause) {
            EscapeScreen.SetActive(true);
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
            EscapeScreen.SetActive(false);
        }

        // measuring the time taken for each game
        time+=Time.deltaTime;
    }


    // randomizing the poles and the position of the coins
    void RandomNumberGen() {
        randomNumberOne = Random.Range(1,5);
        switch(randomNumberOne) {
            case 1:
                randomPoleOne = 1f;
                break;
            case 2:
                randomPoleOne = 0.5f;
                break;
            case 3:
                randomPoleOne = -1f;
                break;
            case 4:
                randomPoleOne = -1.5f;
                break;
            default:
                randomPoleOne = 0.5f;
                break;
        }
    }


    // the stuff that happens after the player dies.
    void OnDeath() {
        tempMoney += (points / 3) + ((int)time / 10) + coinsCollected;
        ButtonsScript.money += tempMoney;
        Destroy(gameObject);
        deathParticles.SetActive(true);
        deathParticles.transform.position = transform.position;
        playerParticles.SetActive(false);
        DeathScreen.SetActive(true);
        TotalCoinsText.text = $"Total: {tempMoney}";
        pointsCollectedText.text = $"Points: {points}";
        tempCoinsCollectedText.text = $"Coins collected: {coinsCollected}";
        totalTimePlayed.text = $"Time played: {time}";
        tempMoney = 0;
    }

    // testing for collisions (stuff that can kill and heal)
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == SPIKESTAG || col.gameObject.tag == GROUNDTAG) {
            OnDeath();
        } 
    }

    // coin collision
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == COINTAG) {
            coinsCollected+=1;
            Destroy(col.gameObject);
            Debug.Log(coinsCollected);
        }
    }
}