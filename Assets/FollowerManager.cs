using System.Collections.Generic;
using UnityEngine;

public class FollowerManager : MonoBehaviour
{
    public Transform player;
    public GameObject fishPrefab;
    public int numberOfFollowers = 5;
    public float spacing = 1.5f;
    public float vOffsetAmount = 1.0f;

    void Start()
    {
        Transform leader = player;

        for (int i = 0; i < numberOfFollowers; i++)
        {
            Vector3 spawnPos = leader.position - leader.up * spacing;
            GameObject newFish = Instantiate(fishPrefab, spawnPos, Quaternion.identity);

            FollowerFish followerScript = newFish.GetComponent<FollowerFish>();
            followerScript.targetToFollow = leader;
            followerScript.followDistance = spacing;

            // Alternate left/right for V-formation
            float sideOffsetX = (i % 2 == 0 ? -1 : 1) * (vOffsetAmount * ((i + 1) / 2));
            followerScript.sideOffset = new Vector2(sideOffsetX, 0f);

            leader = newFish.transform;
        }
    }
}
