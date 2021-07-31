using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Inventory inventory;

    [SerializeField] Animator animator;


    //Attack Cooldown
    bool canAttack = true;
    float attackCooldown = 1.5f;
    float lastAttackTimer = 0f;
    //Movement Direction
    float Hdirection, Vdirection;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Hdirection * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * Vdirection * speed * Time.deltaTime);
        if(Time.time - lastAttackTimer > attackCooldown)
        {
            canAttack = true;
        }
        if(Vdirection + Hdirection == 0 && !animator.GetBool("isIdle"))
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
        }
    }
    public void OnHorizontal(InputValue val)
    {
        Hdirection = val.Get<float>();
        if(Hdirection != 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
        }
    }
    public void OnVertical(InputValue val)
    {
        Vdirection = val.Get<float>();
        if (Vdirection != 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
        }
    }

    public void OnAttack()
    {
        if (canAttack)
        {
            animator.SetTrigger("Attack");
            lastAttackTimer = Time.time;
            canAttack = false;
        }
    }

    public void OnInteract()
    {
        if(GameManager.GetInteractingObject()) GameManager.GetInteractingObject().OnInteract();
    }
    public void PlantASeed(Seed seed)
    {
        GameManager.GetInteractingObject().GetComponent<PlantSlot>().seed = seed;
    }

    public void OnOpenInventory()
    {
        GameManager.GetInventoryPanel().SetActive(!GameManager.GetInventoryPanel().activeSelf);
        if (inventory.onItemsChangedCallBack != null)
        {
            inventory.onItemsChangedCallBack.Invoke();
        }
    }
}
