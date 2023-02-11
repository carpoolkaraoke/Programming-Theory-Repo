using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class SphereController : MonoBehaviour
{
    // *** Encapsulation ***
    [Header("Fields")]
    [SerializeField] private float moveForce;
    [SerializeField] private float getUnstuckDirectionRatio;
    [SerializeField] protected float reactDistance;

    // *** Encapsulation ***
    private int stuckCount;
    private Vector3 direction;
    protected Rigidbody sphereRb;
    protected TransporterController spotlight;

    protected virtual void Awake()
    {
        sphereRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        spotlight = FindObjectOfType<TransporterController>();

        float angleRad = Random.Range(0f, 2 * Mathf.PI);
        direction = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private void FixedUpdate()
    {
        // *** Abstraction ***
        AddForces();
        ExtraStuffFixedUpdate();
    }

    private void Update()
    {
        // *** Abstraction ***
        ExtraStuffUpdate();
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        direction = sphereRb.velocity.normalized;
    }

    private void OnCollisionStay(Collision collision)
    {
        stuckCount += 1;
        if (stuckCount > 100)
        {
            // *** Abstraction ***
            GetUnstuck(collision);
            stuckCount = 0;
        }
    }

    private void OnCollisionExit()
    {
        stuckCount = 0;
    }

    private void AddForces()
    {
        sphereRb.AddForce(moveForce * direction);
    }

    private void GetUnstuck(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bottom Wall"))
        {
            direction.y = getUnstuckDirectionRatio;
            direction.Normalize();
        }
        else if (collision.gameObject.CompareTag("Top Wall"))
        {
            direction.y = -getUnstuckDirectionRatio;
            direction.Normalize();
        }
        else if (collision.gameObject.CompareTag("Left Wall"))
        {
            direction.x = getUnstuckDirectionRatio;
            direction.Normalize();
        }
        else if (collision.gameObject.CompareTag("Right Wall"))
        {
            direction.x = -getUnstuckDirectionRatio;
            direction.Normalize();
        }
    }

    // *** Polymorphism ***
    protected abstract float ValueAtDistance(float minValue, float maxValue, bool isFixedUpdate);

    // *** Polymorphism ***
    protected abstract void ExtraStuffFixedUpdate();

    // *** Polymorphism ***
    protected abstract void ExtraStuffUpdate();
}
