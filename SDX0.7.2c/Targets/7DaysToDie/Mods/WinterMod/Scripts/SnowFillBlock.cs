using System;
using UnityEngine;

// Custom SnowFill class that makes snow act like plants, for the purpose of snow to disappear in low-light situations.
public class BlockSnowFill : BlockPlant
{

    // Stores when to do the next light check and what the current light level is
    // Determines if they run or not.
    private float nextCheck = 0;
    byte lightLevel;

    // Globa value for the light threshold in which zombies run in the dark
    public static byte LightThreshold = 10;

    // Frequency of check to determine the light level.
    public static float CheckDelay = 1f;

    public new int lightLevelStay = 10;

    public int Counter = 0;
    public override void Init()
    {
        base.Init();
      //  this.IsRandomlyTick = false;
        if (this.Properties.Values.ContainsKey("LightLevelStay"))
        {
            int.TryParse(this.Properties.Values["LightLevelStay"], out this.lightLevelStay);
        }
    }
    //Vector3i blockPos = new Vector3i(num2, num, num3);

    public override bool CanPlantStay(WorldBase _world, int _clrIdx, Vector3i _blockPos, BlockValue _blockValue)
    {
        return _world.GetBlockLightValue(_clrIdx, _blockPos) >= this.lightLevelStay; 
    }

    // Token: 0x06000044 RID: 68
    public override bool CheckPlantAlive(WorldBase _world, int _clrIdx, Vector3i _blockPos, BlockValue _blockValue)
    {
        // Check, but only 1 out of 3 times.
        if (!this.CanPlantStay(_world, _clrIdx, _blockPos, _blockValue)  )
        {
            _world.SetBlockRPC(_clrIdx, _blockPos, BlockValue.Air);
           
        }

        return true;
    }

    /*
     * 
     * 				if (blockValue.type == 0 && num9 >= num10)
				{
					sbyte density2 = MarchingCubes.DensityTerrain;
					_chunk.SetDensity(x, num10, z, density2);
					long texture2 = this.GetTexture(i + num2, k, j + num6);
					_chunk.SetTextureFull(x, num10, z, texture2);
					_chunk.SetBlock(_world, x, num10, z, Block.GetBlockValue("snowFill"));
				}
                */



}
