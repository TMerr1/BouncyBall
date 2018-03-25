using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "SceneMaster")]
public class SceneMaster : ScriptableObject
{
    [SerializeField]
    private LevelMaster levelMaster;

    public int levelToLoadSM;

    public void LoadGameScene(int _level)
    {
        levelToLoadSM = _level;
        SceneManager.LoadScene(1);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
