using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstudoDisciplina.Entity;
using System.Globalization;

namespace EstudoDisciplina {
    class Program {

        static void Main(string[] args) {

            CultureInfo cultureInfo = CultureInfo.InvariantCulture;

            string nomeAluno;
            string nomeProfessor;
            string nomeDisciplina;

            int ID = 1;
            string codigo = "";

            string format = "HH:mm";
            string dateString;

            DateTime horario;

            List<Disciplina> listaDisciplinas = new List<Disciplina>();

            Disciplina disciplina = null;
            Aluno aluno = null;
            Professor professor = null;

            Console.WriteLine("Seja bem vindo, vamos começar!");


            bool controle1 = true;
            bool controle2 = true;
            bool controle3 = true;

            Console.WriteLine("Adicione uma disciplina:");

            while (controle1) {

                
                Console.WriteLine("Qual o nome?");
                nomeDisciplina = Console.ReadLine();

                

                while (controle3) {

                    Console.WriteLine("Qual o código?");
                    codigo = Console.ReadLine();

                    if (!VerificaDisciplinaExistente(codigo, listaDisciplinas)) {
                        controle3 = false;

                    } else {

                        Console.WriteLine("Disciplina com esse código já existente, entre com um novo código");
                    }
                }



                Console.WriteLine("Qual o horário?");
                dateString = Console.ReadLine();
                horario = DateTime.ParseExact(dateString, format, cultureInfo);

                disciplina = new Disciplina(ID, codigo, nomeDisciplina, horario);


                ID++;

                professor = CriaProfessor(ID);
                ID++;

                disciplina.Professor = professor;

                while(controle2) {

                    Console.WriteLine("Vamos adicionar alunos à essa disciplina! Dê enter para continuar, ou digite '0' para parar de adicionar alunos");

                    if (Console.ReadLine() == "0") {
                        controle2 = false;
                        
                    } else {
                        aluno = AdicionaAluno(ID, disciplina);
                        ID++;

                        disciplina.AdicionaAluno(aluno);
                    }

                }

                listaDisciplinas.Add(disciplina);

                controle2 = true;
            }



        }

        static public Professor CriaProfessor(int ID) {

            string nomeProfessor;
            int RG;

            Console.WriteLine("Vamos adicionar um professor para essa disciplina! Qual o seu nome?");
            nomeProfessor = Console.ReadLine();

            Console.WriteLine("Qual o RG?");
            Int32.TryParse(Console.ReadLine(), out RG);

            Professor professor = new Professor(ID, nomeProfessor, RG);

            return professor;
        }

        static public Aluno AdicionaAluno(int ID, Disciplina disciplina) {

            string nomeAluno;
            int RA;
            bool control = true;

            Aluno aluno = null;

            Console.WriteLine("Qual o nome do aluno?");
            nomeAluno = Console.ReadLine();

            while (control) {

                Console.WriteLine("Qual o RA?");
                Int32.TryParse(Console.ReadLine(), out RA);

                if (!VerificaMatriculaDisciplina(RA, disciplina)) {
                    aluno = new Aluno(ID, nomeAluno, RA);
                    control = false;

                } else {
                    Console.WriteLine("RA já matriculado, digite um novo RA");

                }
            }            

            return aluno;
        }

        static public bool VerificaMatriculaDisciplina(int RA, Disciplina disciplina) {

            // Verifica se na lista de alunos matriculados da disciplina, já existe um aluno com aquele RA
            bool estaMatriculado = disciplina.alunosMatriculados.Any(p => p.RA == RA);

            return estaMatriculado;
        }



        static public bool VerificaDisciplinaExistente (string codigo, List<Disciplina> listaDisciplinas) {


            bool disciplinaExiste = listaDisciplinas.Any(p => p.codigo == codigo);

            return disciplinaExiste;
        }
    }
}
