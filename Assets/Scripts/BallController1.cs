/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private static float staticSpeedIncrease = 0.5f; // Static variable for speed increase

    public float minDirection = 0.5f;
    public float activationSpeed = 15f; // Speed threshold for activating SmokeVFX

    private float speed = 8f; // Private variable for speed
    public static bool stopped;
    public GameObject sparksVFX;
    public GameObject smokeVFX; // Reference to SmokeVFX object

    private Vector3 direction;
    private Rigidbody rb;

    public AudioSource soundclip;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.direction = new Vector3(0.5f, 0, 0.5f);
        if (smokeVFX != null)
        {
            smokeVFX.SetActive(false); // Deactivate SmokeVFX initially
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Method1
        // transform.position += direction * speed * Time.deltaTime;

        // Check if the ball's speed is greater than or equal to the activation speed
        if (speed >= activationSpeed)
        {
            ActivateSmokeVFX();
        }
        else
        {
            DeactivateSmokeVFX();
        }
    }

    public void FixedUpdate()
    {
        if(stopped == false) { 
        this.rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool hit = false;

        if (other.CompareTag("wall"))
        {
            direction.z = -direction.z;
            direction.y = 0;
            hit = true;
        }
        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);
            newDirection.y = 0;
            direction = newDirection;
            hit = true;
            soundclip.Play();

            // Increase speed on each hit using the static variable
            speed += staticSpeedIncrease;
            Debug.Log(speed);
        }
        if (hit)
        {
            GameObject sparks = Instantiate(this.sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 4f);
        }
    }

    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));
        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);
    }

    public void Stop()
    {
        stopped = true;
    }

    public void Go()
    {
        stopped = false;
    }

    private void ActivateSmokeVFX()
    {
        if (smokeVFX != null)
        {
            smokeVFX.SetActive(true);
        }
    }

    private void DeactivateSmokeVFX()
    {
        if (smokeVFX != null)
        {
            smokeVFX.SetActive(false);
        }
    }
}*/


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private static float staticSpeedIncrease = 0.5f; // Static variable for speed increase

    public float minDirection = 0.5f;
    public float activationSpeed = 15f; // Speed threshold for activating SmokeVFX

    private float speed = 8f; // Private variable for speed
    private bool ballInstantiated = true; // Flag to track if the ball has been instantiated
    public static bool stopped;
    public GameObject sparksVFX;
    public GameObject smokeVFX; // Reference to SmokeVFX object

    private Vector3 direction;
    private Rigidbody rb;

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        this.rb = GetComponent<Rigidbody>();
        this.direction = new Vector3(0.5f, 0, 0.5f);
        if (smokeVFX != null)
        {
            smokeVFX.SetActive(false); // Deactivate SmokeVFX initially
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Method1
        // transform.position += direction * speed * Time.deltaTime;

        if(ballInstantiated && speed >= 9f )
        {
            *//*if (counter == 1) { 
            Instantiate(this.gameObject, gameObject.transform.position, gameObject.transform.rotation);
            counter++;
            }
            else { 
            ballInstantiated = false;
            }*//*

            InstantiateBall();
        }

        // Check if the ball's speed is greater than or equal to the activation speed
        if (speed >= activationSpeed)
        {
            ActivateSmokeVFX();

            // Check if the ball has not been instantiated and speed is greater than or equal to 20
           *//* if (ballInstantiated == true && speed >= 10)
            {
                Instantiate(this.gameObject, gameObject.transform.position, gameObject.transform.rotation);
                ballInstantiated = false;
            }*//*
        }
        else
        {
            DeactivateSmokeVFX();
        }
    }

    public void FixedUpdate()
    {
        if (stopped == false)
        {
            this.rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        bool hit = false;

        if (other.CompareTag("wall"))
        {
            direction.z = -direction.z;
            direction.y = 0;
            hit = true;
        }
        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);
            newDirection.y = 0;
            direction = newDirection;
            hit = true;

            // Increase speed on each hit using the static variable
            speed += staticSpeedIncrease;
            Debug.Log(speed);
        }
        if (hit)
        {
            GameObject sparks = Instantiate(this.sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 4f);
        }
    }

    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));
        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);
    }

    public void Stop()
    {
        stopped = true;
    }

    public void Go()
    {
        stopped = false;
    }

    private void ActivateSmokeVFX()
    {
        if (smokeVFX != null)
        {
            smokeVFX.SetActive(true);
        }
    }

    private void DeactivateSmokeVFX()
    {
        if (smokeVFX != null)
        {
            smokeVFX.SetActive(false);
        }
    }

    private void InstantiateBall()
    {
        // Instantiate the ball (you may need to adjust the parameters based on your game)
        //Instantiate(this.gameObject, new Vector3(0, 0.5f, 0), Quaternion.identity);
        if(counter == 0) {
            //Instantiate(this.gameObject, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(this.gameObject, new Vector3(0, 0.5f, 0), Quaternion.identity);
            counter++;
        }
        else { 
        // Set the flag to true to indicate that the ball has been instantiated
        ballInstantiated = false;
        }
    }
}
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController1 : MonoBehaviour
{
    private static float staticSpeedIncrease = 0.5f; // Static variable for speed increase

    public float minDirection = 0.5f;
    public float activationSpeed = 15f; // Speed threshold for activating SmokeVFX

    private float speed = 8f; // Private variable for speed
    //private bool ballInstantiated = false; // Flag to track if the ball has been instantiated
    public static bool stopped;
    public GameObject sparksVFX;
    public GameObject smokeVFX; // Reference to SmokeVFX object

    private Vector3 direction;
    private Rigidbody rb;
    //int counter = 0;

    //public GameObject ball2;

    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
        this.rb = GetComponent<Rigidbody>();
        this.direction = new Vector3(0.5f, 0, 0.5f);
        if (smokeVFX != null)
        {
            smokeVFX.SetActive(false); // Deactivate SmokeVFX initially
        }
    }

    // Update is called once per frame
    void Update()
    {
       

        // Check if the ball's speed is greater than or equal to the activation speed
        if (speed >= activationSpeed)
        {
            ActivateSmokeVFX();
        }
        else
        {
            DeactivateSmokeVFX();
        }
    }

    public void FixedUpdate()
    {
        if (stopped == false)
        {
            ChooseDirection();
            this.rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool hit = false;

        if (other.CompareTag("wall"))
        {
            direction.z = -direction.z;
            direction.y = 0;
            hit = true;
        }
        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);
            newDirection.y = 0;
            direction = newDirection;
            hit = true;

            // Increase speed on each hit using the static variable
            speed += staticSpeedIncrease;
            Debug.Log(speed);
        }
        if (hit)
        {
            GameObject sparks = Instantiate(this.sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 4f);
        }
    }

    public void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signZ = Mathf.Sign(Random.Range(-1f, 1f));
        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signZ);
    }

    public void Stop()
    {
        stopped = true;
    }

    public void Go()
    {
        stopped = false;
    }

    private void ActivateSmokeVFX()
    {
        if (smokeVFX != null)
        {
            smokeVFX.SetActive(true);
        }
    }

    private void DeactivateSmokeVFX()
    {
        if (smokeVFX != null)
        {
            smokeVFX.SetActive(false);
        }
    }

    
}
