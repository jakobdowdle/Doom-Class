using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSpeed = 2f;

    private float xRotation = 0f;
    [SerializeField] private Transform cameraTransform;

    public static PlayerController Instance;
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Instance = this;
    }

    void Update() {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement() {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveDirection += transform.right;
        }

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }

    void HandleMouseLook() {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;

        // UNCOMMENT THESE LINES OF CODE FOR VERTICAL CAMERA
        //float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;
        //xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent over-rotation

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
