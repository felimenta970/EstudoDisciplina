using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDisciplina.Entity {
    class Aluno {

        public int ID { get; set; }

        public string Nome { get; set; }

        public  List<Disciplina> listaDisciplinas { get; set; }

        public Aluno(string nome) {
            this.Nome = nome;
        }
    }
}
