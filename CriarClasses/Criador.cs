using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriarClasses
{
    class Criador
    {
        private string cla;
        private string pro;
        private string end;
        private string[] str;

        public void setCla(string _cla) { cla = _cla; }
        public void setPro(string _pro) { pro = _pro; }
        public string getCla() { return cla; }
        public string getPro() { return pro; }

        public void criarCla()
        {
            end = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter sr = new StreamWriter(Path.Combine(end, cla + ".txt"));
            sr.WriteLine("class " + cla);
            sr.WriteLine("{");
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i].Length > 0)
                sr.WriteLine("private string " + str[i].ToLower() + ";");
            }
            sr.WriteLine("");
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Length > 0)
                    sr.WriteLine("public void set" + str[i] + "(string _" + str[i].ToLower() + ") { " + str[i].ToLower() + " = _" + str[i].ToLower() + "; }");
            }
            sr.WriteLine("");
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Length > 0)
                    sr.WriteLine("public string get" + str[i] + "() { return " + str[i].ToLower() + "; }" );
            }
            sr.WriteLine("}");
            sr.Close();
        }

        public void prepararPro()
        {
            str = pro.Split('\r');
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i].Replace("\n", "");
                str[i] = CriadorBLL.ajustarLinhas(str[i]);
                str[i] = CriadorBLL.removerCaracteresEspeciais(str[i]);
                str[i] = CriadorBLL.removerAcentos(str[i]);
            }
        }
    }
}
