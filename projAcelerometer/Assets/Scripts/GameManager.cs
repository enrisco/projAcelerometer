using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GameManager : MonoBehaviour
{
    public bool Won = false;
    public bool Lost = false;
    public int NextScene;
    [SerializeField] GameObject End;
    [SerializeField] GameObject txtCongratulations;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch input = Input.GetTouch(0);
            if (input.phase == TouchPhase.Began)
            {
                if (Lost) SceneHelper.ChangeScene(SceneHelper.ReturnSceneIndex());
                if (Won) SceneHelper.ChangeScene(NextScene);
            }

        }
    }

    public void Win()
    {
        Won = true;
        End.SetActive(true);
    }

    public void Lose()
    {
        Lost = true;
        TextManager.SetText(txtCongratulations, "PERDEU");
        End.SetActive(true);
    }
}
