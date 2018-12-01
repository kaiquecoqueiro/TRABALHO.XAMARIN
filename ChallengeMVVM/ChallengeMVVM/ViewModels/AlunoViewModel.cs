using ChallengeMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChallengeMVVM.ViewModels
{
    public class AlunoViewModel : INotifyPropertyChanged
    {




        public AlunoViewModel()
        {

            this.CurrentAluno = new Models.Aluno();
        }


        public ICommand SalvarCommand { get; set; }

        //public Guid Id { get; set; }

        //public string RM { get; set; }

        //public string Nome { get; set; }

        //public string Email { get; set; }


        private ObservableCollection<Aluno> _alunos;

        public ObservableCollection<Aluno> Alunos
        {
            get
            {
                return _alunos;
            }
            set
            {
                _alunos = value;
                OnPropertyChanged(nameof(Alunos));
            }
        }



        public void AddAluno()
        {
            _alunos.Add(CurrentAluno);
        }

        private Aluno _currentAluno;


        public Aluno CurrentAluno
        {
            get { return _currentAluno; }
            set { _currentAluno = value; OnPropertyChanged(nameof(CurrentAluno)); }
        }



        public Command SalvarAlunoCommand
        {
            get
            {
                return new Xamarin.Forms.Command(() =>
                {


                    if (Alunos == null)
                    {
                        Alunos = new ObservableCollection<Aluno>
                        {
                            CurrentAluno
                        };
                    }
                    else
                    {
                        // var aluno = Alunos.FirstOrDefault(a => a.Id.Equals(CurrentAluno.Id));

                        Alunos.Add(CurrentAluno);
                        //}
                        //else
                        //{
                        //    aluno.Nome = CurrentAluno.Nome;
                        //    aluno.Email = CurrentAluno.Email;
                        //    aluno.RM = CurrentAluno.RM;
                        //}
                    }
                    App.Current.MainPage.Navigation.PopAsync();



                });
            }
        }

        public Command AbrirTelaNovoAlunoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                      
                        NovoAlunoView novoAlunoView = new NovoAlunoView() { BindingContext = this };
                        var nav = Application.Current.MainPage.Navigation;
                        await nav.PushAsync(novoAlunoView);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                });


            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}
