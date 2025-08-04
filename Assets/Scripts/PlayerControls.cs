using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public InputActionAsset InputActions;

    private InputAction p_moveAction;

    private Vector2 p_moveAmt;
    private Animator p_animator;
    private Rigidbody p_rigidbody;

    public float WalkSpeed = 5;


    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        p_moveAction = InputSystem.actions.FindAction("Move");

        p_animator = GetComponent<Animator>();
        p_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        p_moveAmt = p_moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Walking();
    }

    private void Walking()
    {
        p_animator.SetFloat("Speed", p_moveAmt.y);
        p_rigidbody.MovePosition(p_rigidbody.position + transform.forward * p_moveAmt.y * WalkSpeed * Time.deltaTime);

    }
}
