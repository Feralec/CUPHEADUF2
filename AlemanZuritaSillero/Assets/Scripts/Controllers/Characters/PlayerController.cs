using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float horizontalSpeed = 5f, jumpImpulse=7f,jumpingHorizontalLimiter = 0.5f,shootExitTime=0.3f;
    public PlayerModel pm;
    public CharacterStates currentState;

    public Transform shotRight, shotLeft; //creo que está bien que esto esté aquí, ya que lo puede usar directamente en el prefab

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new GroundedState(this));
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Execute();
    }
    private void FixedUpdate()
    {
        currentState.FixedExecute();
    }
    public void ChangeState(CharacterStates newState)
    {
        if (newState != null)
        {
            if (currentState != null)
                currentState.OnFinish();
            currentState = newState;
            currentState.OnStart();
        }
    }

    private void LateUpdate()
    {
        currentState.CheckTransitions();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.intoTrigger(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        currentState.outOfTrigger(collision);
    }
}
