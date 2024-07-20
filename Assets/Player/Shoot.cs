using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoot : MonoBehaviour
{
    // Instanciar variaveis iniciais

    public GameObject ArrowPrefab;
    public float ArrowSpeed;

    public GameObject Character;

    public Animator animator;

    public float lastShotTime;
    public float timeBetweenShots;
    public bool canShoot = false;

    public Vector3 worldPosition;
    public Vector3 direction;

    private Rigidbody rb;
    public float rotationSpeed = 5f; // Velocidade de rotação

    // Start is called before the first frame update

    void Start()
    {
        ArrowSpeed = 50.0f;
        timeBetweenShots = 2f;
        lastShotTime = -timeBetweenShots;

        Character = GameObject.Find("Player");
        animator = Character.GetComponentInChildren<Animator>();
        rb = Character.GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        //Converte uma posi��o do mouse numa posi��o no terreno

        Vector3 mousePosition = Input.mousePosition;
        Ray target = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit distance;
        GameObject arrow;

        //Checa se h� uma posi��o valida na posi��o do mouse

        if (Physics.Raycast(target, out distance))
        {
            canShoot = true;
            worldPosition = distance.point;
            Vector3 charTarget = worldPosition;
            Vector3 charRotation = Character.transform.eulerAngles;
            direction = (worldPosition - transform.position).normalized;

            if ((Time.time - lastShotTime) <= timeBetweenShots)
            {                
                //Rotaciona o personagem

                Vector3 direction = (distance.point  - transform.position).normalized;
                direction.y = 0; // Mantém a rotação apenas no plano horizontal

                // Calcula a rotação desejada
                Quaternion lookRotation = Quaternion.LookRotation(direction);

                // Suaviza a rotação
                //Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

                // Aplica a rotação usando o Rigidbody
                rb.MoveRotation(lookRotation);

                //Corrige a posi��o que o personagem olha ao atirar perto dos p�s
                
                /*float targetRotation = 345.0f;

                if(Character.transform.eulerAngles.x < targetRotation)
                {  
                    charRotation.x = targetRotation;
                    Character.transform.eulerAngles = charRotation;
                }*/
                   


            }

        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (canShoot)
            {
                arrow = ShootArrow(direction, worldPosition);
            }
        }
    }

    public GameObject ShootArrow(Vector3 direction, Vector3 targetPosition)
    {
        //Cria a flecha e inicia anima��o

        GameObject arrow = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
        animator.SetTrigger("t_shoot");

        //Ajusta a dire��o da flecha

        arrow.transform.LookAt(targetPosition);
        arrow.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);


        //D� impulso a flecha

        Rigidbody arrowRB = arrow.GetComponent<Rigidbody>();
        arrowRB.AddForce(direction * ArrowSpeed, ForceMode.VelocityChange);
        lastShotTime = Time.time;
        return arrow;
    }
}