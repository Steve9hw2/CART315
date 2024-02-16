using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedController : MonoBehaviour
{
    private SpriteRenderer sr;

    public float xLoc = 0;
    public float bedSpeed = .001f;

    public float score;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && xLoc > -5f)
        {
            xLoc -= bedSpeed;
        }
        if (Input.GetKey(KeyCode.D) && xLoc < 5f)
        {
            xLoc += bedSpeed;
        }
        this.transform.position = new Vector3(
            xLoc,
            transform.position.y,
            transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.name == "Sleepy") score += 1;
        else score -= 1;
        
        Destroy(other.gameObject);
    }
}
