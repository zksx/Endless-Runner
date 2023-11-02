// Instantiates respawnPrefab at the location
// of all GameObjects tagged "Respawn".

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapSpawner : MonoBehaviour
{
    public GameObject prevMap;
    public GameObject[] Maps;


    void Start()
    {
        Vector3 mapSpawn = Vector3.zero;
        Maps = null;
        prevMap = null;

        if (Maps == null)
            Maps = GameObject.FindGameObjectsWithTag("Map");


        foreach (GameObject Map in Maps)
        {
            // check if pervmap isn't null
            if (prevMap != null)
            {

                // find end postion of prev map
                mapSpawn = prevMap.transform.position + (Vector3.forward * 10f);

            }

            print(mapSpawn);


            Instantiate(Map, mapSpawn,  Map.transform.rotation);

            prevMap = Map;
        }
    }

    private void Update()
    {
        
    }

    private void PlaceMap(GameObject[] Maps)
    {

    }
}
