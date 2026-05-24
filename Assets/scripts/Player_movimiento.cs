using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Player_movimiento : MonoBehaviour
{
    [SerializeField] private float RotacionSpeed;
    [SerializeField] public float MovimientoSpeed;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform transformPersonaje;
    [SerializeField] private Camera camara;
    [SerializeField] private float FuerzaSalto;
    [SerializeField] private float Gravedad;

    private Vector3 velocidadVertical;
    private Vector3 movimiento;
    private float rotacionx;
    private bool enSuelo;

    private void Update()
    {
        MovimientoPersonaje();
        MovimientoCamara();
    }

    void MovimientoPersonaje()
    {
        enSuelo = characterController.isGrounded;
        if (enSuelo && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f; 
        }
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        Vector3 movimientoHorizontal = transform.right * movX + transform.forward * movZ;


        characterController.Move(movimientoHorizontal * MovimientoSpeed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            velocidadVertical.y = Mathf.Sqrt(FuerzaSalto * -2f * Gravedad);
        }

        velocidadVertical.y += Gravedad * Time.deltaTime;
        characterController.Move(velocidadVertical * Time.deltaTime);

    }

    void MovimientoCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * RotacionSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * RotacionSpeed * Time.deltaTime;

        rotacionx -= mouseY;
        rotacionx = Mathf.Clamp(rotacionx, -90f, 90f);
        camara.transform.localRotation = Quaternion.Euler(rotacionx, 0f, 0f);
        transformPersonaje.Rotate(Vector3.up * mouseX);
    }

}
