using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AnalyticsEvent.GameStart();   // Tekee saman kuin analytics event tracker, kun valitaan "aloittaessa peliä"

        // AnalyticsEvent.Custom("Level Complete", new Dictionary<string, object>  // Oma custom event. Täytyy muuttaa parametrit!
        // {
        //     { "Level", "Level 1"}
        // });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
