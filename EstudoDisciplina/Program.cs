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

            string format = "HH:mm";
            string dateString;

            DateTime horario;

            List<Disciplina> listaDisciplinas = new List<Disciplina>();

            Disciplina disciplina = null;
            Aluno aluno = null;
            Professor professor = null;

            Console.WriteLine("Seja bem vindo, vamos começar!");


            bool controle1 = true;
            bool controle2;

            while (controle1) {

                Console.WriteLine("Adicione uma disciplina:");
                Console.WriteLine("Qual o nome?");
                nomeDisciplina = Console.ReadLine();

                Console.WriteLine("Qual o horário?");
                dateString = Console.ReadLine();
                horario = DateTime.ParseExact(dateString, format, cultureInfo);

                disciplina = new Disciplina(nomeDisciplina, horario);

                professor = CriaProfessor(ID);

                disciplina.Professor = professor;
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

            ID++;

            return professor;
        }
    }
}
