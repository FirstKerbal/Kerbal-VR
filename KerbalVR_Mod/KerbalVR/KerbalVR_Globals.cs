using System.IO;
using System.Reflection;

namespace KerbalVR
{
    /// <summary>
    /// A class to contain globally accessible constants.
    /// </summary>
    public class Globals
    {
        // plugin name
        public static readonly string KERBALVR_NAME = "KerbalVR";


        // path to asset bundles
        public static readonly string KERBALVR_ASSETBUNDLES_DIR = Path.Combine(KERBALVR_NAME, "AssetBundles");

        // path to textures
        public static readonly string KERBALVR_TEXTURES_DIR = Path.Combine(KERBALVR_NAME, "Textures");

        // define location of OpenVR library
        public static string EXTERNAL_DLL_PATH = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "lib");

        // a prefix to append to every KerbalVR debug log message
        public static readonly string LOG_PREFIX = "[" + KERBALVR_NAME + "] ";
    }
}
