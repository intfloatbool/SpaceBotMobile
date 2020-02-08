using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] protected int _damage = 10;
    private Rigidbody _rb;
    public Rigidbody Rb => _rb;
    public int Damage => _damage;

    private Transform _senderRoot;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void InitializeBullet(Transform sender)
    {
        _senderRoot = sender.root;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_senderRoot == null)
            return;
        var destructableObject = collision.gameObject.GetComponent<DestructableObject>();
        if (destructableObject == null)
            return;
        if (destructableObject.transform.root == _senderRoot)
            return;
        destructableObject.AddDamage(_damage);
        Destroy(gameObject);
    }
}
