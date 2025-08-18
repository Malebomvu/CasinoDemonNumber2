using UnityEngine;
using UnityEngine.InputSystem;

public class Pickupable : MonoBehaviour
{
    [Header("Pickup Settings")]
    public float pickupRange = 3f;
    public Transform HoldObject;
    private Pickupable heldObject;
    private Rigidbody rb;

    [Header("Look")]
    [SerializeField] private Transform camerTransform;
    Transform View = null;
    float cameraRotation = 0f;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void PickUp(Transform HoldObject) { rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.SetParent(HoldObject);
        transform.localPosition = Vector3.zero;

    }
    public void Drop() { rb.useGravity = true;
        transform.SetParent(null);
    }
    public void MoveToHoldObject(Vector3 targetPosition)
    { rb.MovePosition(targetPosition); }
    public void OnPickUp(InputAction.CallbackContext context)
    {
        Transform cameraTransform = null;
        
        if (!context.performed) return;
    
     if (heldObject == null)
        { Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, pickupRange))
            { Pickupable pickUp = hit.collider.GetComponent<Pickupable>();
            if(pickUp != null)
                { pickUp.PickUp(HoldObject);
                    heldObject = null;
                }
            }
        }
     else
        { heldObject.Drop();
            heldObject = null;
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (heldObject != null)
        { heldObject.MoveToHoldObject(HoldObject.position); }
    }
}
