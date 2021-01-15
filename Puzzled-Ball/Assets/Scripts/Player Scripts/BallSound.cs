using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{

    #region Variables
    private Rigidbody mybody;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioSource ballRollAudio;

    [SerializeField]
    private AudioClip pickUp, wallHit;


    private BallMovement ballMovement;

    private Vector3 velocityLastFrame;
    private Vector3 collisionNormal;

    private float xAxisAngle, xFactor;
    private float yAxisAngle, yFactor;
    private float zAxisAngle, zFactor;

    #endregion Variables


    #region UnityFunctions

    private void Awake()
    {
        mybody = GetComponent<Rigidbody>();
        ballMovement = GetComponent<BallMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        BallRollSoundController();
    }

    #endregion UnityFunctions

    void BallRollSoundController()
    {
        if(ballMovement.onFloorTracker > 0 && mybody.velocity.sqrMagnitude > 0)
        {
            ballRollAudio.volume = mybody.velocity.sqrMagnitude * 0.002f;
            ballRollAudio.pitch = 0.4f + ballRollAudio.volume;
            ballRollAudio.mute = false;
        }
        else
        {
            ballRollAudio.mute = true;
        }

    }

    public void PlayPickUpSound()
    {
        audioSource.volume = 0.7f;
        audioSource.PlayOneShot(pickUp);
    }

    void SetSoundVolumeOnCollision(Collision collision)
    {
        // contacts is an array of contact points
        // the contact point is a point where two colliders collided
        // the collision normal is a vector which is used to calculate
        // impulses after the collision
        collisionNormal = collision.contacts[0].normal;

        // vector3.angle returns the angle in degrees between from and to
        // since we want the x angle we are using vector3.right whic his 1, 0, 0
        xAxisAngle = Vector3.Angle(Vector3.right, collisionNormal);
        xFactor = (1.0f / 8100f) * xAxisAngle * xAxisAngle + (-1 / 45f) + 1f;

        yAxisAngle = Vector3.Angle(Vector3.up, collisionNormal);
        yFactor = (1.0f / 8100f) * yAxisAngle * yAxisAngle + (-1 / 45f) + 1f;

        zAxisAngle = Vector3.Angle(Vector3.forward, collisionNormal);
        zFactor = (1.0f / 8100f) * zAxisAngle * zAxisAngle + (-1 / 45f) + 1f;

        audioSource.volume = (Mathf.Abs(velocityLastFrame.x) * xFactor * 0.001f) +
                (Mathf.Abs(velocityLastFrame.y) * yFactor * 0.001f) +
                (Mathf.Abs(velocityLastFrame.z) * zFactor * 0.001f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            SetSoundVolumeOnCollision(collision);
            audioSource.PlayOneShot(wallHit);
        }
    }





} // BallSound class
