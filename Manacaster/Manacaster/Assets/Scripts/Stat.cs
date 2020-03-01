using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private Image content;

    private float currentFill;

    public float MyMaxValue { get; set; } // Max value for health, game objects

    private float currentValue; 

    public float MyCurrentValue // property for accessing from other scripts.
    {
        get{
            return currentValue; // Read current value // Check /Hashtag/
        }

        set{
            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }

            currentValue = value; // Value (RHS) set in player.cs
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>(); // The variable "content" is connected/references the "health", "mana" game objects in scene: "scene"
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(MyCurrentValue);
    }
}
