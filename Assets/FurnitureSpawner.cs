using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class FurnitureSpawner : MonoBehaviour
{
    public List<GameObject> furniture;
    public float spawnInterval;
    private float timer = 0;
    [Header("轻型家具")]
    public Transform lightFurnitureStart;

    private void FixedUpdate()
    {
        SpawnMethod(spawnInterval);
        Debug.Log(timer);
    }

    private void SpawnMethod(float spawnInterval)
    {
        timer += Time.fixedDeltaTime;
        if (timer > spawnInterval)
        {
            int randomIndex = Random.Range(0, furniture.Count);
            Instantiate(furniture[randomIndex], lightFurnitureStart);
            timer = 0;
        }
    }
}
