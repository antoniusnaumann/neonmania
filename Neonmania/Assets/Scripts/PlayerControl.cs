using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private Rigidbody rb;
    private PlayerColorChanger colorChanger;
    private ProjectileController projectileController;
    public GameObject projectilePrefab;

    public float acceleration;
    public float maxSpeed;
    public float deceleration;
    public float shotCooldown;
    public bool readyToShoot;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        colorChanger = GetComponent<PlayerColorChanger>();
        acceleration = 10f;
        maxSpeed = 30f;
        deceleration = 2f;
        shotCooldown = 0.5f;
        readyToShoot = true;
    }

    // Before performing physics calculation
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("LeftJoystickHorizontal");
        float moveVertical = -Input.GetAxis("LeftJoystickVertical");

        Vector3 v3 = new Vector3(moveHorizontal * acceleration, 0f, moveVertical * acceleration);

        if (moveHorizontal==0 && moveVertical==0)
        {
            //The player is not moving LeftJoystick any buttons, adding the mirrored vector to slow down
            Vector3 mirrorDirection = rb.velocity * (-1);
            rb.AddForce(mirrorDirection.normalized * deceleration);
        }
        else
        {   
            //Debug.Log("H: " + moveHorizontal);
            //Debug.Log("V: " + moveVertical);   

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
            else
            {
                rb.AddForce(v3);
            }
        }

        float shootHorizontal = Input.GetAxis("RightJoystickHorizontal");
        float shootVertical = -Input.GetAxis("RightJoystickVertical");    
        
        if (shootHorizontal != 0 || shootVertical != 0) {
            if(readyToShoot) {
                readyToShoot = false;
                Vector3 aimVector = new Vector3(shootHorizontal, 0f, shootVertical);
                StartCoroutine(Shoot(aimVector));
                GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation); //Quaternion.identity
                ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
                projectileController.color = colorChanger.GetColor();
                projectileController.direction = aimVector;
                projectileController.velocity = 40f;
                // Destroy the projectile after 2 seconds
                Destroy(projectile, 2.0f); 

            }
        }

        
    }

    public IEnumerator Shoot (Vector3 aimVector) {
        yield return new WaitForSeconds(shotCooldown);
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update () {

	}
}
