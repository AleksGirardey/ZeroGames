using UnityEngine;

public class ScrollListKennelManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    private void Start()
    {
        for (int i = 0; i < GameManager.Instance.player.kennel.dogs.Count; i++) // INSTANTIATE DES SPRITES DES CHIENS DU JOUEUR DANS MENU TRAINING
        {
            GameObject DogImgButton = Instantiate(buttonPrefab, buttonPrefab.transform.parent, false) as GameObject;
            DogImgButton.SetActive(true);
            DogImgButton.GetComponent<DogButtonListKennel>().SetDog(GameManager.Instance.player.kennel.dogs[i]);

            DogImgButton.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = DogImgButton.GetComponent<RectTransform>().sizeDelta;
            //DogImgButton.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
            DogImgButton.transform.GetChild(0).GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
            DogImgButton.transform.GetChild(0).GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
            DogImgButton.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);


        }

    }

}
