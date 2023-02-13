using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProgBackEnd.Interfaces;

namespace ProgBackEnd.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        
        public string? cnpj {get; set;}

        public string? razaoSocial {get; set;}

        public override float CalcularImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento * 0.03f; //3%
            }
            else if (rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento * 0.05f; //5%
            }
            else if (rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento * 0.07f; //7%
            }
            else
            {
                return rendimento * 0.09f; //9%
            }

        }

        public bool ValidarCnpj(string cnpj)
        //xxxxxxxx0001xx
        //xx.xxx.xxx/0001-xx
        
        {
            bool retornoCnpjValido = Regex.IsMatch(cnpj,@"^(\d{14})|(\d}{2}.\d{3}.\d{3}.\d{4}-\{2})$");

            if (retornoCnpjValido)
            {
               string SubstringCnpj14 = cnpj.Substring(8, 4);
            
                if (SubstringCnpj14 == "0001")
                {
                    return true;
                }
            
            }

            string SubstringCnpj18 = cnpj.Substring(11, 4);

            if (SubstringCnpj18 == "0001")
            {
                return true;                
            }

            return false;

        }
    }
}