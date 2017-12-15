//using System;
//using UnityEngine;

//// Custom SnowFill class that makes snow act like plants, for the purpose of snow to disappear in low-light situations.
//public class KittenSpawner : Block
//{

   
//    public override void Init()
//    {
//        base.Init();
 
//    }


//    public override void OnBlockAdded(WorldBase world, Chunk _chunk, Vector3i _blockPos, BlockValue _blockValue)
//    {
//        int randomFromGroup =EntityGroups.GetRandomFromGroup("Nightmares");
//        Entity newEntity = EntityFactory.CreateEntity(randomFromGroup, new Vector3(0f, UnityEngine.Random.value * 360f, 0f)); 
//        _chunk.AddEntityToChunk(newEntity);
            
            
//    }


//    /*
//     * 
//     * 				if (blockValue.type == 0 && num9 >= num10)
//				{
//					sbyte density2 = MarchingCubes.DensityTerrain;
//					_chunk.SetDensity(x, num10, z, density2);
//					long texture2 = this.GetTexture(i + num2, k, j + num6);
//					_chunk.SetTextureFull(x, num10, z, texture2);
//					_chunk.SetBlock(_world, x, num10, z, Block.GetBlockValue("snowFill"));
//				}
//                */



//}
