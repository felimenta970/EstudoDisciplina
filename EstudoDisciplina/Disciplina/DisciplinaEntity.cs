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

        public Professor Professor { get; set; }

        public DateTime Horario { get; set; }


        public Disciplina (string nomeDisciplina, Professor professor, DateTime horario) {

            this.NomeDisciplina = nomeDisciplina;
            this.Horario = horario;
            this.Professor = professor;
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
