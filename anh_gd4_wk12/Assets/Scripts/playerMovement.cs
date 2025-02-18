using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public Vector2 inputDirection,lookDirection;
    Animator anim;

    Vector2 touchStart, touchEnd;
    public Image dpad;
    public float dPadRadius;
    public Touch theTouch;

    float xlim = 2.2f;
    float ylimPos = 3.8f;
    float ylimNeg = -0.89f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //makes the character look down by default
        lookDirection = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        //getting input from keyboard controls
        //calculateDesktopInputs();

        calculateMobileInput();

        //sets up the animator
        animationSetup();

        //moves the player
        transform.Translate(inputDirection * moveSpeed * Time.deltaTime);
    }


    void calculateDesktopInputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector2(x, y).normalized;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }

    }

    void animationSetup()
    {
        //checking if the player wants to move the character or not
        if (inputDirection.magnitude > 0.1f)
        {
            //changes look direction only when the player is moving, so that we remember the last direction the player was moving in
            lookDirection = inputDirection;

            //sets "isWalking" true. this triggers the walking blend tree
            anim.SetBool("isWalking", true);
        }
        else
        {
            // sets "isWalking" false. this triggers the idle blend tree
            anim.SetBool("isWalking", false);

        }

        //sets the values for input and lookdirection. this determines what animation to play in a blend tree
        anim.SetFloat("inputX", lookDirection.x);
        anim.SetFloat("inputY", lookDirection.y);
        anim.SetFloat("lookX", lookDirection.x);
        anim.SetFloat("lookY", lookDirection.y);
    }

    public void attack()
    {
        anim.SetTrigger("Attack");
    }

    void calculateMobileInput()
    {
        // get left mouse click (also recognised as touch)
        // true for as long as holding button down
        if(Input.GetMouseButton(0))
        {
            dpad.gameObject.SetActive(true);            

            // true only for one frame after started pressing the button
            // set up touchStart position
            if(Input.GetMouseButtonDown(0))
            {
                touchStart = Input.mousePosition;
            }

            // set touchEnd to current mouse position and keep updating every frame
            touchEnd = Input.mousePosition;

            // get difference between touchStart and touchEnd, to get positive or negative value
            float x = touchEnd.x - touchStart.x;
            float y = touchEnd.y - touchStart.y;

            // keep magnitude of number between -1 and 1
            inputDirection = new Vector2(x, y).normalized;

            // make sure dpad does not go outside dpradradius
            if((touchEnd - touchStart).magnitude > dPadRadius)
            {
                dpad.transform.position = touchStart + (touchEnd - touchStart).normalized * dPadRadius;
            }
            else
            {
                dpad.transform.position = touchEnd;
            }
        }
        else
        {
            inputDirection = Vector2.zero;
            //dpad.gameObject.SetActive(false);
        }
    }

    void CalculateTouchInput()
    {
        if(Input.touchCount > 0)
        {
            dpad.gameObject.SetActive(true);
            theTouch = Input.GetTouch(0);

            if(theTouch.phase == TouchPhase.Began)
                {
                    touchStart = theTouch.position;
                }

            if(theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEnd = theTouch.position;
            
                float x = touchEnd.x - touchStart.x;
                float y = touchEnd.y - touchStart.y;
                inputDirection = new Vector2(x, y).normalized;

            }

            if((touchEnd - touchStart).magnitude > dPadRadius)
            {
                dpad.transform.position = touchStart + (touchEnd - touchStart).normalized * dPadRadius;
            }
            else
            {
                dpad.transform.position = touchEnd;
            }

        }

        else
        {
            inputDirection = Vector2.zero;
            //dpad.gameObject.SetActive(false);
        }
    }
}
