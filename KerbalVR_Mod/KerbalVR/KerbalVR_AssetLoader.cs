using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KerbalVR
{
	/// <summary>
	/// Manage KerbalVR's asset bundles.
	/// </summary>
	[KSPAddon(KSPAddon.Startup.Instantly, true)]
	public class AssetLoader : MonoBehaviour
	{
		#region Constants
		/// <summary>
		/// List of AssetBundle file paths to load.
		/// </summary>
		public static string[] KERBALVR_ASSET_BUNDLE_PATHS
		{
			get
			{
				string kvrAssetBundlesPath = Path.Combine(KSPUtil.ApplicationRootPath, "GameData", Globals.KERBALVR_ASSETBUNDLES_DIR);

				string[] assetBundlePaths = {
					Path.Combine(kvrAssetBundlesPath, "kerbalvr.dat"),
					Path.Combine(kvrAssetBundlesPath, "kerbalvr_ui.dat"),
					Path.Combine(kvrAssetBundlesPath, "kerbalvr_font.dat"),
				};
				return assetBundlePaths;
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Set to true when all asset bundles have been loaded.
		/// </summary>
		public static bool IsReady { get; private set; } = false;
		#endregion

		#region Private Members
		protected Dictionary<string, GameObject> gameObjectsDictionary = new Dictionary<string, GameObject>();
		protected Dictionary<string, Shader> shadersDictionary = new Dictionary<string, Shader>();
		protected Dictionary<string, Font> fontsDictionary = new Dictionary<string, Font>();
		protected Dictionary<string, TMP_FontAsset> tmpFontsDictionary = new Dictionary<string, TMP_FontAsset>();
		#endregion

		#region Singleton
		/// <summary>
		/// This is a singleton class, and there must be exactly one GameObject with this Component in the scene.
		/// </summary>
		public static AssetLoader Instance { get; private set; }

		void Start()
		{
			Instance = this;
		}

		public void ModuleManagerPostLoad()
		{
			Initialize();
		}

		/// <summary>
		/// One-time initialization for this singleton class.
		/// </summary>
		protected void Initialize()
		{

			// load KerbalVR asset bundles
			LoadAssets();

			// load TextMeshPro fonts
			tmpFontsDictionary.Add("Futura_Medium_BT", KerbalVR.Fonts.TMPFont_Futura_Medium_BT_SDF.GetInstance());
			tmpFontsDictionary.Add("SpaceMono_Regular", KerbalVR.Fonts.TMPFont_SpaceMono_Regular_SDF.GetInstance());

			IsReady = true;
		}
		#endregion

		/// <summary>
		/// Load game assets from asset bundles.
		/// </summary>
		protected void LoadAssets()
		{
			// load asset bundles
			foreach (var path in KERBALVR_ASSET_BUNDLE_PATHS)
			{
				AssetBundle bundle = AssetBundle.LoadFromFile(path);
				if (bundle == null)
				{
					Utils.LogError("Error loading asset bundle from: " + path);
				}
				else
				{
					// enumerate assets
					string[] assetNames = bundle.GetAllAssetNames();
					for (int i = 0; i < assetNames.Length; i++)
					{
						string assetName = assetNames[i];
#if DEBUG
						Utils.Log("Bundle: " + bundle.name + ", Asset: " + assetName);
#endif

						// find prefabs
						if (assetName.EndsWith(".prefab"))
						{
							GameObject assetGameObject = bundle.LoadAsset<GameObject>(assetName);
							gameObjectsDictionary.Add(assetGameObject.name, assetGameObject);
							Utils.Log("Loaded GameObject \"" + assetGameObject.name + "\" from \"" + assetName + "\"");
						}
						else if (assetName.EndsWith(".shader"))
						{
							Shader assetShader = bundle.LoadAsset<Shader>(assetName);
							shadersDictionary.Add(assetShader.name, assetShader);
							Utils.Log("Loaded Shader \"" + assetShader.name + "\" from \"" + assetName + "\"");
						}
						else if (assetName.EndsWith(".ttf"))
						{
							Font assetFont = bundle.LoadAsset<Font>(assetName);
							fontsDictionary.Add(assetFont.name, assetFont);
							Utils.Log("Loaded Font \"" + assetFont.name + "\" from \"" + assetName + "\"");
						}
					}
				}
			}
		}

		/// <summary>
		/// Get a GameObject asset that was loaded from an asset bundle.
		/// </summary>
		/// <param name="gameObjectName">Name of the GameObject</param>
		/// <returns>The GameObject, or null if not found</returns>
		public GameObject GetGameObject(string gameObjectName)
		{
			if (gameObjectsDictionary.TryGetValue(gameObjectName, out GameObject obj))
			{
				return obj;
			}
			return null;
		}


		/// <summary>
		/// Get a Shader asset that was loaded from an asset bundle.
		/// </summary>
		/// <param name="shaderName">Name of the Shader</param>
		/// <returns>The Shader, or null if not found</returns>
		public Shader GetShader(string shaderName)
		{
			if (shadersDictionary.TryGetValue(shaderName, out Shader shader))
			{
				return shader;
			}
			return null;
		}


		/// <summary>
		/// Get a Font asset that was loaded from an asset bundle.
		/// </summary>
		/// <param name="fontName">Name of the Font</param>
		/// <returns>The Font, or null if not found</returns>
		public Font GetFont(string fontName)
		{
			if (fontsDictionary.TryGetValue(fontName, out Font font))
			{
				return font;
			}
			return null;
		}


		/// <summary>
		/// Get a TMP_FontAsset.
		/// </summary>
		/// <param name="fontName">Name of the font</param>
		/// <returns>The TMP_FontAsset, or null if not found</returns>
		public TMP_FontAsset GetTmpFont(string fontName)
		{
			if (tmpFontsDictionary.TryGetValue(fontName, out TMP_FontAsset font))
			{
				return font;
			}
			return null;
		}
	}
}
