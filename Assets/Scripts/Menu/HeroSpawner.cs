using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    public AllHerosSettings Heros;
    void Start()
    {
        CheckFirstEnter();

        string HeroName = PlayerProgres.GetSelectedHero();
        HeroParametres SelectedHero = Heros.AllHeros[0];
        for (int i = 0; i < Heros.AllHeros.Length; i++)
        {
            if (HeroName == Heros.AllHeros[i].Name)
            {
                SelectedHero = Heros.AllHeros[i];
            }
        }
        GameObject Hero = Instantiate(SelectedHero.MenuPrefab);
        Hero.transform.position = new Vector3(0, -0.5f, 0);
        Hero.transform.eulerAngles = new Vector3(0, 160, 0);
    }

    private void CheckFirstEnter()
    {
        if (PlayerProgres.GetSelectedHero() == "")
        {
            PlayerProgres.BuyHero(Heros.AllHeros[0].Name);
            PlayerProgres.SaveSelectedHero(Heros.AllHeros[0].Name);
        }
    }

    void Update()
    {
        
    }
}
