using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float delay;

    private AudioSource shootAudioSource;
    private float attackTimer;

    void Start()
    {
        shootAudioSource = GetComponent<AudioSource>();
        attackTimer = delay;
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && attackTimer <= 0.0f)
        {
            attackTimer = delay;
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            shootAudioSource.Play();
        }
    }
}
