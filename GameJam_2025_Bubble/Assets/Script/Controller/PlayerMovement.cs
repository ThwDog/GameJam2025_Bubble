using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    internal Controller control;
    internal PlayerController player;
    internal Rigidbody rb;

    [Header("Gravity custom adjust")]
    public float _gravity = -9.81f;
    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    [Header("Gravity real adjust")]
    public float g_Weight_normal = 1;


    private void Start() {
        control = GetComponent<Controller>();
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    public virtual void move(){

    }

    public virtual void action(){

    }

    public virtual void passive(){

    }

    public virtual void gravity_custom(){
        Vector3 gravityForce = Vector3.up * _gravity;

        gravityForce = Vector3.SmoothDamp(Vector3.zero, gravityForce, ref velocity, smoothTime);

        rb.AddForce(gravityForce, ForceMode.Acceleration);
    }

    public virtual void gravity_realistic(float multiply){
        rb.AddForce(Physics.gravity * g_Weight_normal * multiply, ForceMode.Acceleration);
    }
}
