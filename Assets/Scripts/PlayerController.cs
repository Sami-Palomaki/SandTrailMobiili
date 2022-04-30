using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public VariableJoystick js;
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public Timer timer;

    private Rigidbody rb;
    private Vector2 dir;
    Animator anim;

    private void Awake()
    {
        isGameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        timer.StartWatchStart();
        AnalyticsEvent.GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        // Perus syötteen haku näppäimistöltä
        // dir.x = Input.GetAxis("Horizontal");
        // dir.y = Input.GetAxis("Vertical");

        // Syötteen haku joystickiltä (horizontal ja vertical)
        dir.x = js.Horizontal;
        // dir.y = js.Vertical;
        if (isGameOver)
        {
            timer.StopWatchStop();
            GameOver();
            gameOverScreen.SetActive(true);
        }
        else{
            // Syötteen haku joystickillä platformer (horizontal)
            dir.x = js.Horizontal * speed;
            dir.y = rb.velocity.y;
        }

        anim.SetFloat("DirectionX", dir.x);

    }

    private void FixedUpdate()
    {
        
        rb.velocity = dir;
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * 400);
    }

    public void GameOver()
    {
        // FindObjectOfType<InterstitialAdExample>().LoadAd();
        AnalyticsEvent.GameOver();
    }

    public void Respawn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
