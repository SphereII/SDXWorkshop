using System;
using UnityEngine;

// Custom SnowFill class that makes snow act like plants, for the purpose of snow to disappear in low-light situations.
public class EntitySeal : EntityAnimal
{

    
    public override void Init(int _entityClass)
    {
        base.Init(_entityClass);
    
    }

    public override void OnEntityDeath()
    {
        if (this.entityThatKilledMe is global::EntityPlayerLocal)
        {
            ((global::EntityPlayer)this.entityThatKilledMe).PlayerJournal.AddJournalEntry("harvestTip", null, true, false);
        }
        base.OnEntityDeath();
        
        int randomFromGroup = EntityGroups.GetRandomFromGroup("Nightmares");
        Entity newEntity = EntityFactory.CreateEntity(randomFromGroup, this.position);
        world.GetAIDirector().World.SpawnEntityInWorld(newEntity);
    }
  


}
