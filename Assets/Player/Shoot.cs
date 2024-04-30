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

    // Start is called before the first frame update

    void Start()
    {
        ArrowSpeed = 50.0f;
        timeBetweenShots = 2f;
        lastShotTime = -timeBetweenShots;

        Character = GameObject.Find("Player");
        animator = Character.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        //Converte uma posição do mouse numa posição no terreno

        Vector3 mousePosition = Input.mousePosition;
        Ray target = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit distance;
        GameObject arrow;

        //Checa se há uma posição valida na posição do mouse

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

                Character.transform.LookAt(charTarget);

                //Corrige a posição que o personagem olha ao atirar perto dos pés
                
                float targetRotation = 345.0f;

                if(Character.transform.eulerAngles.x < targetRotation)
                {  
                    charRotation.x = targetRotation;
                    Character.transform.eulerAngles = charRotation;
                }
                   


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
        //Cria a flecha e inicia animação

        GameObject arrow = Instantiate(ArrowPrefab, transform.position, Quaternion.identity);
        animator.SetTrigger("t_shoot");

        //Ajusta a direção da flecha

        arrow.transform.LookAt(targetPosition);
        arrow.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);


        //Dá impulso a flecha

        Rigidbody arrowRB = arrow.GetComponent<Rigidbody>();
        arrowRB.AddForce(direction * ArrowSpeed, ForceMode.VelocityChange);
        lastShotTime = Time.time;
        return arrow;
    }
}