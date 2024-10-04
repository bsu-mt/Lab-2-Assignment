using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LanternLightToggle : MonoBehaviour
{
    public Light pointLight; 
    private bool isLightOn = true;

    public void Select(BaseInteractionEventArgs args)
    {
        // Retrieve the interactor object (usually a hand controller or other device).
        var interactor = args.interactorObject;

        // If the interactor or its transform is null, exit the method to avoid errors.
        if (interactor == null || interactor.transform == null) return;

        // Log the name of the interactor that triggered the selection event.
        Debug.Log("Select triggered by: " + interactor.transform.name);

        // Check if the interactor's tag matches the right hand tag, used for selecting interactions.
        if (interactor.transform.CompareTag("Right")) // Assuming "Right" is the tag for right hand interactor
        {
            // Toggle the light on or off.
            isLightOn = !isLightOn;
            pointLight.enabled = isLightOn;

            // Log the current state of the light.
            Debug.Log("Light toggled. Current state: " + (isLightOn ? "On" : "Off"));
        }
    }
}
