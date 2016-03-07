using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    // Use this for initialization

	public GameObject bulletSpawn;
    public GameObject bullet;
	Animator anim;
    Rigidbody rb;
    IngameMenu menuRef;
    void Start() {
        rb = GetComponent<Rigidbody>();
        menuRef = gameObject.GetComponent<IngameMenu>();
    }

    public float speed = 2;

    public int livesLeft = 10;
    public int bulletsLeft = 50;
    public float timeLeft = 60;

    public float delayTime = 0.2f;
    public float mouseFix;

    void Control()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TimeMoving = false;


        if (Input.GetMouseButton(0) 
            && Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(mouseWorldSpace.x, mouseWorldSpace.z)) > mouseFix 
            && shootingMode == false 
            && switching == false
            && menu == false)
        {
            TimeMoving = true;
            timeLeft -= Time.deltaTime;
            var targetRotation = Quaternion.LookRotation(mouseWorldSpace - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            transform.rotation = targetRotation;
            if (targetRotation.y - transform.rotation.y <= 1f && targetRotation.y - transform.rotation.y >= -1f)
            {
                timerStart = true;
            }
            transform.rotation = Quaternion.Euler(270f, transform.eulerAngles.y + 180f, 0f);
            if (Timer > delayTime) {
                Move();
            }
        }

        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(mouseWorldSpace.x, mouseWorldSpace.z)) < mouseFix)
        {
            TimeMoving = false;
            rb.velocity = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetMouseButton(0) && shootingMode == true && switching == false && menu == false) {
            TimeMoving = true;
            timeLeft -= Time.deltaTime;
            rb.velocity = new Vector3(0f, 0f, 0f);
            var targetRotation = Quaternion.LookRotation(mouseWorldSpace - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            transform.rotation = targetRotation;
            if (targetRotation.y - transform.rotation.y <= 1f && targetRotation.y - transform.rotation.y >= -1f)
            {
                timerStart = true;
            }
            transform.rotation = Quaternion.Euler(270f, transform.eulerAngles.y + 180f, 0f);
            if (Timer > delayTime)
            {
                Shoot();
            }

        }
    }

    public float moveSpeed;

    void Move() {
        rb.velocity = transform.up * moveSpeed;
    }

    public float bulletSpeed;

    GameObject bullit;
    bool coolDownState = false;

    public GameObject fireParticle;

    void Shoot()
    {
        if (coolDownState == false)
        {
            coolDownState = true;
			bullit = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;

            Instantiate(fireParticle, bulletSpawn.transform.position, bulletSpawn.transform.rotation);


        }
    }

    public float coolDownTime;
    public float coolDownTimer = 1.07f;
    void ShootDelay() {
        if (coolDownState)
        {
            TimeMoving = true;
            coolDownTimer -= Time.deltaTime;
            if (coolDownTimer < 0f)
            {
                coolDownTimer = coolDownTime;
                coolDownState = false;
                TimeMoving = false;
            }
        }
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
            rb.velocity = new Vector3(0f, 0f, 0f);
        }

    }

    bool shootingMode = false;
    public float switchTime;
    bool switching = false;

    void ModeSwitch()
    {
        if (Input.GetMouseButtonDown(1) && shootingMode == false && switching == false)
        {
            switching = true;
        }
        else if (Input.GetMouseButtonDown(1) && shootingMode == true && switching == false)
        {
            switching = true;
        }
    }

    float switchTiming;

    void SwitchTimer()
    {
        if (switching == true)
        {
            TimeMoving = true;
            switchTiming += Time.deltaTime;
            timeLeft -= Time.deltaTime;

            if (!shootingMode)
            {
                rb.velocity = new Vector3(0f, 0f, 0f);
            }

            if (switchTiming >= switchTime)
            {
                if (shootingMode)
                {
                    shootingMode = false;
                }
                else shootingMode = true;
                switching = false;
                switchTiming = 0;
                TimeMoving = false;
            }
        }
    }

    bool menu;
    bool timerStart = false;
    float Timer;

    // Update is called once per frame
    void Update () {
        menu = menuRef.menuActive;
        Control();
        Delay();
        ModeSwitch();
        SwitchTimer();
        TimeFlowSetter();
        ShootDelay();
		transform.position = new Vector3(transform.position.x, 0.82f, transform.position.z);


    }

    public bool TimeMoving = false;

    void TimeFlowSetter()
    {
        if (!TimeMoving)
        {
            Time.timeScale = 0.0000001F;
        }
        if (TimeMoving)
        {
            Time.timeScale = 1.0f;
        }
    }

}