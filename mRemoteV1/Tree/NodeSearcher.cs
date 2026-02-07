using System.Collections.Generic;
using System.Linq;
using mRemoteNG.Connection;


namespace mRemoteNG.Tree
{
	public class NodeSearcher
    {
        private readonly ConnectionTreeModel _connectionTreeModel;

        public List<ConnectionInfo> Matches { get; private set; }
        public ConnectionInfo CurrentMatch { get; private set; }


        public NodeSearcher(ConnectionTreeModel connectionTreeModel)
        {
            _connectionTreeModel = connectionTreeModel;
        }

        public IEnumerable<ConnectionInfo> SearchByName(string searchText)
        {
            ResetMatches();
            if (searchText == "") return Matches;
            var nodes = _connectionTreeModel.GetRecursiveChildList();
            var searchTextLower = searchText.ToLowerInvariant();
            foreach (var node in nodes)
            {
                if (node.Name.ToLowerInvariant().Contains(searchTextLower) ||
                    node.Description.ToLowerInvariant().Contains(searchTextLower) ||
                    node.Hostname.ToLowerInvariant().Contains(searchTextLower))
                    Matches.Add(node);
            }
            if (Matches.Count > 0)
                CurrentMatch = Matches.First();
            return Matches;
        }

        public ConnectionInfo NextMatch()
        {
            if (CurrentMatch == null || Matches == null) return null;
            var currentMatchIndex = Matches.IndexOf(CurrentMatch);
            if (!CurrentMatchIsTheLastMatchInTheList())
                CurrentMatch = Matches[currentMatchIndex + 1];
            return CurrentMatch;
        }

        private bool CurrentMatchIsTheLastMatchInTheList()
        {
            var currentMatchIndex = Matches.IndexOf(CurrentMatch);
            return currentMatchIndex >= Matches.Count - 1;
        }

        public ConnectionInfo PreviousMatch()
        {
            if (CurrentMatch == null || Matches == null) return null;
            var currentMatchIndex = Matches.IndexOf(CurrentMatch);
            if (!CurrentMatchIsTheFirstMatchInTheList())
                CurrentMatch = Matches[currentMatchIndex - 1];
            return CurrentMatch;
        }

        private bool CurrentMatchIsTheFirstMatchInTheList()
        {
            var currentMatchIndex = Matches.IndexOf(CurrentMatch);
            return currentMatchIndex <= 0;
        }

        private void ResetMatches()
        {
            Matches = new List<ConnectionInfo>();
            CurrentMatch = null;
        }

        public string GetItemMatchPositionDesc(ConnectionInfo item)
        {
            //if (CurrentMatch == null || Matches == null) return "0/0";
            if(item == null) item=CurrentMatch;
            var pos = Matches?.IndexOf(item) + 1;
            var count = Matches?.Count;
            return pos+"/"+count;
        }

    }
}