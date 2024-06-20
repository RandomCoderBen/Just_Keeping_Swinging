using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingHook : MonoBehaviour
{
    public KeyCode SwingPress = KeyCode.Mouse0;

    private Vector3 currentGrapplePosition;


    public LineRenderer Cable;
    public Transform GrappleTip;
    public Transform Camera;
    public Transform Player;


    public LayerMask GrapplePoint;



    private float MaxSwingDistance = 50f;
    private Vector3 SwingPoint;
    private SpringJoint Joint;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(SwingPress)) StartSwing();
        if (Input.GetKeyUp(SwingPress)) StopSwing();
    }


    void LateUpdate()
    {
        DrawCable();
    }


    private void StartSwing()
    {
        RaycastHit Hit;
        if (Physics.Raycast(Camera.position, Camera.forward, out Hit, MaxSwingDistance, GrapplePoint))
        {
            SwingPoint = Hit.point;
            Joint = Player.gameObject.AddComponent<SpringJoint>();
            Joint.autoConfigureConnectedAnchor = false;
            Joint.connectedAnchor = SwingPoint;

            float distanceFromPoint = Vector3.Distance(Player.position, SwingPoint);

            Joint.maxDistance = distanceFromPoint * 0.8f;
            Joint.minDistance = distanceFromPoint * 0.25f;


            Joint.spring = 4.5f;
            Joint.damper = 7f;
            Joint.massScale = 4.5f;


            Cable.positionCount = 2;
            currentGrapplePosition = GrappleTip.position;

        }
    }

    private void StopSwing()
    {
        Cable.positionCount = 0;
        Destroy(Joint);
    }

    void DrawCable()
    {
        if (!Joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, SwingPoint, Time.deltaTime * 8f);

        Cable.SetPosition(0, GrappleTip.position);
        Cable.SetPosition(1, currentGrapplePosition);
    }

}
