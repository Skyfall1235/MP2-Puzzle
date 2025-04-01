using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class GyroMovement : MonoBehaviour
{
    bool shouldBallMove = true;
    public UnityEvent resetGyroPosition = new UnityEvent();
    public float MaxDeviationForReset;
    public float MaxSpeed;
    Rigidbody body;
    public Transform floor;

    bool canReset = false;
    public bool CanReset { get => canReset; set => canReset = value; }

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Input.gyro.enabled = true;
    }
    private void FixedUpdate()
    {
        if (shouldBallMove)
        {
            ApplyForceFromGyro();
        }
    }

    void ApplyForceFromGyro()
    {
        //get the qwuaterion from the device
        Quaternion CurrentDeviceAngle = GyroToUnity();
        

        //go read below or read the xml summary
        //CustomVector DirectionAndScalar = ConvertGyroToScaled(CurrentDeviceAngle);
        //Vector2 scaledVector = DirectionAndScalar.planeDir * DirectionAndScalar.NormalizedValue;
        //Vector3 FinalizedVector = new Vector3(scaledVector.x, 0f, scaledVector.y);

        //apply that force
        //Debug.Log($"applying force of size : {FinalizedVector}");
        Debug.Log(CurrentDeviceAngle);
        floor.rotation = CurrentDeviceAngle;
        //body.AddForce(FinalizedVector * Time.fixedDeltaTime, ForceMode.Force);
    }

    //CustomVector ConvertGyroToScaled(Quaternion rawValue)
    //{
    //    float MagnitudeScalar;

    //    //convert it to euler
    //    Vector3 UelerConvert = rawValue.eulerAngles;

    //    //conver the anle of rotation into a scalrat to deterin the max speed of the ball
    //    if(UelerConvert.magnitude > 0)
    //    {
    //        MagnitudeScalar = (UelerConvert.x + rawValue.eulerAngles.y) / 180;
            
    //    }
    //    else
    //    {
    //        MagnitudeScalar = 0f;
    //    }
    //    return new CustomVector(UelerConvert,MagnitudeScalar);
    //}

    //public struct CustomVector
    //{
    //    public Vector2 planeDir;
    //    public float NormalizedValue;

    //    public CustomVector(Vector2 planeDir, float normalizedValue)
    //    {
    //        this.planeDir = planeDir;
    //        NormalizedValue = normalizedValue;
    //    }
    //}

    public void PlayerDied()
    {
        canReset = true;
        shouldBallMove = false;
    }
    public void ResetPlayer()
    {
        resetGyroPosition.Invoke();
        canReset = false;
        shouldBallMove = true;
    }

    private static Quaternion GyroToUnity()
    {
        Quaternion q = Input.gyro.attitude;
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

}
