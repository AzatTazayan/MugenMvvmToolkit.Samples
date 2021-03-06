using ApiExamples.Templates;
using ApiExamples.ViewModels;
using Foundation;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Views;
using UIKit;

namespace ApiExamples.Views
{
    [Register("MultipleSelectionCollectionViewController")]
    [ViewModel(typeof(TableViewModel), Constants.MultipleSelectionCollectionView)]
    public class MultipleSelectionCollectionViewController : MvvmCollectionViewController
    {
        #region Constructors

        public MultipleSelectionCollectionViewController()
            : base(new UICollectionViewFlowLayout())
        {
        }

        #endregion

        #region Overrides of MvvmCollectionViewController

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            CollectionView.BackgroundColor = UIColor.White;
            CollectionView.AllowsMultipleSelection = true;

            using (var set = new BindingSet<TableViewModel>())
            {
                NavigationItem.RightBarButtonItem = new UIBarButtonItem("Invert selection", UIBarButtonItemStyle.Plain, null);
                set.Bind(NavigationItem.RightBarButtonItem).To(() => (vm, ctx) => vm.InvertSelectionCommand);
                set.Bind(CollectionView, AttachedMemberConstants.ItemsSource)
                    .To(() => (vm, ctx) => vm.GridViewModel.ItemsSource);
                CollectionView.SetBindingMemberValue(AttachedMembers.UICollectionView.ItemTemplateSelector, CollectionViewCellTemplateSelector.Instance);
            }
        }

        #endregion
    }
}