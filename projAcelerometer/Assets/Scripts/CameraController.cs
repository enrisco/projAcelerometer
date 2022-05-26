using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    float distance = -10f, height = 0f, damping = 5.0f;

    [Header("Min")]
    public float minX;
    public float minY;
    public float minZ;
    [Header("Max")]
    public float maxX;
    public float maxY;
    public float maxZ;

    void Update()
    {
        // get the position of the target (AKA player)
        Vector3 wantedPosition = target.TransformPoint(0, height, distance);

        // check if it's inside the boundaries on the X position
        wantedPosition.x = (wantedPosition.x < minX) ? minX : wantedPosition.x;
        wantedPosition.x = (wantedPosition.x > maxX) ? maxX : wantedPosition.x;

        wantedPosition.y = (wantedPosition.y < minY) ? minY : wantedPosition.y;
        wantedPosition.y = (wantedPosition.y > maxY) ? maxY : wantedPosition.y;

        // check if it's inside the boundaries on the Y position
        wantedPosition.z = (wantedPosition.z < minZ) ? minZ : wantedPosition.z;
        wantedPosition.z = (wantedPosition.z > maxZ) ? maxZ : wantedPosition.z;

        // set the camera to go to the wanted position in a certain amount of time
        transform.position = Vector3.MoveTowards(transform.position, wantedPosition, (Time.deltaTime * damping));
    }
}

