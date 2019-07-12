using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CriarClasses
{
    class CriadorBLL
    {
        public static void validaDados(Criador corrigir)
        {
            Erro.setErro(false);
            if (corrigir.getCla().Length == 0)
            {
                Erro.setErro("O campo Nome da Classe é obrigatorio!");
                return;
            }
            if(corrigir.getPro().Length == 0)
            {
                Erro.setErro("O campo Nome das Propriedades é obrigatorio!");
                return;
            }
        }

        public static string removerCaracteresEspeciais(string valor)
        {
            Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(valor, String.Empty);
        }

        public static string removerAcentos(string valor)
        {
            valor = Regex.Replace(valor, "[ÁÀÂÃ]", "A");
            valor = Regex.Replace(valor, "[ÉÈÊ]", "E");
            valor = Regex.Replace(valor, "[Í]", "I");
            valor = Regex.Replace(valor, "[ÓÒÔÕ]", "O");
            valor = Regex.Replace(valor, "[ÚÙÛÜ]", "U");
            valor = Regex.Replace(valor, "[Ç]", "C");
            valor = Regex.Replace(valor, "[áàâã]", "a");
            valor = Regex.Replace(valor, "[éèê]", "e");
            valor = Regex.Replace(valor, "[í]", "i");
            valor = Regex.Replace(valor, "[óòôõ]", "o");
            valor = Regex.Replace(valor, "[úùûü]", "u");
            valor = Regex.Replace(valor, "[ç]", "c");
            valor = Regex.Replace(valor, "[ ]", "");
            return valor;
        }

        public static string ajustarLinhas(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
