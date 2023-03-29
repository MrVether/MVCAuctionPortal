using AuctionPortal.Models;

namespace MVCAuctionPortal.Models;

public class AuctionViewModel
{
    public int ItemID { get; set; }
    public int WarrantyID { get; set; }
    public int SubCategoryID { get; set; }
    public string NewItemName { get; set; }
    public string NewItemDescription { get; set; }
    public string NewItemManufacturer { get; set; }
    public string NewItemCondition { get; set; }
    public string NewItemModel { get; set; }
    public string NewItemOther { get; set; }
    public string Title { get; set; }
    public bool BuyItNow { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal Price { get; set; }
    public int Pieces { get; set; }

    public string ImageURL { get; set; }
    public IEnumerable<Item> Items { get; set; }
    public IEnumerable<Warranty> Warranties { get; set; }
    public IEnumerable<SubCategory> SubCategories { get; set; }

}