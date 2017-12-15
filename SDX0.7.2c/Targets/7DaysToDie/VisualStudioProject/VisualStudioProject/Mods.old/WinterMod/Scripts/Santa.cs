using System;
using System.Collections.Generic;
using UnityEngine;
using Audio;
// Extending HAL9000's Zombies Run In Dark mod by adding speed variation
public class BlockSantaVending : BlockVendingMachine
{
    private float nextCheck = 0;
    public static float CheckDelay = 100f;

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

    public override bool UpdateTick(WorldBase _world, int _clrIdx, Vector3i _blockPos, BlockValue _blockValue, bool _bRandomTick, ulong _ticksIfLoaded, System.Random _rnd)
    {
        base.UpdateTick( _world,  _clrIdx,  _blockPos,  _blockValue,  _bRandomTick,  _ticksIfLoaded, _rnd);

        if (nextCheck < Time.time)
        {
            nextCheck = Time.time + CheckDelay;
            Vector3i v = new Vector3i(this.position);
            if (v.x < 0) v.x -= 1;
            if (v.z < 0) v.z -= 1;
            lightLevel = GameManager.Instance.World.ChunkClusters[0].GetLight(v, Chunk.LIGHT_TYPE.SUN);
        }
        return false;
    }
}
