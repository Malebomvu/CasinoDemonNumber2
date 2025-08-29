using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform playercamTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            float pickupDistance = 5f;
            if (Physics.Raycast(playercamTransform.position, playercamTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))
                Debug.Log(raycastHit.transform);
                if(raycastHit.transform.TryGetComponent(out GrabObjects objectgrab))
            {
                objectgrab.Grab(objectGrabPointTransform);
                Debug.Log(objectgrab);
            }
        }
    }
}
