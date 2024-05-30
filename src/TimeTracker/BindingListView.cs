using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.ibindinglist.issorted?view=net-8.0&redirectedfrom=MSDN#System_ComponentModel_IBindingList_IsSorted
// https://groups.google.com/g/microsoft.public.dotnet.languages.csharp/c/125jmmTncJc?pli=1
// https://github.com/geomatics-io/BindingListView/blob/master/src/BindingListView/BindingListView.cs
// https://stackoverflow.com/questions/4317479/func-vs-action-vs-predicate
// https://blw.sourceforge.net/
//https://gist.github.com/wcabus/6138716

namespace TimeTracker;

public class BindingListView<T> : BindingList<T>, IBindingListView
{

    //private Action? _filterAction;
    private string? _filter;
    //private Func<T, bool>? _filterFunc;
    //private Expression<Func<T,bool>>? _filterExpression;
    private Predicate<T> _filterPredicate;
    private List<int> sortIndexes = new List<int>();
    private readonly List<T> _originalData;
    public BindingListView(BindingList<T> List) : base()
    {
        _originalData = new List<T>(List);
    }
    
    public Predicate<T> FilterPredicate
    {
        get { return this._filterPredicate; }
        set
        {
            if (this._filterPredicate != value)
            {
                this._filterPredicate = value;
                //ApplyFilter();
                //RaiseEvents();
            }
        }
    }


    public void Refresh()
    {
        this.sortIndexes = new List<int>(_originalData.Count);
        for (int i = 0; i < _originalData.Count; i++)
        {
            if (this._filterPredicate(_originalData[i]))
            {
                this.sortIndexes.Add(i);
            }
        }

        this.Items.Clear();
        foreach (int i in sortIndexes)
        {
            this.Items.Add(_originalData[i]);
        }
        
        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    
    
     
    
    #region Not yet implemented
    public void ApplySort(ListSortDescriptionCollection SortDescription)
    => throw new NotImplementedException();

    public void RemoveFilter()
    {
        Items.Clear();
        foreach (var item in _originalData)
        {
            Items.Add(item);
        }
    }

    public string? Filter
    {
        get
        {
            return _filter;
        }
        set
        {

            _filter = value;
        }
    }

    public bool SupportsAdvancedSorting => throw new NotImplementedException();

    public bool SupportsFiltering => true;

    ListSortDescriptionCollection IBindingListView.SortDescriptions => throw new NotImplementedException();


#endregion
}
