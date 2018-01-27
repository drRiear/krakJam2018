using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootDelay;
    [SerializeField] private int amo;
    [SerializeField] private float shootNoiseRadius;

    private AudioSource shootAudioSource;
    private float attackTimer;
    private Weapons weapon;

    private Death currentDeathComponent;

    #region Unity Events

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, shootNoiseRadius);    
    }

    void Start()
    {
        shootAudioSource = GetComponent<AudioSource>();
        attackTimer = shootDelay;
    }

    void Update()
    {
        ChangeWeapon();

        if (weapon == Weapons.Melee)
            Hit();
        if (weapon == Weapons.Range)
            Shoot();
        
        CollectAmo();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentDeathComponent = collision.GetComponent<Death>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        currentDeathComponent = null;
    }
    #endregion

    #region Private Methods

    private void Shoot()
    {
        if (amo == 0) return;

        attackTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && attackTimer <= 0.0f)
        {
            amo--;
            attackTimer = shootDelay;
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            shootAudioSource.Play();
        }
    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            weapon = Weapons.Melee;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            weapon = Weapons.Range;
    }
    private void CollectAmo()
    {
        if (currentDeathComponent == null || !currentDeathComponent.isDead) return;

        print("Collect amo");
        if (Input.GetKeyDown(KeyCode.E))
        {
            amo += currentDeathComponent.amunition;
            currentDeathComponent.amunition = 0;
        }
    }

    private void Hit()
    {
        if (currentDeathComponent == null) return;

        if (Input.GetMouseButton(0))
            currentDeathComponent.isDead = true;
    }

    #endregion

    enum Weapons { Melee, Range }
}
