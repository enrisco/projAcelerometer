using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

class SceneHelper
{
    public static void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static int ReturnSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
