using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ControlsForMovement : MonoBehaviour
{
    Vector2 facing = Vector2.zero;  

    public float speed;
    public StuckInSpace controls;
    public Camera Look;
    public Rigidbody rb;
    public GameObject Player;
    public float boostSpeed;
    public float turnSpeed = 0.01f;

    private InputAction WSZX;
    private InputAction up;
    private InputAction down;
    private InputAction right;
    private InputAction left;
    private InputAction flipForward;
    private InputAction flipDown;
    private InputAction barrelRollL;
    private InputAction barrelRollR;

    private void Awake()
    {
        controls = new StuckInSpace();
    }

    // Start is called before the first frame update
    void Start()
    {
        controls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        facing = WSZX.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(facing.x * speed, rb.velocity.y, facing.y * speed);
        if (up.IsPressed())
        {
            rb.AddForce(transform.up * speed, ForceMode.Force);
        }
        if (down.IsPressed())
        {
            rb.AddForce(-transform.up * speed, ForceMode.Force);
        }
        if (right.IsPressed())
        {
            Player.transform.RotateAroundLocal(Player.transform.up, turnSpeed);
        }
        if (left.IsPressed())
        {
            Player.transform.RotateAroundLocal(-Player.transform.up, turnSpeed);
        }
        if (flipDown.IsPressed())
        {
            Player.transform.Rotate(Vector3.right);
        }
        if (flipForward.IsPressed())
        {
            Player.transform.Rotate(Vector3.left);
        }
        if (barrelRollL.IsPressed())
        {
            Player.transform.Rotate(Vector3.forward);
        }
        if (barrelRollR.IsPressed())
        {
            Player.transform.Rotate(-Vector3.forward);
        }
    }

    public void OnEnable()
    {
        //This controls the actual controls being used
        WSZX = controls.Player.Move;
        up = controls.Player.ThrusterUp;
        down = controls.Player.ThrusterDown;
        right = controls.Player.right;
        left = controls.Player.left;
        flipForward = controls.Player.Flipforwards;
        flipDown = controls.Player.Flipdown;
        barrelRollL = controls.Player.BarrelRollLeft;
        barrelRollR = controls.Player.BarrelRollRight;

        up.Enable();
        right.Enable();
        left.Enable();
        flipForward.Enable();
        flipDown.Enable();
        down.Enable();
        WSZX.Enable();
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }

    public void DisableMovement()
    {
        controls.Disable();
    }

    public void EnableMovement()
    {
        controls.Enable();
    }
}
