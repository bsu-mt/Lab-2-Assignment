using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NPCInteraction : MonoBehaviour
{
    // The target position where the player will be teleported.
    public Transform playerDestination;

    // Tags for identifying the left and right hand controllers.
    public string leftHandTag = "Left";
    public string rightHandTag = "Right";

    // Start is called before the first frame update.
    // Check if the playerDestination is properly set in the inspector.
    private void Start()
    {
        if (playerDestination == null)
        {
            // Display a warning in the console if the playerDestination is not assigned.
            Debug.LogWarning("Player destination is not set!");
        }
    }

    // This method is responsible for teleporting the player.
    // It is triggered when an object enters the interactable range (Select Enter).
    public void TeleportPlayer(SelectEnterEventArgs args)
    {
        // If playerDestination is not set, exit the method.
        if (playerDestination == null) return;

        // Get the interactor object (the object performing the interaction, e.g., hand controller).
        var interactor = args.interactorObject;

        // If the interactor or its transform is null, exit the method.
        if (interactor == null || interactor.transform == null) return;

        // Log which interactor triggered the teleport (e.g., left hand or right hand).
        Debug.Log("TeleportPlayer triggered by: " + interactor.transform.name);

        // Check if the interactor's tag matches the left hand tag (used for teleporting).
        if (interactor.transform.CompareTag(leftHandTag))
        {
            Debug.Log("Teleporting player");

            // Get the root of the interactor (typically the player's transform root).
            Transform player = interactor.transform.root;

            // Teleport the player to the set playerDestination position and rotation.
            player.position = playerDestination.position;
            player.rotation = playerDestination.rotation;

            // Log a message confirming the teleportation.
            Debug.Log("Teleported!");
        }
    }

    // This method is triggered when an interactable object is activated (e.g., A button press).
    public void Interact(ActivateEventArgs args)
    {
        // Get the interactor object (the object performing the interaction, e.g., hand controller).
        var interactor = args.interactorObject;

        // If the interactor or its transform is null, exit the method.
        if (interactor == null || interactor.transform == null) return;

        // Log which interactor triggered the interaction.
        Debug.Log("Interact triggered by: " + interactor.transform.name);

        // Check if the interactor's tag matches the right hand tag (used for activating interactions).
        if (interactor.transform.CompareTag(rightHandTag))
        {
            // Log a message for successful interaction.
            Debug.Log("Happy Halloween!");
        }
    }
}
