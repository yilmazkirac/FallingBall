using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Top : MonoBehaviour
{
    bool Ziplayabilirmi = true;
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private AudioSource SekmeSesi;
    [SerializeField] private AudioSource KaybetmeSesi;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") && Ziplayabilirmi)
        {
            Ziplayabilirmi = false;
            SekmeSesi.Play();
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 90, 0) * 10f, ForceMode.Force);
            Invoke("ZiplamaKontrol", .1f);
        }
        if (collision.gameObject.CompareTag("Die"))
        {
            KaybetmeSesi.Play();
            _GameManager.OyunMusic.Stop();
            if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
                _GameManager.HighScoreText[0].text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
            }
            _GameManager.HighScoreText[1].text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
            _GameManager.ScoreText[1].text = "Score : " + PlayerPrefs.GetInt("Score").ToString();
            _GameManager.Paneller[0].SetActive(false);
            _GameManager.Paneller[1].SetActive(true);
            PlayerPrefs.SetInt("Score", 0);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            _GameManager.OyunDevamEdiyor = false;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlatformWall"))
        {
            _GameManager.Sayac++;
            if (_GameManager.Sayac > 0)
            {
                Color32 Color = new Color32(57, 175, 197, 0);
                _GameManager._Camera.GetComponent<Camera>().backgroundColor = Color;
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 3);
            }
            if (_GameManager.Sayac > 3)
            {
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 6);
                Color32 Color = new Color32(81, 81, 81, 0);
                _GameManager._Camera.GetComponent<Camera>().backgroundColor = Color;
            }
            if (_GameManager.Sayac > 6)
            {
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 9);
                _GameManager._Camera.GetComponent<Camera>().backgroundColor = Color.yellow;
            }
            if (_GameManager.Sayac > 12)
            {

                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 13);
                Color32 Color = new Color32(109, 67, 255, 0);
                _GameManager._Camera.GetComponent<Camera>().backgroundColor = Color;
            }
            if (_GameManager.Sayac > 18)
            {
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 23);
                Color32 Color = new Color32(154, 74, 126, 0);
                _GameManager._Camera.GetComponent<Camera>().backgroundColor = Color;
            }
            if (_GameManager.Sayac > 26)
            {
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 34);
                Color32 Color = new Color32(81, 81, 81, 0);
                _GameManager._Camera.GetComponent<Camera>().backgroundColor = Color;
            }
            _GameManager.ScoreText[0].text = "Score : " + PlayerPrefs.GetInt("Score").ToString();
        }
    }
    void ZiplamaKontrol()
    {
        Ziplayabilirmi = true;
    }
}
