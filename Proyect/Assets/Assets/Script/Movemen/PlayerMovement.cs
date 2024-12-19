using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
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
    //float negativeScore;

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
    [SerializeField] ParticleSystem dashParticle;
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

    [Header("Jump Abilitie")]
    [SerializeField] float jumpForce;

    
    

    void Start()
    {
        controls = new Controles();
        controls.Enable();
        controls.Movement.Enable();
        particulasAC.Stop();
        particulasGiro1.Stop();
        particulasGiro2.Stop();
        dashParticle.Stop();
        rb = GetComponent<Rigidbody>();
        passTimeScore = startScore;
        canvasScore.SetActive(false);
        GameEvents.PlayerWantsToUseDash.AddListener(dashIsUsed);
        //GameEvents.PlayerWantsToJump.AddListener(jumpIsUsed);
    }


    void Update()
    {
        MovementInput();
        passTimeScore -= Time.deltaTime;
        if(passTimeScore <= 0) 
            passTimeScore = 0;

        if(totalScore <= 0)
            totalScore = 0;
        
        //if (canvasScore.SetActive(true))
        //{

        //}

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    totalScore += Mathf.FloorToInt(passTimeScore);
        //    plusMinusScoreToShow = +Mathf.FloorToInt(passTimeScore);
        //    textoScoreTotal.text = totalScore.ToString();
        //    textoScoreSumaResta.text = "+" + plusMinusScoreToShow.ToString();
        //    //if (seconds >= animationDuration)
        //    //    canvasScore.SetActive(true);
        //    StartCoroutine(fadeOut());

        //    passTimeScore = startScore;
        //}
    }

    private void FixedUpdate()
    {
        Movement();
        rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
    }

    void MovementInput()
    {
        movementInput = Vector2.zero;
        ////Comportamientos relacionados con la tecla W////
        if (controls.Movement.Aceleracion.IsPressed())
        {
            if (!parAc)
            {
                particulasAC.Play();
                parAc = true;
                //print("parAc");
            }
            movementInput.x += 1;

        }
        else
        {
            if (parAc)
            {
                particulasAC.Stop();
                parAc = false;
                //print("pa");
            }
        }

        //if (controls.Movement.Aceleracion.IsPressed())
        //    print("Chimuelo");

        ///////////////////////////////////////////////////

        ////Frenado y MarchaAtras////

        if (controls.Movement.Freno.IsPressed())
        {
            movementInput.x -= 1;
        }

        //////////////////////////

        ////Giro////

        //if (Input.GetKey(KeyCode.D))
        //{
        //    movementInput.y -= 1;
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    movementInput.y += 1;
        //}
        movementInput.y = controls.Movement.Giro.ReadValue<float>();

        //////////

        ////Frenado////
        PalancaCambio = controls.Movement.FrenoMano.IsPressed(); 
        //////////////
        
        ///Dash///
        Dash = controls.Movement.Dash.IsPressed();
        /////////

        ////Particulas////

        //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        //{
        //    particulasGiro1.Stop();
        //    particulasGiro2.Stop();
        //}

        /////////////////
    }


    void Movement()
    {
        //freno/marcha atras
        if(movementInput.x < 0)
        {

            if(transform.InverseTransformDirection(rb.velocity).z < 0)
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
            //print(movementInput);
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

       

        ///Movimiento izquierda
        if (movementInput.y > 0)
        {
            rb.angularVelocity -= new Vector3(
                rb.angularVelocity.x ,
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

            if (Dash)
            {
                //////////Antiguo///////////////
                //transform.Rotate(dashVisualIZ);
                //rb.velocity = new Vector3(transform.forward.x * dashForce, 0, transform.forward.z * dashForce);
                //StartCoroutine(dashCooldownIZ());


                ////////Reciente//////////////
                //GameObject PlayerChild = GameObject.Find("GameObject");
                //PlayerChild.transform.rotation = Quaternion.Euler(0, 0, -dashRotation);
                dashParticle.Play();
                
                //Dash = false;
                //StartCoroutine(dashRotationVisual());

                //rb.velocity = new Vector3(transform.forward.x * dashForce, 
                //    0, 
                //    transform.forward.z * dashForce);
            }
           
            else if (controls.Movement.Dash.WasReleasedThisFrame() == false)
            {
                new WaitForSeconds(0.8f);
                dashParticle.Stop();
               // print("djada");
            }
            

            if (PalancaCambio)
            {
                rb.angularVelocity -= new Vector3(
                rb.angularVelocity.x,
                rb.angularVelocity.y - giroFrenoMano.y);
            }
        }

        ///Movimiento derecha
        if(movementInput.y < 0)
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
                //////////Antiguo///////////////
                //transform.Rotate(dashVisualDR);
                //Vector3 ForceToApply = transform.forward * dashForce;
                //StartCoroutine(dashCooldownIZ());

                ////////Reciente//////////////
                //GameObject PlayerChild = GameObject.Find("GameObject");
                //PlayerChild.transform.rotation = Quaternion.Euler(0, 0, dashRotation);

                dashParticle.Play();
                
                //rb.velocity = new Vector3(transform.forward.x * dashForce, 
                //    0, 
                //   transform.forward.z * dashForce);
                //StartCoroutine(dashRotationVisual());
                //Dash = false;
                
                //rb.velocity = new Vector3(transform.forward.x * dashForce, 
                //    0, 
                //    transform.forward.z * dashForce);
            }
            
            else if(controls.Movement.Dash.WasReleasedThisFrame() == false)
            {
                new WaitForSeconds(0.8f);
                dashParticle.Stop();
               // print("dadda");
            }
            

            if (PalancaCambio)
            {
                rb.angularVelocity -= new Vector3(
                rb.angularVelocity.x,
                rb.angularVelocity.y + giroFrenoMano.y);
            }
        }

        
        //Acceleracion 
        if (movementInput.x > 0)
        {
            rb.velocity += transform.forward * speedPlayer * Time.fixedDeltaTime;
            //if (Input.GetKey(KeyCode.S))
            //{
            //    rb.velocity = new Vector3(
            //        rb.velocity.x / (1 + FuerzaDeFrenado * Time.deltaTime),
            //        rb.velocity.y,
            //        (rb.velocity.z / (1 + FuerzaDeFrenado * Time.deltaTime)));
            //    print("Estoy Frenando");
            //}
        }

        else
        {
            rb.velocity = new Vector3(
                rb.velocity.x / (1 + friccion * Time.deltaTime),
                rb.velocity.y,
                (rb.velocity.z / (1 + friccion * Time.deltaTime)));
            //print(friccion);
            
            //particulasAC.Stop();
            //if (Input.GetKey(KeyCode.S))
            //{
            //    rb.velocity -= transform.forward * speedPlayer * Time.deltaTime;
            //    print("MarchaTra");
            //}
        }

        if (rb.velocity.x >= maxVelocity || rb.velocity.z >= maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
            //if (PalancaCambio)
            //{
            //    for(int i = 4; i < drifftSpawn.Count; i++)
            //    {
            //        GameObject drifftInstance = Instantiate(drifftPF,
            //            drifftSpawn[i].position, 
            //            Quaternion.identity);
            //        print("GAS GAS GAS GAS GAS GAS");
            //        Destroy(drifftInstance, 5f);
            //    }
            //}
        }

        

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
            //if(seconds >= animationDuration)
            //canvasScore.SetActive(true);
            if (passTimeScore <= 0)
                passTimeScore = startScore;
            //passTimeScore = 0;

        }
    }

   //Contacto con el coleccionable 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {


            totalScore += Mathf.FloorToInt(passTimeScore);
            plusMinusScoreToShow = +Mathf.FloorToInt(passTimeScore);
            textoScoreTotal.text = totalScore.ToString();
            textoScoreSumaResta.text = "+" + plusMinusScoreToShow.ToString();
            //if (seconds >= animationDuration)
            //    canvasScore.SetActive(true);
            StartCoroutine(fadeOut());
            
            passTimeScore = startScore;
        }
    }

    //Corrutina de la animacion del scorage del marcador de puntos 
    public IEnumerator fadeOut()
    {
        float t = animationDuration;
        while(t > 0)
        {
            canvasScore.SetActive(true);
            t -= Time.deltaTime;
            yield return null;
        }
        canvasScore.SetActive(false);
    }


    //corrutina para que la rotacion del coche vuelva a la que tenia anteriormente
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
        //transform.Rotate(dashVisualIZ);
    }


    void dashIsUsed()
    {
        //Dash = true;
        //dashParticle.Play();
        rb.velocity = new Vector3(transform.forward.x * dashForce,
            0,
            transform.forward.z * dashForce);
    }

    void jumpIsUsed()
    {
        rb.velocity = new Vector3(rb.velocity.x, transform.forward.y * jumpForce, rb.velocity.z);
    }
        //dashing = true;
        //yield return new WaitForSeconds(0.3f);
        //transform.Rotate(dashVisualIZ);
        //yield return new WaitForSeconds(dashCooldownTime);
        //dashing = true;


        // leer la velocity actual
        // calcular la velocity que se aplicará durante la duración del dash
        // poner al obj en la rotación pertinente
        // bloquear el input
        // aplicar esa velocity durante todo el dash
        // desbloquear el input
        // devovler físicas a la rotación 

    //public IEnumerator dashCooldownDR()
    //{
    //    //transform.Rotate(dashVisualDR);
    //    //yield return new WaitForSeconds(1);
    //    //rb.velocity = new Vector3(transform.forward.x * dashForce, 0, transform.forward.z * dashForce);
    //    //yield return null;
    //}
}


/*
 * 
 * Dash izquierda / derecha
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */

