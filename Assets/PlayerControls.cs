using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    // Use this for initialization

    public Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
    }

    public float speed = 2;

    bool leftMouseDown = false;
    bool delayStart = false;

    public int livesLeft = 10;
    public int bulletsLeft = 50;
    float timeLeft = 60;

    public float delayTime = 0.2f;
    public float mouseFix;

    void Control()
    {
        Vector3 upAxis = new Vector3(0, 0, -1);
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        if (Input.GetMouseButton(0) && Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(mouseWorldSpace.x, mouseWorldSpace.z)) > mouseFix)
        {
            var targetRotation = Quaternion.LookRotation(mouseWorldSpace - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0f, targetRotation.y, 0f);
            if (targetRotation.y - transform.rotation.y <= 1f && targetRotation.y - transform.rotation.y >= -1f)
            {
                timerStart = true;
            }
            transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
            if (Timer > delayTime) {
                Move();
            }
        }

        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(mouseWorldSpace.x, mouseWorldSpace.z)) < mouseFix)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
    }

    public float moveSpeed;

    void Move() {
            rb.velocity = transform.forward * moveSpeed; 
    }

    void Delay() {
        if (timerStart == true && Input.GetMouseButton(0) && Timer < delayTime)
        {
            Timer += Time.deltaTime;
        }
        else if (!Input.GetMouseButton(0))
        {
            Timer = 0;
            timerStart = false;
            rb.velocity = new Vector3(0f, 0f ,0f);
        }

    }

    bool timerStart = false;
    float Timer;

    // Update is called once per frame
    void Update () {
        Control();
        Delay();
	}

}