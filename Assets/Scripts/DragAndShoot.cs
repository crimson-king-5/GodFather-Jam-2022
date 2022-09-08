using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    [Header("Movement")]
    public float maxPower;
    private float _shootPower = 0f;

    public bool forwardDraging = true;
    public bool showLineOnScreen = false;

    [Header("Target")]
    public GameObject target = null;
    private Vector3 _testDir = Vector3.zero;
    private Vector3 _startDir = Vector3.zero;


    private Transform direction = null;
    private Rigidbody2D rb = null;
    private LineRenderer line = null;
    private LineRenderer screenLine = null;

    private Vector3 _startPosition = Vector2.zero;
    private Vector3 _targetPosition = Vector2.zero;
    private Vector3 _startMousePos = Vector2.zero;
    private Vector3 _currentMousePos = Vector2.zero;

    private bool _canShoot = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
        direction = transform.GetChild(0);
        screenLine = direction.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            MouseClick();

        if (Input.GetMouseButton(0))
            MouseDrag();

        if (Input.GetMouseButtonUp(0))
            MouseRelease();

        if (rb.velocity.magnitude < 0.7f)
        {
            rb.velocity = new Vector2(0, 0);
            _canShoot = true;
        }
    }

    private void MouseClick()
    {
        if (_canShoot)
        {
            Vector2 dir = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.right = dir * 1;
            _startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void MouseDrag()
    {
        CalculateTargetPos();
        if (_canShoot)
        {
            LookAtShootDirection();
            DrawLine();

            if (showLineOnScreen)
                DrawScreenLine();

            float distance = Vector2.Distance(_currentMousePos, _startMousePos);
            if (distance > 1)
            {
                line.enabled = true;
                if (showLineOnScreen)
                    screenLine.enabled = true;
            }
        }
    }

    private void MouseRelease()
    {
        if (_canShoot)
        {
            Shoot();
            screenLine.enabled = false;
            line.enabled = false;
        }
    }

    private void LookAtShootDirection()
    {
        Vector3 dir = _startMousePos - _currentMousePos;
        _testDir = new Vector3(dir.x, 0, dir.y);

        if (forwardDraging)
            transform.right = dir * -1;
        else
            transform.right = dir;

        float dis = Vector2.Distance(_startMousePos, _currentMousePos);
        dis *= 4;

        if (dis < maxPower)
        {
            direction.localPosition = new Vector2(dis / 6, 0);
            _shootPower = dis;
        }
        else
        {
            _shootPower = maxPower;
            direction.localPosition = new Vector2(maxPower / 6, 0);
        }
    }

    public void Shoot()
    {
        _canShoot = false;
        rb.velocity = transform.right * _shootPower;
    }

    private void DrawScreenLine()
    {
        screenLine.positionCount = 1;
        screenLine.SetPosition(0, _startMousePos);

        screenLine.positionCount = 2;
        screenLine.SetPosition(1, _currentMousePos);
    }

    private void DrawLine()
    {
        _startPosition = transform.position;

        line.positionCount = 1;
        line.SetPosition(0, _startPosition);

        _targetPosition = direction.transform.position;
        _currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        line.positionCount = 2;
        line.SetPosition(1, _targetPosition);
    }

    private void CalculateTargetPos()
    {
        float angle = Vector3.SignedAngle(_startDir, _testDir, Vector3.forward);
        if (angle < 0)
            angle += 360;
        target.transform.rotation = Quaternion.Euler(new Vector3(90, 0, angle));
        target.transform.localPosition = new Vector3(target.transform.up.x * (_shootPower / 2), 5f, 
            target.transform.up.z * (_shootPower / 2));
    }
}
