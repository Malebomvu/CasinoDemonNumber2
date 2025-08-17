using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject bullet;
    public Transform gunPoint;
    public float gravity = -9.8f;

    public void OnShoot (InputAction.CallbackContext context) { if (context.performed) { Shoot(); } }
    private void Shoot()
    { 
        if (bullet != null && gunPoint != null)
        { GameObject bullets = Instantiate(bullet, gunPoint.position, gunPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null) 
            { rb.AddForce (gunPoint.forward * 100f); }
        }
        
        
    }
    private void CollisionEnter(Collision collision) { if (collision.gameObject.CompareTag("Enemy"))
        { print("EnemyHit" + collision.gameObject.name + "!"); } }
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
      
        
    }
   
    
  
        
        
    
    
    
       
    
}
