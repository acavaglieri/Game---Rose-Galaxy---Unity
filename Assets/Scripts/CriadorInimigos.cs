using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriadorInimigos : MonoBehaviour
{
    // Variaveis
    public GameObject[] asteroides, navesInimigas;

    // Funções
    private void Start()
    {
        InvokeRepeating("CriarInimigo", 2f, 1f);
    }
    private void CriarInimigo()
    {
        // Chance de criar asteroide = 70%
        float chance = Random.Range(0, 100f);
        if (chance < 70)
        {
            // Criar asteroide!!!
            int indexEscolhido = Random.Range(0, 3); // Escolhe aleatoriamente entre os 3 asteroides disponiveis!!!
            Instantiate
                (
                    asteroides[indexEscolhido],                         // O nome do objeto
                    new Vector3(20f, 0f, Random.Range(-5.5f, 5.5f)),        // A posição no mundo do objeto
                    asteroides[indexEscolhido].transform.rotation       // A rotação no mundo do objeto
                );
        }
        else
        {
            // Criar nave!!!
            int indexEscolhido = Random.Range(0, 5); // Escolhe aleatoriamente entre os 3 asteroides disponiveis!!!
            Instantiate
                (
                    navesInimigas[indexEscolhido],                         // O nome do objeto
                    new Vector3(20f, 0f, Random.Range(-5.5f, 5.5f)),           // A posição no mundo do objeto
                    navesInimigas[indexEscolhido].transform.rotation       // A rotação no mundo do objeto
                );
        }
    }
}
