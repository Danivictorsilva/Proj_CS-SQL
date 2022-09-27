using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_CS_SQL
{
    public class Pet
    {
        //Propriedades
        public int Chip { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }
        
        //Metodos
        public Pet(int chip)
        {
            Chip = chip;
        }
        public Pet(string familia, string raca, char sexo, string nome)
        {
            Familia = familia;
            Raca = raca;
            Sexo = sexo;
            Nome = nome;
        }
        public Pet(int chip, string familia, string raca, char sexo, string nome)
        {
            Chip = chip;
            Familia = familia;
            Raca = raca;
            Sexo = sexo;
            Nome = nome;
        }
        public override string ToString()
        {
            return String.Format("{{'{0:00000}';'{1}';'{2}';'{3}';'{4}'}}",
                Chip, Familia, Raca, Sexo, Nome);
        }
        public static bool BuscarPorChip(List<Pet> listaDePets, int chip)
        {
            foreach (Pet pet in listaDePets)
            {
                if (pet.Chip == chip) return true;
            }
            return false;
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

