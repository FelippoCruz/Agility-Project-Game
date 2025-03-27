using UnityEngine;

//NÃO PRECISA MEXER NESSE SCRIPT, É SÓ IA NA PASTA DE PREFABS E PEGAR O PREFAB QUE EU CRIEI
public class MovingObstacle : Obstacle
{
        [SerializeField] private Transform position1;
        [SerializeField] private Transform position2;
        [SerializeField] private float moveSpeed;
        [SerializeField] private int waitTime;
        private float elapsedTime;
        private bool canMove = true;
        private bool canSwitch = false;
    
        private void Update()
        {
            if (CheckCanMove() == false) return;
    
            CheckAndHandleMovement();
    
            CheckAndHandleReachedPosition();
            
        }
        
        //Verifica se o obstáculo pode se mover, se não puder, inicia a contagem do tempo para poder mover novamente
        private bool CheckCanMove()
        {
            if (canMove == false)
            {
                TimeCount();
                return false;
            }
    
            return true;
        }
        
        
        //Responsável por movimentar o obstáculo
        private void CheckAndHandleMovement()
        {
            if (canSwitch == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, 
                    position2.position, 
                    moveSpeed * Time.deltaTime);
            }
            else if (canSwitch == true)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    position1.position,
                    moveSpeed * Time.deltaTime);
            }
        }
        
        //Verifica se o obstáculo chegou as posições ou não
        private void CheckAndHandleReachedPosition()
        {
            if(transform.position == position1.position)
            {
                canMove = false;
                canSwitch = false;
            }
            else if(transform.position == position2.position)
            {
                canMove = false;
                canSwitch = true;
            }
        }
    
        //Realiza a contagem do tempo
        private void TimeCount()
        {
            elapsedTime += Time.deltaTime;
    
            if(elapsedTime >= waitTime)
            {
                canMove = true;
                elapsedTime = 0;
            }
        }
}
