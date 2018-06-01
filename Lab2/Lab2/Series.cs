using System;
using System.Collections.Generic;

namespace Lab2
{
    class Series
    {
        private List<Function> _functionList;
        public List<Function> FunctionList {
            get {
                return _functionList;
            }
            set {
                _functionList.Clear();
                Changed(this, new EventArgs("Changed function list info"));
                for (int i = 0; i < value.Count; i++)
                {
                    _functionList.Add(value[i]);
                }
            }
        }

        // Events
        private delegate void SeriesEventHandler(object sender, EventArgs e);
        private event SeriesEventHandler Added;
        private event SeriesEventHandler Deleted;
        private event SeriesEventHandler Changed;


        // Constructors
        public Series()
        {
            _functionList = new List<Function>();
            InitializeEvents();
        }
        public Series(params Function[] functions)
        {
            _functionList = new List<Function>();
            InitializeEvents();
            for (int i = 0; i < functions.Length; i++)
            {
                Add(functions[i]);
            }
        }
        public Series(List<Function> functionList)
        {
            _functionList = functionList;
            InitializeEvents();
        }


        // Event Methods
        private void InitializeEvents()
        {
            Added   += OnEventTriggered;
            Deleted += OnEventTriggered;
            Changed += OnEventTriggered;
        }
        
        public void OnEventTriggered(object sender, EventArgs e)
        {
            Console.WriteLine(e.Text);
        }


        // Basic Methods to work with collection
        public void Add(Function function)
        {
            _functionList.Add(function);
            Added?.Invoke(this, new EventArgs("Added " + function.ToString()));
        }

        public void Remove(object obj)
        {
            _functionList.Remove((Function)obj);
            Deleted(this, new EventArgs("Deleted " + ((Function)obj).ToString()));
        }

        public void RemoveAt(int index)
        {
            _functionList.RemoveAt(index);
            Deleted(this, new EventArgs("Deleted function by index" + index.ToString()));
        }


        // Override ToString
        public override string ToString()
        {
            string result = "Series:\n";
            foreach(Function function in _functionList)
            {
                result += function.ToString() + '\n';
            }

            return result;
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            List<Function> anotherFunctionList = ((Series)obj).FunctionList;
            if(anotherFunctionList.Count != _functionList.Count)
            {
                return false;
            }

            for (int i = 0; i < _functionList.Count; i++)
            {
                if (!_functionList[i].Equals(anotherFunctionList[i]))
                {
                    return false;
                }
            }
            return true;
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach(var element in _functionList)
            {
                hashCode += element.GetHashCode();
            }

            hashCode /= 100;
            return hashCode;
        }

        // Method returns copy of an object
        public object DeepCopy()
        {
            Series newSeries = new Series();
            foreach (var element in _functionList)
            {
                newSeries.Add(element);
            }
            return newSeries;
        }


        // Override operators == and !=
        public static bool operator ==(Series series1, Series series2)
        {
            return series1.Equals(series2);
        }
        public static bool operator !=(Series series1, Series series2)
        {
            return !series1.Equals(series2);
        }
    }
}
