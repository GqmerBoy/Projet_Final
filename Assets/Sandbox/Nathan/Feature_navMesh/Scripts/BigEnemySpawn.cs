using Meta.XR.MRUtilityKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemySpawn : MonoBehaviour
{

    [SerializeField] private float spawnTimer = 10f;
    [SerializeField] private GameObject prefabToSpawn;

    [SerializeField] private float minDistance = 0.3f;
    [SerializeField] MRUKAnchor.SceneLabels spawnLabel;
    [SerializeField] private float normalOffset;

    private float timer;


    // Update is called once per frame
    void Update()
    {
        if (!MRUK.Instance && !MRUK.Instance.IsInitialized)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer > spawnTimer)
        {
            SpawnEnemy();
            timer -= spawnTimer;
            spawnTimer -= 0.5f;
        }

        if (spawnTimer <= 4f)
        {
            spawnTimer = 4f;
        }
    }

    public void SpawnEnemy()
    {
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();

        room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minDistance, LabelFilter.Included(spawnLabel), out Vector3 pos, out Vector3 norm);

        Vector3 randomPositionNormalOffset = pos + norm * normalOffset;
        randomPositionNormalOffset.y = 1;

        Instantiate(prefabToSpawn, randomPositionNormalOffset, Quaternion.identity);
    }
}
