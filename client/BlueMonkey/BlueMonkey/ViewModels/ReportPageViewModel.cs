﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using BlueMonkey.Business;
using BlueMonkey.Model;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace BlueMonkey.ViewModels
{
    public class ReportPageViewModel : BindableBase, INavigationAware
    {
        public static readonly string ReportIdKey = "reportId";

        /// <summary>
        /// Model to manage the registration and change of the report.
        /// </summary>
        private readonly IEditReport _editReport;

        /// <summary>
        /// It is a screen transition services provided by the Prism.
        /// </summary>
        private readonly INavigationService _navigationService;

        public ReactiveProperty<Report> Report { get; }
        public ReadOnlyReactiveCollection<Expense> Expenses { get; }

        /// <summary>
        /// Save Report Command.
        /// </summary>
        public DelegateCommand SaveReportCommand => null;

        /// <summary>
        /// Initialize Instance.
        /// </summary>
        /// <param name="editReport"></param>
        /// <param name="navigationService"></param>
        public ReportPageViewModel(IEditReport editReport, INavigationService navigationService)
        {
            _editReport = editReport;
            _navigationService = navigationService;
            Report = editReport.ObserveProperty(x => x.Report).ToReactiveProperty();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey(ReportIdKey))
            {
                var reportId = parameters[ReportIdKey] as string;
                if (reportId == null)
                {
                    // Case : New Report.
                    await _editReport.InitializeForNewReportAsync();
                }
                else
                {
                    // Case : Update Report.

                }
            }
        }
    }
}
