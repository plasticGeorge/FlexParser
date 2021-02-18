using System;
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
        private DateTime _StartDate = DateTime.Today;
        private DateTime _EndDate = DateTime.Today;
        private string[] _TextBlockContent;
        
        #endregion

        #region INotifyPropertyChangedImplementation
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperyChanged([CallerMemberName] string prop = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        #region Properties
        public IParser Parser { get; set; }
        public IParserSettings ParserSettings { get; set; }
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
        public string[] TextBlockContent
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

        public ICommand AddFunction
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Parse();
                });
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
                    throw new Exception();
                    break;
            }

            ParserSettings.Category = "";
            ParserSettings.StartDate = StartDate;
            ParserSettings.EndDate = EndDate;
            ParserSettings.SearchString = SearchString;
        }
        private async void Parse()
        {
            if (Parser == null || ParserSettings == null)
            {
                //LoL -*-___-*-
            }

            string source = Parser.HtmlLoad();
            var document = HtmlParser.ParseDocument(source);
            string[] result = Parser.Parse(document);

            TextBlockContent = result;
        }

        #endregion
    }
} 