using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYERDISTANCESPAWN = 30f;

    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Player player;

    private Vector2 lastEndPosition;
    
    // Start is called before the first frame update    
    void Start()
    {
        lastEndPosition = levelPartStart.Find("EndPosition").position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.GetPosition(), lastEndPosition) < PLAYERDISTANCESPAWN)
        {
            SpawnLevelParts();
        }
    }

    private void SpawnLevelParts()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelParts(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelParts(Transform levelPart, Vector2 spawnPosition)
    {
        Transform levelPartsTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartsTransform;
    }
}
