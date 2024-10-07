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
    
    [SerializeField] private float outlineSetVisibleRange;

    private void Update()
    {
       // InteractionOutline();
    }

    public void InteractOnTap() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray r;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                r = playerCamera.ScreenPointToRay(touch.position);
            }
            else
            {
                r = playerCamera.ScreenPointToRay(Input.mousePosition);
            }

          
            Debug.DrawRay(r.origin, r.direction * interactRange, Color.green, 1f);

            // perform the raycast to detect objects with colliders
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                // check if the object hit has an IInteractible component
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractible interactObj))
                {
                    interactObj.Interact(); 
                }

            }
        }
    }

    /*public void InteractionOutline()
    {
        Ray r = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(r.origin, r.direction * interactRange, Color.green, 1f);

        if (Physics.Raycast(r, out RaycastHit hitInfo, outlineSetVisibleRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out CharacterOutliner characterOutliner))
            {
                characterOutliner.SetOutline();
            }
        }
    }
*/
   

}
