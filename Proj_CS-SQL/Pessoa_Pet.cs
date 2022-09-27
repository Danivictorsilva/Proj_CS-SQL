using System;
using System.Collections.Generic;

namespace Proj_CS_SQL
{
    public class Pessoa_Pet
    {
        //Propriedades
        public string CPF { get; set; }
        public int Chip { get; set; }

        //Metodos
        public Pessoa_Pet(int chip)
        {
            Chip = chip;
        }
        public Pessoa_Pet(string cPF, int chip)
        {
            CPF = cPF;
            Chip = chip;
        }
        public override string ToString()
        {
            return String.Format("{{'{0}';'{1}'}}",
                CPF, Chip);
        }
        public static bool BuscarPorChip(List<Pessoa_Pet> listaDePessoa_Pets, int chip)
        {
            foreach (Pessoa_Pet pessoa_pet in listaDePessoa_Pets)
            {
                if (pessoa_pet.Chip == chip) return true;
            }
            return false;
        }
    }
}
