using UnityEngine;

public class PlayerController : MonoBehaviour 
{    
    public float speed;
    public float turnSpeed = 200;
    public Rigidbody rb;
    public Vector3 moveDirectionSmoothly;
    public string xbox_name_Horizontal;
    public string xbox_name_Vertical;
    public string xbox_name_RstickX;
    public string xbox_name_RstickY;
    public string xbox_name_Rtrigger;
    public string xbox_name_RBumper;
    public string m_controllerID;   // This is for assigning

    public Vector3 screenPos;
    public float sizeWidth;
    public float sizeHeight;
    public float half_sz_X;
    public float half_sz_Y;

    public bool över;
    private bool walking = false;
    public bool m_energySpeed = false;
    private bool m_energyTiming = false;
    private float m_energyDuration = 0f;

    public float whatValue;

    Vector3 rbLastPosition;
    private Animator anim;

    void Awake()
    {
        rb.freezeRotation = true;
        rb.useGravity = false;
        anim = GetComponent<Animator>();
    }

    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        half_sz_X = GetComponentInChildren<Renderer>().bounds.size.x;
        half_sz_Y = GetComponentInChildren<Renderer>().bounds.size.y / 2;

        över = false;
        
        walking = false;
        
        rbLastPosition = transform.position;
    }

    void Update()
    {

        screenPos.x = Mathf.Clamp(screenPos.x, 0, Camera.main.pixelWidth);

        sizeWidth = Camera.main.pixelWidth;
        sizeHeight = Camera.main.pixelHeight;

        screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if(m_energySpeed == true)
        {
            speed = 24f;
            turnSpeed = 360f;
            m_energyTiming = true;
        }

        if(m_energyTiming == true)
        {
            m_energyDuration += Time.deltaTime;
        }

        if(m_energyDuration >= 3.5f)
        {
            m_energySpeed = false;
            m_energyTiming = false;
            speed = 12f;
            turnSpeed = 200f;
            m_energyDuration = 0f;
        }

    }
    
    void FixedUpdate()
    {
        //Jonathan Pisch
        //Kontroller för XBOX_360 
        float moveHorizontal = Input.GetAxis(xbox_name_Horizontal);
        float moveVertical = Input.GetAxis(xbox_name_Vertical);
        float rStickX = Input.GetAxis(xbox_name_RstickX);
        float rStickY = Input.GetAxis(xbox_name_RstickY);
        float rTrigger = Input.GetAxis(xbox_name_Rtrigger);

        // Animating the players while they are going
        Animating(moveHorizontal, moveVertical);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;


        whatValue = (screenPos.x - 10);
        if ((screenPos.y + 10) > sizeHeight)
        {
            rb.velocity = new Vector3(0, 0, -rb.velocity.z - 20);
            //rb.position = rbLastPosition;
        }
        else if ((screenPos.y - 20) < 0)
        {
            rb.velocity = new Vector3(0, 0, -rb.velocity.z + 20);
            //rb.position = rbLastPosition;
        }
        else if ((screenPos.x + 10) > sizeWidth)
        {
            rb.velocity = new Vector3(-rb.velocity.x - 10, 0, 0);
            //rb.position = rbLastPosition;
        }
        else if ((screenPos.x - 10) < 0)
        {
            rb.velocity = new Vector3(-rb.velocity.x + 10, 0, 0);
            //rb.position = rbLastPosition;
        }

        rbLastPosition = rb.position;

        var direction = new Vector3(Input.GetAxis(xbox_name_RstickX), 0, -(Input.GetAxis(xbox_name_RstickY)));
        if (direction.magnitude > 0.1f)
        {
            var rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = rotation;
        }

        float dPadX = Input.GetAxis("X360_DPadX");

        float dPadY = Input.GetAxis("X360_DPadY");

        //float triggerAxis = Input.GetAxis("X360_Triggers");
       
    }

    void OnCollisionEnter(Collision collision)
    {
        //Environment was initially EastWall in case you want/need to change it back
        if (gameObject.CompareTag("Environment")) // or if(gameObject.CompareTag("YourWallTag"))
        {
            rb.velocity = Vector3.zero;
        }
    }

    void LateUpdate()
    {
        //fix flying if is blocked on jump
        if (rb.velocity.y == 0)
        {
            moveDirectionSmoothly.y = rb.velocity.y;
        }

        //fix "walk stopped" (stop the character if it is blocked by a wall)
        if (rb.velocity.z == 0)
        {
            moveDirectionSmoothly.z = rb.velocity.z;
        }
    }

    void Animating(float moveHorizontal, float moveVertical)
    {
        bool walking = moveHorizontal != 0f || moveVertical != 0f;
        anim.SetBool("IsWalking", walking);
    }

    void AssignController()
    {
        if (Input.GetButton("X360_Start1"))
            m_controllerID = "1";

        else if (Input.GetButton("X360_Start2"))
            m_controllerID = "2";

        else if (Input.GetButton("X360_Start3"))
            m_controllerID = "3";

        else if (Input.GetButton("X360_Start4"))
            m_controllerID = "4";
    }
}
