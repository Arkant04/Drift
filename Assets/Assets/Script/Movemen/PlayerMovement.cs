using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Rigibody")]
    [SerializeField] Transform sphere;
    Rigidbody rb;

    [Header("Score")]
    float startScore = 50;
    int totalScore;
    float passTimeScore;
    float plusMinusScoreToShow;
    [SerializeField] GameObject canvasScore;
    float seconds;
    float animationDuration = 2;
    [SerializeField] TMP_Text textoScoreTotal;
    [SerializeField] TMP_Text textoScoreSumaResta;

    [Header("Velocidades")]
    [SerializeField] float speedPlayer;
    [SerializeField] float maxVelocity;

    [Header("Giro")]
    [SerializeField] Vector3 giroNormal;
    [SerializeField] Vector3 giroFrenoMano;

    [Header("Friccion y otros")]
    [SerializeField] float FuerzaDeFrenado;
    [SerializeField] float friccion;
    bool PalancaCambio;
    [SerializeField] float FuerzaFrenoMano;

    [Header("Derrape")]
    [SerializeField] List<Transform> drifftSpawn;
    [SerializeField] GameObject drifftPF;

    [Header("Particles")]
    [SerializeField] ParticleSystem particulasAC;
    [SerializeField] ParticleSystem particulasGiro1;
    [SerializeField] ParticleSystem particulasGiro2;
    Vector2 movementInput = Vector2.zero;
    bool parAc = false;
    bool parGiro1 = false;
    bool parGiro2 = false;

    [Header("Control")]
    Controles controls;

    [Header("Dash")]
    [SerializeField] float dashForce;
    [SerializeField] float dashRotation;
    [SerializeField] float dashCooldownTime;
    bool Dash;
    bool dashing;

    [Header("Gravity")]
    [SerializeField] float gravityScale;
    bool isOnground;

    [Header("Jump Platform")]
    [SerializeField] float jumpForce;

    [Header("Sphere performance")]
    [SerializeField] float maxRotationSpeedSphere = 360f;
    float accumulatedAngleX = 0f;
    float accumulatedAngleY = 0f;
    Quaternion initialRotation;

    [Header("Grappling")]
    bool isGrappling;
    Vector3 grapplePoint;
    [SerializeField] float grappleSpeed;

    void Start()
    {
        controls = new Controles();
        controls.Enable();
        controls.Movement.Enable();
        particulasAC.Stop();
        particulasGiro1.Stop();
        particulasGiro2.Stop();
        rb = GetComponent<Rigidbody>();
        passTimeScore = startScore;
        canvasScore.SetActive(false);
        GameEvents.PlayerWantsToUseDash.AddListener(dashIsUsed);
        initialRotation = sphere.rotation;
    }

    void Update()
    {
        MovementInput();
        passTimeScore -= Time.deltaTime;
        if (passTimeScore <= 0)
            passTimeScore = 0;

        if (totalScore <= 0)
            totalScore = 0;
    }

    private void FixedUpdate()
    {
        if (isGrappling)
        {
            GrappleMovement();
        }
        else
        {
            Movement();
        }
        rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
    }

    void MovementInput()
    {
        movementInput = Vector2.zero;
        if (controls.Movement.Aceleracion.IsPressed())
        {
            if (!parAc)
            {
                particulasAC.Play();
                parAc = true;
            }
            movementInput.x += 1;
        }
        else
        {
            if (parAc)
            {
                particulasAC.Stop();
                parAc = false;
            }
        }

        if (controls.Movement.Freno.IsPressed())
        {
            movementInput.x -= 1;
        }

        movementInput.y = controls.Movement.Giro.ReadValue<float>();
        PalancaCambio = controls.Movement.FrenoMano.IsPressed();
        Dash = controls.Movement.Dash.IsPressed();
    }

    void Movement()
    {
        if (movementInput.x < 0)
        {
            if (transform.InverseTransformDirection(rb.velocity).z < 0)
            {
                rb.velocity -= transform.forward * speedPlayer * Time.fixedDeltaTime;
            }
            else
            {
                rb.velocity = new Vector3(
                        rb.velocity.x / (1 + FuerzaDeFrenado * Time.fixedDeltaTime),
                        rb.velocity.y,
                        rb.velocity.z / (1 + FuerzaDeFrenado * Time.fixedDeltaTime));
            }
        }

        if (PalancaCambio)
        {
            rb.velocity = new Vector3(
                        rb.velocity.x / (1 + FuerzaFrenoMano * Time.fixedDeltaTime),
                        rb.velocity.y,
                        rb.velocity.z / (1 + FuerzaFrenoMano * Time.fixedDeltaTime));

            for (int i = 0; i < drifftSpawn.Count; i++)
            {
                GameObject drifftInstance = Instantiate(drifftPF,
                    drifftSpawn[i].position,
                    Quaternion.identity);
                drifftPF.transform.LookAt(drifftSpawn[i].position);
                Destroy(drifftInstance, 0.5f);
            }
        }

        if (movementInput.y > 0)
        {
            rb.angularVelocity -= new Vector3(
                rb.angularVelocity.x,
                rb.angularVelocity.y - giroNormal.y);

            if (!parGiro1)
            {
                particulasGiro1.Play();
                parGiro1 = true;
            }
            else
            {
                if (particulasGiro1)
                {
                    particulasGiro1.Stop();
                    parGiro1 = false;
                }
            }

            if (PalancaCambio)
            {
                rb.angularVelocity -= new Vector3(
                rb.angularVelocity.x,
                rb.angularVelocity.y - giroFrenoMano.y);
            }
        }

        if (movementInput.y < 0)
        {
            if (!parGiro2)
            {
                particulasGiro2.Play();
                parGiro2 = true;
            }
            else
            {
                if (parGiro2)
                {
                    particulasGiro2.Stop();
                    parGiro2 = false;
                }
            }

            rb.angularVelocity -= new Vector3(
                rb.angularVelocity.x,
                rb.angularVelocity.y + giroNormal.y);

            if (Dash)
            {
                // Código relacionado con el dash (comentado)
            }

            if (PalancaCambio)
            {
                rb.angularVelocity -= new Vector3(
                rb.angularVelocity.x,
                rb.angularVelocity.y + giroFrenoMano.y);
            }
        }

        if (movementInput.x > 0)
        {
            rb.velocity += transform.forward * speedPlayer * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = new Vector3(
                rb.velocity.x / (1 + friccion * Time.deltaTime),
                rb.velocity.y,
                (rb.velocity.z / (1 + friccion * Time.deltaTime)));
        }

        if (rb.velocity.x >= maxVelocity || rb.velocity.z >= maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }

        Vector3 direction = rb.velocity;

        if (movementInput != Vector2.zero)
        {
            float angleX = direction.z * speedPlayer * Time.fixedDeltaTime;
            float angleY = direction.x * speedPlayer * Time.fixedDeltaTime;

            angleX = Mathf.Clamp(angleX, -maxRotationSpeedSphere * Time.fixedDeltaTime, maxRotationSpeedSphere * Time.fixedDeltaTime);
            angleY = Mathf.Clamp(angleY, -maxRotationSpeedSphere * Time.fixedDeltaTime, maxRotationSpeedSphere * Time.fixedDeltaTime);

            if (direction.z < 0)
            {
                angleX = -angleX;
            }

            accumulatedAngleX += angleX;
            accumulatedAngleY += angleY;

            sphere.rotation = Quaternion.Euler(accumulatedAngleX, accumulatedAngleY, 0);
        }
        else
        {
            sphere.rotation = Quaternion.Lerp(sphere.rotation, initialRotation, Time.fixedDeltaTime * 2f);
            accumulatedAngleX = Mathf.Lerp(accumulatedAngleX, 0f, Time.fixedDeltaTime * 2f);
            accumulatedAngleY = Mathf.Lerp(accumulatedAngleY, 0f, Time.fixedDeltaTime * 2f);
        }
    }

    public void StartGrappling(Vector3 point)
    {
        isGrappling = true;
        grapplePoint = point;
    }

    public void StopGrappling()
    {
        isGrappling = false;
    }

    void GrappleMovement()
    {
        // El movimiento de balanceo se maneja con el SpringJoint en el script Grappling
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            plusMinusScoreToShow = -Mathf.FloorToInt(passTimeScore);

            if (totalScore <= 0)
            {
                totalScore = 0;
                textoScoreTotal.text = "0";
                print("Te pasas");
            }
            else
            {
                totalScore -= Mathf.FloorToInt(passTimeScore);
                textoScoreTotal.text = totalScore.ToString();
            }
            textoScoreSumaResta.text = plusMinusScoreToShow.ToString();
            StartCoroutine(fadeOut());
            if (passTimeScore <= 0)
                passTimeScore = startScore;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            totalScore += Mathf.FloorToInt(passTimeScore);
            plusMinusScoreToShow = +Mathf.FloorToInt(passTimeScore);
            textoScoreTotal.text = totalScore.ToString();
            textoScoreSumaResta.text = "+" + plusMinusScoreToShow.ToString();
            StartCoroutine(fadeOut());
            passTimeScore = startScore;
        }

        if (other.gameObject.CompareTag("jump"))
        {
            rb.velocity += new Vector3(0, jumpForce, 0);
            print("AAAAAAAAAAAA");
        }
    }

    public IEnumerator fadeOut()
    {
        float t = animationDuration;
        while (t > 0)
        {
            canvasScore.SetActive(true);
            t -= Time.deltaTime;
            yield return null;
        }
        canvasScore.SetActive(false);
    }

    public IEnumerator dashRotationVisual()
    {
        GameObject PlayerChild = GameObject.Find("GameObject");
        var Angles = PlayerChild.transform.rotation;
        Angles.z += Time.deltaTime * 10;
        PlayerChild.transform.rotation = Angles;
        if (Angles.z >= dashRotation)
        {
            yield return new WaitForSeconds(0.5f);
            PlayerChild.transform.rotation = transform.rotation;
        }
        yield return null;
    }

    void dashIsUsed()
    {
        rb.velocity = new Vector3(transform.forward.x * dashForce,
            0,
            transform.forward.z * dashForce);
    }
}
