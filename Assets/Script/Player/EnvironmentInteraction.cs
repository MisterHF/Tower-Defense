using UnityEngine;
using UnityEngine.InputSystem;

public class EnvironmentInteraction : MonoBehaviour
{
    private InputSystem_Actions action;
    private InputAction InputAction;

    [SerializeField] private LayerMask layerMask;

    [SerializeField] private GameObject wheelChoiceTurret;
    private void Awake()
    {
        action = new InputSystem_Actions();
        InputAction = action.Player.Attack;
    }
    private void Start()
    {
        InputAction.started += Interact;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D objectHit = Physics2D.Raycast(ray, Vector2.zero, 1, layerMask);

        if (objectHit)
        {
            print("je suis normalement là...");
            wheelChoiceTurret.SetActive(true);
            wheelChoiceTurret.transform.position = objectHit.transform.position;
           
            return;

        }
        //wheelChoiceTurret.SetActive(false);
        print("mais en faite non...");
    }
    private void OnEnable()
    {
        InputAction.Enable();
    }
    private void OnDisable()
    {
        InputAction.Disable();
    }
}
