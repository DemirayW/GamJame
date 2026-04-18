using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections; // Kararma Animasyonu (IEnumerator) için bu şarttır

public class Menu : MonoBehaviour
{
    public Image gecisEkrani; // Menüdeki Siyah Perde

    public void OyunuBaslat()
    {
        // Oyna tuşuna basınca karartmayı ateşler
        StartCoroutine(KarartVeGec("ana oyun")); 
    }

    public void AyarlaraGit()
    {
        // Ayarlara şimdilik anında geçiyor (istersen buna da kararma ekleriz)
        SceneManager.LoadScene("ayarlar"); 
    }

    public void OyundanCik()
    {
        Application.Quit();
        Debug.Log("Oyundan çıkıldı");
    }

    // Karartma Sihri (0.4 Saniyelik Hızlı Animasyon)
    IEnumerator KarartVeGec(string sahneAdi)
    {
        gecisEkrani.gameObject.SetActive(true);
        Color renk = gecisEkrani.color;
        
        float gecisSuresi = 0.4f; // Saniyesi! (1 yerine 0.4 ile hızlandırdık)
        float sure = 0f;

        while (sure < gecisSuresi)
        {
            sure += Time.deltaTime;
            renk.a = sure / gecisSuresi; 
            gecisEkrani.color = renk;
            yield return null;
        }

        // Ekran TAMAMEN siyah olunca, "ana oyun" sahnesini yükle!
        SceneManager.LoadScene(sahneAdi);
    }
}
