using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjects : MonoBehaviour
{
    [SerializeField]
    GameObject[] boxPrefabs;
    
    private float maxPosX = 7f;
    [SerializeField]
    float spawnInterval;
    

    public static SpawnGameObjects instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        StartSpawningBox();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void boxSpawner()
    {
        int randomPrefabs = Random.Range(0, boxPrefabs.Length);
        float randomX = Random.Range(-maxPosX, maxPosX);
        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(boxPrefabs[randomPrefabs], randomPos, Quaternion.identity);
    }

    IEnumerator SpawnBoxIE()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            boxSpawner();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void StartSpawningBox()
    {
        StartCoroutine("SpawnBoxIE");
    }
    public void StopSpawningBox()
    {
        StopCoroutine("SpawnBoxIE");
    }
}
