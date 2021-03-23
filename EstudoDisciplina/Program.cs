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
            
            // Adicionado comentário para testes

            // Variável para auxilio na definição do recebimento de horário
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;

            // Strings de nome
            string nomeDisciplina;

            // Inteiros de controle
            int ID = 1;
            string codigo = "";

            // Strings usadas para receber horario
            string format = "HH:mm";
            string dateString;

            DateTime horario;

            // Lista de disciplinas
            List<Disciplina> listaDisciplinas = new List<Disciplina>();

            // Inicializa as variáveis de aluno, disciplina e professor
            Disciplina disciplina = null;
            Aluno aluno = null;
            Professor professor = null;

            // Variáveis booleanas de controle
            bool controle1 = true;
            bool controle2 = true;
            bool controle3 = true;

            Console.WriteLine("Seja bem vindo, vamos começar!");


            Console.WriteLine("Adicione uma disciplina:");

            while (controle1) {

                Console.WriteLine("Qual o nome?");
                nomeDisciplina = Console.ReadLine();

                while (controle3) {

                    Console.WriteLine("Qual o código?");
                    codigo = Console.ReadLine();

                    // Caso não tenha outra disciplina com o mesmo código
                    if (!VerificaDisciplinaExistente(codigo, listaDisciplinas)) {

                        // Insere o código
                        disciplina.Codigo = codigo;
                        controle3 = false;

                    // Caso exista duplicado
                    } else {

                        Console.WriteLine("Disciplina com esse código já existente, entre com um novo código");
                    }
                }


                Console.WriteLine("Qual o horário?");
                dateString = Console.ReadLine();

                // Realiza o parsing para formato de DateTime
                horario = DateTime.ParseExact(dateString, format, cultureInfo);

                // Constroi a disciplina com os valores definidos
                disciplina = new Disciplina(ID, codigo, nomeDisciplina, horario);

                // Incremenda a ID
                ID++;

                // Cria o professor e incremenda a ID
                professor = CriaProfessor(ID);
                ID++;

                // Coloca na disciplina, o nome do professor
                disciplina.Professor = professor;

                // Adiciona alunos na disciplina
                while(controle2) {

                    Console.WriteLine("Vamos adicionar alunos à essa disciplina! Dê enter para continuar, ou digite '0' para parar de adicionar alunos");

                    // Se digitar 0, para
                    if (Console.ReadLine() == "0") {
                        controle2 = false;
                        
                    
                    } else {

                        // Adiciona o aluno, e incrementa o ID
                        aluno = AdicionaAluno(ID, disciplina);
                        ID++;

                        // Adiciona o aluno na disciplina
                        disciplina.AdicionaAluno(aluno);
                    }

                }

                // Adiciona a disciplina na lista de disciplinas
                listaDisciplinas.Add(disciplina);

                // Booleana de controle 2 para uso subsequente
                controle2 = true;
            }



        }

        // Cria professor
        // Recebe um ID
        static public Professor CriaProfessor(int ID) {

            // Variaveis para receber valores
            string nomeProfessor;
            int RG;

            Console.WriteLine("Vamos adicionar um professor para essa disciplina! Qual o seu nome?");
            nomeProfessor = Console.ReadLine();

            Console.WriteLine("Qual o RG?");
            // Parse para Int do RG
            Int32.TryParse(Console.ReadLine(), out RG);

            // Cria um novo professor com os valores obtidos
            Professor professor = new Professor(ID, nomeProfessor, RG);

            return professor;
        }

        // Adiciona alunos
        static public Aluno AdicionaAluno(int ID, Disciplina disciplina) {

            string nomeAluno;
            int RA;
            bool control = true;

            Aluno aluno = null;

            Console.WriteLine("Qual o nome do aluno?");
            nomeAluno = Console.ReadLine();

            // Um while para receber um RA que não seja repetido
            while (control) {

                Console.WriteLine("Qual o RA?");
                // Parse para inteiro
                Int32.TryParse(Console.ReadLine(), out RA);

                // Se o RA não estiver matriculado já na disciplina
                if (!VerificaMatriculaDisciplina(RA, disciplina)) {
                    aluno = new Aluno(ID, nomeAluno, RA);
                    control = false;

                } else {
                    Console.WriteLine("RA já matriculado, digite um novo RA");

                }
            }            

            return aluno;
        }

        // Verificação de matricula na disciplina
        // Recebe o RA e a disciplina
        static public bool VerificaMatriculaDisciplina(int RA, Disciplina disciplina) {

            // Verifica se na lista de alunos matriculados da disciplina, já existe um aluno com aquele RA
            bool estaMatriculado = disciplina.alunosMatriculados.Exists(p => p.RA == RA);

            return estaMatriculado;
        }

        // Verificação de existencia de disciplina com o mesmo código
        // Recebe o codigo e a lista de disciplinas
        static public bool VerificaDisciplinaExistente (string codigo, List<Disciplina> listaDisciplinas) {

            // Verifica se uma disciplinacom o mesmo código existe
            bool disciplinaExiste = listaDisciplinas.Exists(p => p.Codigo == codigo);

            return disciplinaExiste;
        }
    }
}
