using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public int m_PlayerNumber = 1;         
    public float m_TurnSpeed = 180f;    
    public float m_PitchRange = 0.2f;
   
    private string m_MovementAxisName;     
    private string m_TurnAxisName;         
    private Rigidbody m_Rigidbody;  
    private float m_TurnInputValue;        
    // private float m_OriginalPitch;   
    private Transform pTransform;      


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        pTransform = transform.parent;
    }


    private void OnEnable ()
    {
        m_Rigidbody.isKinematic = false;
        m_TurnInputValue = 0f;
    }


    private void OnDisable ()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        m_TurnAxisName = "Turret" + m_PlayerNumber;

        // m_OriginalPitch = m_MovementAudio.pitch;
    }

    private void Update()
    {
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
        transform.localPosition =  new Vector3(pTransform.localPosition.x, transform.localPosition.y, pTransform.localPosition.z);
    }


    private void FixedUpdate()
    {
        Turn();
    }

    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.

        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}