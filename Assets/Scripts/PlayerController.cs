using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float lookSpeed = 2f;
    public float interactDistance = 2f;
    private CharacterController controller;
    private Camera cam;
    private float pitch;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * v + transform.right * h;
        controller.SimpleMove(move * moveSpeed);

        float mx = Input.GetAxis("Mouse X") * lookSpeed;
        float my = Input.GetAxis("Mouse Y") * lookSpeed;
        transform.Rotate(0, mx, 0);
        pitch -= my;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        cam.transform.localEulerAngles = new Vector3(pitch, 0, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            var interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
        }
    }
}

public interface IInteractable
{
    void OnInteract();
}
