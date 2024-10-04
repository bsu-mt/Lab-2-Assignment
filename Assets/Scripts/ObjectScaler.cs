using UnityEngine;
using UnityEngine.UI;  // Reference the UI namespace to access Slider

public class ObjectScaler : MonoBehaviour
{
    public Slider sizeSlider; // Used to connect the Slider in the UI
    public Transform objectToScale; // Objects to be scaled

    void Start()
    {
        // Make sure the Slider and Zoom objects are assigned
        if (sizeSlider != null && objectToScale != null)
        {
            // Monitor the changes in the Slider value and call the OnSliderValueChanged method every time it changes
            sizeSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }
    }

    // Executed when the value of the Slider changes
    public void OnSliderValueChanged(float newValue)
    {
        // Change the size of the object according to the value of the Slider
        objectToScale.localScale = new Vector3(newValue, newValue, newValue);
    }
}
