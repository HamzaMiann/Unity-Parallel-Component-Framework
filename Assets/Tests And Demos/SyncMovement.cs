/*
 * @file            SyncMovement.cs
 * @author          Hamza Mian
 * @last_updated    August 30, 2018
 * @notes           Component that moves an object upwards synchronously
 */

using UnityEngine;

public class SyncMovement : MonoBehaviour {

    // caching is simulated to match the implementation of the AsyncMovement
    Vector3 pos;
    float deltaTime;
    float speed;

    // set starting value of cached data
    private void Start()
    {
        pos = transform.position;
        deltaTime = 1.0f;
        speed = Random.Range(0.1f, 1f);
    }

    // get/set cached values on the main thread in the update function
    void Update()
    {
        // expensive calculation simulation
        //----------------------------------
        for (int i = 0; i < 5000; ++i)
        {
            int k = i * i;
            if (k % 2 == 0)
                k = i;
        }
        //----------------------------------
        pos = new Vector3(pos.x, pos.y + speed * deltaTime, pos.z);
        transform.position = pos;
        deltaTime = Time.deltaTime;
    }
}
