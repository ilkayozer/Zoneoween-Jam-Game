using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySceneController : MonoBehaviour
{
    private TextManager TextManager;
    private PlayerStatus PlayerStats;
    private CharSelect Spawner;
    private DoorMovement DoorManager;

    // Start is called before the first frame update
    void Start()
    {
        DoorManager = FindAnyObjectByType<DoorMovement>();
        Spawner = FindAnyObjectByType<CharSelect>();
        TextManager = FindAnyObjectByType<TextManager>();
        PlayerStats = FindAnyObjectByType<PlayerStatus>();

        StartCoroutine(Routine());
        Spawner.SelectRandomChar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Routine()
    {
        yield return new WaitForSeconds(1f);
        DoorManager.Open();
        yield return new WaitForSeconds(2f);

        TextManager.ShowNextDialog();
        yield return new WaitForSeconds(TextManager.GetTypeingTime(2));
        while (!(PlayerStats.isDenied || PlayerStats.isLetIn))
        {
            yield return new WaitForSeconds(1f); // Tuþ basýlana kadar bekliyor (ÇALIÞIYO)
        }
        if(PlayerStats.isDenied)
        {
            StartCoroutine(DenyOption());
        } else if(PlayerStats.isLetIn)
        {
            StartCoroutine(LetInOption());
        }
    }
    private IEnumerator DenyOption()
    {
        DoorManager.Close();
        //1 kat yukarý gidicek her türlü, yanlýþsa asansör kapýlarý kapalý durucak ve quicktime a giricek, doðruysa yarra.
        yield return new WaitForSeconds(1f); //placeholder to code to work, return gerekiyor

    }

    private IEnumerator LetInOption()
    {
        //içeri gircek, doðruysa üstte inicek (baþka sequence a), yanlýþ ise eleman yok olucak ve quick time event olucak.
        yield return new WaitForSeconds(1f); //placeholder to code to work, return gerekiyor
    }

    private IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}
