/*
 * @file            AsyncBehvaiour.cs
 * @author          Hamza Mian
 * @last_updated    August 30, 2018
 * @notes           This class should be derived from to create async components.
 */

using UnityEngine;

public abstract class AsyncBehaviour : MonoBehaviour {

    // The AsyncAwake function should be used instead of the awake function
    private void Awake()
    {
        // self-registering instance
        AsyncManager.Instance().addAsyncComponent(this);
        this.AsyncAwake();
    }

    public abstract void AsyncAwake();
    
    // AsyncUpdate method should be implemented
    public abstract void AsyncUpdate();
}
