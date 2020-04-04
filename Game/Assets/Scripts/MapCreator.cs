using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public static MapCreator instance;

    public List<GameObject> closebackGrounds = new List<GameObject>();
    public List<GameObject> middlebackGrounds = new List<GameObject>();
    public List<GameObject> farbackGrounds = new List<GameObject>();
    public float closeMovingSpeedAddition;
    public float middleMovingSpeedAddition;
    public float farMovingSpeedAddition;

    public GameObject platformerPrefab;
    public GameObject sonicGunItemPrefab;
    public GameObject freezeGunItemPrefab;
    public GameObject gravityGrenadeItemPrefab;

    public float minMovingSpeed;
    public float maxMovingSpeed;
    public float speedGrowthTime;

    public float vanishingHeight;
    public float spawnVeticalPosition;
    public Vector2 spawnHorizontalRange;
    public Vector2 spawnDistance;
    public int minSpawnCount;
    public int maxSpawnCount;

    public float itemSpawnRatio = 0.1f;

    public List<GameObject> initialPlatformers = new List<GameObject>();

    [HideInInspector] public List<GameObject> platformerList = new List<GameObject>();
    private bool isReadySpawn;

    public float movingSpeed;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        foreach(var i in initialPlatformers)
        {
            platformerList.Add(i);
        }
        isReadySpawn = true;
        movingSpeed = minMovingSpeed;
        InitBackGrounds();
    }

    void Update()
    {
        if (isReadySpawn)
        {
            CreatePlatformer();
        }
        MoveBackGrounds();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < platformerList.Count; i++)
        {
            platformerList[i].transform.position += new Vector3(0, movingSpeed * Time.fixedDeltaTime, 0);
            if(platformerList[i].transform.position.y > vanishingHeight)
            {
                platformerList.RemoveAt(i);
                i--;
            }
        }
        if(movingSpeed < maxMovingSpeed)
        {
            movingSpeed += Time.fixedDeltaTime * (maxMovingSpeed - minMovingSpeed) / speedGrowthTime;
        }
    }

    void CreatePlatformer()
    {
        int seed = Random.Range(minSpawnCount, maxSpawnCount + 1);
        for(int i = 0; i < seed; i++)
        {
            Vector3 pos = new Vector3(Random.Range(spawnHorizontalRange.x, spawnHorizontalRange.y), spawnVeticalPosition, 0);
            GameObject go = Instantiate(platformerPrefab, pos, platformerPrefab.transform.rotation, this.transform);
            platformerList.Add(go);
            float t = Random.Range(0, 1.0f);
            if (t <= itemSpawnRatio)
            {
                int se = Random.Range(0, 3);
                GameObject it;
                switch (se)
                {
                    case 0:
                        it = Instantiate(sonicGunItemPrefab, pos + new Vector3(0, 0.45f, 0), transform.rotation);
                        platformerList.Add(it);
                        break;
                    case 1:
                        it = Instantiate(freezeGunItemPrefab, pos + new Vector3(0, 0.45f, 0), transform.rotation);
                        platformerList.Add(it);
                        break;
                    case 2:
                        it = Instantiate(gravityGrenadeItemPrefab, pos + new Vector3(0, 0.45f, 0), transform.rotation);
                        platformerList.Add(it);
                        break;
                    default: break;
                }
            }
        }
        isReadySpawn = false;
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(Random.Range(spawnDistance.x, spawnDistance.y) / movingSpeed);
        isReadySpawn = true;
    }

    void InitBackGrounds()
    {
        closebackGrounds[0].transform.position = new Vector3(0, 0, 0);
        closebackGrounds[1].transform.position = new Vector3(0, -10, 0);
        middlebackGrounds[0].transform.position = new Vector3(0, 0, 0);
        middlebackGrounds[1].transform.position = new Vector3(0, -10, 0);
        farbackGrounds[0].transform.position = new Vector3(0, 0, 0);
        farbackGrounds[1].transform.position = new Vector3(0, -10, 0);
    }

    void MoveBackGrounds()
    {
        for(int i = 0; i < closebackGrounds.Count; i++)
        {
            closebackGrounds[i].transform.position += new Vector3(0, movingSpeed * closeMovingSpeedAddition * Time.deltaTime, 0);
            if (closebackGrounds[i].transform.position.y > 10)
            {
                closebackGrounds[i].transform.position = new Vector3(0, -10, 0);
            }
        }
        for (int i = 0; i < middlebackGrounds.Count; i++)
        {
            middlebackGrounds[i].transform.position += new Vector3(0, movingSpeed * middleMovingSpeedAddition * Time.deltaTime, 0);
            if (middlebackGrounds[i].transform.position.y > 10)
            {
                middlebackGrounds[i].transform.position = new Vector3(0, -10, 0);
            }
        }
        for (int i = 0; i < farbackGrounds.Count; i++)
        {
            farbackGrounds[i].transform.position += new Vector3(0, movingSpeed * farMovingSpeedAddition * Time.deltaTime, 0);
            if (farbackGrounds[i].transform.position.y > 10)
            {
                farbackGrounds[i].transform.position = new Vector3(0, -10, 0);
            }
        }
    }

}
