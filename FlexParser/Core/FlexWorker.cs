using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using AngleSharp.Html.Parser;
using FlexParser.RIA;

namespace FlexParser.Classes
{
    public class FlexWorker : INotifyPropertyChanged
    {
        #region PrivateFields
        
        private string _SearchString = "";
        private int _Resource;
        private int _Category;
        private DateTime _StartDate = DateTime.Today;
        private DateTime _EndDate = DateTime.Today;
        private ObservableCollection<ParsedInfo> _TextBlockContent;
        
        #endregion

        #region INotifyPropertyChangedImplementation
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperyChanged([CallerMemberName] string prop = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        #region Properties
        
        //Base properties
        public IParser Parser { get; set; }
        public IParserSettings ParserSettings { get; set; }
        public HtmlLoader Loader { get; set; } = new HtmlLoader();
        public HtmlParser HtmlParser { get; set; } = new HtmlParser();

        //Properties that notify about changes
        public string SearchString
        {
            get
            {
                return _SearchString;
            }
            set
            {
                _SearchString = value;
                OnProperyChanged();
            }
        }
        public int Resource
        {
            get
            {
                return _Resource;
            }
            set
            {
                _Resource = value;
                OnProperyChanged();
            }
        }
        public int Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
                OnProperyChanged();
            }
        }
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
                OnProperyChanged();
            }
        }
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
                OnProperyChanged();
            }
        }
        public ObservableCollection<ParsedInfo> TextBlockContent
        {
            get
            {
                return _TextBlockContent;
            }
            set
            {
                _TextBlockContent = value;
                OnProperyChanged();
            }
        }

        //Command properties
        public ICommand AddFunction
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    SetParser();
                    Parse();
                }, (obj) => Resource >= 0);
            }
        }
        #endregion
            
        #region Methods

        private void SetParser()
        {
            switch (Resource)
            {
                case 0: 
                    Parser = new RiaParser();
                    ParserSettings = new RiaSettings();
                    break;
                default:
                    MessageBox.Show("Error 4");
                    break;
            }

            switch (Category)
            {
                case 0:
                    ParserSettings.Category = "politics";
                    break;
                case 1:
                    ParserSettings.Category = "world";
                    break;
                case 2:
                    ParserSettings.Category = "economy";
                    break;
                case 3:
                    ParserSettings.Category = "society";
                    break;
                case 4:
                    ParserSettings.Category = "incidents";
                    break;
                case 5:
                    ParserSettings.Category = "incidents";
                    break;
                default:
                    ParserSettings.Category = "";
                    break;
            }

            ParserSettings.StartDate = StartDate;
            ParserSettings.EndDate = EndDate;
            ParserSettings.SearchString = SearchString;
        }
        private async void Parse()
        {
            if (Parser == null || ParserSettings == null)
            {
                MessageBox.Show("Error 1");
                return;
            }

            string source = await Loader.HtmlLoad(ParserSettings);
            var document = HtmlParser.ParseDocument(source);
            ObservableCollection<ParsedInfo> result = Parser.Parse(document, ParserSettings.SearchString);

            TextBlockContent = result;
        }

        #endregion
    }
} 