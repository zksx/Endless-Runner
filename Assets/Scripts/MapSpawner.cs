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

    void Start()
    {
        Vector3 mapSpawn = Vector3.zero;
        prevMap = null;

        //foreach (GameObject Map in Maps)
        //{
        //    // check if pervmap isn't null
        //    if (prevMap != null)
        //    {

        //        // find end postion of prev map
        //        mapSpawn = prevMap.transform.position + (Vector3.forward * 10f);

        //    }

        //    print(mapSpawn);

        //    Instantiate(Map, mapSpawn,  Map.transform.rotation);

        //    prevMap = Map;
        //}

        // Create the first three maps
        // TODO: Figure out coordinate offsets to connect maps
        foreach (GameObject Map in Maps)
        {
            createdMaps.Add(Instantiate(Map));
        }
    }

    private void Update()
    {
        
    }

    private void PlaceMap(GameObject[] Maps)
    {

    }
}
