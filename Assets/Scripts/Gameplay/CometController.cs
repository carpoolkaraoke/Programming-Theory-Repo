using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometController : SphereController
{
    [SerializeField] private float minMaxScaleRatio;
    [SerializeField] private float reactDistanceRatio;

    private float minStartLifetime;
    private float maxStartLifetime;
    private float minStartSize;
    private float maxStartSize;
    private ParticleSystem cometTrail;

    protected override void Awake()
    {
        base.Awake();

        // *** Polymorphism ***
        cometTrail = GetComponent<ParticleSystem>();
        maxStartLifetime = cometTrail.main.startLifetime.constant;
        minStartLifetime = maxStartLifetime * minMaxScaleRatio;
    }

    protected override void ExtraStuffFixedUpdate()
    {
        // This class doesn't implement this method call.
    }

    protected override void ExtraStuffUpdate()
    {
        float startLifetime = ValueAtDistance(minStartLifetime, maxStartLifetime, false);
        var cometTrailMain = cometTrail.main;
        cometTrailMain.startLifetime = startLifetime;
    }

    protected override float ValueAtDistance(float minValue, float maxValue, bool isFixedUpdate)
    {
        Vector3 position = isFixedUpdate ? sphereRb.position : transform.position;
        float distance = (position - spotlight.PositionZeroZ()).magnitude;
        float midDistance = reactDistance * reactDistanceRatio;

        float valueAtDistance;
        if (distance < midDistance)
        {
            valueAtDistance = maxValue;
        }
        else if (distance < reactDistance)
        {
            valueAtDistance = minValue + (maxValue - minValue) * (reactDistance - distance) / midDistance;
        }
        else
        {
            valueAtDistance = minValue;
        }

        return valueAtDistance;
    }
}
