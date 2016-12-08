using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    public float speed;
    public float turnSpeed = 200;
    public Rigidbody rb;
    public Vector3 moveDirectionSmoothly;
    public string xbox_name_Horizontal;
    public string xbox_name_Vertical;
    public string xbox_name_RstickX;
    public string xbox_name_RstickY;
        

    public Vector3 screenPos;
    public float sizeWidth;
    public float sizeHeight;
    public float half_sz_X;
    public float half_sz_Y;

    public bool över;
    public float whatValue;

    Vector3 rbLastPosition;

    void Awake()
    {
        rb.freezeRotation = true;
        rb.useGravity = false; 
    }

    void Start ()
    {


        rb = GetComponent<Rigidbody>();

        half_sz_X = GetComponent<Renderer>().bounds.size.x;
        half_sz_Y = GetComponent<Renderer>().bounds.size.y / 2;

        över = false;
        rbLastPosition = transform.position;
    }

    void Update()
    {
        screenPos.x = Mathf.Clamp(screenPos.x, 0, Camera.main.pixelWidth);

        sizeWidth = Camera.main.pixelWidth;
        sizeHeight = Camera.main.pixelHeight;

        screenPos = Camera.main.WorldToScreenPoint(transform.position);


    }
    
    void FixedUpdate()
    {
        //Jonathan Pisch
        //Kontroller för XBOX_360 
        float moveHorizontal = Input.GetAxis(xbox_name_Horizontal);
        float moveVertical = Input.GetAxis(xbox_name_Vertical);
        float rStickX = Input.GetAxis(xbox_name_RstickX);
        float rStickY = Input.GetAxis(xbox_name_RstickY);

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

        float triggerAxis = Input.GetAxis("X360_Triggers");

        if (dPadX != 0)
        {
            print("DPad Horizontal Value: " + dPadX);
        }
        if (dPadY != 0)
        {
            print("DPad Vertical Value: " + dPadY);
        }
        if (triggerAxis != 0)
        {
            print("Trigger Value: " + triggerAxis);
        }
        if (Input.GetButtonDown("X360_LBumper"))
        {
            print("Left Bumper");
        }
        if (Input.GetButtonDown("X360_RBumper"))
        {
            print("Right Bumper");
        }
        if (Input.GetButtonDown("X360_A"))
        {
            print("A Button");
        }
        if (Input.GetButtonDown("X360_B"))
        {
            print("B Button");
        }
        if (Input.GetButtonDown("X360_X"))
        {
            print("X Button");
        }
        if (Input.GetButtonDown("X360_Y"))
        {
            print("Y Button");
        }
        if (Input.GetButtonDown("X360_Back"))
        {
            print("Back Button");
        }
        if (Input.GetButtonDown("X360_Start"))
        {
            print("Start Button");
        }
        if (Input.GetButtonDown("X360_LStickClick"))
        {
            print("Clicked Left Stick");
        }
        if (Input.GetButtonDown("X360_RStickClick"))
        {
            print("Clicked Right Stick");
        }

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
}
