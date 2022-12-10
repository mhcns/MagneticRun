using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    private GameManager gameManager;
    float speed;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        speed = gameManager.GetComponent<GameManager>().GetSpeed();
    }
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        speed = gameManager.GetComponent<GameManager>().GetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Meteor")) speed = gameManager.GetComponent<GameManager>().GetSpeed() / 50;
        else if (gameObject.CompareTag("Background")) speed = gameManager.GetComponent<GameManager>().GetSpeed() / 20;
        else if (gameObject.CompareTag("Bg Layer2") || (gameObject.CompareTag("Fire"))) speed = gameManager.GetComponent<GameManager>().GetSpeed() / 7;
        else if (gameObject.CompareTag("Bg Layer3")) speed = gameManager.GetComponent<GameManager>().GetSpeed() / 1.2f;
        else speed = gameManager.GetComponent<GameManager>().GetSpeed();

        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
