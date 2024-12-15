using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChangerScript : MonoBehaviour
{

    [Header("Colores")]
    
    [SerializeField] List<Color> listaColores;
    [SerializeField] List<Color> colorDash;

    [Header("Indices")]
    int startPoint;
    int toGoPoint;

    [Header("Curvas")]
    [SerializeField] AnimationCurve curve;

    [Header("Duraciones e varios")]
    float seconds;
    [SerializeField] float durationColorChange;
    [SerializeField] float durationColorChangeDash;

    [Header("Velocidades")]
    [SerializeField] Vector2 velocidad;
    [SerializeField] Vector2 velocidadWhilePlayerDash;

    [Header("Cosas necesarias para el control del cambio de color del dash")]
    Controles controls;
    bool playerIsDashing;
    void Start()
    {
        controls = new Controles();
        controls.Enable();
        controls.Movement.Enable();
        startPoint = 0;
        toGoPoint = 1;
        StartCoroutine(colorChanger());
    }

    // Update is called once per frame
    void Update()
    {
        playerIsDashing = controls.Movement.Dash.IsPressed();

        //if (playerIsDashing)
        //{
            
        //    StartCoroutine(colorChangerDash());
        //    print("nini");
        //}
        //else
        //{
        //    StopCoroutine(colorChangerDash());
        //}


    }

    public IEnumerator colorChanger()
    {
        while (true)
        {

            if (playerIsDashing)
            {
                while (seconds <= durationColorChangeDash)
                {
                    seconds += Time.deltaTime;

                    transform.GetComponent<MeshRenderer>().material.color = Color.Lerp(
                        colorDash[startPoint],
                        colorDash[toGoPoint],
                        curve.Evaluate(seconds / durationColorChangeDash));
                    transform.GetComponent<MeshRenderer>().material.mainTextureOffset += velocidadWhilePlayerDash * Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
            }

            else 
            {
                while(seconds <= durationColorChange)
                {
                    seconds += Time.deltaTime;
                    transform.GetComponent<MeshRenderer>().material.color = Color.Lerp(
                        listaColores[startPoint],
                        listaColores[toGoPoint],
                        curve.Evaluate(seconds / durationColorChange));
                    transform.GetComponent<MeshRenderer>().material.mainTextureOffset += velocidad * Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
            }

            seconds = 0;
            yield return null;
            indexChanger();
        }
    }

    public IEnumerator colorChangerDash()
    {
        while (seconds <= durationColorChangeDash)
        {
            seconds += Time.deltaTime;

            transform.GetComponent<MeshRenderer>().material.color = Color.Lerp(
                colorDash[startPoint],
                colorDash[toGoPoint],
                curve.Evaluate(seconds / durationColorChangeDash));
            transform.GetComponent<MeshRenderer>().material.mainTextureOffset += velocidad * Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
            indexChangerDash();
            yield return new WaitForEndOfFrame();
        }
        seconds = 0;
        yield return null;
        StartCoroutine(colorChanger());

    }

    void indexChanger()
    {
        startPoint = toGoPoint;
        toGoPoint = (startPoint + 1) % listaColores.Count;
    }

    void indexChangerDash()
    {
        startPoint = toGoPoint;
        toGoPoint = (startPoint + 1) % colorDash.Count;
    }
}
