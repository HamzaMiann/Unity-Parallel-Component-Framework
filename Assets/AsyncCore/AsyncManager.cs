/*
 * @file            AsyncManager.cs
 * @author          Hamza Mian
 * @last_updated    August 30, 2018
 * @notes           This object should never be directly instantiated or used by the client.
 *                  It will spawn by itself when an AsyncBehaviour component is self-registered
 */

using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AsyncManager : MonoBehaviour {

    // singleton instance
    private static AsyncManager _instance;

    // list of AsyncBehaviour components that will self-register
    private List<AsyncBehaviour> asyncComponents = new List<AsyncBehaviour>();
    private List<Task> tasks;

    // gets the instance of this manager
    public static AsyncManager Instance()
    {
        if (_instance == null)
        {
            GameObject singleton = new GameObject("AsyncManager");
            _instance = singleton.AddComponent<AsyncManager>();
        }
        return _instance;
    }
	
    // updates all async components
	void Update () {
        tasks = new List<Task>();
        
        foreach (AsyncBehaviour component in asyncComponents)
        {
            if (component == null)
                continue;
            tasks.Add(Task.Run(() => { component.AsyncUpdate(); }));
        }

        Task.WaitAll(tasks.ToArray());
        
    }

    // function to register AsyncBehaviour components
    public void addAsyncComponent(AsyncBehaviour component)
    {
        asyncComponents.Add(component);
    }
}
