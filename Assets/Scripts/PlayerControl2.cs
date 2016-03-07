using UnityEngine;
using System.Collections;

public class PlayerControl2 : MonoBehaviour
{

    // Use this for initialization

    public GameObject bulletSpawn;
    public GameObject bullet;
    Rigidbody rb;
    IngameMenu menuRef;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        menuRef = gameObject.GetComponent<IngameMenu>();
    }

    public float speed = 2;

    public int livesLeft = 10;
    public int bulletsLeft = 50;
    public float timeLeft = 60;

    public float delayTime = 0.2f;
    public float mouseFix;

    public GameObject bulletmove;

    void Control()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TimeMoving = false;

        /*if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(mouseWorldSpace.x, mouseWorldSpace.z)) < mouseFix)
        {
            TimeMoving = false;
            rb.velocity = new Vector3(0f, 0f, 0f);
        }*/

        if (Input.GetMouseButton(0) && menu == false)
        {
            TimeMoving = true;
            timeLeft -= Time.deltaTime;
            var targetRotation = Quaternion.LookRotation(mouseWorldSpace - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            transform.rotation = targetRotation;
            transform.rotation = Quaternion.Euler(270f, transform.eulerAngles.y + 180f, 0f);
            if (Timer > delayTime)
            {
                Shoot();
            }

        }
    }

    public float moveSpeed;
    Vector3 movement = new Vector3(0f, 0f, 0f);

    void Move()
    { 
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.up * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = -transform.right * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.up * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.right * moveSpeed;
        }

    }

    public float bulletSpeed;

    GameObject bullit;
    bool coolDownState = false;

    void Shoot()
    {
        if (coolDownState == false)
        {
            coolDownState = true;
            bullit = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as GameObject;
        }
    }

    public float coolDownTime;
    float coolDownTimer;
    void ShootDelay()
    {
        if (coolDownState)
        {
            TimeMoving = true;
            coolDownTimer += Time.deltaTime;
            if (coolDownTimer > coolDownTime)
            {
                coolDownTimer = 0;
                coolDownState = false;
                TimeMoving = false;
            }
        }
    }

    bool menu;
    float Timer;

    // Update is called once per frame
    void Update()
    {
        menu = menuRef.menuActive;
        Control();
        TimeFlowSetter();
        ShootDelay();
        Move();
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