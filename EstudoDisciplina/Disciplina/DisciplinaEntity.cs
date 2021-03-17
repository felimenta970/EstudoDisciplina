using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDisciplina.Entity {
    class Disciplina {

        public int ID { get; set; }

        public string NomeDisciplina { get; set; }

        public List<Aluno> alunosMatriculados { get; set; }

        public DateTime horario { get; set; }


        public Disciplina (string nomeDisciplina) {
            this.NomeDisciplina = nomeDisciplina;
        }


        public void AdicionaAluno(Aluno aluno) {

            alunosMatriculados.Add(aluno);

            return;
        }

        public void ListaAlunos() {

            Console.WriteLine($"Alunos matriculados em {NomeDisciplina}: \n");
            Console.WriteLine("---*---*---*---*---*---*---*---*---*---*");

            foreach (Aluno aluno in alunosMatriculados) {

                Console.WriteLine($"{aluno.ID}: {aluno.Nome}");
            }

            Console.WriteLine("\n---*---*---*---*---*---*---*---*---*---*");

            return;
        }
    }
}
