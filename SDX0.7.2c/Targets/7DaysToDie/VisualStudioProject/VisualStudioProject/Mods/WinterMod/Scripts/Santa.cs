using System;
using System.Collections.Generic;
using UnityEngine;
using Audio;
// Extending HAL9000's Zombies Run In Dark mod by adding speed variation
public class BlockSantaVending : BlockVendingMachine
{

    public override void Init()
    {
        base.Init();
       
    }

    public override void OnBlockAdded(WorldBase world, Chunk _chunk, Vector3i _blockPos, BlockValue _blockValue)
    {
        
        Manager.BroadcastPlay("GoodSantaGreetingSounds");
        base.OnBlockAdded(world, _chunk, _blockPos, _blockValue);
    }

    public override bool OnBlockActivated(int _indexInBlockActivationCommands, WorldBase _world, int _cIdx, Vector3i _blockPos, BlockValue _blockValue, EntityAlive _player)
    {
        // Allows us to change which sounds to play, based on the the trader id. 98 is Badsanta whereas 99 is Good santa
        if (this.traderID == 98)
        {
            Manager.BroadcastPlay("GoodSantaSounds");
        }
        else
        {
            Manager.BroadcastPlay("GoodSantaSounds");
        }

        return base.OnBlockActivated(_indexInBlockActivationCommands, _world, _cIdx, _blockPos, _blockValue, _player);
    }

    public override bool OnBlockDestroyedBy(WorldBase _world, int _clrIdx, Vector3i _blockPos, BlockValue _blockValue, int _entityId, bool _bUseHarvestTool)
    {
        Manager.BroadcastPlay("GoodSantaByeSounds");
        return true;
    }

}
