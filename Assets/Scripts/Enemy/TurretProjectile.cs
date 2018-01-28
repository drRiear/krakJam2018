using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 difference;

    [SerializeField] private float speed;

    private void Start()
    {
        playerTransform = CharacterManager.Instance.player.transform;
        SetRotationDirection();
    }
    private void Update()
    {
        transform.position += difference * speed * Time.deltaTime;
        SetDifference();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        var wallIndex = (1 << CharacterManager.Instance.wallsLayer.value) + 7;

        if (collision.gameObject.layer == wallIndex)
            Destroy(gameObject);

        var deathComponent = collision.GetComponent<PlayerDeath>();
        
        if (deathComponent == null) return;

        deathComponent.Die();
        Destroy(gameObject);
    }

    private void SetRotationDirection()
    { 
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void SetDifference()
    {
        difference = playerTransform.position - transform.position;
        difference.Normalize();
        difference.z = 0.0f;
    }
}