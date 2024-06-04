using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!PlaneMovementV2.onGround)
        {
            PlaneMovementV2.onGround = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (PlaneMovementV2.onGround)
        {
            PlaneMovementV2.onGround = false;
        }
    }
}
