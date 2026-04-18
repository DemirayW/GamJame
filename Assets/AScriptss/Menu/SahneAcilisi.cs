using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SahneAcilisi : MonoBehaviour
{
    public Image karanlikEkrani;

    void Start()
    {
        // Sahne başladığı saniye aydınlanma sekansını ateşle
        StartCoroutine(Aydinlan());
    }

    IEnumerator Aydinlan()
    {
        Color renk = karanlikEkrani.color;
        float gecenZaman = 0f;
        float aydinlanmaSuresi = 1f; // Kaç saniyede açılsın istersen burayı değiştir

        while (gecenZaman < aydinlanmaSuresi)
        {
            gecenZaman += Time.deltaTime;
            renk.a = 1f - (gecenZaman / aydinlanmaSuresi); // Siyahlığı yavaşça siliyoruz
            karanlikEkrani.color = renk;
            yield return null;
        }

        // Tamamen saydamlaşınca kapat ki arka planda boşuna enerji yemesin
        karanlikEkrani.gameObject.SetActive(false); 
    }
}
