using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialHardCalclator
{

  public  class Element
    {
        static Microsoft.JScript.Vsa.VsaEngine vsa = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
        public string Name;
        public string[] Values;
        public string ComputeDanseiMomentStr;
        public double ComputeDanseiMoment((string Name, double value)[] inputs)
        {
            var func = ComputeDanseiMomentStr;
            foreach(var x in inputs)
            func= func.Replace(x.Name, x.value.ToString());
          
   
            return 
                (double)Microsoft.JScript.Eval.JScriptEvaluate(
                    func, vsa);
        }

        public string Computex((string Name, string value)[] inputs)
        {
            var func = ComputeDanseiMomentStr;
            foreach (var x in inputs)
                func = func.Replace(x.Name, x.value.ToString());


            return
               func.ToString();
        }

    }

    public static class Elements
    {
        static void Init()
        {
            string strs = File.ReadAllText(FilePath, Encoding.GetEncoding("sjis"));
            elements = Newtonsoft.Json.JsonConvert.DeserializeObject<Element[]>(strs);
            IsInited = true;
        }
        static readonly string FilePath = "Elements.Json";
        static bool IsInited = false;
        static Element[] elements = null;
        static public Element[] GetElements()
        {
            if (!IsInited) Init();
            return elements.Skip(1).ToArray();
        }
    }
}
