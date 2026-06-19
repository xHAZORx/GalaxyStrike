using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
        bool isFiring = false;
    void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    void ProcessFiring()
    {            
            foreach (GameObject laser in lasers)
            {
                var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
                emmissionModule.enabled = isFiring;        
            }
    }
    void MoveCrosshair()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        crosshair.position = mousePosition;
    }
    void MoveTargetPoint()
    {    
    Vector2 mousePosition = Mouse.current.position.ReadValue();
    Vector3 targetPointPosition = new Vector3(mousePosition.x,mousePosition.y,targetDistance);
    targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}