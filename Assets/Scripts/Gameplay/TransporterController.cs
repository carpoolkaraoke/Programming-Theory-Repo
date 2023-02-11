using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterController : MonoBehaviour
{
    // *** Encapsulation ***
    [Header("In-Scene Game Objects")]
    [SerializeField] private Light spotlight;
    [SerializeField] private SphereCollider bumper;

    // *** Encapsulation ***
    private float spotlightPositionZ;
    private float rayRange;

    private void Start()
    {
        // *** Abstraction ***
        InitializeFields();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // *** Abstraction ***
            MoveBumper();
        }
        if (Input.GetMouseButtonDown(1))
        {
            // *** Abstraction ***
            MoveSpotlight();
        }
    }

    public Vector3 PositionZeroZ()
    {
        return new Vector3(spotlight.transform.position.x, spotlight.transform.position.y);
    }

    private void InitializeFields()
    {
        spotlightPositionZ = spotlight.transform.position.z;
        rayRange = 2 * Mathf.Abs(Camera.main.transform.position.z);
    }

    private void MoveSpotlight()
    {
        int layermask = 1 << 6;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayRange, layermask))
        {
            Vector3 position = hitInfo.point;
            position.z = spotlightPositionZ;
            spotlight.transform.position = position;
        }
    }

    private void MoveBumper()
    {
        int layermask = 1 << 6;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayRange, layermask))
        {
            Vector3 position = hitInfo.point;
            bumper.transform.position = position;
        }
    }
}
