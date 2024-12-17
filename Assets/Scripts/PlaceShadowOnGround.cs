using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceShadowOnGround : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float raycastDistance = 2f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float radius = 0.2f;
    [SerializeField] float verticalOffset = 0.02f;

    // Update is called once per frame
    void Update()
    {
        RaycastHit raycastHit;

        bool hasHit = Physics.SphereCast(target.position, radius, Vector3.down, out raycastHit,raycastDistance, layerMask);

        if (hasHit)
        {
            transform.position = new Vector3(target.position.x, raycastHit.point.y + verticalOffset, target.position.z);
        }
    }
}
