# 🎮 Prototype-Game

![Prototype-Game](https://user-images.githubusercontent.com/62818241/201542077-c8cde7eb-47e2-4cfd-8e35-9d61e21192fa.png)

## 📌 Introduction
**Prototype-Game** is a simple level-based game where players progress through multiple stages. The game features smooth scene transitions, player movement, collision detection, and a scoring system. The mechanics include level progression, restart functionality, and game-over handling.

## 🔥 Features
- 🎯 **Level Progression**: Players move through multiple levels upon completion.
- 🚪 **Scene Management**: Smooth transitions between levels.
- 🕹️ **Player Controls**: Move left and right using arrow keys.
- ⚔️ **Obstacle Collision**: If the player collides with an obstacle, the game restarts.
- 🎵 **Sound Effects**: Audio feedback for interactions.
- 📊 **Score Tracking**: Displays score based on player movement.
- ⏳ **Game Over Handling**: Restarts the game when falling off the platform.

---

## 🏗️ How It Works

The game consists of different levels, and the player advances upon reaching specific checkpoints. Collision with obstacles or falling off the map triggers a restart.

### 📌 **Level Management**

Each level has a script to transition to the next scene after a delay.

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_1_UI : MonoBehaviour
{
    private float x;
    void Update()
    {
        x += Time.deltaTime;
        if(x > 3f)
        {
            SceneManager.LoadScene("Level_2");
        }   
    }
}
```

Similarly, **Level_2_UI** and **Complete_Level** scripts manage transitions between other levels and the main menu.

---

### 📌 **Player Movement**

This script controls player movement and detects if the player falls below a certain point to trigger game over.

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float forwardforces = 1000f;
    public float sideways = 500f;
    public Rigidbody rb;

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardforces * Time.deltaTime);

        if(Input.GetKey("right"))
        {
            rb.AddForce( sideways * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKey("left"))
        {
            rb.AddForce(-sideways * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f)
        {
            SceneManager.LoadScene("Game_Over");
        }
    }
}
```

---

### 📌 **Collision Detection**

If the player collides with an obstacle, the game resets.

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public Player movement;
    public GameManager gameManager;

    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            SceneManager.LoadScene("Game_Over");
        }
    }
}
```

---

### 📌 **Score System**

Tracks the player's progress and updates the score based on movement.

```csharp
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    void Update()
    {
        scoreText.text = player.position.z.ToString("0");        
    }
}
```

---

### 📌 **Game Management**

Handles level completion and game restarts.

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamehasEnded = false;
    public float RestartDelay = 1f;
    public GameObject CompleteLevelUI;

    public void CompleteLevel()
    {
        CompleteLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if(gamehasEnded == false)
        {
            gamehasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart",RestartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
```

---

## 🎯 Conclusion

**Prototype-Game** is a simple but effective demonstration of level-based progression, player movement, and scene transitions. It provides a foundation for developing more complex platformer or runner-style games. 🚀🔥

