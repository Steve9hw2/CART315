using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class breakoutBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public float ballSpeed;
    public float maxSpeed = 10f;
    public float minSpeed = 2f;
    public bool ballEnabled = true;

    public TMP_Text launchTip;

    public AudioSource scoreSound, blip;

    private bool ballLaunched;

    private int[] dirOptions = { -1, 1 };
    private int hDir, vDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(!ballLaunched){
            StartCoroutine(Launch());
            ballLaunched = true;
            launchTip.text = " ";
            }
        }
    }

    // Ball Start
    public IEnumerator Launch()
    {
        if (ballEnabled)
        {
            yield return new WaitForSeconds(0f);

            hDir = dirOptions[Random.Range(0, dirOptions.Length)];

            rb.AddForce(transform.right * ballSpeed * hDir);
            rb.AddForce(transform.up * -1);
        }
    }

    private void Reset()
    {
        if (ballEnabled)
        {
            rb.velocity = Vector2.zero;
            ballSpeed = 2;
            transform.position = new Vector2(0, -0.5f);
           // StartCoroutine("Launch");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (ballEnabled)
        {
            if (other.gameObject.tag == "Wall")
            {
                // pitch
                blip.pitch = 0.75f;
                blip.Play();
                SpeedCheck();
            }

            if (other.gameObject.tag == "Paddle")
            {
                blip.pitch = 1f;
                blip.Play();
                SpeedCheck();
            }

            if (other.gameObject.tag == "Bricks")
            {
                blip.pitch = 1f;
                blip.Play();
                SpeedCheck();
                Destroy(other.gameObject);
                GameManager.S.gainScore();
                GameManager.S.subtractBrickCount();
            }

            if (other.gameObject.name == "bottomWall")
            {
                GameManager.S.loseLife();
                ballLaunched = false;
                launchTip.text = "Press Space to launch the ball!";
                Reset();
            }
        }
    }

    private void SpeedCheck()
    {
        if (ballEnabled)
        {
            if (Mathf.Abs(rb.velocity.x) > maxSpeed) rb.velocity = new Vector2(rb.velocity.x * 0.9f, rb.velocity.y);
            if (Mathf.Abs(rb.velocity.y) > maxSpeed) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.9f);
            if (Mathf.Abs(rb.velocity.x) < minSpeed) rb.velocity = new Vector2(rb.velocity.x * 1.1f, rb.velocity.y);
            if (Mathf.Abs(rb.velocity.y) < minSpeed) rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.1f);

            if (Mathf.Abs(rb.velocity.x) < minSpeed)
            {
                rb.velocity = new Vector2((rb.velocity.x < 0) ? -minSpeed : minSpeed, rb.velocity.y);
            }
            if (Mathf.Abs(rb.velocity.y) < minSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y < 0) ? -minSpeed : minSpeed);
            }

            Debug.Log(rb.velocity);
        }
    }
}
