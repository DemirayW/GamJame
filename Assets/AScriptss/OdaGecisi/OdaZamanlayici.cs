using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OdaZamanlayici : MonoBehaviour
{
    public static OdaZamanlayici Instance; 

    public TextMeshProUGUI sureYazisi; 
    public Image sureBari; 
    
    private float kalanSure;
    private float anaSure;
    private bool zamanSayiyorMu = false;
    
    private Transform suAnkiBaslangic; 
    private GameObject oyuncu;

    void Awake()
    {
        Instance = this; 
        oyuncu = GameObject.Find("Player"); 
    }

    void Start()
    {
        if (sureBari != null)
        {
            RectTransform barAyari = sureBari.GetComponent<RectTransform>();
            if (barAyari != null)
            {
                barAyari.anchorMin = new Vector2(0, 1);
                barAyari.anchorMax = new Vector2(0, 1);
                barAyari.pivot = new Vector2(0, 1);
                barAyari.anchoredPosition = new Vector2(50, -50);
                barAyari.sizeDelta = new Vector2(300, 40); 
            }

            // OYUN İLK AÇILDIĞINDA BARI GİZLE (Sadece süresi olan odaya girince açılacak)
            sureBari.gameObject.SetActive(false); 
        }
    }

    void Update()
    {
        if (zamanSayiyorMu)
        {
            kalanSure -= Time.deltaTime; 

            if (sureYazisi != null)
                sureYazisi.text = "Süre: " + Mathf.CeilToInt(kalanSure).ToString(); 

            if (sureBari != null)
                sureBari.fillAmount = kalanSure / anaSure;

            if (kalanSure <= 0)
            {
                SureBitti();
            }
        }
    }

    public void ZamanlayiciBaslat(float sure, Transform baslamaNoktasi)
    {
        anaSure = sure;
        kalanSure = sure;
        suAnkiBaslangic = baslamaNoktasi;
        zamanSayiyorMu = true;
        
        // Zamanlayıcı başladı, Kırmızı Barı Görünür Yap!
        if (sureBari != null) sureBari.gameObject.SetActive(true);
    }

    public void ZamanlayiciDurdur()
    {
        zamanSayiyorMu = false;
        if (sureYazisi != null) sureYazisi.text = ""; 
        
        // Süresiz Odaya (Oda 1) Girildi! Kırmızı Barı Kapat/Gizle!
        if (sureBari != null) sureBari.gameObject.SetActive(false); 
    }

    void SureBitti()
    {
        if(oyuncu != null && suAnkiBaslangic != null)
        {
            oyuncu.transform.position = suAnkiBaslangic.position;
        }
        kalanSure = anaSure; 
    }
}
