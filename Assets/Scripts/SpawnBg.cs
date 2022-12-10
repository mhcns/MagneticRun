using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBg : MonoBehaviour
{
    public GameObject background;
    public GameObject bgLayer2;
    public GameObject bgLayer3;
    public GameObject fire1, fire2, fire3;
    public GameObject[] meteoros;
    Transform spawn;

    // Start is called before the first frame update
    void Awake()
    {
        spawn = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Background"))
        {
            Instantiate(background);
        }

        if (collision.gameObject.CompareTag("Bg Layer2"))
        {
            Instantiate(bgLayer2);
            Instantiate(fire1);
            Instantiate(fire2);
            Instantiate(fire3);
        }

        if(collision.gameObject.CompareTag("Bg Layer3"))
        {
            Instantiate(bgLayer3);
        }
    }

    public void SpawnMeteoro()
    {
        spawn.position = new Vector3(33.8f, 10 + Random.Range(0, 2.5f), 0);
        Instantiate(meteoros[Random.Range(0, 3)], spawn);
    }
}
