using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : SphereController
{
    [SerializeField] private float maxScale;
    [SerializeField] private float maxDrag;

    protected override void ExtraStuffFixedUpdate()
    {
        float drag = ValueAtDistance(1, maxDrag, true);
        sphereRb.drag = drag;
    }

    protected override void ExtraStuffUpdate()
    {
        float scale = ValueAtDistance(1, maxScale, false);
        transform.localScale = scale * Vector3.one;
    }
}
