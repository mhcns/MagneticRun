using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menu, pause, ui, death;
    public Text finalScore, pointsText;
    Player player;
    public AudioSource bgAudio, deathMusic;
    public AudioClip deathLoop, bgMusic;

    bool play = false, turbo = false, restart = false;
    GameObject[] obstacles, tools;
    [SerializeField] float speed;
    float pauseSpeed, SFXVolume = 1;
    int points = 0;
    private IEnumerator coroutine, turboCoroutine;
    // Start is called before the first frame update

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        //audio = GetComponent<AudioSource>();
        speed = 0;
        coroutine = WaitAndAccelerate(1.5f);
        turboCoroutine = WaitAndAccelerate(0.5f);

        if (player == null) player = FindObjectOfType<Player>();

        pause.SetActive(false);
        death.SetActive(false);
        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) player = FindObjectOfType<Player>();

        if (restart)
        {
            
            restart = false;
        }

        if (!play) speed = 0;

        if (Input.GetKeyDown(KeyCode.Escape) && play && !menu.activeInHierarchy) Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && !play && !menu.activeInHierarchy) Resume();

        if (Input.GetKeyDown(KeyCode.Return) && menu.activeInHierarchy) Play();

        if (points < 10) pointsText.text = "000" + points.ToString();
        else if (points < 100) pointsText.text = "00" + points.ToString();
        else if (points < 1000) pointsText.text = "0" + points.ToString();
        else pointsText.text = points.ToString();
    }

    private IEnumerator WaitAndAccelerate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            speed += 0.5f;
            player.AdjustSpeed();
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void Death()
    {
        speed = 0;
        play = false;
        finalScore.text = pointsText.text;
        ui.SetActive(false);
        death.SetActive(true);
        bgAudio.clip = deathLoop;
        bgAudio.Play();
        deathMusic.Play();
        if (!turbo) StopCoroutine(coroutine);
        else StopCoroutine(turboCoroutine);
    }

    public void AddPoints(int x)
    {
        if (!turbo) points += x;
        else points += x * 3;
    }

    public void Play()
    {
        play = true;
        speed = 15;
        menu.SetActive(false);
        ui.SetActive(true);
        player.Play();
        if (!turbo) StartCoroutine(coroutine);
        else StartCoroutine(turboCoroutine);
    }

    public void Pause()
    {
        pauseSpeed = speed;
        play = false;
        pause.SetActive(true);
        player.Pause();
        if (!turbo) StopCoroutine(coroutine);
        else StopCoroutine(turboCoroutine);
    }

    public void Resume()
    {
        speed = pauseSpeed;
        play = true;
        pause.SetActive(false);
        player.Resume();
        if (!turbo) StartCoroutine(coroutine);
        else StartCoroutine(turboCoroutine);
    }

    public void Exit()
    {
        //SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        if (death.activeSelf)
        {
            bgAudio.clip = bgMusic;
            bgAudio.Play();
        }
        pause.SetActive(false);
        death.SetActive(false);
        ui.SetActive(false);
        menu.SetActive(true);
        player.Restart();
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        tools = GameObject.FindGameObjectsWithTag("Tool");
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
        foreach (GameObject tool in tools)
        {
            Destroy(tool);
        }
        points = 0;
    }
    public float GetSFXVolume()
    {
        return SFXVolume;
    }
    public void SetSFXVolume(float x)
    {
        SFXVolume = x;
    }
    public float GetVolume()
    {
        return bgAudio.volume;
    }

    public void SetVolume(float x)
    {
        bgAudio.volume = x * 0.28f;
        deathMusic.volume = x * 0.1f;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public bool GetPlay()
    {
        return play;
    }

    public bool GetTurbo()
    {
        return turbo;
    }

    public void SetTurbo(bool x)
    {
        turbo = x;
    }
}
