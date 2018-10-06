




# Unity-Parallel-Component-Framework

A Unity framework to allow parallel processing of independent system components.
Used to increase performance when using multiple components that require heavy per-frame computation.

***Requirements:***

- .NET 4.x Framework enabled in Unity

***Notes:***

- Your Async components should be independent and not interact with other independent components
- Performance gains may only be seen if there is a large number of components that require heavy computation per-frame.
- You can play around with this Unity project to test performance impacts (AsyncDemoTest/SyncDemoTest prefabs demonstrate this)



# How to use in your project

Steps:

1. Add the **AsyncCore** folder to your Unity project
2. Derive your independent components from **AsyncBehvaiour**
3. Cache any data you will need for calculation in the **Start** method
4. Implement your calculation in the **AsyncUpdate** method
5. Set your updated cached data in the **Update** method
