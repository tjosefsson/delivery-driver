using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(42, 224, 28, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] float destroyDelay = 0.3f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("It was his mistake!");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage) {
            
            Debug.Log("Package picked up.");
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            hasPackage = true;

        } else if(other.tag == "Package" && hasPackage) {
            Debug.Log("You already have a package.");
        }
        
        if(other.tag == "Customer" && hasPackage) {
            Debug.Log("You Delivered the package");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        } else if(other.tag == "Customer" && !hasPackage) {
            Debug.Log("You dont have a package to deliver");
        }
    }
}