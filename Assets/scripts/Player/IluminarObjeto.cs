using TMPro;
using UnityEngine;

public class IluminarObjeto : MonoBehaviour
{
    public TMP_Text mensajeUI;
    public Transform camaraJugador;
    public float distanciaRaycast = 10f;

    private Outline ultimoOutlineIluminado;

    void Start()
    {
        if (camaraJugador == null && Camera.main != null)
        {
            camaraJugador = Camera.main.transform;
        }
    }

    void Update()
    {
        Vector3 origen = camaraJugador.position;
        Vector3 direccion = camaraJugador.forward;
        RaycastHit hit;

        if (Physics.Raycast(origen, direccion, out hit, distanciaRaycast))
        {
            if (hit.collider.CompareTag("Interactuable"))
            {
                Outline outlineObjeto = hit.collider.GetComponent<Outline>();

                if (outlineObjeto != null)
                {
                    if (ultimoOutlineIluminado != null && ultimoOutlineIluminado != outlineObjeto)
                    {
                        ApagarUltimoObjeto();
                    }
                    outlineObjeto.enabled = true;
                    mensajeUI.text = "Oprimir E para interactuar";

                    ultimoOutlineIluminado = outlineObjeto;
                }
            }
            else
            {
                ApagarUltimoObjeto();
            }
        }
        else
        {

            ApagarUltimoObjeto();
        }

        Debug.DrawRay(origen, direccion * distanciaRaycast, Color.red);
    }

    private void ApagarUltimoObjeto()
    {
        mensajeUI.text = "";
        if (ultimoOutlineIluminado != null)
        {
            ultimoOutlineIluminado.enabled = false;
            ultimoOutlineIluminado = null;
        }
    }
}