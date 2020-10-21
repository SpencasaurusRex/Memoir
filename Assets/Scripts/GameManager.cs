using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    IGameEvent[] events;
    int currentEventIndex;
    
    void Start()
    {
        events = GetComponentsInChildren<IGameEvent>();
        
        currentEventIndex = 0;
        events[0].EventStart();
    }
    
    void Update()
    {
        if (events.Length == currentEventIndex)
        {
            return;
        }
        
        if (events[currentEventIndex].EventUpdate())
        {
            currentEventIndex++;
            if (currentEventIndex < events.Length)
            {
                events[currentEventIndex].EventStart();
            }
        }
    }
}
