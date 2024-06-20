using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullHook : MonoBehaviour
{

    public KeyCode PullPress = KeyCode.Mouse1;

    public LineRenderer Cable;
    public Transform GrappleTip;
    public Transform Camera;
    public Transform Player;


    public LayerMask GrapplePoint;

    public float MaxPullDistance;
    public float PullDelayTime;

    private Vector3 PullPoint;

    

    public float PullCooldown;
    private float PullCooldownTimer;

    private bool Hooked;

    public Rigidbody PlayerRB;



    //public CharacterController CharControl;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PullPress)) StartPullHook();
        //if (Input.GetKeyUp(PullPress)) StopPullHook();

        if (PullCooldownTimer > 0)
            PullCooldownTimer -= Time.deltaTime;
    }


    private void LateUpdate()
    {
       if(Hooked)
            Cable.SetPosition(0,GrappleTip.position);


        float ReachedPullHookPoint = 30f;

        if (Vector3.Distance(transform.position, PullPoint) <= ReachedPullHookPoint)
        {
            StopPullHook();
        }
    }



    private void StartPullHook()
    {
        if (PullCooldownTimer > 0) return;

        Hooked = true;

        RaycastHit hit;
        if(Physics.Raycast(Camera.position, Camera.forward, out hit, MaxPullDistance, GrapplePoint))
        {
            PullPoint = hit.point;

            Invoke(nameof(Pulling),PullDelayTime);
        }
        else
        {
            PullPoint = Camera.position + Camera.forward * MaxPullDistance;

            Invoke(nameof(StopPullHook),PullDelayTime);
        }

        Cable.enabled = true;
        Cable.SetPosition(1,PullPoint);


    }


    private void Pulling()
    {
        Vector3 PullHookDirection = (PullPoint - transform.position).normalized;

        float PullHookSpeed = 40f;

        PlayerRB.useGravity = false;

        PlayerRB.AddForce((PullPoint - transform.position).normalized * PullHookSpeed, ForceMode.VelocityChange);


        
    }


    private void StopPullHook()
    {
        Hooked = false;

        PlayerRB.useGravity = true;

        PullCooldownTimer = PullCooldown;

        Cable.enabled = false;
    }



  


  

    


}
