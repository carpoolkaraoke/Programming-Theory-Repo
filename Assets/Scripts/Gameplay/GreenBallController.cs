using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallController : SphereController
{
    // *** Encapsulation ***
    [SerializeField] private float maxScale;
    [SerializeField] private float maxDrag;
    [SerializeField] private float scaleSmoothTime;

    // *** Encapsulation ***
    private float minScale = 1f;
    private float scale;
    private float currentScale;

    // *** Polymorphism ***
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        GameManager.Instance.IncreaseScore(collision);
    }

    // *** Polymorphism ***
    protected override void ExtraStuffFixedUpdate()
    {
        float drag = ValueAtDistance(1, maxDrag, true);
        sphereRb.drag = drag;
    }

    // *** Polymorphism ***
    protected override void ExtraStuffUpdate()
    {
        float targetscale = ValueAtDistance(minScale, maxScale, false);
        scale = Mathf.SmoothDamp(scale, targetscale, ref currentScale, scaleSmoothTime);
        transform.localScale = scale * Vector3.one;
    }

    // *** Polymorphism ***
    protected override float ValueAtDistance(float minValue, float maxValue, bool isFixedUpdate)
    {
        Vector3 position = isFixedUpdate ? sphereRb.position : transform.position;
        float distance = (position - spotlight.PositionZeroZ()).magnitude;
        float valueAtDistance = (distance > reactDistance) ? minValue : minValue + (maxValue - minValue) * (reactDistance - distance) / reactDistance;

        return valueAtDistance;
    }
}
