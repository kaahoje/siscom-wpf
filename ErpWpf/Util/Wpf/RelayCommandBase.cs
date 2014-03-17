﻿using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Util.Wpf
{
    public class RelayCommandBase: ICommand
    {
        #region Fields

    readonly Action<object> _execute;
    readonly Predicate<object> _canExecute;        

    #endregion // Fields

    #region Constructors

    public RelayCommandBase(Action<object> execute)
    : this(execute, null)
    {
    }

    public RelayCommandBase(Action<object> execute, Predicate<object> canExecute)
    {
        if (execute == null)
            
            throw new ArgumentNullException("execute");

        _execute = execute;
        _canExecute = canExecute;           
    }
    #endregion // Constructors

    #region ICommand Members

    [DebuggerStepThrough]
    public bool CanExecute(object parameter)
    {
        return _canExecute == null ? true : _canExecute(parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public void Execute(object parameter)
    {
        _execute(parameter);
    }

    #endregion // ICommand Members
    }
}
