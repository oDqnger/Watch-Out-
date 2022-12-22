using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{   
    public static MusicControl instance;

    [SerializeField]
    private AudioSource MainMenuAudio;

    [SerializeField]
    private Button audioButton;

    [SerializeField]
    private Sprite Pause, Resume;

    public static bool isAudio = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
        
    }

    public void ToggleMusic() {
        if (isAudio) {
            MainMenuAudio.Stop();
            isAudio = false;
            audioButton.GetComponent<Image>().sprite = Pause;
        } else {
            MainMenuAudio.Play();
            isAudio = true;
            audioButton.GetComponent<Image>().sprite = Resume;
        }        
    }
}
