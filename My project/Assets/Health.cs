using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Animator animator;
    public Slider HealthSlider;
    public Gradient gradient;
    public Image fill;
   
    public Text textElement;
   
    // Start is called before the first frame update
    public int maxHealth = 100;
    public int CurrentHealth; 

    void Start()
    {

        CurrentHealth = maxHealth;
        HealthSlider.maxValue = maxHealth;
        HealthSlider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
       
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        HealthSlider.value = CurrentHealth;
        animator.SetTrigger("Hurt");
        fill.color = gradient.Evaluate(HealthSlider.normalizedValue);
        Debug.Log("health" + CurrentHealth);
        

        if (CurrentHealth <= 0)
        {
            HealthSlider.value = 0;
            if (transform.root.name == "Player 1")
            {
                textElement.text = "Player 2 Won";
            }
            if (transform.root.name == "Player 2")
            {
                textElement.text = "Player 1 Won";
            }
            GetComponent<Collider2D>().enabled = false;
            Debug.Log(transform.root.name);
            this.enabled = false;
            StartCoroutine(Die());

        }
        


    }



    // Update is called once per frame
    void Update()
    {

        
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}
