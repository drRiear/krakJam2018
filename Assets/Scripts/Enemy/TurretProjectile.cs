using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 difference;

    [SerializeField] private float speed;

    private void Start()
    {
        playerTransform = CharacterManager.Instance.player.transform;
        SetDirection();
    }
    private void Update()
    {
        transform.position += difference * speed * Time.deltaTime;
        SetDifference();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == CharacterManager.Instance.wallsLayer)
            Destroy(gameObject);

        var deathComponent = collision.GetComponent<PlayerDeath>();
        
        if (deathComponent == null) return;

        deathComponent.Die();
        Destroy(gameObject);
    }

    private void SetDirection()
    { 
        float rot_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    private void SetDifference()
    {
        difference = playerTransform.position - transform.position;
        difference.Normalize();
        difference.z = 0.0f;
    }
}