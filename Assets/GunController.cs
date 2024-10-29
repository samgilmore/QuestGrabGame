using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform muzzlePoint;
    public float projectileSpeed = 20f;

    private OVRGrabbable grabbable;

    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        Debug.Log("GunController initialized.");
    }

    void Update()
    {
        if (grabbable.isGrabbed)
        {
            Debug.Log("Gun is grabbed.");

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Debug.Log("Trigger pressed.");
                ShootProjectile();
            }
        }
    }

    void ShootProjectile()
    {
        Debug.Log("Shooting projectile...");
        GameObject projectile = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation);

        if (projectile != null)
        {
            Debug.Log("Projectile instantiated.");
        }

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = muzzlePoint.forward * projectileSpeed;
            Debug.Log("Projectile velocity set.");
        }
        else
        {
            Debug.LogWarning("No Rigidbody found on projectile!");
        }
    }
}