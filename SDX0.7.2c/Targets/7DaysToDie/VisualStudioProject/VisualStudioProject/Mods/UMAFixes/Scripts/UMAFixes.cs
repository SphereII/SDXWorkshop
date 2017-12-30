// Decompiled with JetBrains decompiler
// Type: GameObjectAnimalAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B66E2A5-B854-4FE4-983E-8D0DC9B247E0
// Assembly location: C:\Games\Steam\steamapps\common\7 Days To Die SDX\7DaysToDie_Data\Managed\Assembly-CSharp.dll
// Compiler-generated code is shown
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UMA;
    public class UMAFixes 
    {
        String umaTextureDir = "Assets/Resources/UMA/BakedTextures";
        private Dictionary<string, List<ArchetypeTextures>> Cache = new Dictionary<string, List<ArchetypeTextures>>();

    // Token: 0x0200019E RID: 414
    public struct ArchetypeTextures
    {
        // Token: 0x0400090B RID: 2315
        public Texture2D[] Textures;
    }
    public bool LoadFromFile(string archetypeName, bool archetypeIsPlayer, int atlasIndex)
        {
            // Different Texture Atlases
            String strTextureD = this.umaTextureDir + "/" + archetypeName + "_" + atlasIndex.ToString() + "_d.png";
            String strTextureS = this.umaTextureDir + "/" + archetypeName + "_" + atlasIndex.ToString() + "_s.png";
            String strTextureN = this.umaTextureDir + "/" + archetypeName + "_" + atlasIndex.ToString() + "_n.png";

            // If they don't exists, then don't bother trying to load them up.
            if (!File.Exists(strTextureD) || !File.Exists(strTextureS) || !File.Exists(strTextureN))
                return false;

            if (!this.Cache.ContainsKey(archetypeName) || this.Cache[archetypeName] == null)
            {
                this.Cache[archetypeName] = new List<ArchetypeTextures>();
            }
            else if (this.Cache[archetypeName].Count > 0)
            {
                return true;
            }

            ArchetypeTextures item = default(ArchetypeTextures);
            item.Textures = new Texture2D[3];
       
            // Generate the D texture
            byte[] array = GenerateTexture(strTextureD);
            item.Textures[0] = new Texture2D(1, 1);
            item.Textures[0].LoadImage(array);
            item.Textures[0].Compress(true);

            array = GenerateTexture(strTextureS);
            item.Textures[1] = new Texture2D(1, 1);
            item.Textures[1].LoadImage(array);
            item.Textures[1].Compress(true);


            array = GenerateTexture(strTextureN);
            item.Textures[2] = new Texture2D(1, 1);
            item.Textures[2].LoadImage(array);
            item.Textures[2].Compress(true);

            this.Cache[archetypeName].Add(item);
            return true;
        }

    public byte[] GenerateTexture(String strFileName)
    {
        using (FileStream fileStream = File.Open(strFileName, FileMode.Open))
        {

            byte[] array = new byte[fileStream.Length];
            fileStream.Read(array, 0, (int)fileStream.Length);
            return array;
        }

    }
}

