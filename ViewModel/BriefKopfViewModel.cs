using AnschreibenCreator.Lib.Models;
using AnschreibenCreator.Lib.Service;
using CkWPF.Base.MvvmBase;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;


namespace AnschreibenCreator.Lib.ViewModel
{
    public class BriefKopfViewModel : BaseViewModel
    {
        private BriefKopfViewModel()
        {
            LoadFileCommand = new(o =>
            {
                LoadFile();
                if (!string.IsNullOrEmpty(FilePath))
                {
                    AnschriftLoader loader = new(FilePath);
                    AnschriftenListe = new(loader.GetFirmenAnschriftModels());
                    RaisPropertyChanged(nameof(AnschriftenListe));
                }
            });

            AnredeCommand = new(o =>
            {
                var para = o as string;

                if (SelectedModel != null)
                {
                    SelectedModel.AnredeGeschlecht = para;
                    RaisPropertyChanged(nameof(SelectedModel));
                }

            });
        }



        private string _EigeneAnschriftRaw;

        public string EigeneAnschriftRaw
        {
            get => _EigeneAnschriftRaw;
            set
            {
                if (value != _EigeneAnschriftRaw)
                {
                    _EigeneAnschriftRaw = value;

                    EigeneAnschriftConverter conv = new(_EigeneAnschriftRaw);
                    EigeneAnschrift = conv.GetAnschrift();

                    RaisPropertyChanged();

                }
            }
        }


        private EigeneAnschriftModel _eigeneAnschrift;

        public EigeneAnschriftModel EigeneAnschrift
        {
            get => _eigeneAnschrift;
            set
            {
                if (value != _eigeneAnschrift)
                {
                    _eigeneAnschrift = value;
                    RaisPropertyChanged();
                }
            }
        }


        private FirmenAnschriftModel _selectedModel;

        public FirmenAnschriftModel SelectedModel
        {
            get => _selectedModel;
            set
            {
                if (value != _selectedModel)
                {
                    _selectedModel = value;
                    RaisPropertyChanged();
                }
            }
        }



        private static BriefKopfViewModel _instance;

        public static BriefKopfViewModel Instance
        {
            get => _instance ?? (_instance = _instance ?? new BriefKopfViewModel());
        }

        private string _FilePath;

        public string FilePath
        {
            get => _FilePath;
            set
            {
                if (value != _FilePath)
                {
                    _FilePath = value;
                    RaisPropertyChanged();
                }
            }
        }


        private ObservableCollection<FirmenAnschriftModel> _Anschriftenlist;

        public ObservableCollection<FirmenAnschriftModel> AnschriftenListe
        {
            get => _Anschriftenlist;
            set
            {
                if (value != _Anschriftenlist)
                {
                    _Anschriftenlist = value;
                    RaisPropertyChanged();
                }
            }
        }


        public DelegateCommand LoadFileCommand { get; set; }

        public DelegateCommand AnredeCommand { get; set; }

        private void LoadFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".txt";
            ofd.Filter = "Text Files (*.txt)|*.txt";
            Nullable<bool> result = ofd.ShowDialog();
            ofd.Multiselect = false;
            if (result == true)
            {
                FilePath = ofd.FileName;
            }
        }
    }
}
