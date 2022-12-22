using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{   
    [SerializeField]
    private AudioSource GameAudio;
    // Start is called before the first frame update
    void Start()
    {
        if (MusicControl.isAudio) {
            GameAudio.Play();
        } else {
            GameAudio.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
