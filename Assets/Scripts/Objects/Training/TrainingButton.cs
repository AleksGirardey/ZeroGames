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

    public Vector2 baseSize;
    public void SetName(string name)
    {
        Name.text = name;
    }

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = FindObjectOfType<Canvas>();
    }

    void Start()
    {
        trainingManager = GameObject.FindWithTag("TrainingManager").GetComponent<TrainingManager>();
        baseSize = GetComponent<RectTransform>().sizeDelta;

        if (Training.VitesseMaxDef != 0 || Training.VitesseMaxTempo != 0)
        {
            GetComponent<Image>().color = new Color32(175, 255, 255, 175);
        }
        else if (Training.EnduranceDef != 0 || Training.EnduranceTempo != 0)
        {
            GetComponent<Image>().color = new Color32(255, 175, 255, 175);
        }
        else if (Training.AccelerationDef != 0 || Training.AccelerationTempo != 0)
        {
            GetComponent<Image>().color = new Color32(255, 255, 175, 175);
        }
    }
 
    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<RectTransform>().sizeDelta = baseSize;
        GetComponentInChildren<RectTransform>().sizeDelta = baseSize;
        if (Clone)
        {
            if (TrainingSlot != null && TrainingSlot.training == Training)
            {
                TrainingSlot.energyBar.UpdEnergy(TrainingSlot.energyBar.previousDay, TrainingSlot.energyBar.EnergyUsed);
                TrainingSlot.actualTraining = null;
                TrainingSlot.training = null;
                trainingManager.trainingList.Remove(Training);
            }
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.6f;
            //canvasGroup.ignoreParentGroups = true;
            //print("drag begin");
            initialParent = transform.parent;
            transform.SetParent(ParentWhileDrag); // SETPARENT MARCHE MAIS PAS DANS LINSPECTEUR MAIS VISUELLEMENT CELA CHANGE BIEN QUELQUE CHOSE

            initialPos = transform.position;
            dropped = false;
            DefaultTrainingButton.CloneSpawned = false;
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

        
    }

    

   
}
