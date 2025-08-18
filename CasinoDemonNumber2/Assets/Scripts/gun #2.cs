using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(Rigidbody ))]
public class guns : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  

      
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Mouse1)) { GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.right * 10f);
        } 
    }
}
