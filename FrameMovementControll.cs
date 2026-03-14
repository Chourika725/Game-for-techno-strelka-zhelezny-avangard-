using UnityEngine;

public class FrameMovementControll : MonoBehaviour
{
    public float speed = 0f;
    private Rigidbody rb;
    private Vector3 movementInput;
    public static FrameMovementControll Instance;
    private bool physicsActive = false;
    public GameObject CameraCara;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CameraCara.active = !physicsActive;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = new Vector3(
            Mathf.Round(transform.position.x * 2f) / 2f,
            Mathf.Round(transform.position.y * 2f) / 2f,
            Mathf.Round(transform.position.z * 2f) / 2f
        );
        transform.rotation = Quaternion.identity;
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementInput = new Vector3(horizontal, 0.0f, vertical);

        if (Input.GetKeyDown(KeyCode.G))
        {

            physicsActive = !physicsActive;
            CameraCara.active = !physicsActive;

            if (physicsActive)
            {
                // Включаем физику
                rb.isKinematic = false;
                rb.constraints = RigidbodyConstraints.None;
                rb.useGravity = true;
            }
            else
            {
                // Выключаем физику
                rb.isKinematic = true;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                rb.useGravity = false;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Выравниваем позицию
                transform.position = new Vector3(
                    Mathf.Round(transform.position.x * 2f) / 2f,
                    Mathf.Round(transform.position.y * 2f) / 2f,
                    Mathf.Round(transform.position.z * 2f) / 2f
                );
                transform.rotation = Quaternion.identity;
            }
        }
    }

    void FixedUpdate()
    {
        if (physicsActive && !rb.isKinematic)
        {
            Vector3 newVelocity = movementInput * speed;
            newVelocity.y = rb.linearVelocity.y;
            rb.linearVelocity = newVelocity;
        }
    }
}