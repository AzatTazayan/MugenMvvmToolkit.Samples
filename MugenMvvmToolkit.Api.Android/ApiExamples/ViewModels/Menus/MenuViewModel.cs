using System.Collections.Generic;
using System.Windows.Input;
using ApiExamples.Models;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels.Menus
{
    public class MenuViewModel : ViewModelBase
    {
        #region Fields

        private readonly IToastPresenter _toastPresenter;

        #endregion

        #region Constructors

        public MenuViewModel(IToastPresenter toastPresenter)
        {
            Should.NotBeNull(toastPresenter, nameof(toastPresenter));
            _toastPresenter = toastPresenter;
            ExecuteCommand = new RelayCommand<MenuItemModel>(Execute);


            var root = new MenuItemModel
            {
                Name = "level 1",
                Items = new[]
                {
                    new MenuItemModel
                    {
                        Name = "level 1.1",
                        Items = new[]
                        {
                            new MenuItemModel
                            {
                                Name = "level 1.1.1"
                            },
                            new MenuItemModel
                            {
                                Name = "level 1.1.2"
                            }
                        }
                    },
                    new MenuItemModel
                    {
                        Name = "level 1.2",
                        Items = new[]
                        {
                            new MenuItemModel
                            {
                                Name = "level 1.2.1"
                            }
                        }
                    },
                    new MenuItemModel
                    {
                        Name = "level 1.3",
                        Items = new[]
                        {
                            new MenuItemModel
                            {
                                Name = "level 1.3.1"
                            }
                        }
                    }
                }
            };
            Items = new[]
            {
                root,
                new MenuItemModel
                {
                    Name = "level 2",
                    Items = new[]
                    {
                        new MenuItemModel
                        {
                            Name = "level 2.1"
                        }
                    }
                }
            };
        }

        #endregion

        #region Properties

        public IList<MenuItemModel> Items { get; }

        #endregion

        #region Commands

        public ICommand ExecuteCommand { get; }

        private void Execute(MenuItemModel menuItem)
        {
            _toastPresenter.ShowAsync(menuItem.Name, ToastDuration.Short);
        }

        #endregion
    }
}