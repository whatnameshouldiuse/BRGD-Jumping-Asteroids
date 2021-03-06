using UnityEngine;
using Cinemachine;

public class ShockManager : MonoBehaviour
{
  public static ShockManager Instance;

  void Awake() => Instance = this;
  public void StartShake(Vector3 velocity) => GetComponent<CinemachineImpulseSource>().GenerateImpulse(velocity);
}