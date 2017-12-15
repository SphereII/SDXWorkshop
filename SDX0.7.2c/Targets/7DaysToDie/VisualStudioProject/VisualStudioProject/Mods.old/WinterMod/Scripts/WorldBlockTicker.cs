using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using A;
public class NewWorldBlockTicker : WorldBlockTicker
{
    //// Token: 0x04002D95 RID: 11669
    //private object KZ = new object();

    //// Token: 0x04002D96 RID: 11670
    //private SortedList ZZ = new SortedList(new WorldBlockTicker.CL());

    //// Token: 0x04002D97 RID: 11671
    private Dictionary<int, WorldBlockTickerEntry> WZ = new Dictionary<int, WorldBlockTickerEntry>();

    //// Token: 0x04002D98 RID: 11672
    //private DictionarySave<long, HashSet<WorldBlockTickerEntry>> QZ = new DictionarySave<long, HashSet<WorldBlockTickerEntry>>();

    //// Token: 0x04002D99 RID: 11673
    //private int GZ;

    //// Token: 0x04002D9A RID: 11674
    private World HZ;

    //// Token: 0x04002D9B RID: 11675
    //private int LZ;

    //// Token: 0x04002D9C RID: 11676
    //private int RZ;

    //// Token: 0x04002D9D RID: 11677
    //private List<long> TZ = new List<long>();


    // Token: 0x06003C31 RID: 15409 RVA: 0x0024141C File Offset: 0x0023F61C
    public NewWorldBlockTicker(World _world) : base( _world )
    {
    }

    public void BlockTickerPatch(Chunk chunk, Random rnd)
    {
        //if (chunk == null)
        //{
        //    return;
        //}
        //if (chunk.NeedsLightCalculation)
        //{
        //    return;
        //}
        //if (GameTimer.Instance.ticks - chunk.LastTimeRandomTicked < 1200UL)
        //{
        //    return;
        //}
        //ulong ticksIfLoaded = GameTimer.Instance.ticks - chunk.LastTimeRandomTicked;
        //chunk.LastTimeRandomTicked = GameTimer.Instance.ticks;
        //DictionaryKeyList<Vector3i, int> tickedBlocks = chunk.GetTickedBlocks();
        //DictionaryKeyList<Vector3i, int> obj = tickedBlocks;
        //lock (obj)
        //{
        //    for (int i = tickedBlocks.list.Count - 1; i >= 0; i--)
        //    {
        //        try
        //        {
        //            Vector3i vector3i2 = tickedBlocks.list[i];
        //            Vector3i vector3i = tickedBlocks.list[i];
        //            BlockValue block = chunk.GetBlock(World.toBlockXZ(vector3i.x), vector3i.y, World.toBlockXZ(vector3i.z));
        //            if (this.WZ.Count == 0 || !this.WZ.ContainsKey(WorldBlockTickerEntry.ToHashCode(chunk.ClrIdx, vector3i, block.type)))
        //            {
        //                Block.list[block.type].UpdateTick(this.HZ, chunk.ClrIdx, vector3i, block, true, ticksIfLoaded, rnd);
        //            }
        //        }
        //        catch (ArgumentOutOfRangeException)
        //        {
        //        }
        //    }
      //  }
    }
}
