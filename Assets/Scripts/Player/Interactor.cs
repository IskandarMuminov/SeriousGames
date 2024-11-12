using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IInteractible {
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactRange;

    [SerializeField] private CharacterOutliner characterOutliner;
    [SerializeField] private float outlineSetVisibleRange;


    private void Update()
    {
        //InteractionOutline();
        InteractOnTap();
    }

    public void InteractOnTap()
    {
        // Check if the player tapped the screen or pressed the E key
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.E))
        {
            Ray r;

            // Determine the ray based on the input type
            if (Input.touchCount > 0)
            {
                // For touch, cast ray from the touch position
                Touch touch = Input.GetTouch(0);
                r = playerCamera.ScreenPointToRay(touch.position);
            }
            else
            {
                // For keypress (E), cast ray from the center of the screen
                r = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            }

            // Draw debug ray for visualization in the editor
            Debug.DrawRay(r.origin, r.direction * interactRange, Color.green, 1f);

            // Perform the raycast to detect objects within range
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                // Check if the object hit has an IInteractible component
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractible interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }


    public void InteractionOutline()
    {
        Ray r = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(r.origin, r.direction * interactRange, Color.green, 1f);

        if (Physics.Raycast(r, out RaycastHit hitInfo, outlineSetVisibleRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractible interactObj))
            {
                characterOutliner.SetOutline();
            }
        }

        else
        {
            characterOutliner.ResetOutline();
        }
    }



}
