using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject ferstScreen;
    [SerializeField] private GameObject secondScreen;

    private GameObject currentScreen;

    private void Start()
    {
        ferstScreen.SetActive(true);
        currentScreen = ferstScreen;
    }

    public void ChangeState(GameObject state)
    {
        if (currentScreen != null)
        {
            currentScreen.SetActive(false);
            state.SetActive(true);
            currentScreen = state;
        }
    }
}
