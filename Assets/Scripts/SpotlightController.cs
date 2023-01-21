using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    [SerializeField] private Light spotlight;

    private float spotlightPositionZ;

    private void Start()
    {
        spotlightPositionZ = spotlight.transform.position.z;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 position = hit.point;
                position.z = spotlightPositionZ;
                spotlight.transform.position = position;
            }
        }
    }

    public Vector3 PositionZeroZ()
    {
        return new Vector3(spotlight.transform.position.x, spotlight.transform.position.y);
    }
}
