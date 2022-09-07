using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;
    public Vector3 currentPosition;
    public float maxLength;
    public float buttomBoundary; 
    bool isMouseDown;
    public GameObject zombiePrefab;
    Rigidbody2D zombie;
    Collider2D zombieCollider;
    public float zombiePositionOffset;
    public float force; 
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);
        CreateZombie();
    }

    void CreateZombie()
    {
        zombie = Instantiate(zombiePrefab).GetComponent<Rigidbody2D>();
        zombieCollider = zombie.GetComponent<Collider2D>();
        zombieCollider.enabled = false;
        zombie.isKinematic = true;

        ResetStrips();
    }
  
    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            currentPosition = Camera.main.ScreenToViewportPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);
            currentPosition = ClampBoundary(currentPosition);
            SetStrips(currentPosition);
            if (zombieCollider)
            {
                zombieCollider.enabled = true;
            }
        }
        else
        {
            ResetStrips();
        }
    }
    private void OnMouseDown()
    {
        isMouseDown = true;
    }
    private void OnMouseUp()
    {
        isMouseDown = false;
    }
    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }
    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (zombie)
        {

        
        Vector3 dir = position - center.position;
        zombie.transform.position = position + dir.normalized * zombiePositionOffset;
        zombie.transform.right = -dir.normalized;
        }
    }
    private void OnMouseUpAsButton()
    {
        isMouseDown = false;
        Shoot();
    }
    void Shoot()
    {
        zombie.isKinematic = false;
        Vector3 zombieForce = (currentPosition - center.position) * force * -1;
        zombie.velocity = zombieForce;
        zombie = null;
        zombieCollider = null;
        Invoke("CreateZombie", 2);
    }
    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, buttomBoundary, 1000);
        return vector;
    }

}
