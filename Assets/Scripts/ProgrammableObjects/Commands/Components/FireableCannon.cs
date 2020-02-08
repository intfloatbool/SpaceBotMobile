using UnityEngine;

public class FireableCannon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _forceToLaunch = 3000;
    [SerializeField] private Transform _firePosition;
    [SerializeField] private Vector3 _launchRelativeForce = new Vector3(0, 0.2f, 0);
    public void Fire()
    {
        var bullet = Instantiate(_bulletPrefab, _firePosition.position, _firePosition.transform.localRotation);
        bullet.InitializeBullet(transform);
        bullet.Rb.AddForce((_firePosition.forward + _launchRelativeForce) * _forceToLaunch);
    }
}
