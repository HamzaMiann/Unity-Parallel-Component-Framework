/*
 * @file            SyncTest.cs
 * @author          Hamza Mian
 * @last_updated    August 30, 2018
 * @notes           Component that spawns a certain number of cubes with SyncMovement components
 */

using UnityEngine;

public class SyncTest : MonoBehaviour {

    public int cubesToSpawn = 100;
    public GameObject cube;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < cubesToSpawn; ++i)
        {
            GameObject cb = Instantiate(cube);
            cb.transform.position = new Vector3(Random.Range(-18f, 18f), Random.Range(-2f, 2f), Random.Range(-18f, 10f));
            cb.AddComponent<SyncMovement>();
        }
    }
}
