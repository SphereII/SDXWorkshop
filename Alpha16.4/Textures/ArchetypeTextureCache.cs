using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UMA
{
	// Token: 0x020001BA RID: 442
	public class ArchetypeTextureCache
	{
		// Token: 0x06000A74 RID: 2676 RVA: 0x00014808 File Offset: 0x00012A08
		public ArchetypeTextureCache()
		{
			ArchetypeTextureCache.Instance = this;
			if (Application.isEditor)
			{
				this.umaTextureDir = "Assets/Resources/UMA/BakedTextures";
				return;
			}
			this.umaTextureDir = Path.Combine(Application.dataPath, "..");
			this.umaTextureDir = Path.Combine(this.umaTextureDir, "Data");
			this.umaTextureDir = Path.Combine(this.umaTextureDir, "UMATextures");
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x000072B4 File Offset: 0x000054B4
		public bool HasTextureCache(string archetypeName)
		{
			return false;
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0001488C File Offset: 0x00012A8C
		public void AddTexturesToCache(string archetypeName, bool archetypeIsPlayer, Texture[] textures, int atlasIndex)
		{
			if (archetypeName != null && archetypeName != string.Empty && !archetypeIsPlayer)
			{
				if (this.LoadFromFile(archetypeName, archetypeIsPlayer, atlasIndex))
				{
					return;
				}
				if (!this.Cache.ContainsKey(archetypeName) || this.Cache[archetypeName] == null)
				{
					this.Cache[archetypeName] = new List<ArchetypeTextures>();
				}
				ArchetypeTextures archetypeTextures = default(ArchetypeTextures);
				archetypeTextures.Textures = new Texture2D[3];
				for (int i = 0; i < textures.Length; i++)
				{
					this.renderTexture = (textures[i] as RenderTexture);
					RenderTexture.active = this.renderTexture;
					archetypeTextures.Textures[i] = new Texture2D(this.renderTexture.width, this.renderTexture.height);
					archetypeTextures.Textures[i].ReadPixels(new Rect(0f, 0f, (float)this.renderTexture.width, (float)this.renderTexture.height), 0, 0, false);
					archetypeTextures.Textures[i].Apply(true);
					RenderTexture.active = null;
					this.renderTexture.Release();
				}
				this.Cache[archetypeName].Add(archetypeTextures);
				this.SaveToFile(archetypeName, archetypeIsPlayer, atlasIndex, archetypeTextures.Textures[0], archetypeTextures.Textures[1], archetypeTextures.Textures[2]);
			}
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x000149E0 File Offset: 0x00012BE0
		public bool LoadFromFile(string archetypeName, bool archetypeIsPlayer, int atlasIndex)
		{
			if (this.LoadFromResources(archetypeName, archetypeIsPlayer, atlasIndex))
			{
				return true;
			}
			string text = Path.Combine(this.umaTextureDir, archetypeName + "_" + atlasIndex.ToString() + "_d.png");
			string text2 = Path.Combine(this.umaTextureDir, archetypeName + "_" + atlasIndex.ToString() + "_s.png");
			string text3 = Path.Combine(this.umaTextureDir, archetypeName + "_" + atlasIndex.ToString() + "_n.png");
			if (!File.Exists(text) || !File.Exists(text2) || !File.Exists(text3))
			{
				Debug.Log("No  Texture exists. Generation Required for " + archetypeName);
				return false;
			}
			if (!this.Cache.ContainsKey(archetypeName) || this.Cache[archetypeName] == null)
			{
				Debug.Log("Initial Hit. No Cache Available for: " + archetypeName);
				this.Cache[archetypeName] = new List<ArchetypeTextures>();
			}
			else if (this.Cache[archetypeName].Count > 0)
			{
				Debug.Log("Cache Hit for UMA: " + archetypeName);
				return true;
			}
			ArchetypeTextures archetypeTextures = default(ArchetypeTextures);
			archetypeTextures.Textures = new Texture2D[3];
			byte[] data = this.LoadTexture(text);
			archetypeTextures.Textures[0] = new Texture2D(1, 1);
			archetypeTextures.Textures[0].LoadImage(data);
			archetypeTextures.Textures[0].Apply(true);
			data = this.LoadTexture(text2);
			archetypeTextures.Textures[1] = new Texture2D(1, 1);
			archetypeTextures.Textures[1].LoadImage(data);
			archetypeTextures.Textures[1].Apply(true);
			data = this.LoadTexture(text3);
			archetypeTextures.Textures[2] = new Texture2D(1, 1);
			archetypeTextures.Textures[2].LoadImage(data);
			archetypeTextures.Textures[2].Apply(true);
			this.Cache[archetypeName].Add(archetypeTextures);
			return true;
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x00014BBC File Offset: 0x00012DBC
		public bool LoadFromResources(string archetypeName, bool archetypeIsPlayer, int atlasIndex)
		{
			if (this.Cache.ContainsKey(archetypeName) && this.Cache[archetypeName].Count != 0)
			{
				return true;
			}
			this.Cache[archetypeName] = new List<ArchetypeTextures>();
			ArchetypeTextures archetypeTextures = new ArchetypeTextures
			{
				Textures = new Texture2D[3]
			};
			string path = Path.Combine("UMA/BakedTextures", archetypeName + "_" + atlasIndex.ToString() + "_d.png");
			string path2 = Path.Combine("UMA/BakedTextures", archetypeName + "_" + atlasIndex.ToString() + "_s.png");
			string path3 = Path.Combine("UMA/BakedTextures", archetypeName + "_" + atlasIndex.ToString() + "_n.png");
			archetypeTextures.Textures[0] = (Texture2D)Resources.Load(path);
			archetypeTextures.Textures[1] = (Texture2D)Resources.Load(path2);
			archetypeTextures.Textures[2] = (Texture2D)Resources.Load(path3);
			if (archetypeTextures.Textures[0] == null || archetypeTextures.Textures[1] == null || archetypeTextures.Textures[2] == null)
			{
				return false;
			}
			this.Cache[archetypeName].Add(archetypeTextures);
			return true;
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x00014CFC File Offset: 0x00012EFC
		public void SaveToFile(string archetypeName, bool archetypeIsPlayer, int atlasIndex, Texture2D diff, Texture2D spec, Texture2D nrm)
		{
			if (!Directory.Exists(this.umaTextureDir))
			{
				Directory.CreateDirectory(this.umaTextureDir);
			}
			string strFilename = Path.Combine(this.umaTextureDir, archetypeName + "_" + atlasIndex.ToString() + "_d.png");
			string strFilename2 = Path.Combine(this.umaTextureDir, archetypeName + "_" + atlasIndex.ToString() + "_s.png");
			string strFilename3 = Path.Combine(this.umaTextureDir, archetypeName + "_" + atlasIndex.ToString() + "_n.png");
			this.SaveTexture(strFilename, diff);
			this.SaveTexture(strFilename2, spec);
			this.SaveTexture(strFilename3, nrm);
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00014DA8 File Offset: 0x00012FA8
		public Texture[] GetTexturesFromCache(string archetypeName, bool archetypeIsPlayer, int atlasIndex)
		{
			if (archetypeName == null || archetypeName == string.Empty)
			{
				return null;
			}
			if (!this.Cache.ContainsKey(archetypeName) || this.Cache[archetypeName] == null)
			{
				return null;
			}
			if (atlasIndex >= this.Cache[archetypeName].Count)
			{
				return null;
			}
			return new Texture[]
			{
				this.Cache[archetypeName][atlasIndex].Textures[0],
				this.Cache[archetypeName][atlasIndex].Textures[1],
				this.Cache[archetypeName][atlasIndex].Textures[2]
			};
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x00014E58 File Offset: 0x00013058
		public void SaveTexture(string strFilename, Texture2D texture)
		{
			if (File.Exists(strFilename))
			{
				return;
			}
			using (FileStream fileStream = File.Create(strFilename))
			{
				byte[] array = texture.EncodeToPNG();
				fileStream.Write(array, 0, array.Length);
			}
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x00014EA4 File Offset: 0x000130A4
		public byte[] LoadTexture(string strFileName)
		{
			byte[] result;
			using (FileStream fileStream = File.Open(strFileName, FileMode.Open))
			{
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, (int)fileStream.Length);
				result = array;
			}
			return result;
		}

		// Token: 0x04000929 RID: 2345
		public static ArchetypeTextureCache Instance;

		// Token: 0x0400092A RID: 2346
		private Dictionary<string, List<ArchetypeTextures>> Cache = new Dictionary<string, List<ArchetypeTextures>>();

		// Token: 0x0400092B RID: 2347
		private string umaTextureDir = "";

		// Token: 0x0400092C RID: 2348
		private RenderTexture renderTexture;
	}
}
