using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurboButton : MonoBehaviour
{
    public GameObject gameManager;
    public Sprite verdad, mentira;

    private void Awake()
    {
        //gameManager = GameObject.Find("Game Manager");
    }
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().GetTurbo()) gameObject.GetComponent<Image>().color = new Color(0, 255, 0);
        else gameObject.GetComponent<Image>().color = new Color(255, 0, 0);
    }

    public void OnClick()
    {
        if (gameManager.GetComponent<GameManager>().GetTurbo())
        {
            gameObject.GetComponent<Image>().color = new Color(255, 0, 0);
            gameObject.GetComponent<Image>().sprite = mentira;
            gameManager.GetComponent<GameManager>().SetTurbo(false);
        }
        else
        {
            gameManager.GetComponent<GameManager>().SetTurbo(true);
            gameObject.GetComponent<Image>().sprite = verdad;
            gameObject.GetComponent<Image>().color = new Color(0, 255, 0);
        }
    }
}
