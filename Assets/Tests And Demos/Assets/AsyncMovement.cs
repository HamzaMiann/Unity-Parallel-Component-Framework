/*
 * @file            AsyncMovement.cs
 * @author          Hamza Mian
 * @last_updated    August 30, 2018
 * @notes           Component that moves an object upwards asynchronously
 */

using UnityEngine;

public class AsyncMovement : AsyncBehaviour
{
    // Values used in separate threads must be cached and cannot be accessed by the main thread
    Vector3 pos;
    float deltaTime;
    float speed;

    // Should be used instead of the Awake() function
    public override void AsyncAwake() { }

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
        transform.position = pos;
        deltaTime = Time.deltaTime;
    }

    // All operations in this method should be independent, otherwise locks may be required
    // Multithreaded operations may occur here
    public override void AsyncUpdate()
    {
        // expensive calculation simulation
        //----------------------------
        for (int i = 0; i < 5000; ++i)
        {
            int k = i * i;
            if (k % 2 == 0)
                k = i;
        }
        //----------------------------
        pos = new Vector3(pos.x, pos.y + speed * deltaTime, pos.z);
    }

}
