using UnityEngine;

public class OdaGecisi : MonoBehaviour
{
    private BoxCollider2D buOdaninKutusu;
    private CameraFollow kameraKodu;

    [Header("Bu Alanın Zoom Uzaklığı")]
    public float odaZoomDegeri = 5f;

    [Header("Oda Süre Ayarları")]
    [Tooltip("Karakteri başa sarmak için saniye. Süre istemiyorsan 0 yap.")]
    public float odaninSuresi = 10f; 
    public Transform baslangicNoktasi; 

    void Start()
    {
        buOdaninKutusu = GetComponent<BoxCollider2D>();
        kameraKodu = Camera.main.GetComponent<CameraFollow>();
    }

    void OnTriggerEnter2D(Collider2D temasEden)
    {
        if (temasEden.name == "Player")
        {
            if (kameraKodu != null)
            {
                kameraKodu.sinirKutusu = buOdaninKutusu;
                kameraKodu.targetZoom = odaZoomDegeri; 
            }

            if (OdaZamanlayici.Instance != null)
            {
                // Eğer Odanın Süresi 0'dan büyükse VE Işınlanacağı nokta boş bırakılmamışsa çalış:
                if (odaninSuresi > 0 && baslangicNoktasi != null)
                {
                    OdaZamanlayici.Instance.ZamanlayiciBaslat(odaninSuresi, baslangicNoktasi);
                }
                else // Değilse (Yani Güvenli Bölgeyse) süreleri iptal et ve kırmızı çubuğu sakla!
                {
                    OdaZamanlayici.Instance.ZamanlayiciDurdur(); 
                }
            }
        }
    }
}
