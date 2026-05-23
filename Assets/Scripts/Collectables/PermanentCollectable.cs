public class PermanentCollectable : Collectable
{
    public override void Collect()
    {
        //change the players progression (idek hwo archipelago works yet)
        StartCoroutine(CollectAnimation());
        
    }

    public override void Setup()
    {
        //check if player has it or not.
        if(0 == 0)
        {
            
        } else
        {
            Destroy(this.gameObject);
        }
    }

    


}