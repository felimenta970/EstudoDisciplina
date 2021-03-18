using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDisciplina.Entity {
    class Disciplina {

        public int ID { get; set; }

        public string Codigo { get; set; }

        public string NomeDisciplina { get; set; }

        public List<Aluno> alunosMatriculados { get; set; }

        public Professor Professor { get; set; }

        public DateTime Horario { get; set; }


        public Disciplina (int ID, string codigo, string nomeDisciplina, DateTime horario) {

            alunosMatriculados = new List<Aluno>();
            this.Codigo = codigo;
            this.ID = ID;
            this.NomeDisciplina = nomeDisciplina;
            this.Horario = horario;
        }

        // Adiciona o aluno na lista de alunos matriculados
        public void AdicionaAluno(Aluno aluno) {

            alunosMatriculados.Add(aluno);

            return;
        }


        // Lista todos os alunos matriculados na disciplina
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
