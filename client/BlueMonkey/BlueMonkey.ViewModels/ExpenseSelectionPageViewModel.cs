﻿using Prism.Mvvm;
using BlueMonkey.Model;
using Reactive.Bindings;

namespace BlueMonkey.ViewModels
{
    public class ExpenseSelectionPageViewModel : BindableBase
    {
        public ReadOnlyReactiveCollection<SelectableExpense> Expenses { get; }
        public ExpenseSelectionPageViewModel(IEditReport editReport)
        {
            Expenses = editReport.SelectableExpenses.ToReadOnlyReactiveCollection();
        }
    }
}
