using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : ShipWeapon
{
  // Todo: define Laser stats; Nan for now to intentionally cause errors if used
  public LaserWeapon(string bPrefab, Vector2 sPosOffset, GameObject fSource, string weaponSprite) :
      base(float.NaN, float.NaN, float.NaN, fSource, bPrefab, sPosOffset, weaponSprite)
  { }
  public LaserWeapon(string bPrefab, Vector2 sPosOffset, GameObject fSource) :
      base(10, 2, 7, fSource, bPrefab, sPosOffset, "")
  { }

  public override void Fire(bool isEnemyBullet)
  {
    // Load and instantiate bullet prefab from resource
    GameObject laser = Object.Instantiate<GameObject>(Resources.Load<GameObject>(this._bulletPrefab),
      _firingSource.transform.position, _firingSource.transform.rotation);
    // Instantiate bullet fields
    laser.GetComponent<BulletBehaviour>().isEnemyBullet = isEnemyBullet;
    laser.GetComponent<BulletBehaviour>().damage = _damage;
    laser.GetComponent<BulletBehaviour>().speed = _bulletSpeed;
  }
}
