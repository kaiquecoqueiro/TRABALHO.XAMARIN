using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  
namespace ChallengeMVVM.Models
{
    public class Aluno : INotifyPropertyChanged
    {
        public Guid Id { get; set; }

        private string _rm { get; set;}

        public string _nome { get; set; }

        public string _email { get; set; }

        public Aluno(string rm, string nome, string email)
        {
            this.RM = rm;
            this.Nome = nome;
            this.Email = email;
        }
        public Aluno()
        {

        }

        public string Nome

        {

            get { return _nome; }

            set { _nome = value; OnPropertyChanged(nameof(Nome)); }

        }

        public string RM

        {

            get { return _rm; }

            set { _rm = value; OnPropertyChanged(nameof(RM)); }

        }

        public string Email

        {

            get { return _email; }

            set { _email = value; OnPropertyChanged(nameof(Email)); }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
