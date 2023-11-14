// Instantiates respawnPrefab at the location
// of all GameObjects tagged "Respawn".

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapSpawner : MonoBehaviour
{
    public GameObject prevMap;
    public List<GameObject> Maps;
    public List<GameObject> createdMaps;
    public int numCreatedMaps;
    public int numMapPrefabs;

    public GameObject ballObject;

    void Start()
    {
        Vector3 mapSpawn = Vector3.zero;
        prevMap = null;
        numCreatedMaps = 0;
        numMapPrefabs = 0;
        ballObject = GameObject.Find("Player");

        // Create the first three maps
        foreach (GameObject Map in Maps)
        {
            GameObject mapSpawned = Instantiate(Map);
            
            PlaceMap(mapSpawned);

            numMapPrefabs++;
        }
    }

    private void Update()
    {
        // Get positions of the player and the start/end maps that
        // have been spawned
        Vector3 ballPos = ballObject.transform.position;
        Vector3 farthestPos = createdMaps[numCreatedMaps - 1].transform.position;
        Vector3 ballToEndDist = farthestPos - ballPos;

        Vector3 startPlatPos = createdMaps[0].transform.position;
        Vector3 startToBallDist = ballPos - startPlatPos;

        // Check to see if the distance from the player to the farthest
        // platform ahead is not far enough
        if (ballToEndDist.magnitude < 400f)
        {
            // Create new random platform
            int randMap = Random.Range(0, numMapPrefabs - 1);
            GameObject appendedMap = Instantiate(Maps[randMap]);

            PlaceMap(appendedMap);
        }

        // Check to see if the player is far enough away from the first
        // platform
        if(startToBallDist.magnitude > 100f)
        {
            // Deleted the platform
            GameObject mapToRemove = createdMaps[0];
            Destroy(mapToRemove);

            createdMaps.RemoveAt(0);
            numCreatedMaps--;
        }
    }

    private void PlaceMap(GameObject newMap)
    {
        if(prevMap != null)
        {
            // Update the new position based on the previous platform
            newMap.transform.position = prevMap.transform.position + (Vector3.forward * 50f);
        }

        createdMaps.Add(newMap);

        prevMap = newMap;
        numCreatedMaps++;
    }
}
