using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController characterController;
    public Transform cam;
    public float lookSensivity;
    public float maxXRot;
    public float minXRot;
    private float curXRot;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;//mouse'u gizledik
        animator.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Cursor.lockState==CursorLockMode.Locked)
        { Look();}
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);

        }

        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalking", true);

        }

        /*else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
           
        }

        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", true);
           
        }*/

        else
        {
            animator.SetBool("isWalking", false);

        }
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal"); //getaxisraw aral�k de�er alm�yor sadece 1 ve -1
        float z = Input.GetAxisRaw("Vertical");   //getaxis aral�ktaki de�erleri de al�yor

        Vector3 dir = transform.right * x + transform.forward * z;
        dir.Normalize(); //vekt�rler toplam� falan dedi :d d�zg�n a��klamad�
        dir *= moveSpeed * Time.deltaTime;
        characterController.Move(dir);
    }

    void Look()
    {
        float x = Input.GetAxis("Mouse X") * lookSensivity;
        float y = Input.GetAxis("Mouse Y") * lookSensivity;

        transform.eulerAngles += Vector3.up * x; //Vector3.up==y ekseni
        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot); //Clamp aral�kta tutuyor
        cam.localEulerAngles = new Vector3(-curXRot, 0f, 0f);
    }
}
