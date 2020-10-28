using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneCD
{
    class ClassBrano
    {
        //ATTRIBUTI
        string _titolo, _autore;
        int _durata; //in secondi

        //COSTRUTTORE
        public ClassBrano (string title, string autor, int time)
        {
            _titolo = title;
            _autore = autor;
            _durata = time;
        }

        public string Titolo
        {
            get { return _titolo; }
            set { _titolo = value; }
        }
        public string Autore
        {
            get { return _autore; }
            set { _autore = value; }
        }
        public int Durata
        {
            get { return _durata; }
            set { _durata = value; }
        }
    }
}
