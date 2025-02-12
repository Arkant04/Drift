using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform gunTip;
    [SerializeField] LayerMask whatIsGrappleable;
    [SerializeField] LineRenderer lr;
    [SerializeField] Transform lrTr;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject grappleMarker; // Marca en pantalla para el punto de enganche

    [Header("Grappling")]
    [SerializeField] float maxDistance;
    [SerializeField] float grappleDelay;
    Vector3 grapplePoint;

    [Header("Cooldown")]
    [SerializeField] float grapplingCD;
    float grapplingCdTimer;

    bool grappling;
    SpringJoint springJoint;

    void Start()
    {
        grappleMarker.SetActive(true); // Asegurarse de que la marca esté activa al inicio
        lr.positionCount = 2; // Asegurarse de que el LineRenderer tenga dos posiciones
        lr.enabled = false; // Desactivar el LineRenderer al inicio
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            StartGrap();

        if (Input.GetKeyUp(KeyCode.Mouse1))
            StopGrap();

        if (grapplingCdTimer > 0)
            grapplingCdTimer -= Time.deltaTime;

        UpdateGrappleMarker();
    }

    private void LateUpdate()
    {
        if (grappling)
        {
            lr.SetPosition(0, gunTip.position);
            lr.SetPosition(1, grapplePoint);
        }
        else
        {
            UpdateLineRenderer();
        }
    }

    private void StartGrap()
    {
        if (grapplingCdTimer > 0)
            return;

        grappling = true;
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            Invoke(nameof(ExecuteGrap), grappleDelay);
        }
        else
        {
            grapplePoint = playerCamera.position + playerCamera.forward * maxDistance;
            Invoke(nameof(StopGrap), grappleDelay);
        }

        lr.enabled = true;
        lr.SetPosition(1, grapplePoint);
    }

    private void ExecuteGrap()
    {
        playerMovement.StartGrappling(grapplePoint); // Llamar a la función de grappling en PlayerMovement
        springJoint = playerMovement.gameObject.AddComponent<SpringJoint>();
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.connectedAnchor = grapplePoint;
        springJoint.spring = 4.5f;
        springJoint.damper = 7f;
        springJoint.massScale = 4.5f;
        springJoint.maxDistance = Vector3.Distance(playerMovement.transform.position, grapplePoint) * 0.8f;
        springJoint.minDistance = Vector3.Distance(playerMovement.transform.position, grapplePoint) * 0.25f;
    }

    private void StopGrap()
    {
        grappling = false;
        grapplingCdTimer = grapplingCD;
        lr.enabled = false;
        playerMovement.StopGrappling(); // Detener el grappling en PlayerMovement
        if (springJoint != null)
        {
            Destroy(springJoint); // Destruir el SpringJoint
        }
    }

    private void UpdateGrappleMarker()
    {
        Ray ray = playerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, whatIsGrappleable))
        {
            grappleMarker.transform.position = hit.point;
        }
        else
        {
            grappleMarker.transform.position = ray.GetPoint(maxDistance);
        }
    }

    private void UpdateLineRenderer()
    {
        //lrTr.position = gunTip.position;
        lrTr.position = grappleMarker.transform.position;
        
    }
}
