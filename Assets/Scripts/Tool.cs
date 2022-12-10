using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    GameObject gameManager;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("Game Manager");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = gameManager.GetComponent<GameManager>().GetSFXVolume();
    }
    public void PlaySound()
    {
        audioSource.Play();
    }
}
