using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    [SerializeField] float destroyPackageDelay = 0.5f;
    [SerializeField] Color32 packagedCarColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 emptyCarColor = new Color32(1, 1, 1, 1);

    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package in car");
            hasPackage = true;
            spriteRenderer.color = packagedCarColor;
            Destroy(other.gameObject, destroyPackageDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivery done");
            hasPackage = false;
            spriteRenderer.color = emptyCarColor;
        }
    }
}
