using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.X86;

namespace Proj_CS_SQL
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Declaracoes
            string op = "-1";
            string msg = "";
            List<String> optionsList = new List<String>
            {
                "Modulo de Cadastro de Pessoa",
                "Modulo de Cadastro de Pet",
                "Modulo de Adocao",
                "Sair do Programa"
            };
            string[] options = new string[optionsList.Count];

            //Programa Principal
            options[optionsList.Count - 1] = "0";
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = (i + 1).ToString();
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********TELA INICIAL*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = ReadString("Opcao: ");
                if (!BuscarNoArray(op, options))
                {
                    msg = "Opcao invalida! Digite novamente...";
                    continue;
                }
                switch (op)
                {
                    case "1":
                        Modulo_CadastroPessoa();
                        msg = "";
                        break;
                    case "2":
                        Modulo_CadastroPet();
                        msg = "";
                        break;
                    case "3":
                        Modulo_Adocao();
                        msg = "";
                        break;
                    case "0":
                        msg = "";
                        break;
                }
            }

        }

        #region MODULOS
        public static void Modulo_CadastroPessoa()
        {
            //Declaracoes
            List<Pessoa> tabelaPessoa;
            string cpf;
            string op = "-1";
            string msg = "";
            int aux;
            List<String> optionsList = new List<String>
            {
                "Vizualizar Primeiros 10 Cadastros",
                "Cadastrar Nova Pessoa",
                "Editar Cadastro Existente",
                "Deletar Cadastro Existente",
                "Voltar"
            };
            string[] options = new string[optionsList.Count];

            //Corpo Funcao
            options[optionsList.Count - 1] = "0";
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = (i + 1).ToString();
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********MODULO DE CADASTRO DE PESSOAS*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = ReadString("Opcao: ");
                if (!BuscarNoArray(op, options))
                {
                    msg = "Opcao invalida! Digite novamente...";
                    continue;
                }
                switch (op)
                {
                    case "1":
                        msg = "\n";
                        try
                        {
                            tabelaPessoa = DataAcces.GetPessoa();
                        }
                        catch (Exception e)
                        {
                            msg += $"Error: {e.Message}\n";
                            break;
                        }
                        msg += "Nome;CPF;Sexo;DataDeNascimento;Endereco;Telefone\n";
                        aux = tabelaPessoa.Count;
                        if (aux > 10) aux = 10;
                        for (int i = 0; i < aux; i++)
                            msg += tabelaPessoa[i].ToString() + "\n";
                        break;
                    case "2":
                        try
                        {
                            tabelaPessoa = DataAcces.GetPessoa();
                        }
                        catch (Exception e)
                        {
                            msg += $"Error: {e.Message}\n";
                            break;
                        }
                        cpf = ReadString("Digite o CPF da pessoa: ");
                        if (Pessoa.BuscarPorCPF(tabelaPessoa, cpf))
                        {
                            msg = "Este CPF já consta na base de dados!";
                            break;
                        }
                        try
                        {
                            DataAcces.Pessoa_Insert
                            (
                                new Pessoa
                                (
                                    ReadString("Digite o nome da pessoa: "),
                                    cpf,
                                    Pessoa.ReadSexo("Digite o sexo da pessoa (M / F): "),
                                    ReadDateTime("Digite a data de nascimento da pessoa: "),
                                    ReadString("Digite o endereco da pessoa: "),
                                    Pessoa.ReadTelefone("Digite o novo telefone da pessoa (11 dígitos apenas, com DDD): ")
                                )
                            );
                        }
                        catch (Exception e)
                        {
                            msg += $"Error: {e.Message}\n";
                            break;
                        }
                        msg = "Inserção realizada com sucesso!";
                        break;
                    case "3":
                        tabelaPessoa = DataAcces.GetPessoa();
                        cpf = ReadString("Digite o CPF da pessoa que deseja editar na base de dados: ");
                        if (Pessoa.BuscarPorCPF(tabelaPessoa, cpf))
                        {
                            try
                            {
                                DataAcces.Pessoa_Update
                                (
                                    new Pessoa
                                    (
                                        ReadString("Digite o novo nome da pessoa: "),
                                        cpf,
                                        Pessoa.ReadSexo("Digite o novo sexo da pessoa (M / F): "),
                                        ReadDateTime("Digite a nova data de nascimento da pessoa: "),
                                        ReadString("Digite o novo endereco completo da pessoa: "),
                                        Pessoa.ReadTelefone("Digite o novo telefone da pessoa (11 dígitos apenas, com DDD): ")
                                    )
                                );
                            }
                            catch (Exception e)
                            {
                                msg += $"Error: {e.Message}\n";
                                break;
                            }
                            msg = "Edição realizada com sucesso";
                        }
                        else msg = "Este CPF não consta na base de dados!";
                        break;
                    case "4":
                        try
                        {
                            tabelaPessoa = DataAcces.GetPessoa();
                        }
                        catch (Exception e)
                        {
                            msg += $"Error: {e.Message}\n";
                            break;
                        }
                        cpf = ReadString("Digite o CPF da pessoa que deseja deletar da base de dados: ");
                        if (Pessoa.BuscarPorCPF(tabelaPessoa, cpf))
                        {
                            try
                            {
                                DataAcces.Pessoa_Delete(new Pessoa(cpf));
                            }
                            catch (Exception e)
                            {
                                msg += $"Error: {e.Message}\n";
                                break;
                            }
                            msg = "Remoção realizada com sucesso";
                        }
                        else msg = "Este CPF não consta na base de dados!";
                        break;
                    case "0":
                        msg = "";
                        break;
                }
            }
        }
        public static void Modulo_CadastroPet()
        {
            //Declaracoes
            List<Pet> tabelaPet;
            int chip;
            string op = "-1";
            string msg = "";
            int aux;
            List<String> optionsList = new List<String>
            {
                "Vizualizar Primeiros 10 Cadastros",
                "Cadastrar Novo Pet",
                "Editar Cadastro Existente",
                "Deletar Cadastro Existente",
                "Voltar"
            };
            string[] options = new string[optionsList.Count];

            //Corpo Funcao
            options[optionsList.Count - 1] = "0";
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = (i + 1).ToString();
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********MODULO DE CADASTRO DE PETS*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = ReadString("Opcao: ");
                if (!BuscarNoArray(op, options))
                {
                    msg = "Opcao invalida! Digite novamente...";
                    continue;
                }
                switch (op)
                {
                    case "1":
                        msg = "\n";
                        try
                        {
                            tabelaPet = DataAcces.GetPet();
                        }
                        catch (Exception e)
                        {
                            msg += $"Error: {e.Message}\n";
                            break;
                        }
                        msg += "Chip; Família; Raça; Sexo; Nome\n";
                        aux = tabelaPet.Count;
                        if (aux > 10) aux = 10;
                        for (int i = 0; i < aux; i++)
                            msg += tabelaPet[i].ToString() + "\n";
                        break;
                    case "2":
                        try
                        {
                            DataAcces.Pet_Insert
                            (
                                new Pet
                                (
                                    ReadString("Digite a família de animais da qual o pet pertence: "),
                                    ReadString("Digite a raça do pet: "),
                                    Pet.ReadSexo("Digite o sexo do pet (M / F): "),
                                    ReadString("Digite o nome do pet: ")
                                )
                            );
                        }
                        catch (Exception e)
                        {
                            msg += $"Error: {e.Message}\n";
                            break;
                        }
                        msg = "Inserção realizada com sucesso!";
                        break;
                    case "3":
                        tabelaPet = DataAcces.GetPet();
                        chip = ReadInt("Digite o Chip da pet que deseja editar na base de dados: ");
                        if (Pet.BuscarPorChip(tabelaPet, chip))
                        {
                            try
                            {
                                DataAcces.Pet_Update
                                (
                                    new Pet
                                    (
                                        chip,
                                        ReadString("Digite a nova família de animais da qual o pet pertence:  "),
                                        ReadString("Digite a nova raça do pet: "),
                                        Pet.ReadSexo("Digite o novo sexo do pet (M / F): "),
                                        ReadString("Digite o novo nome do pet: ")
                                    )
                                );
                            }
                            catch (Exception e)
                            {
                                msg += $"Error: {e.Message}\n";
                                break;
                            }
                            msg = "Edição realizada com sucesso";
                        }
                        else msg = "Este Chip não consta na base de dados!";
                        break;
                    case "4":
                        try
                        {
                            tabelaPet = DataAcces.GetPet();
                        }
                        catch (Exception e)
                        {
                            msg += $"Error: {e.Message}\n";
                            break;
                        }
                        chip = ReadInt("Digite o Chip do pet que deseja deletar da base de dados: ");
                        if (Pet.BuscarPorChip(tabelaPet, chip))
                        {
                            try
                            {
                                DataAcces.Pet_Delete(new Pet(chip));
                            }
                            catch (Exception e)
                            {
                                msg += $"Error: {e.Message}\n";
                                break;
                            }
                            msg = "Remoção realizada com sucesso";
                        }
                        else msg = "Este Chip não consta na base de dados!";
                        break;
                    case "0":
                        msg = "";
                        break;
                }
            }
        }
        public static void Modulo_Adocao()
        {
            //Declaracoes
            List<Pessoa> tabelaPessoa;
            List<Pet> tabelaPet;
            List<Pessoa_Pet> tabelaPessoa_Pet;
            int chip;
            string cpf;
            string op = "-1";
            string msg = "";
            int aux;
            List<String> optionsList = new List<String>
            {
                "Vizualizar Primeiros 10 Cadastros",
                "Cadastrar Nova Adoção",
                "Deletar Cadastro Existente",
                "Voltar"
            };
            string[] options = new string[optionsList.Count];

            //Corpo Funcao
            options[optionsList.Count - 1] = "0";
            for (int i = 0; i < optionsList.Count - 1; i++) options[i] = (i + 1).ToString();
            while (op != "0")
            {
                Console.Clear();
                Console.WriteLine("*********MODULO DE CADASTRO DE ADOÇÃO*********");
                for (int i = 0; i < optionsList.Count; i++) Console.WriteLine($"{options[i]}. {optionsList[i]}");
                Console.Write("\n{0}{1}{2}", msg == "" ? "" : ">>> ", msg, msg == "" ? "" : "\n");
                op = ReadString("Opcao: ");
                if (!BuscarNoArray(op, options))
                {
                    msg = "Opcao invalida! Digite novamente...";
                    continue;
                }
                switch (op)
                {
                    case "1":
                        msg = "\n";
                        try
                        {
                            tabelaPessoa_Pet = DataAcces.GetPessoa_Pet();
                        }
                        catch (Exception e)
                        {
                            msg += $"Error: {e.Message}\n";
                            break;
                        }
                        msg += "CPF Adotante;Nr Chip Pet Adotado\n";
                        aux = tabelaPessoa_Pet.Count;
                        if (aux > 10) aux = 10;
                        for (int i = 0; i < aux; i++)
                            msg += tabelaPessoa_Pet[i].ToString() + "\n";
                        break;
                    case "2":
                        try
                        {
                            tabelaPessoa = DataAcces.GetPessoa();
                            tabelaPet = DataAcces.GetPet();
                            tabelaPessoa_Pet = DataAcces.GetPessoa_Pet();
                        }
                        catch (Exception e)
                        {
                            msg += $"Error: {e.Message}\n";
                            break;
                        }
                        cpf = ReadString("Digite o CPF do adotante: ");
                        if (!Pessoa.BuscarPorCPF(tabelaPessoa, cpf))
                        {
                            msg = "Este CPF não consta na base de dados!";
                            break;
                        }
                        chip = ReadInt("Digite o número identificador (chip) do pet: ");
                        if (!Pet.BuscarPorChip(tabelaPet, chip))
                        {
                            msg = "Este Chip não consta na base de dados!";
                            break;
                        }
                        if (Pessoa_Pet.BuscarPorChip(tabelaPessoa_Pet, chip))
                        {
                            msg = "Este Chip já consta como adotado!";
                            break;
                        }
                        try
                        {
                            DataAcces.Pessoa_Pet_Insert(new Pessoa_Pet(cpf, chip));
                        }
                        catch (Exception e)
                        {
                            msg += $"Error: {e.Message}\n";
                            break;
                        }
                        msg = "Adoção realizada com sucesso!";
                        break;
                    case "3":
                        try
                        {
                            tabelaPessoa_Pet = DataAcces.GetPessoa_Pet();
                        }
                        catch (Exception e)
                        {
                            msg += $"Error: {e.Message}\n";
                            break;
                        }
                        chip = ReadInt("Digite o Chip do pet que deseja cancelar a adoção: ");
                        if (Pessoa_Pet.BuscarPorChip(tabelaPessoa_Pet, chip))
                        {
                            try
                            {
                                DataAcces.Pessoa_Pet_Delete(new Pessoa_Pet(chip));
                            }
                            catch (Exception e)
                            {
                                msg += $"Error: {e.Message}\n";
                                break;
                            }
                            msg = "Remoção realizada com sucesso";
                        }
                        else msg = "Este Chip não consta como adotado!";
                        break;
                    case "0":
                        msg = "";
                        break;
                }
            }
        }
        #endregion

        #region FUNCOES AUXILIARES
        public static string ReadString(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        public static int ReadInt(string text)
        {
            Console.Write(text);
            int i;
            while (!int.TryParse(Console.ReadLine(), out i))
                Console.Write("Digite um inteiro válido!\n{0}", text);
            return i;
        }
        public static char ReadChar(string text)
        {
            Console.Write(text);
            char c;
            while (!char.TryParse(Console.ReadLine(), out c))
                Console.Write("Digite um caractere válido!\n{0}", text);
            return c;
        }
        public static DateTime ReadDateTime(string text)
        {
            Console.Write(text);
            DateTime d;
            while (!DateTime.TryParse(Console.ReadLine(), out d))
                Console.Write("Digite uma data válida!\n{0}", text);
            return d;
        }
        public static bool BuscarNoArray(string c, string[] list)
        {
            for (int i = 0; i < list.Length; i++)
                if (list[i] == c) return true;
            return false;
        }
        #endregion
    }
}