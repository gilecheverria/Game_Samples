/*
Generic script to control the health of a game character

Gilberto Echeverria
2023-03-19
*/

using UnityEngine;

public enum LifeState {alive, dead};

public class AgentHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;

    int currentHealth;
    LifeState status;

    ColorBlink blinker;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        status = LifeState.alive;
        blinker = GetComponent<ColorBlink>();
    }

    public void TakeDamage(int amount)
    {
        if(currentHealth > 0) {
            currentHealth -= amount;
            blinker.Blink();
        }

        if(currentHealth <= 0) {
            status = LifeState.dead;
            Destroy(gameObject);
        }
    }
}