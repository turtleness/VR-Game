using UnityEngine;
using System.Collections;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Movement : MonoBehaviour {

    [SteamVR_DefaultActionSet("default")]
    public SteamVR_ActionSet actionSet;

    [SteamVR_DefaultAction("touchPad", "default")]
    public SteamVR_Action_Vector2 a_move;


    public GameObject Player;
    public Transform PlayerPos;
    public float joyMove = 0.1f;

    [SerializeField]
    private float m_MovingTurnSpeed = 360;
    [SerializeField]
    private float m_StationaryTurnSpeed = 180;

    private Vector3 movement;
    private bool jump;
    private float glow;
    private SteamVR_Input_Sources hand;
    private Interactable interactable;

    private float turnAmount;
    private float forwardAmount;

    private Vector3 input;

    private new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        interactable = GetComponent<Interactable>();
        interactable.activateActionSetOnAttach = actionSet;
    }

    private void Update()
    {
        if (interactable.attachedToHand)
        {
            hand = interactable.attachedToHand.handType;
            Vector2 m = a_move.GetAxis(hand);
            movement = new Vector3(m.x, 0, m.y);
        }
        else
        {
            movement = Vector2.zero;
        }

        PlayerPos.localPosition = movement * joyMove;

        float rot = transform.eulerAngles.y;

        movement = Quaternion.AngleAxis(rot, Vector3.up) * movement;

        Move(movement * 2);
    }

    public void Move(Vector3 move)
    {
        input = move;
        if (move.magnitude > 1f)
            move.Normalize();

        move = transform.InverseTransformDirection(move);

        turnAmount = Mathf.Atan2(move.x, move.z);
        forwardAmount = move.z;

        ApplyExtraTurnRotation();

    }

    private void ApplyExtraTurnRotation()
    {
        // help the character turn faster (this is in addition to root rotation in the animation)
        float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, forwardAmount);
        transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
    }
}


