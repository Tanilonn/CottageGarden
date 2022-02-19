using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string fileName;

    //events
    public List<EventHandler> events = new List<EventHandler>();
    public event EventHandler SalesSpiritEvent;
    public event EventHandler RandomPlantEvent;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        events.Add(SalesSpiritEvent);
        events.Add(RandomPlantEvent);

        InvokeRepeating("SpiritRandomEvent", 0f, 20f);
        InvokeRepeating("RandomPlant", 0f, 5f);

    }

    public void SpiritRandomEvent()
    {
        var random = new System.Random();
        int index = random.Next(events.Count);
        Debug.Log("event");
        SalesSpiritEvent?.Invoke(this, EventArgs.Empty);
    }

    public void RandomPlant()
    {
        var random = new System.Random();
        int index = random.Next(4);
        //25 percent chance
        if(index == 1)
        {
            RandomPlantEvent?.Invoke(this, EventArgs.Empty);
        }
    }


}
