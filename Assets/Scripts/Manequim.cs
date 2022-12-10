using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manequim : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InvertY()
    {
        player.GetComponent<Player>().InvertY();
    }

    void Pisada()
    {
        player.GetComponent<Player>().Pisada();
    }

}
