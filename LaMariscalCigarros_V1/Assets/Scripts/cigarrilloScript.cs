using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cigarrilloScript : MonoBehaviour
{

    //controla las mecanicas del juego
    public GameObject cigarrette;
    public GameObject scoreText;
    public GameObject livesText;
    public GameObject altura;
    public int scoreNumber;
    public int livesNumber = 3;
    public float fallingSpeed = 0.1f;
    public int genValue = 1;
    private static cigarrilloScript instance;
    public GameOverScreen GameOverScreen;
    public Animator animator;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

  
    // Start is called before the first frame update
    void Start()
    {
        //Initialize the GUI components
        livesText.GetComponentInChildren<Text>().text = "Vidas: " + livesNumber;
        scoreText.GetComponentInChildren<Text>().text = "Puntaje: " + scoreNumber;

        
        Invoke("GenerateCigarrette", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        //game over
        if(livesNumber == 0)
        {
       
            GameOver();
        }
    }

    void GameOver()
    {
        altura = null;
        GameOverScreen.Setup(scoreNumber);
    }

    void GenerateCigarrette()
    {

        // Create a new instance of the prefab at a random position
        Instantiate(cigarrette, GeneratePosition(), Quaternion.identity);
        fallingSpeed = Random.Range(0.1f, 0.7f);

        // Set a new random interval for the next object generation
        Invoke("GenerateCigarrette", Random.Range(0.5f, 2));

    }

    //Increments points per cigarrette destroyed
    public void AumentarPuntaje()
    {
        scoreNumber++;
        scoreText.GetComponentInChildren<Text>().text = "Puntaje: " + scoreNumber;
    }

    //decreases life based on hits taken by the tree
    public void DisminuirVida()
    {
        if(livesNumber > 0)
        {
            animator.Play("arbolHerido");
            livesNumber--;
            livesText.GetComponentInChildren<Text>().text = "Vidas: " + livesNumber;

        }
    }



    //Generates random position for cigarette object
    Vector2 GeneratePosition()
    {
        // Generate a random position within a desired range
        Vector2 randomPosition = new Vector2(
            Random.Range(-4.9f, 4.9f),
            altura.transform.position.y
        );

        return randomPosition;
    }


    public static cigarrilloScript Instance
    {
        get { return instance; }
    }


}
