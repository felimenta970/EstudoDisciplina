using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoDisciplina.Entity {
    class Disciplina {

        public int ID { get; set; }

        public string NomeDisciplina { get; set; }

        public List<AlunoMatriculado> alunosMatriculados { get; set; }

        public DateTime horario { get; set; }


        public Disciplina (string nomeDisciplina) {
            this.NomeDisciplina = nomeDisciplina;
        }



    }
}
