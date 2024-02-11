using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public CameraShake camerashake;
    public UIManager uiManager;
    public SoundsManager sounds;
    public InterstitialAdExample Interstitial;

    public GameObject Camera;
    public Transform vectorBack;
    public Transform vectorForward;
    public GameObject[] Fracture;

    [Header("Get Component")]
    private Touch touch;
    private Rigidbody rb;

    [Range(10, 100)]
    public float speedModifier;
    [Range(5,30)]
    public int forwordSpeed;

    private bool speedBallforword = false;
    private bool firstTouchControl = false;

    private int soundLimitCount;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      
        if(Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) //Çalýþýlcak
                {
                    if(!firstTouchControl)
                    {
                        Variables.firtTouch = 1;
                        uiManager.FirtTouch();
                        firstTouchControl = true;
                    }
                }
                
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) //Çalýþýlcak
                {
                    rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                             transform.position.y,
                                             touch.deltaPosition.y * speedModifier * Time.deltaTime);
                    if (!firstTouchControl)
                    {
                        Variables.firtTouch = 1;
                        uiManager.FirtTouch();
                        firstTouchControl = true;
                    }
                }

            }

            

            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void LateUpdate()
    {
        if (Variables.firtTouch == 1 && speedBallforword == false)
        {
            transform.position += new Vector3(0, 0, forwordSpeed * Time.deltaTime);
            vectorBack.transform.position += new Vector3(0, 0, forwordSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwordSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision hit)
    {

        if(hit.gameObject.CompareTag("Obstacle(Enemy)"))
        {
            Interstitial.LoadAd();
            camerashake.CameraShakesCall();
            uiManager.StartCoroutine("WhiteEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            sounds.BlowUpSound();
            forwordSpeed = 0;
            if(PlayerPrefs.GetInt("Vibration") == 1)
            {
                StartCoroutine(ShowAdTime());
                
                Vibration.Vibrate(100);
            }
            else if(PlayerPrefs.GetInt("Vibration") == 2)
            {
                StartCoroutine(ShowAdTime());
                Debug.Log("Vibration off");
            }
            
            foreach (GameObject item in Fracture)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
                
            }
            StartCoroutine(TimeScaleControl());
            
        }

        if(hit.gameObject.CompareTag("Untagged"))
        {
            
            soundLimitCount += 1;
        }
        if(hit.gameObject.CompareTag("Untagged") && soundLimitCount % 3 == 0)
        {
            sounds.ObjectHitSound();
        }
    }

    public IEnumerator TimeScaleControl()
    {
        speedBallforword = true;
        yield return new WaitForSecondsRealtime(0.6f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.8f);
        uiManager.RestartButtonActive();
        rb.velocity = Vector3.zero;
        
    }

    public IEnumerator ShowAdTime()
    {
        yield return new WaitForSecondsRealtime(1.3f);
        Interstitial.ShowAd();
        
    }



}//class
