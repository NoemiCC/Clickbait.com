using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 1f;
    public int damage = 10;
    private Vector3 dir;
    private Vector3 prevPosition;

    public void Seek(Transform _target)
    {
        target = _target;
        dir = (target.position - transform.position).normalized;
    }

    void HitTarget(RaycastHit hit) {
        if (hit.collider.gameObject.tag == "Player") {
            Debug.Log("Hit!");
            hit.collider.gameObject.GetComponent<PlayerMove>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    void Update()
    {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        prevPosition = transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        RaycastHit hit;
        if (Physics.Raycast(prevPosition, (transform.position - prevPosition).normalized, out hit, (transform.position - prevPosition).magnitude)) {
            HitTarget(hit);
        }
    }
}
