using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDisciplina.Entity {
    class Pessoa {

        public int ID { get; set; }

        public string Nome { get; set; }

        public List<Disciplina> listaDisciplinas { get; set; }

        // Construtor
        public Pessoa(int ID, string nome) {
            this.ID = ID;
            this.Nome = nome;
        }

        // Adiciona a disciplina na lista de disciplinas da pessoa
        public void AdicionaDisciplina(Disciplina disciplina) {

            listaDisciplinas.Add(disciplina);

            return;
        }

        // Lista as disciplinas que a pessoa faz parte
        public void ListaDisciplinas() {

            Console.WriteLine($"Disciplinas em que {Nome} está matriculado: \n");
            Console.WriteLine("---*---*---*---*---*---*---*---*---*---*");

            foreach (Disciplina disciplina in listaDisciplinas) {

                Console.WriteLine($"{disciplina.ID}: {disciplina.NomeDisciplina}");
            }

            Console.WriteLine("\n---*---*---*---*---*---*---*---*---*---*");

            return;
        }

    }

    class Aluno : Pessoa {

        public int RA { get; set; }

        // Construtor
        public Aluno(int ID, string nome, int RA) : base(ID, nome) {

            this.RA = RA;

        }
        
    }

    class Professor : Pessoa {
        public int RG { get; set; }

        // Construtor
        public Professor(int ID, string nome, int RG) : base (ID, nome) {

            this.RG = RG;
        }
    }
}
