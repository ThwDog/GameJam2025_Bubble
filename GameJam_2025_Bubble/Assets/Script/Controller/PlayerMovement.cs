using System.Data.Common;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    internal Controller control;
    internal PlayerController player;
    internal Rigidbody rb;

    [Header("Gravity custom adjust")]
    [SerializeField] private float _gravity = -9.81f;
    internal float current_G;
    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    [Header("Gravity real adjust")]
    public float g_Weight_normal = 1;
    
    public bool _stop = false;
    private bool isResume = false;


    public virtual void Start() {
        control = GetComponent<Controller>();
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();

        current_G = _gravity;
    }

    public void movement(){
        if(!_stop){
            if(!isResume) resume();
            move();
            action();
            passive();
        }
        else stop();
    }

    public virtual void move(){

    }

    public virtual void action(){

    }

    public virtual void passive(){
        current_G =  _gravity * (player.checkHealthStageRevert() / 2);
        player.current_speed = (player.speed * 2) / player.checkHealthStageRevert();  
    }

    public virtual void stop(){
        // Debug.Log("Stop");
        _stop = true;
        current_G = -1000f;
        rb.velocity = Vector3.zero;
        isResume = false;
        gravity_custom();
    }

    public virtual void resume(){
        _stop = false;
        rb.velocity = Vector3.zero;
        current_G = _gravity;
        isResume = true;
        gravity_custom();
    }

    public virtual void gravity_custom(){
        Vector3 gravityForce = Vector3.up * current_G;

        gravityForce = Vector3.SmoothDamp(Vector3.zero, gravityForce, ref velocity, smoothTime);

        rb.AddForce(gravityForce, ForceMode.Acceleration);
    }

    public virtual void gravity_realistic(float multiply){
        rb.AddForce(Physics.gravity * g_Weight_normal * multiply, ForceMode.Acceleration);
    }
}
