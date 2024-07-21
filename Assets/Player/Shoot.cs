using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public float ArrowSpeed;

    public GameObject Character;

    public Animator animator;

    public float lastShotTime;
    public float aimInterval;
    public float timeBetweenShots;
    public bool canShoot = false;

    public Vector3 worldPosition;
    public Vector3 direction;

    private Rigidbody rb;
    public float rotationSpeed;

    private bool isAiming = false;
    private float aimEndTime;

    void Start()
    {
        ArrowSpeed = 75.0f;
        timeBetweenShots = 0.3f;
        aimInterval = 2.5f;
        rotationSpeed = 150f;
        lastShotTime = -timeBetweenShots;

        Character = GameObject.Find("Player");
        animator = Character.GetComponentInChildren<Animator>();
        rb = Character.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray target = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit distance;
        GameObject arrow;

        if (Physics.Raycast(target, out distance))
        {
            canShoot = true;
            worldPosition = distance.point;
            direction = (worldPosition - transform.position).normalized;
        }

        if (isAiming)
        {
            AimAtCursor();
            if (Time.time >= aimEndTime)
            {
                isAiming = false;
            }
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= lastShotTime + timeBetweenShots)
        {
            if (canShoot)
            {
                arrow = ShootArrow(direction, worldPosition);
                lastShotTime = Time.time;
                isAiming = true;
                aimEndTime = Time.time + (aimInterval);
            }
        }
    }

    void AimAtCursor()
    {
        Vector3 direction = (worldPosition - Character.transform.position).normalized;
        direction.y = 0; // Mantém a rotação apenas no plano horizontal
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Character.transform.rotation = Quaternion.Slerp(Character.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public GameObject ShootArrow(Vector3 direction, Vector3 targetPosition)
    {
        GameObject arrow = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
        animator.SetTrigger("t_shoot");

        arrow.transform.LookAt(targetPosition);
        arrow.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);

        Rigidbody arrowRB = arrow.GetComponent<Rigidbody>();
        arrowRB.AddForce(direction * ArrowSpeed, ForceMode.VelocityChange);

        return arrow;
    }
}