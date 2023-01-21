using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class SphereController : MonoBehaviour
{
    [SerializeField] private float moveForce;
    [SerializeField] protected float reactDistance;

    private Vector3 direction;
    protected Rigidbody sphereRb;
    private SpotlightController spotlight;

    private void Awake()
    {
        sphereRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        spotlight = FindObjectOfType<SpotlightController>();

        float angleRad = Random.Range(0f, 2 * Mathf.PI);
        direction = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private void FixedUpdate()
    {
        AddForces();
        ExtraStuffFixedUpdate();
    }

    private void Update()
    {

        ExtraStuffUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        direction = sphereRb.velocity.normalized;
    }

    private void AddForces()
    {
        sphereRb.AddForce(moveForce * direction);
    }

    protected float ValueAtDistance(float minValue, float maxValue, bool isFixedUpdate)
    {
        Vector3 position = isFixedUpdate ? sphereRb.position : transform.position;
        float distance = (position - spotlight.PositionZeroZ()).magnitude;
        float valueAtDistance = (distance > reactDistance) ? minValue : minValue + (maxValue - minValue) * (reactDistance - distance) / reactDistance;

        return valueAtDistance;
    }

    protected abstract void ExtraStuffFixedUpdate();

    protected abstract void ExtraStuffUpdate();
}
