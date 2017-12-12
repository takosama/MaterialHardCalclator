using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialHardCalclator
{
    class Function
    {
     public   string[] Values;
     public   string Name;
     public   string Func;
        static Microsoft.JScript.Vsa.VsaEngine vsa = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
        public double ComputeHizumi((string Name, double value)[] inputs,double danseiniji,Material material)
        {
            var func = Func;
            foreach (var x in inputs)
                func = func.Replace(x.Name, x.value.ToString());
            func = func.Replace("Young", ((double)material.Young * 1000000000.0).ToString());
            func = func.Replace("Inertia", danseiniji.ToString());


            return
                (double)Microsoft.JScript.Eval.JScriptEvaluate(
                    func, vsa);
        }
        public string Computex((string Name, string value)[] inputs, string danseiniji, Material material,double tawami)
        {
            var func = Func;
            foreach (var x in inputs)
                func = func.Replace(x.Name, x.value.ToString());
            func = func.Replace("Young", ((double)material.Young * 1000000000.0).ToString());
            func = func.Replace("Inertia", danseiniji.ToString());
            func += "-たわみ";
            func = func.Replace("たわみ",tawami.ToString());
            func += "=0";
            return func;
        }
    }

    static class Functions
    {
   static     Function[] functions;
       static bool isInited = false;
      static  void Init()
        {
            functions = Newtonsoft.Json.JsonConvert.DeserializeObject<Function[]>(File.ReadAllText("Functions.Json",Encoding.GetEncoding("sjis")));
        }

  public static     Function [] GetFunctions()
        {
            if (!isInited) Init();
            return functions;
        }
    }
}
