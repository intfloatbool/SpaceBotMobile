using System.Collections;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected int _health = 50;
    public int Health => _health;

    [SerializeField] protected bool _isDead = false;
    public bool IsDead => _isDead;

    [SerializeField] protected Transform _mainBody;
    [SerializeField] protected Transform _deathEffectTransform;
    [SerializeField] protected float _timeToDissapear = 3f;

    public virtual void AddDamage(int damage)
    {
        if (_isDead)
            return;
        _health -= damage;
        _isDead = _health <= 0;

        if(_isDead)
        {
            _health = 0;
            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {
        StartCoroutine(OnDeathCoroutine());
        if(_animator != null)
        {
            _animator.SetBool("isDead", true);
        }
    }

    protected virtual IEnumerator OnDeathCoroutine()
    {
        _mainBody.gameObject.SetActive(false);
        _deathEffectTransform.gameObject.SetActive(true);

        yield return new WaitForSeconds(_timeToDissapear);
        Destroy(gameObject);
    }
}
