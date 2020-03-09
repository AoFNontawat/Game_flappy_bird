using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brid_Controller : MonoBehaviour
{

    private Animator animator;
    private AudioSource audiosoucre;
    private Rigidbody2D rigidbody2D;

    public Vector2 velocity;
    public AudioClip audioflap;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator> ();
        audiosoucre = GetComponent<AudioSource> ();
        rigidbody2D = GetComponent<Rigidbody2D> ();

    }

    // Update is called once per frame
    void Update()
    {
        bool keyDown =  Input.GetKeyDown (KeyCode.Space);
        bool mouseDown = Input.GetMouseButtonDown (0);

        if(keyDown || mouseDown)
        {
            Flap();
        }
        else
        {
            FaceDown();
        }
    }

    void Flap ()
    {
        animator.SetTrigger("IsFlap");
        audiosoucre.PlayOneShot(audioflap);

        rigidbody2D.velocity = velocity;

        FaceUp();
    }

    void FaceDown()
    {
        float zAngle = transform.eulerAngles.z;

        if (zAngle > 180) zAngle -= 360; //fix bird drop
        
        float facedownAngle = (zAngle > -30) ? -2 : 0; //if(zAngle > -30) yes : -2 , no : 0
        transform.Rotate(0, 0, facedownAngle);
    }

    void FaceUp()
    {
        float zAngle = transform.eulerAngles.z;

        if (zAngle > 180) zAngle -= 360; //fix bird drop

        float faceupAngle = (zAngle < 30) ? 30-zAngle : 0; //if(zAngle < 30) yes : 30-zAngle , no : 0
        transform.Rotate(0, 0, faceupAngle);
    }
}
