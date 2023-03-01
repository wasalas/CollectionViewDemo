using CollectionViewDemo.MVVM.ViewModels;
using System.Diagnostics;

namespace CollectionViewDemo.MVVM.Views;

public partial class ProductsView : ContentPage
{
    public ProductsView()
    {
        InitializeComponent();
        BindingContext = new ProductsViewModel();
    }

    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        //Debug.WriteLine("------------- I N I C I O---------------------------------");
        //Debug.WriteLine("Horizontal Delta:" + e.HorizontalDelta);
        //Debug.WriteLine("Vertical Delta:" + e.VerticalDelta);
        //Debug.WriteLine("Horizontal Offset:" + e.HorizontalOffset);
        //Debug.WriteLine("Vertical Offset:" + e.VerticalOffset);
        //Debug.WriteLine("First Visible Item Index:" + e.FirstVisibleItemIndex);
        //Debug.WriteLine("Center Item Index:" + e.CenterItemIndex);
        //Debug.WriteLine("Last Visible Item Index:" + e.LastVisibleItemIndex);
        //Debug.WriteLine("----------------- F I N  --------------------------------");

    }   

    private void btnScroll_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as ProductsViewModel;        

        var product = vm.Products.SelectMany(p => p).FirstOrDefault(x => x.Id == 10);

        collectionView.ScrollTo(10, groupIndex:3);
        collectionView.ScrollTo(product, animate:false, position:ScrollToPosition.Center);
    }

    private void btnAddItem_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as ProductsViewModel;

        vm.Products.Add(new Models.ProductsGroup("New Group",
            new List<Models.Product>
            {
                new Models.Product
                {
                    Id=100,
                    Name="Bitcoint",
                    Price=99999
                }

            }
            ));

        // var product = vm.Products.SelectMany(p => p).FirstOrDefault(x => x.Id == 10);
    }
}