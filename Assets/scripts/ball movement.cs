 using UnityEngine;
using UnityEngine.InputSystem;

public class ballmovement : MonoBehaviour
{
    public Rigidbody rb;
    [Header("final values")]
    [SerializeField] private float A_D_movement = 0f;
    [SerializeField] private float angle = 0f;
    [SerializeField] private float power = 0f;

    [Header("position movement")]
    public float A_D_speed = 1f;
    public float A_D_range = 0.78f;

    [Header("angle movement")]
    public float angle_speed = 1f;
    public float angle_range = 50f;

    [Header("power management")]
    public float power_speed = 1;
    public float max = -100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Position();
        Angle();
        ThrowingPower();

        if (Keyboard.current.spaceKey.wasPressedThisFrame) { 
            RollingSTones();
        }
    }
    void RollingSTones() {
        rb.AddForce(angle, 0, power);
    }
    void Position() {
        if (Keyboard.current.aKey.IsPressed()) { 
            A_D_movement = A_D_movement + A_D_speed * Time.deltaTime * 100;
        }
        if(Keyboard.current.dKey.IsPressed()) {
            A_D_movement = A_D_movement - A_D_speed * Time.deltaTime * 100;
        }
        A_D_movement = Mathf.Clamp(A_D_movement, -A_D_range, A_D_range);
        Vector3 pos = transform.position;
        pos.x = A_D_movement;
        rb.transform.position = pos;
    }

    void Angle() {
        if (Keyboard.current.leftArrowKey.IsPressed()) {
            angle = angle + angle_speed;
        }
        if(Keyboard.current.rightArrowKey.IsPressed()) {
            angle = angle - angle_speed;
        }
        angle = Mathf.Clamp(angle, -angle_range, angle_range);

    }

    void ThrowingPower() { 
        if(Keyboard.current.upArrowKey.IsPressed()) {
            power = power - power_speed * Time.deltaTime * 50;
        }
        if (Keyboard.current.downArrowKey.IsPressed())
        {
            power = power + power_speed * Time.deltaTime * 50;
        }
    }
}
