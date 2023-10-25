using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Platform;
    public GameObject[] Paneller;
    public TextMeshProUGUI[] ScoreText;
    public TextMeshProUGUI[] HighScoreText;
    public int Sayac = 1;
    public bool OyunDevamEdiyor;
    public AudioSource OyunMusic;
    public Camera _Camera;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("HighScore", 0);
        }
        OyunDevamEdiyor = true;
        HighScoreText[0].text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();

    }
    private void Update()
    {
        if (OyunDevamEdiyor)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    Platform.transform.Rotate(0, .8f, 0);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    Platform.transform.Rotate(0, -.8f, 0);
                }
            }
        }

    }
    public void YenidenYerles(Vector3 Pos, GameObject Obje)
    {

        float Sayi = Random.Range(0, 359);
        Obje.transform.position = new Vector3(0, Pos.y - 17.5f, 0);
        Obje.transform.rotation = Quaternion.Euler(0, Sayi, 0);
        int Sayi1 = Random.Range(0, 5);
        int Sayi2 = Random.Range(0, 5);
        var Obje1Clone = Obje.transform.GetChild(Sayi1).rotation;
        Obje.transform.GetChild(Sayi1).rotation = Obje.transform.GetChild(Sayi2).rotation;
        Obje.transform.GetChild(Sayi2).rotation = Obje1Clone;
        
    }
    public void YenidenYerlesBlock(Vector3 Pos, GameObject Obje)
    {
        Obje.transform.position = new Vector3(0, Pos.y - 22.5f, 0);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
