using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootDelay;
    [SerializeField] private float amo;

    private AudioSource shootAudioSource;
    private float attackTimer;
    [SerializeField] private Weapons weapon;

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

                break;
            case Weapons.Range:
                Shoot();
                break;
        }
        
    }

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

    enum Weapons { Melee, Range }
}
