

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FlexParser.Classes
{
    public class ParserWorker : INotifyPropertyChanged
    {
        #region INotifyPropertyChangedImplementation
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProperyChanged([CallerMemberName] string prop = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
        
        #region Fields

        private string _SerachString;
        private string _Resource;
        private int _StartPoint;
        private int _EndPoint;
        private string _Prefix;
        private string _Categories;

        #endregion

        #region Properties
        public string SerachString
        {
            get
            {
                return _SerachString;
            }
            set
            {
                _SerachString = value;
                OnProperyChanged();
            }
        }
        
        public string Resource
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

        public int StartPoint
        {
            get
            {
                return _StartPoint;
            }
            set
            {
                _StartPoint = value;
                OnProperyChanged();
            }
        }
        
        public int EndPoint
        {
            get
            {
                return _EndPoint;
            }
            set
            {
                _EndPoint = value;
                OnProperyChanged();
            }
        }
        
        public string Prefix
        {
            get
            {
                return _Prefix;
            }
            set
            {
                _Prefix = value;
                OnProperyChanged();
            }
        }
        
        public string Categories
        {
            get
            {
                return _Categories;
            }
            set
            {
                _Categories = value;
                OnProperyChanged();
            }
        }
        
        //Properties that do not change the view
        
        public IParser Parser { get; set; }
        
        public IParserSettings ParserSettings { get; set; }
        
        #endregion

        #region Methods

        string[] Parse(IParser parser, IParserSettings parserSettings)
        {
            string[] result = null;
            
            //"HtmlLoader" gets the source of the resource in the form of a document using the "ParserSettings"
            
            //The "Parse" function from the "Parser" class of the specified resource gets the result and returns it
            
            //Bravo!!!
            
            return result;
        }

        #endregion
    }
}