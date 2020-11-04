using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneCD
{
    class Brano
    {
        //ATTRIBUTI
        private string _nome;
        private string _autore;
        private int _durata;

        //COSTRUTTORE
        public Brano(string nome, string autore, int durata) ///LA DURATA è IN SECONDI
        {
            try
            {
                SetNome(nome);
                SetAutore(autore);
                SetDurata(durata);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetNome()
        {
            return _nome;
        }

        public string GetAutore()
        {
            return _autore;
        }

        public int GetDurata()
        {
            return _durata;
        }

        public void SetNome(string nome)
        {
            _nome = nome;
        }

        public void SetAutore(string autore)
        {
            _autore = autore;
        }

        public void SetDurata(int durata)
        {
            if (durata <= 0)
                throw new Exception("Durata sotto lo 0");
            _durata = durata;
        }

        public override string ToString()
        {
            return GetNome() + ", di " + GetAutore() + ", durata: " + GetDurata() + "sec";
        }

        public bool shortSong(int durata)
        {
            if (GetDurata() >= durata)
            {
                return false;
            }
            return true;
        }
    }
}
