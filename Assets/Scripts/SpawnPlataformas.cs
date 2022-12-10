using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataformas : MonoBehaviour
{
    public GameObject tile0;
    public GameObject tile1;
    public GameObject tile2;
    public GameObject obstacle;
    public GameObject tool;

    public GameManager gameManager;
    public SpawnBg background;
    public SpawnPlataformas outroTrigger;

    int spawnCont = 3, spawnObstacle = 0, spawnTool = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma") && collision.gameObject.layer == 3)
        {
            if (spawnCont < 4)
            {
                if (Random.Range(0, 2) != 0) Instantiate(tile1);
                else Instantiate(tile2);
                spawnCont++;
                if (gameManager != null) gameManager.AddPoints(1);
            }
            else
            {
                Instantiate(tile0);
                spawnCont = 0;
                if (gameManager != null) gameManager.AddPoints(2);
            }

            if(spawnObstacle < 5)
            {
                spawnObstacle++;
            }
            else
            {
                if (Random.Range(0, 10 - spawnObstacle) == 0)
                {
                    Instantiate(obstacle);
                    spawnObstacle = 0;
                    spawnTool++;
                    outroTrigger.ZerarSpawnObstacle();
                    if (Random.Range(0, 20) == 0 && background != null) background.SpawnMeteoro();
                }
                else
                {
                    spawnObstacle++;
                    if (Random.Range(0, 30 - spawnTool) == 0) Instantiate(tool);
                    spawnTool = 0;
                }
            }
        }
    }

    public void ZerarSpawnObstacle()
    {
        spawnObstacle = 0;
    }
}
