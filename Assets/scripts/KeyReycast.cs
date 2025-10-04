using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeyReycast : MonoBehaviour
{
    private bool IsKotel = false;
    private bool isGarage = false;
    private bool isSkot = false;
    private bool isSafe = false;
    private bool issafeapproached = false;
    private bool IsOpened;
    public GameObject textSafe;
    public GameObject textSafe1;
    private float timetowrite = 2f;
    private float timetostop = 0f;
    private float timetowrite1 = 2f;
    private float timetostop1 = 0f;
    void Start()
    {
        
    }


    void Update()
    {
        if (IsOpened)
        {
            timetowrite -= Time.deltaTime;
        
            if (timetostop >= timetowrite )
            {
                textSafe.SetActive(false);
                timetowrite = 0;
            }
        }
        if (issafeapproached)
        {
            timetowrite1 -= Time.deltaTime;

            if (timetostop1 >= timetowrite1)
            {
                textSafe1.SetActive(false);
                timetowrite1 = 0;
            }
        }

        Debug.Log("safe" + isSafe);
        Debug.Log("open" + IsOpened);
        Debug.Log("approach" + issafeapproached);

        //    Debug.Log("safe" + isSafe);
        //    Debug.Log("garage" + isGarage);
        //    Debug.Log("kotel" + IsKotel);
        //    Debug.Log("skot" + isSkot);
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null && hit.collider.tag == "key")
            {
                Destroy(hit.collider.gameObject);
                IsKotel = true;
            }
            if (hit.collider != null && hit.collider.tag == "safeKey")
            {
                Destroy(hit.collider.gameObject);
                isSafe = true;
            }
            if (hit.collider != null && hit.collider.tag == "GarageKey")
            {
                isGarage = true;
                Destroy(hit.collider.gameObject);
              

            }
            if (hit.collider != null && hit.collider.tag == "SkotKey")
            {
                Destroy(hit.collider.gameObject);
                isSkot = true;

            }
           if (hit.collider != null && hit.collider.tag == "GarageDoor" && isGarage)
            {
                Destroy(hit.collider.gameObject);
            }
           if (hit.collider != null && hit.collider.tag == "KotelDoor" && IsKotel)
            {
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider != null && hit.collider.tag == "SkotDoor" && isSkot)
            {
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider != null && hit.collider.tag == "SafeDoor" && isSafe)
            {
                Destroy(hit.collider.gameObject);
            }
            if (hit.collider != null && hit.collider.tag == "SafeDoor" && isSafe == false)
            {
                textSafe.SetActive(true);
                IsOpened = true;
               

            }











        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "safe")
        {
            issafeapproached = true;
            textSafe1.SetActive(true);
        }
    }

}
