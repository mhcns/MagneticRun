using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButtons : MonoBehaviour
{
    GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager");
    }
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().GetVolume() != 0) gameObject.GetComponent<Image>().color = new Color(0, 255, 0);
        else gameObject.GetComponent<Image>().color = new Color(255, 0, 0);
    }

    public void OnClick()
    {
        if(gameManager.GetComponent<GameManager>().GetVolume() != 0)
        {
            gameObject.GetComponent<Image>().color = new Color(255, 0, 0);
            gameManager.GetComponent<GameManager>().SetVolume(0);
        }
        else
        {
            gameManager.GetComponent<GameManager>().SetVolume(1);
            gameObject.GetComponent<Image>().color = new Color(0, 255, 0);
        }
    }
}
