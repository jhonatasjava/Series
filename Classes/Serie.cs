using System;
namespace Series
{
    public class Serie : EntidadeBase
    {
        Genero genero {get; set;}

        private string titulo {get; set;}

        private string descricao {get; set;}

        private int ano {get; set;}

        private bool excluido {get; set;}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
            
        }
        
        public string retornaTitulo()
        {
            return this.titulo;
        }

        public int retornaId()
        {
            return this.id;
        }

        public void excluir()
        {
            this.excluido = true;
        }

        public bool retornaExcluido()
        {
            return this.excluido;
        }
        
        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero : " + this.genero + Environment.NewLine;
            retorno += "Titulo : " + this.titulo + Environment.NewLine;
            retorno += "Descricao : " + this.descricao + Environment.NewLine;
            retorno += "Ano : " + this.ano;
            return retorno;
        }
    }
}