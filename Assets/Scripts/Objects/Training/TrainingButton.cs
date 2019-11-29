using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class TrainingButton : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Training Training;
    private RectTransform rectTransform;
    public Canvas canvas;
    public CanvasGroup canvasGroup;
    private Vector3 initialPos;
    public bool dropped;
    public bool onCalendar;
    public bool Monday, Tuesday, Wednesday, Thursday, Friday;
    public TrainingSlot TrainingSlot;
    public Transform ParentWhileDrag;
    private Transform initialParent;
    public Text Name;
    public bool Clone, CloneSpawned;
    public TrainingButton DefaultTrainingButton;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    [FormerlySerializedAs("TrainingManager")] public TrainingManager trainingManager;

    private Vector2 baseSize;
    public void SetName(string name)
    {
        Name.text = name;
    }

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
    }

    void Start()
    {
        trainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();
        baseSize = GetComponent<RectTransform>().sizeDelta;
        /*
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
        */
    }
    /*
    public void OnMouseOver()
    {
        if(gameObject.name == "DogShowcaseBG")
        {
            print("ENTER HOVERING DOGSHOWCASE BG MOUSE OVER");
        }
        else
        {
            print(gameObject.name);
        }
    }
    

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        
        Debug.Log("Cursor Entering " + name + " GameObject");
        if(pointerEventData.pointerEnter.gameObject.name == "DogShowcaseBG")
        {
            print("ENTER HOVERING DOGSHOWCASE BG");
        }
    }
    */
    /*
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        //Debug.Log("Cursor Entering " + name + " GameObject");
        if (pointerEventData.pointerEnter.gameObject.name == "DogShowcaseBG")
        {
            print("EXIT HOVERING DOGSHOWCASE BG");
        }
    }
    */
    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().sizeDelta = baseSize;
        GetComponentInChildren<RectTransform>().sizeDelta = baseSize;
        if (Clone)
        {
            if (TrainingSlot != null && TrainingSlot.training == Training)
            {
                TrainingSlot.energyBar.UpdEnergy(TrainingSlot.energyBar.previousDay, TrainingSlot.energyBar.EnergyUsed);
                TrainingSlot.training = null;
            }
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.6f;
            // canvasGroup.ignoreParentGroups = true;
            //print("drag begin");
            initialParent = transform.parent;
            transform.SetParent(ParentWhileDrag); // SETPARENT MARCHE MAIS PAS DANS LINSPECTEUR MAIS VISUELLEMENT CELA CHANGE BIEN QUELQUE CHOSE

            initialPos = transform.position;
            dropped = false;
            DefaultTrainingButton.CloneSpawned = false;
        }
        else
        {

        }

        trainingManager.SetBinScreen();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = Input.mousePosition;
        if (Clone)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Clone)
        {
            //transform.localPosition = Vector3.zero;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1;


            //print("end drag");
            if (!dropped)
            {
                if(DefaultTrainingButton != null)
                {
                    DefaultTrainingButton.CloneSpawned = false;
                }
                Destroy(gameObject);
                transform.position = initialPos;
                transform.SetParent(initialParent);
                // canvasGroup.ignoreParentGroups = false;
            }
        }
        trainingManager.SetBinScreen();


    }

    void Update()
    {
        if (!Clone && !CloneSpawned)
        {
            GameObject TrainingButtonClone = Instantiate(gameObject) as GameObject;
            TrainingButtonClone.transform.SetParent(transform.parent, false);
            TrainingButton TrainingButtonCS = TrainingButtonClone.GetComponent<TrainingButton>();
            TrainingButtonCS.Clone = true;
            CloneSpawned = true;
            TrainingButtonCS.DefaultTrainingButton = GetComponent<TrainingButton>();
        }
        /*
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
            }
        }
        */
    }

    

   
}
