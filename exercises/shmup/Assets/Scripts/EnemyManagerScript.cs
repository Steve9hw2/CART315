using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public float spawnFreq;

    public float closestX;
    public float farthestX;
    public float topY;
    public float bottomY;

    public GameObject enemy;

    private float xPos = 10;
    private float yPos;

    private bool enemySpawning = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!enemySpawning)
        {
            StartCoroutine(EnemySpawner());
        }
        
    }

  //  public IEnumerator EnemySpawn()
  //  {
   //     enemySpawning = true;
   //     Debug.Log("Enemy Spawn Routine Go!");
  //      xPos = 10;
 //       yPos = Random.Range(topY, bottomY);

 //       Instantiate(enemy, new Vector3(xPos, yPos, 0), Quaternion.identity, this.transform);

 //       yield return null;
 //   }

    public IEnumerator EnemySpawner()
    {
        enemySpawning = true;
        Debug.Log("Enemy Spawn Routine Go!");
        xPos = 10;
        yPos = Random.Range(topY, bottomY);

        Instantiate(enemy, new Vector3(xPos, yPos, 0), Quaternion.identity, this.transform);
        yield return new WaitForSeconds(spawnFreq);
        enemySpawning = false;
    }
}
