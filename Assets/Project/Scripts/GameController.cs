using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Basketball basketball;
    private Rigidbody basketballRigidbody;
    private Player player;
    private GameObject playerCamera;

    private float resetTimerInitial;
    private float resetTimer;

    private bool resetGame;
    private bool pauseTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        basketball = GameObject.Find("Basketball").GetComponent<Basketball>();
        Debug.Log(basketball == null);
        basketballRigidbody = basketball.GetComponent<Rigidbody>();
        playerCamera = GameObject.Find("FirstPersonCharacter");

        resetTimerInitial = 10.0f;
        resetTimer = resetTimerInitial;
        resetGame = false;
        pauseTimer = false;

        player.InitializeObjects();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.IsHoldingBall && !pauseTimer)
        {
            if (resetGame)
            {
                resetTimer -= Time.deltaTime;
                if (resetTimer <= 0)
                {
                    // Reset
                    SceneManager.LoadScene(0); // Only scene right now
                }
            }
            else
            {
                resetGame = true;
            }
        }
    }

    public void StopTimer()
    {
        pauseTimer = true;
    }

    public void StartTimer()
    {
        resetTimer = resetTimerInitial;
        ResumeTimer();
    }

    public void ResumeTimer()
    {
        pauseTimer = false;
    }

    public Player PlayerObject
    {
        get
        {
            return player;
        }
    }

    public Basketball BasketballObject
    {
        get
        {
            return basketball;
        }
    }

    public Rigidbody BasketballRigidbody
    {
        get
        {
            return basketballRigidbody;
        }
    }

    public GameObject PlayerCamera
    {
        get
        {
            return playerCamera;
        }
    }
}
