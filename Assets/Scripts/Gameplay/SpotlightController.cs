using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    // *** Encapsulation ***
    [Header("In-Scene Game Objects")]
    [SerializeField] private Light spotlight;

    // *** Encapsulation ***
    private float spotlightPositionZ;
    private float spotlightRange;

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
        spotlightRange = spotlight.range;
    }

    private void MoveSpotlight()
    {
        int layermask = 1 << 6;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, spotlightRange, layermask))
        {
            Vector3 position = hitInfo.point;
            position.z = spotlightPositionZ;
            spotlight.transform.position = position;
        }
    }
}
