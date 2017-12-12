using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaterialHardCalclator
{
  public  class Material
    {
        public double Young = 0;
        public double Density = 0;
        public string Name = "";
    }

  public  static class Materials
    {
        static void Init()
        {
            string strs = File.ReadAllText(FilePath,Encoding.GetEncoding("sjis"));
            materials = Newtonsoft.Json.JsonConvert.DeserializeObject<Material[]>(strs);
            IsInited = true;
        }
        static readonly string FilePath = "Materials.Json";
        static bool IsInited = false;
        static Material[] materials = null;
        static public Material[] GetMaterials()
        {
            if (!IsInited) Init();
            return materials;
        }
    }
}
