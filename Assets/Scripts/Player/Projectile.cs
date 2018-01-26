using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    #region Inspector Variables
    [SerializeField]
    private float lifeTime;
    [SerializeField] private float speed;
    [Header("Layer names")]
    [SerializeField] private string wallLayerName;
    [SerializeField] private string enemyLayerName;
    #endregion

    #region Private variables
    private Vector3 difference;
    [HideInInspector] public float damage;
    #endregion

    private void Start()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        difference.z = 0.0f;

        float rot_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        transform.position += difference * speed * Time.deltaTime;

        if (lifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(wallLayerName))
            Destroy(gameObject);

        print(enemyLayerName);
        if (collision.gameObject.layer == LayerMask.NameToLayer(enemyLayerName))
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }
}
