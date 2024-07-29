using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public Vida vida;
    [SerializeField] private int danoBase = 5;
    [SerializeField] private float attackCooldown = 1f; // Tempo de cooldown entre danos
    private bool canApplyDamage = true;

    private Animator animator;
    private static readonly int AttackHash = Animator.StringToHash("BaseEnemyAttack1");
    private static readonly int RunHash = Animator.StringToHash("EnemyRun");


    public void Start(){
        animator = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canApplyDamage && collision.gameObject.tag == "Player")
        {
            vida = collision.gameObject.GetComponent<Vida>();
            if (vida != null)
            {
                // Inicia a animação de ataque
                animator.SetTrigger(AttackHash);

                // Inicia o cooldown para o próximo dano
                StartCoroutine(DamageCooldown());

                // Interrompe a animação de movimento durante a animação de ataque
                StartCoroutine(StopMovementDuringAttack());
            }
        }
    }

    private IEnumerator DamageCooldown()
    {
        canApplyDamage = false;
        yield return new WaitForSeconds(attackCooldown);
        canApplyDamage = true;
    }

     private IEnumerator StopMovementDuringAttack()
    {
        // Obtenha a duração da animação de ataque
        AnimatorStateInfo attackStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float attackDuration = attackStateInfo.length;

        //Desabilita o movimento
        //UnityEngine.AI.NavMeshAgent.enabled = false;
        
        //espera o ataque acabar
        yield return new WaitForSeconds(attackDuration/2);

        // Aplica o dano
        vida.dano(danoBase);

        yield return new WaitForSeconds(attackDuration/2);

        //habilita o movimento
        animator.SetTrigger(RunHash);

        
        //UnityEngine.AI.NavMeshAgent.enabled = true;
    }
}