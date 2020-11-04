using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneCD
{
    class CD
    {
        private string _autore;
        private string _nome;
        private List<Brano> _listaBrani;

        public CD(string nome, string autore, List<Brano> listaBrani)
        {
            SetAutore(autore);
            SetNome(nome);
            _listaBrani = listaBrani;
        }

        public string GetAutore()
        {
            return _autore;
        }

        public string GetNome()
        {
            return _nome;
        }

        public List<Brano> GetListaBrani()
        {
            return _listaBrani;
        }

        public void SetNome(string nome)
        {
            _nome = nome;
        }

        public void SetAutore(string autore)
        {
            _autore = autore;
        }

        public override string ToString()
        {
            string line = "";
            for (int i = 0; i < GetListaBrani().Count; i++)
            {
                line += GetListaBrani()[i].ToString();
                if (i != GetListaBrani().Count - 1)
                {
                    line += "/";
                }
            }
            return line;
        }

        public int Durata()
        {
            int durata = 0;
            for (int i = 0; i < GetListaBrani().Count; i++)
            {
                durata += GetListaBrani()[i].GetDurata();
            }
            return durata;
        }
    }
}
