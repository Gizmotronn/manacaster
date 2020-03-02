using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private Image content;

    [SerializeField]
    private float lerpSpeed;

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

            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }

            // currentValue = value; // Value (RHS) set in player.cs // See https://acord-robotics.github.io/stellarios/ar-11-healthmanabar2dot0/
            currentFill = currentValue / MyMaxValue;
        
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MyMaxValue = 100; // Prevents the health/mana going above 100
        
        content = GetComponent<Image>(); // The variable "content" is connected/references the "health", "mana" game objects in scene: "scene"
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFill != content.fillAmount){
            content.fillAmount = Mathf.Lerp(content.fillAmount,currentFill, Time.deltaTime * lerpSpeed); // Moves equally on every single device // Smooth transitions
        }
        

        Debug.Log(MyCurrentValue);

        content.fillAmount = currentFill;
    }

    // Initialize for stat values
    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyMaxValue = currentValue;
    }
}
