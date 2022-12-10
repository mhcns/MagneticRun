using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXButton : MonoBehaviour
{
    GameObject gameManager;
    Player player;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager");
    }
    void Update()
    {
        if(player == null) player = gameManager.GetComponent<GameManager>().GetPlayer();
        else
        {
            if (player.GetComponent<AudioSource>().volume != 0) gameObject.GetComponent<Image>().color = new Color(0, 255, 0);
            else gameObject.GetComponent<Image>().color = new Color(255, 0, 0);
        }
        
    }

    public void OnClick()
    {
        if (player.GetComponent<AudioSource>().volume != 0)
        {
            gameObject.GetComponent<Image>().color = new Color(255, 0, 0);
            player.GetComponent<AudioSource>().volume = 0;
            gameManager.GetComponent<GameManager>().SetSFXVolume(0);
        }
        else
        {
            player.GetComponent<AudioSource>().volume = 0.05f;
            gameManager.GetComponent<GameManager>().SetSFXVolume(1);
            gameObject.GetComponent<Image>().color = new Color(0, 255, 0);
        }
    }
}
