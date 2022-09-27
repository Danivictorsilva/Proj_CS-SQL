using System;
using System.Collections.Generic;

namespace Proj_CS_SQL
{
    public class Pessoa
    {
        //Propriedades
        public string Nome { get; set; }
        public string CPF { get; set; }
        public char Sexo { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        //Metodos
        public Pessoa(string cPF)
        {
            CPF = cPF;
        }
        public Pessoa(string nome, string cPF, char sexo, DateTime dataDeNascimento, string endereco, string telefone)
        {
            Nome = nome;
            CPF = cPF;
            Sexo = sexo;
            DataDeNascimento = dataDeNascimento;
            Endereco = endereco;
            Telefone = telefone;
        }
        public override string ToString()
        {
            return String.Format("{{'{0}';'{1}';'{2}';'{3}';'{4}';'{5}'}}",
                Nome, CPF, Sexo, DataDeNascimento.ToShortDateString(), Endereco, Telefone);
        }
        public static bool BuscarPorCPF(List<Pessoa> listaDePessoas, string cPF)
        {
            foreach (Pessoa pessoa in listaDePessoas)
            {
                if (pessoa.CPF == cPF) return true;
            }
            return false;
        }
        public static string ReadCPF(string text)
        {
            string cpfString;
            long cpfLong;
            int digVerificador, v1, v2, aux;
            int[] digitosCPF = new int[9];
            bool digitosIguais = false;

            do
            {
                Console.Write(text);
                cpfString = Console.ReadLine();
                while (!long.TryParse(cpfString, out cpfLong))
                {
                    Console.Write("Digite um CPF válido!\n{0}", text);
                    cpfString = Console.ReadLine();
                }
                digVerificador = (int)(cpfLong % 100);
                cpfLong /= 100;
                for (int i = 0; i < 9; i++)
                {
                    aux = (int)cpfLong % 10;
                    digitosCPF[i] = aux;
                    cpfLong /= 10;
                }
                digitosIguais = false;
                for (int i = 0; i < digitosCPF.Length; i++)
                {
                    if (i == digitosCPF.Length - 1)
                    {
                        Console.WriteLine("O CPF não segue as regras de validação da Receita Federal!");
                        digitosIguais = true;
                        break;
                    }
                    if (digitosCPF[i] != digitosCPF[i + 1]) break;
                }
                if (digitosIguais) continue;
                v1 = v2 = 0;
                for (int i = 0; i < 9; i++)
                {
                    v1 += digitosCPF[i] * (9 - i);
                    v2 += digitosCPF[i] * (8 - i);
                }
                v1 = (v1 % 11) % 10;
                v2 += v1 * 9;
                v2 = (v2 % 11) % 10;
                if (v1 * 10 + v2 == digVerificador) return cpfString;
                else Console.WriteLine("O CPF não segue as regras de validação da Receita Federal!");
            } while (true);
        }
        public static string ReadTelefone(string text)
        {
            string TelString;
            long TelLong;
            Console.Write(text);
            TelString = Console.ReadLine();
            while (!long.TryParse(TelString, out TelLong))
            {
                Console.Write("Digite um Telefone válido!\n{0}", text);
                TelString = Console.ReadLine();
            }
            while (TelString.Length != 11)
            {
                Console.Write("Digite um Telefone válido!\n{0}", text);
                TelString = Console.ReadLine();
            }
            return TelString;
        }
        public static char ReadSexo(string text)
        {
            char s = Char.ToUpper(Program.ReadChar(text));
            while (s != 'M' && s != 'F')
            {
                Console.WriteLine("Entrada inválida! Digite novamente...");
                s = Char.ToUpper(Program.ReadChar(text));
            }
            return s;
        }
    }
}
