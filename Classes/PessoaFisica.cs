using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgBackEnd.Interfaces;

namespace ProgBackEnd.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        
        public string? cpf{get; set;}

        public string? dataNasc{get; set;}

        public override float CalcularImposto(float rendimento)
        {

            if (rendimento <= 1500)
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                float resultado = (rendimento / 100) * 2;
                return resultado;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                float resultado = (rendimento / 100) * 3.5f;
                return resultado;
            }
            else
            {
                float resultado = (rendimento / 100) * 5;
                return resultado;
            }


            
        }

        public bool ValidarDataNasc(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;
            double anos = (dataAtual - dataNasc).TotalDays / 365;

            //Console.WriteLine(anos);
            
            if (anos >= 18)
            {
                return true;
            }
            return false;
        }

        public bool ValidarDataNasc(string dataNasc)
        {

            if(DateTime.TryParse( dataNasc, out DateTime dataConvertida ))
            {
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays / 365;

                Console.WriteLine(anos);
            
                if (anos >= 18)
                {
                    return true;
                }
            }   

            return false;
        }
    }
}
