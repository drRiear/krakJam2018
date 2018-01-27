using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootDelay;
    [SerializeField] private float amo;
    [SerializeField] private float shootNoiseRadius;

    private AudioSource shootAudioSource;
    private float attackTimer;
    private Weapons weapon;
    private bool canHit;

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

        switch (weapon)
        {
            case Weapons.Melee:
                canHit = Input.GetMouseButton(0);
                break;
            case Weapons.Range:
                Shoot();
                break;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!canHit) return;
        Destroy(collision.gameObject);
    }
    #endregion

    #region Private Methods

    private void Shoot()
    {
        attackTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && attackTimer <= 0.0f)
        {
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

    #endregion

    enum Weapons { Melee, Range }
}
